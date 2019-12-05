using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DatabaseContext.DatabaseContext;
using WebApp.Model.Model;

namespace WebApp.Repository.Repository
{
    public class DepartmentRepository
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        public bool Add(Department department)
        {
            dbContext.Departments.Add(department);
            //dbContext.SaveChanges();

            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Department aDepartment = dbContext.Departments.FirstOrDefault(c => c.Id == id);

            dbContext.Departments.Remove(aDepartment);

            return dbContext.SaveChanges() > 0;
        }
        public bool Update(Department department)
        {

            //Method - 2
            dbContext.Entry(department).State = EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }

        public List<Department> GetAll()
        {
            //return dbContext.Departments.ToList();
            //return dbContext.Departments.Include(c=>c.Students).ToList(); //Eagar Loading

            var departments = dbContext.Departments.ToList();
            foreach (var department in departments)
            {
                //All
                //dbContext.Entry(department).Collection(c=>c.Students).Load();

                //Query
                dbContext.Entry(department)
                    .Collection(c => c.Students)
                    .Query()
                    .Where(c=>c.Age>20 )
                    .Where(c=>c.Name.Contains("l"))
                    .Load();
            }

            return departments;
        }

        public Department GetBy(int id)
        {
            return dbContext.Departments.First(c => c.Id == id);
        }
    }

}
