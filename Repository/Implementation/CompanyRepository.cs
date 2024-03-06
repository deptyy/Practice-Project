using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using WebApplicationDemo2.Data;
using WebApplicationDemo2.Model;
using WebApplicationDemo2.Repository.Interface;

namespace WebApplicationDemo2.Repository.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _dataContext;
        public CompanyRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<bool> CreateCompanyAsync(Company company)
        {
            await _dataContext.Companies.AddAsync(company);
            return await Save();
        }

        private async  Task<bool> Save()
        {
            return await _dataContext.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<ICollection<Company>> GetAllCompaniesAsync()
        {
            return await _dataContext.Companies.ToListAsync();
        }

        public async Task<ICollection<Company>> GetCompaniesAsync()
        {
            return await _dataContext.Companies.Where(X => X.IsDeleted == false).ToListAsync();
        }

        public async Task<Company> GetCompanyByGUIDAsync(Guid CompanyGUID)
        {
            return await _dataContext.Companies.FirstOrDefaultAsync(X => X.GUID == CompanyGUID);
        }

        public async Task<Company> GetCompanyByIDAsync(int CompanyId)
        {
            return await _dataContext.Companies.FirstOrDefaultAsync(X => X.Id == CompanyId);
        }

        public async Task<ICollection<Company>> GetDeletedCompaniesAsync()
        {
            return await _dataContext.Companies.Where(X => X.IsDeleted == true).ToListAsync();
        }

        public async Task<bool> HardDeleteCompanyAsync(Company company)
        {
            _dataContext.Remove(company);
            return await Save();
        }

        public async Task<bool> SoftDeleteCompanyAsync(Guid CompanyGUID)
        {
            var _exisitngCompany = await GetCompanyByGUIDAsync(CompanyGUID);

            if (_exisitngCompany != null)
            {
                _exisitngCompany.IsDeleted = true;
                return await Save();
            }
            return false;
        }

        public async Task<bool> UpdateCompanyAsync(Company company)
        {
            _dataContext.Companies.Update(company);
            return await Save();
        }
    }
}
