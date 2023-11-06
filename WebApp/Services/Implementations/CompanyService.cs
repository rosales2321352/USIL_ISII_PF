using WebApp.Models;
using WebApp.Data;
namespace WebApp.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository repository) : base(repository)
        {
            _companyRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllCompanies()
        {
            return await _companyRepository.GetAllCompanies();
        }

        public async Task CreateCompany(CompanyRequest request)
        {
            Company company = new()
            {
                Name = request.Name,
                RUC = request.RUC,
                Address = request.Address,
                Email = request.Email
            };
            await _repository.Add(company);
        }
    }
}