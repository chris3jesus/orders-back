using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrdersBack.DTOs;

namespace OrdersBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SunatController : ControllerBase
    {
        // GET: api/sunat/ruc/5
        [HttpGet("ruc/{doc}")]
        public ActionResult<SunatDTO> GetClienteRuc(string doc)
        {
            try
            {
                return ScrapSunat(doc);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los datos: {ex.Message}");
            }
        }

        // GET: api/sunat/dni/5
        [HttpGet("dni/{doc}")]
        public ActionResult<SunatDTO> GetClienteDni(string doc)
        {
            try
            {
                return ScrapSunat(doc);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los datos: {ex.Message}");
            }
        }

        [HttpGet("dnix/{doc}")]
        public SunatDTO ScrapSunat(string doc)
        {
            SunatDTO resultado = new SunatDTO();
            using (var driver = new ChromeDriver())
            {
                //driver.Navigate().GoToUrl("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaWeb.jsp");
                driver.Navigate().GoToUrl("https://e-consultaruc.sunat.gob.pe/");


                var inputElement = driver.FindElement(By.Id("txtRuc"));
                inputElement.SendKeys(doc);

                var buttonElement = driver.FindElement(By.Id("btnAceptar"));
                buttonElement.Click();
                Thread.Sleep(3000);

                resultado.Documento = doc;

                //IWebElement nombreComercialElement = driver.FindElement(By.XPath("//h4[contains(text(),'Nombre Comercial:')]/following-sibling::div"));
                //resultado.Comercial = nombreComercialElement.Text.Trim();

                //IWebElement estadoContribuyenteElement = driver.FindElement(By.XPath("//h4[contains(text(),'Estado del Contribuyente:')]/following-sibling::div"));
                //resultado.Comercial = estadoContribuyenteElement.Text.Trim();

                //IWebElement domicilioFiscalElement = driver.FindElement(By.XPath("//h4[contains(text(),'Domicilio Fiscal:')]/following-sibling::div"));
                //resultado.Comercial = domicilioFiscalElement.Text.Trim();

                driver.Quit();
            }
            return resultado;
        }
    }
}
