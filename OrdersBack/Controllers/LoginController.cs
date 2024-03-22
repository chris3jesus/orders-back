using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersBack.DTOs;
using OrdersBack.Models;

namespace OrdersBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BdatosContext _context;
        public LoginController(BdatosContext context)
        {
            _context = context;
        }

        // GET: api/login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendedorDTO>> GetVendedor(int id)
        {
            try
            {
                var vendedor = await _context.Vemaests.FirstOrDefaultAsync(v => v.VemCodven == id && v.VemDesactivo != "A" && v.VemCodcia == "01");

                if (vendedor == null)
                {
                    return NotFound("No se encontraron vendedores.");
                }

                var vendedorDto = MapToVendedorDTO(vendedor);
                return Ok(vendedorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener el vendedor: {ex.Message}");
            }
        }

        // POST: api/login/
        [HttpPost]
        public async Task<ActionResult<VendedorDTO>> IniciarSesion(LoginDTO login)
        {
            try
            {
                var vendedor = await _context.Vemaests.FirstOrDefaultAsync(v => v.VemCodven == login.Codigo && v.Clave == login.Clave && v.VemDesactivo != "A" && v.VemCodcia == "01");

                if (vendedor == null)
                {
                    return BadRequest("Datos de inicio de sesión incorrectos.");
                }

                var vendedorDto = MapToVendedorDTO(vendedor);
                return Ok(vendedorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al iniciar sesión: {ex.Message}");
            }
        }

        private VendedorDTO MapToVendedorDTO(Vemaest vendedor)
        {
            return new VendedorDTO
            {
                Codigo = vendedor.VemCodven,
                Nombre = vendedor.VemNombre.Trim(),
                Clave = vendedor.Clave
            };
        }
    }
}
