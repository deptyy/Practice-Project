using Microsoft.Exchange.WebServices.Data;
using WebApplicationDemo2.Dtos.Company;

namespace WebApplicationDemo2.Service.Interface
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAllCompany();
        Task<CompanyDto> GetCompanyById(int id);
        Task<CompanyDto> SaveCompany(CompanyDto companyDto);
        Task<UpdateCompanyDto> UpdateCompany(int CompanyId, UpdateCompanyDto updateCompanyDto);
        Task<int> DeleteCompanyById(int CompanyId);
    }
}
