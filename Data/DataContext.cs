
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplicationDemo2.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

        public DbSet<Model.Company> Companies { get; set; }

    }
}
