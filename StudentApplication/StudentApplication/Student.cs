using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication
{
    internal class Student
    {
        
        public string namn;
        public string surname;

        public static List<Student> students = new List<Student>();

        public Student(string namn, string surname)
        {
            
            this.namn = namn;
            this.surname = surname;
            students.Add(this);
        }   
    }
}
