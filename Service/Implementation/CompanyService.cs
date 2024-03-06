using AutoMapper;
using WebApplicationDemo2.Dtos.Company;
using WebApplicationDemo2.Model;
using WebApplicationDemo2.Repository.Interface;
using WebApplicationDemo2.Service.Interface;

namespace WebApplicationDemo2.Service.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {

            this.uow = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<int> DeleteCompanyById(int CompanyId)
        {
            try
            {
                var company = await uow.GenericRepo<Company>().GetById(CompanyId) ?? throw new Exception("company not found");
                uow.GenericRepo<Company>().Delete(company);
                return await uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete Company", ex);
            }
        }

        public async Task<List<CompanyDto>> GetAllCompany()
        {
            try
            {
                var company = await uow.GenericRepo<Company>().GetAll();
                var companyDto = _mapper.Map<List<CompanyDto>>(company);
                return companyDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occurred while getting the copmany", ex);
            }
        }

        public async Task<CompanyDto> GetCompanyById(int id)
        {
            try
            {
                var company = await uow.GenericRepo<Company>().GetById(id);
                var companyDto = _mapper.Map<CompanyDto>(company);
                return companyDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occured while getting the Company", ex);
            }
        }

        public async Task<CompanyDto> SaveCompany(CompanyDto companyDto)
        {
            try
            {
                var company = _mapper.Map<Company>(companyDto);
                await uow.GenericRepo<Company>().Add(company);
                await uow.Save();

                var responseCompany = uow.GenericRepo<Company>().GetById(company.Id);

                return _mapper.Map<CompanyDto>(responseCompany);
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occured while saving company", ex);
            }
        }

        public async Task<UpdateCompanyDto> UpdateCompany(int CompanyId, UpdateCompanyDto updateCompanyDto)
        {
            try
            {

                var company = await uow.GenericRepo<Company>().GetById(CompanyId) ?? throw new Exception("Company not found");
                _mapper.Map(updateCompanyDto, company);
                await uow.Save();
                return _mapper.Map<UpdateCompanyDto>(company);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the About Us.", ex);
            }
        }
    }
}
