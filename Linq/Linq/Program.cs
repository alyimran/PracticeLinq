using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {



        string[] stringArray =
{
    "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
    "0123456789"
};


      static  string[] countries = { "Australia", "Canada", "Germany", "US", "India", "UK", "Italy" };
        static void Main(string[] args)
        {


            // flattenthestring(stringArray);
            //giveAndShowBonus();
            // showAllSubjects();
            //showSubjectsWithName();
            //showSubjectsWithQuerySyntax();
            // sortStudentsByName();
            // sortByTotalNumbers();
            //getfirstThreegreaterthan2();
            //skipfirstThree();


            convertToDictionalry();
            Console.ReadLine();
        }


        private static void convertToDictionalry()
        {
            Dictionary<int, string> dictionary = Student2.GetAllStudents().ToDictionary(x => x.StudentID , x=> x.Name);
            foreach (KeyValuePair<int, string> kvp in dictionary)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
        }


        private static void getfirstThreegreaterthan2()
        {
            IEnumerable<string> result = countries.TakeWhile(x=> x.Length >2);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }



        private static void getfirstThree()
        {
            IEnumerable<string> result = (from country in countries
                                         select country).Take(3);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void skipfirstThree()
        {
            IEnumerable<string> result = (from country in countries
                                          select country).Skip(3);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        private static void sortByTotalNumbers()
        {
            IEnumerable<Student2> sortedmarks = from student in Student2.GetAllStudents()
                         orderby student.TotalMarks , student.Name , student.StudentID
                        
                         select student;


            foreach (var item in sortedmarks)
            {
                Console.WriteLine(item.TotalMarks + " "  +item.Name + " " + item.StudentID);
              
            }
        }




        private static void sortStudentsByName()
        {
            IEnumerable<Student2> sortedStudents = from student in Student2.GetAllStudents()
                                                   orderby student.Name descending
                                                   select student;

            foreach (var item in sortedStudents)
            {
                Console.WriteLine(item.Name);
            }

        }



        private static void flattenthestring(string [] s)
        {
            // IEnumerable<char> mystring = s.SelectMany(x => x);
            IEnumerable<char> mystring = from st in s
                                         from c in st
                                         select  c;


            foreach (var item in mystring)
            {
                Console.WriteLine(item);
            }

        }


        private static void showAllSubjects()
        {

            IEnumerable<string> subjects = Student.GetAllStudetns()
                .SelectMany(x => x.Subjects).Distinct();

            foreach (var item in subjects)
            {
                Console.WriteLine(item);
                Console.WriteLine("");
            }
        }


        private static void showSubjectsWithQuerySyntax()
        {

            IEnumerable<string> allsubjects = (from student in Student.GetAllStudetns()
                                              from subject in student.Subjects
                                              select subject).Distinct();


            foreach (var item in allsubjects)
            {
                Console.WriteLine(item);
                Console.WriteLine("");
            }
        }


        private static void showSubjectsWithName()
        {
            var result = from student in Student.GetAllStudetns()
                         from subject in student.Subjects
                         select new { FirstName = student.Name, Subject = subject };

            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName + "-" + item.Subject);
            }

        }


        private static void giveAndShowBonus()

        { 

            var result = Employee.GetAllEmployees()
            .Where(x => x.AnnualSalary > 5000)
            .Select(emp => new
            {
                FirstName = emp.FirstName,
                Salary = emp.AnnualSalary,
                Bonus = emp.AnnualSalary * 10
            });



           


            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName);
                Console.WriteLine(item.Salary);
                Console.WriteLine(item.Bonus);
            }
        }
    }


    
}
