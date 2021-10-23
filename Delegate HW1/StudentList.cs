using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Delegate_HW1.Program;

namespace Delegate_HW1
{
    class StudentList

    {
        public List<Student> Students { get; set; }

        public StudentList()
        {
            Students = new List<Student>();
        }
        public void AddStudent(Student s)
        {
            Students.Add(s);
        }
        public void RemoveStudent(Student s)
        {
            Students.Remove(s);
        }

        public List<Student> Filter(FilterStud filterDelegate)
        {
            return filterDelegate.Invoke(Students );
        }

        public bool Contains(CheckIfContains condDel)
        {
            foreach (Student student in Students)
            {
                if (condDel.Invoke(student))
                {
                    return true;
                }
            }
            return false;
        }
    }
    class Student
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        
    }
}
