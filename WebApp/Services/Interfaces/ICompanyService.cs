using WebApp.Models;
namespace WebApp.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<IEnumerable<object>> GetAllCompanies();
        Task CreateCompany(CompanyRequest request);
    }
}