using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Model;
using WebApp.BLL.BLL;

namespace MyEF
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager _studentManager = new StudentManager();
            //DepartmentManager _departmentManager = new DepartmentManager();

            //Console.WriteLine("\t\tDepartment");
            //foreach (var department in _departmentManager.GetAll())
            //{
            //    Console.WriteLine("\nDepartment Name:\t" + department.Name + "\n\t\t\t\tStudents");
            //    if (department.Students != null && department.Students.Any())
            //    {
            //        foreach (var student in department.Students)
            //        {
            //            Console.WriteLine("Student RollNo:\t" + student.RollNo + "\tName:\t" + student.Name + "\tAge:\t" + student.Age);
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("\t\tNo Student Found!!!");
            //    }
            //}


            //Department department = new Department()
            //{
            //    Name = "EEE",
            //    Students = new List<Student>()
            //    {
            //        new Student()
            //        {
            //                RollNo = "009",
            //                Name =  "Sabbir",
            //                Address = "C. Get",
            //                Age = 26
            //        },
            //        new Student()
            //        {
            //            RollNo = "010",
            //            Name =  "Fahim",
            //            Address = "Savar",
            //            Age = 21
            //        }
            //    }

            //};

            //Student student = new Student()
            //{
            //    RollNo = "011",
            //    Name = "Siam",
            //    Address = "Mirpur",
            //    Age = 26
            //};

            //department.Students.Add(student);
            //_departmentManager.Add(department);


            //if (_studentManager.Add(student))
            //{
            //    Console.WriteLine("Saved");
            //}
            //else
            //{
            //    Console.WriteLine("Not Saved");
            //}

            //if (_studentManager.Delete(1))
            //{
            //    Console.WriteLine("Deleted");
            //}
            //else
            //{
            //    Console.WriteLine("Not Deleted");
            //}

            //Student aStudent = new Student();
            //aStudent.Id = 2;
            //aStudent.RollNo = "002";
            //aStudent.Name = "Md Ashik";
            //aStudent.Address = "Motijhil";
            //aStudent.Age = 23;

            //if (_studentManager.Update(aStudent))
            //{
            //    Console.WriteLine("Updated");
            //}
            //else
            //{
            //    Console.WriteLine("Not Updated");
            //}

            Console.WriteLine("-------------------------------------------------------------------------");
            int i = 1;
            Console.WriteLine("Sl\t Name \t\t Roll No \t Address \t Age \t\tDepartment");

            foreach (var std in _studentManager.GetAll())
            {

                Console.WriteLine(i + "\t" + std.Name + "\t\t" + std.RollNo + " \t\t " + std.Address + " \t\t " + std.Age + "\t\t" + std.DepartmentId);
                i++;
            }

            Console.WriteLine("-------------------------------------------LINQ-----------------------------------------");
            i = 1;

            //SELECT * FROM Student AS s WHERE Age >20 AND Age <30 

            var students = _studentManager.GetAll();
            //Classical
            var result = from s in students
                            where s.Age >20 && s.Age < 30
                            select s; 
            //Lamda
            result = students.Where((c => c.Age > 20 && c.Age < 30));
            Console.WriteLine("Sl\t Name \t\t Roll No \t Address \t Age \t\tDepartment");
            foreach (var std in result)
            {

                Console.WriteLine(i + "\t" + std.Name + "\t\t" + std.RollNo + " \t\t " + std.Address + " \t\t " + std.Age + "\t\t" + std.DepartmentId);
                i++;
            }

            Console.ReadKey();
        }
    }
}
