using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
namespace WebApp.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext()
        {
            Configuration.LazyLoadingEnabled = false; //Disable Lazy loading
        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Department> Departments { set; get; }
    }
}
