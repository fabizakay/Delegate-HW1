using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_HW1
{
    class Program
    {
        public delegate double Calc(double n1, double n2);
        public delegate List<Student> FilterStud(List<Student> students);
        public delegate bool CheckIfContains(Student student);
        static void Main(string[] args)
        {
            StudentList sl = new StudentList();

            Student s = new Student {FullName = "Avi",Age = 25, Grade = 80 };
            Student s1 = new Student {FullName = "Fabi",Age = 31, Grade = 95 };
            Student s2 = new Student { FullName = "Riki", Age = 25, Grade = 100 };
            Student s3 = new Student { FullName = "Ran", Age = 52, Grade = 55 };

            sl.AddStudent(s);
            sl.AddStudent(s1);
            sl.AddStudent(s2);
            sl.AddStudent(s3);


            FilterStud ByGrade = FilterByGradeUpTo90;
            FilterStud ByName = FilterByLengthName;
            List<Student> ls = sl.Filter(ByGrade);
            List<Student> ls2 = sl.Filter(ByName);




            Calc add = Add;
            Calc SUB = Sub;

            Console.WriteLine(add(5, 2));
            Console.WriteLine(SUB(5, 2));

            CheckIfContains cicByStartWith = new CheckIfContains(ContainsNamesStartWithA);
            CheckIfContains cicByAgeIs = new CheckIfContains(ContainsNamesStartWithA);



            bool isExist = sl.Contains(cicByStartWith);
            bool isExist1 = sl.Contains(cicByAgeIs);

        }
        static bool ContainsNamesStartWithA(Student s)
        {
            return s.FullName.StartsWith("A");
        }
        static bool ContainsAgeIs25(Student s)
        {
            return s.Age==25;
        }

        static List<Student> FilterByGradeUpTo90(List<Student> students)
        {
            return students.Where(s => s.Grade > 90).ToList();
        }

        static List<Student> FilterByLengthName(List<Student> students)
        {
            return students.Where(s => s.FullName.Length > 3).ToList();
        }
        static  double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        static double Sub (double n1, double n2)
        {
            return n1 - n2;
        }
    }
}
