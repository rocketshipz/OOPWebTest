using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFirebase
{
    public class StudentList
    {
        public List<Student> students = new List<Student>();
        public void Init(int num)
        {
            students = new List<Student>(num);
        }
        public void Add(Student student)
        { this.students.Add(student); }

        public void Clear()
        {  this.students.Clear(); }

        public int Count()
        { return this.students.Count(); }

        public List<Student> GetStudents() { return this.students; }
    }
}
