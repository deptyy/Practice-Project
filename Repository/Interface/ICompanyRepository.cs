using WebApplicationDemo2.Model;

namespace WebApplicationDemo2.Repository.Interface
{
    public interface ICompanyRepository
    {
        Task<ICollection<Company>> GetAllCompaniesAsync();
        Task<ICollection<Company>>GetCompaniesAsync();
        Task<ICollection<Company>> GetDeletedCompaniesAsync();

        Task<Company> GetCompanyByGUIDAsync(Guid CompanyGUID);
        Task<Company> GetCompanyByIDAsync(int CompanyId);
        Task<bool> CreateCompanyAsync(Company company);
        Task<bool> UpdateCompanyAsync(Company company);
        Task<bool> SoftDeleteCompanyAsync(Guid CompanyGUID);
        Task<bool> HardDeleteCompanyAsync(Company company);




    }
}
