using StudentManagerment.Models;
using System.Collections.Generic;

namespace StudentManagerment.ViewModels
{
    public class HomeDetailsViewModel
    {
        public StudentModel Student { get; set; }
        public string PageTitle { get; set; }

        public IEnumerable<StudentModel> stuArr { get; set; }
    }
}
