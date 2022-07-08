using System.Collections.Generic;

namespace StudentManagerment.Models
{
    public interface IStudentRepository
    {
        StudentModel GetStudentById(int id);

        IEnumerable<StudentModel> GetAllStudents();
        
    }
}
