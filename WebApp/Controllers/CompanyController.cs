using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetList()
        {
            var list = await _companyService.GetAllCompanies();
            ApiListResponse<object> response = new(list, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        [Route("detail/{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var company = await _companyService.GetById(id);

            ApiSingleObjectResponse<object> response = new(company, StatusCodes.Status200OK, "Compañia Encontrada");

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyRequest request)
        {
            var company = await _companyService.CreateCompany(request);
            ApiSingleObjectResponse<object> response = new(company, StatusCodes.Status200OK, "Compañia Creada");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditCompany([FromBody] CompanyUpdate request)
        {
            var company = await _companyService.EditCompany(request);
            ApiSingleObjectResponse<object> response = new(company, StatusCodes.Status200OK, "Compañia Actualizada");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] CompanyDelete request)
        {
            await _companyService.DeleteCompany(request);
            return StatusCode(StatusCodes.Status200OK, "Compañía Eliminada");
        }
    }
}
