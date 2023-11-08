using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<object>> GetAllCompanies()
        {
            var list = await _context.Companies
            .OrderByDescending(e => e.CompanyID)
            .Select(company => new
            {
                company.CompanyID,
                company.Name,
                company.Address,
                company.RUC,
                company.Email
            }).ToListAsync();

            return list;
        }
    }
}