using WebApp.Models;
namespace WebApp.Data
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<IEnumerable<object>> GetAllCompanies();
    }
}