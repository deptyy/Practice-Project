namespace WebApplicationDemo2.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public Guid GUID { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
