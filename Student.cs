using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFirebase
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public int SubjectTaken { get; set; }

        public Student(string name, int age, int subjectTaken, string id) 
        {
            Name = name;
            Age = age;
            SubjectTaken = subjectTaken;
            Id = id;
        }
    }
}
