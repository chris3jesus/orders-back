using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrdersBack.DTOs;
using Microsoft.Extensions.Options;

namespace OrdersBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SunatController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public SunatController(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiKey = apiSettings.Value.SunatApiKey;
        }

        // GET: api/sunat/ruc/5
        [HttpGet("ruc/{doc}")]
        public async Task<ActionResult<SunatDTO>> GetClienteRuc(string doc)
        {
            try
            {
                var requestUrl = $"https://dniruc.apisperu.com/api/v1/ruc/{doc}?token={_apiKey}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, $"Error al obtener los datos: {response.ReasonPhrase}");
                }

                var content = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<JObject>(content);

                var sunatData = new SunatDTO
                {
                    Documento = jsonResponse["ruc"]?.ToString(),
                    Comercial = jsonResponse["razonSocial"]?.ToString(),
                    Estado = jsonResponse["estado"]?.ToString(),
                    Domicilio = jsonResponse["direccion"]?.ToString(),
                    FechaConsulta = DateTime.Today
                };

                return Ok(sunatData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los datos: {ex.Message}");
            }
        }

    }
}
