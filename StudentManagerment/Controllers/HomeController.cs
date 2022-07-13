using Microsoft.AspNetCore.Mvc;
using StudentManagerment.Models;
using StudentManagerment.ViewModels;
using System.Linq;

namespace StudentManagerment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _IStudentRepository;//防止不小心赋值为空

        public HomeController(IStudentRepository studentRepository)
        {
            _IStudentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            var ip = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            var stuList = _IStudentRepository.GetAllStudents();
            var homeDetailsViewModel = new HomeDetailsViewModel()
            {
                PageTitle = "学生列表",
                stuArr = stuList
            };

            return View(homeDetailsViewModel);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || (id > 4 && id < 0))
                id = 3;
            StudentModel studentModel = _IStudentRepository.GetStudentById(id);

            //弱类型视图
            ViewData["pageTitle"] = "Student Details";
            ViewData["Student"] = studentModel;
            ViewBag.pageTitle = "Student Details";
            ViewBag.student = studentModel;
            //ViewModel
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = studentModel,
                PageTitle = "ViewModel"
            };
            return View(homeDetailsViewModel);
            //自定义视图
        }
    }
}
