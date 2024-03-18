using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersBack.DTOs;
using OrdersBack.Models;

namespace OrdersBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly BdatosContext _context;
        public ClientesController(BdatosContext context)
        {
            _context = context;
        }

        // GET: api/cliente/{key}
        [HttpGet("{key}")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetCliente(string key)
        {
            var clienteQuery = _context.Clientes.Where(a => a.CliCodcia == "01" && a.CliEstado == "A");

            if (int.TryParse(key, out int codigo))
            {
                clienteQuery = clienteQuery.Where(a => a.CliCodclie == codigo);
            }
            else
            {
                clienteQuery = clienteQuery.Where(a => a.CliRucEsposo == key || a.CliRucEsposa == key || a.CliNombreEsposo.Contains(key) || a.CliNombreEsposa.Contains(key) || a.CliNombreEmpresa.Contains(key));
            }

            var clientes = await clienteQuery.ToListAsync();

            if (clientes == null || !clientes.Any())
            {
                return NotFound("No se encontraron clientes.");
            }

            var clientesDtos = new List<ClienteDTO>();

            foreach (var cliente in clientes)
            {
                var direcciones = await _context.Dirclis.Where(d => d.Codcli == cliente.CliCodclie && d.Codcia == "01").ToListAsync();

                var clienteDto = new ClienteDTO
                {
                    Codigo = (int)cliente.CliCodclie,
                    Documento = cliente.CliRucEsposo.Trim() != "" ? cliente.CliRucEsposo.Trim() : cliente.CliRucEsposa.Trim(),
                    Razon = cliente.CliNombreEsposo.Trim(),
                    Nombre = cliente.CliNombreEsposa.Trim(),
                    Comercial = cliente.CliNombreEmpresa.Trim(),
                    Vendedor = (int)cliente.CliCodven,

                    Direcciones = direcciones.Select(d =>
                    {
                        var ubigeos = _context.Ubigeos.Where(u => u.UUbigeo == d.Ubigeo).Select(u => new
                        {
                            Distrito = u.UNomdist.Trim(),
                            Provincia = u.UNomprov.Trim(),
                            Departamento = u.UNomdep.Trim()
                        }).ToList();

                        var distrito = ubigeos.Select(u => u.Distrito).FirstOrDefault() ?? "";
                        var provincia = ubigeos.Select(u => u.Provincia).FirstOrDefault() ?? "";
                        var departamento = ubigeos.Select(u => u.Departamento).FirstOrDefault() ?? "";

                        return new DireccionDTO
                        {
                            Codigo = d.Dircli1,
                            Direccion = d.Direc.Trim(),
                            Distrito = distrito,
                            Provincia = provincia,
                            Departamento = departamento
                        };
                    }).ToList()
                };
                clientesDtos.Add(clienteDto);
            }
            return clientesDtos;
        }
    }
}
