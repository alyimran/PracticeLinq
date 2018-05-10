using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            countEmployeeByDepartment();
            Console.ReadLine();
        }


        private static void countEmployeeByDepartment()
        {

            var employeeGroup = from employee in Employee.GetAllEmployees()
                                group employee by  new { employee.Department , employee.Gender }  into eGroup
                                orderby eGroup.Key.Department , eGroup.Key.Gender ascending
                                select new {
                                    Key = eGroup.Key ,
                                    Employees = eGroup.OrderBy(x => x.Name)

                                };

            foreach (var group in employeeGroup)
            {
               
                Console.WriteLine("{0} - {1}" , group.Key , group.Employees.Count());


                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Department);
                }
            }
                               

        }

    }


   
}
