using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrdersBack.DTOs;
using OrdersBack.Models;
using System.Linq;

namespace OrdersBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvancesController : ControllerBase
    {
        private readonly BdatosContext _context;
        public AvancesController(BdatosContext context)
        {
            _context = context;
        }

        // GET: api/avances/general
        [HttpGet("general")]
        public IActionResult General(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                string periodo = fechaInicio.ToString("MMyyyy");

                // Get active sellers except supervisor
                var vendedoresQuery = _context.Vemaests
                    .Where(v => v.Supervisor != true && v.VemDesactivo != "A" && v.VemCodcia == "01")
                    .Select(v => v.VemCodven)
                    .ToList();

                if (!vendedoresQuery.Any())
                {
                    return Ok(new { Message = "No active sellers found" });
                }

                // Generate the IN clause for vendedoresQuery
                var vendedoresInClause = string.Join(",", vendedoresQuery);

                // SQL for quotas
                var cuotasSql = $@"
                    SELECT [c].[CUO_CODVEN], COALESCE(SUM([c].[CUO_VALOR]), 0.0) AS [CUO_VALOR]
                    FROM [CUOTAVEND] AS [c]
                    WHERE [c].[CUO_CODVEN] IN ({vendedoresInClause})
                        AND [c].[CUO_PERIODO] = @periodo
                        AND [c].[CUO_CODCIA] = '01'
                        AND [c].[CUO_LINEA] < 90
                        AND [c].[CUO_LINEA] NOT IN (51, 52)
                    GROUP BY [c].[CUO_CODVEN]";

                var cuotas = _context.Cuotavends
                    .FromSqlRaw(cuotasSql, new SqlParameter("@periodo", periodo))
                    .Select(c => new CuotaDto
                    {
                        Vendedor = c.CuoCodven,
                        Cuota = (decimal)c.CuoValor
                    })
                    .ToList();

                // SQL for advances
                var avancesSql = $@"
                    SELECT [c].[CLI_CODVEN] AS [FAR_CODVEN],
                        SUM([f].[FAR_CANTIDAD] / [f].[FAR_EQUIV] * [f].[FAR_PRECIO] * CASE WHEN [f].[FAR_TIPMOV] = 97 THEN -1 ELSE 1 END) AS [FAR_CANTIDAD]
                    FROM [FACART] AS [f]
                        INNER JOIN [ARTI] AS [a] ON [a].[ART_KEY] = [f].[FAR_CODART]
                            AND [a].[ART_CODCIA] = [f].[FAR_CODCIA]
                        INNER JOIN [CLIENTES] AS [c] ON [c].[CLI_CODCLIE] = [f].[FAR_CODCLIE]
                            AND [c].[CLI_CODCIA] = [f].[FAR_CODCIA]
                            AND [c].[CLI_CP] = [f].[FAR_CP]
                    WHERE [c].[CLI_CODVEN] IN ({vendedoresInClause})
                        AND [f].[FAR_CODCIA] = '01'
                        AND [f].[FAR_ESTADO] != 'E'
                        AND [f].[FAR_ESTADO2] != 'L'
                        AND [f].[FAR_TIPMOV] IN (10, 97)
                        AND [f].[FAR_FECHA_COMPRA] BETWEEN @fechaInicio AND @fechaFin
                        AND [f].[FAR_CODART] != 0
                        AND [a].[ART_FAMILIA] > 0
                    GROUP BY [c].[CLI_CODVEN]";

                var avances = _context.Facarts
                    .FromSqlRaw(avancesSql,
                        new SqlParameter("@fechaInicio", fechaInicio),
                        new SqlParameter("@fechaFin", fechaFin))
                    .Select(f => new AvanceDTO
                    {
                        Vendedor = (int)f.FarCodven,
                        Avance = (decimal)f.FarCantidad
                    })
                    .ToList();

                // Join quotas and advances to calculate saldo and porcentaje
                var result = from cuota in cuotas
                             join avance in avances on cuota.Vendedor equals avance.Vendedor into ca
                             from subavance in ca.DefaultIfEmpty()
                             select new
                             {
                                 Vendedor = cuota.Vendedor,
                                 Cuota = cuota.Cuota,
                                 Avance = subavance?.Avance ?? 0,
                                 Saldo = cuota.Cuota - (subavance?.Avance ?? 0),
                                 Porcentaje = cuota.Cuota == 0 ? 0 : (subavance?.Avance ?? 0) / cuota.Cuota * 100,
                                 Saldo95 = (cuota.Cuota * 0.95M) - (subavance?.Avance ?? 0),
                             };

                var orderedResult = result.OrderBy(r => r.Vendedor).ToList();
                var totalCuota = orderedResult.Sum(r => r.Cuota);
                var totalAvance = orderedResult.Sum(r => r.Avance);
                var totalSaldo = orderedResult.Sum(r => r.Saldo);
                var totalPorcentaje = totalCuota == 0 ? 0 : (totalAvance / totalCuota) * 100;
                var totalSaldo95 = (totalCuota * 0.95M) - totalAvance;

                var totalRow = new
                {
                    Vendedor = "Total",
                    Cuota = totalCuota,
                    Avance = totalAvance,
                    Saldo = totalSaldo,
                    Porcentaje = totalPorcentaje,
                    Saldo95 = totalSaldo95
                };

                var finalResult = orderedResult.Cast<dynamic>().ToList();
                finalResult.Add(totalRow);
                return Ok(finalResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
