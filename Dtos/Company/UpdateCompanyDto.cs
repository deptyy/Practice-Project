using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo2.Dtos.Company
{
    public class UpdateCompanyDto
    {
        public int Id { get; set; }
      
        public string CompanyName { get; set; }
    }
}
