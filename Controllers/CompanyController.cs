using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo2.Dtos.Company;
using WebApplicationDemo2.Service.Interface;
using WebApplicationDemo2.ServiceResponder;

namespace WebApplicationDemo2.Controllers
{
    [Route("api/[controller]")]

    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            this._companyService = companyService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CompanyDto>>>> GetAllCategories()
        {
            var company = await _companyService.GetAllCompany();
            if (company == null)
            {
                return NotFound(new ServiceResponse<List<CompanyDto>>(false, data: null, "No company found"));
            }
            return Ok(new ServiceResponse<List<CompanyDto>>(true, company));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CompanyDto>>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound(new ServiceResponse<CompanyDto>(false, data: null, "No company found"));
            }

            return Ok(new ServiceResponse<CompanyDto>(true, company));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CompanyDto>>> SaveCompany(CompanyDto companyDto)
        {
            try
            {
                return Ok(new ServiceResponse<CompanyDto>(true, await _companyService.SaveCompany(companyDto)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<CompanyDto>(false, null!, ex.Message));
            }
        }
        [HttpPatch("{CompId}")]

        public async Task<ActionResult<ServiceResponse<UpdateCompanyDto>>> UpdateCompany(int CompId, [FromBody] UpdateCompanyDto updatecompanyDto)
        {

            try
            {
                return Ok(new ServiceResponse<UpdateCompanyDto>(true, await _companyService.UpdateCompany(CompId, updatecompanyDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<CompanyDto>>> DeleteCompany(int id)
        {
            try
            {
                await _companyService.DeleteCompanyById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<List<CompanyDto>>(false, null, ex.Message));
            }

        }
    }
}