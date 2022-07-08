
using System.Collections.Generic;
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
                new StudentModel(){ id=1,Name="刘美双",ClassName="幼儿大班", Email="1213331"},
                new StudentModel(){ id=2,Name="扣扣",ClassName="学前班", Email="2213331"},
                new StudentModel(){ id=3,Name="晓晓",ClassName="幼儿小班", Email="3213331"},
                new StudentModel(){ id=4,Name="董伟男",ClassName="小学一年级", Email="4213331"}
            };
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
            return _students;
        }

        public StudentModel GetStudentById(int id)
        {
            return _students.FirstOrDefault(x => x.id == id);
        }
    }
}
