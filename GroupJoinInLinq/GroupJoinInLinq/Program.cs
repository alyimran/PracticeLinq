using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupJoinInLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            groupJoin();
            Console.ReadLine();
        }


        private static void groupJoin()
        {
            var employeesByDepartment = from d in Department.GetAllDepartments()
                                        join e in Employee.GetAllEmployees()
                                             on d.ID equals e.DepartmentID
                                             into eGroup
                                        select new
                                        {
                                            Department = d,
                                            Employees = eGroup
                                        };

            foreach (var item in employeesByDepartment)
            {
                Console.WriteLine(item.Department.Name);

                foreach (var emp in item.Employees)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
    }
}
