
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentManagerment.Models
{
    public class MockStudentRepository : IStudentRepository
    {

        private List<StudentModel> _students;
        public MockStudentRepository()
        {

            _students = new List<StudentModel>()
            {

                new StudentModel(){ id=1,Name="呦呦",ClassName="幼儿小班", Email="1213331",imgSrc="b.png"},
                new StudentModel(){ id=2,Name="扣扣",ClassName="幼儿大班", Email="2213331",imgSrc="c.png"},
                new StudentModel(){ id=3,Name="晓晓",ClassName="幼儿小班", Email="3213331",imgSrc="d.png"},
                new StudentModel(){ id=4,Name="伟男",ClassName="幼儿大班", Email="4213331",imgSrc="e.png"}
            };
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
            return _students;
        }

        public StudentModel GetStudentById(int? id)
        {
            return _students.FirstOrDefault(x => x.id == id);
        }
    }
}
