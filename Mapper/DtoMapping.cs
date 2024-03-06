using AutoMapper;
using System.Runtime;
using WebApplicationDemo2.Dtos.Company;
using WebApplicationDemo2.Model;

namespace WebApplicationDemo2.Mapper
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();

            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
        }
    }
}