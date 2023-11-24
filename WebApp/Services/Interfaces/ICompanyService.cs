using WebApp.Models;
namespace WebApp.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<IEnumerable<object>> GetAllCompanies();
        Task<object> CreateCompany(CompanyRequest request);
        Task<object> EditCompany(CompanyUpdate request);
        Task DeleteCompany(CompanyDelete request);
    }
}