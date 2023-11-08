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

            ApiSingleObjectResponse<object> response = new(company, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyRequest request)
        {
            await _companyService.CreateCompany(request);

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EdiCompany([FromBody]CompanyUpdate request)
        {
            await _companyService.EditCompany(request);

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        //TODO!
        /*[HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Company? company = await _context.Companies.FindAsync(id);

            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Not Company Found with that ID");
        }*/
    }
}
