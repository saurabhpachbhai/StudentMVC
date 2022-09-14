using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMVC.Data;
using StudentMVC.Models;
using System.Security.Claims;
using System.Xml.Linq;

namespace StudentMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsDbContext studentsDbContext;

        public StudentsController(StudentsDbContext studentsDbContext)
        {
            this.studentsDbContext = studentsDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await studentsDbContext.Student.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudent addStudent)
        {
            var student = new Students()
            {
                Id = Guid.NewGuid(),
                Name = addStudent.Name,
                RollNO = addStudent.RollNO,
                Class = addStudent.Class,
                DOB=addStudent.DOB
            };
            await studentsDbContext.Student.AddAsync(student);
            await studentsDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var student = await studentsDbContext.Student.FirstOrDefaultAsync(x => x.Id == id);

            if (student != null)
            {
                var ViewModel = new EditStudent()
                {
                    Id = student.Id,
                    Name = student.Name,
                    RollNO = student.RollNO,
                    Class = student.Class,
                    DOB=student.DOB
                };
                return await Task.Run(() => View("View", ViewModel));
            }
            return RedirectToAction("Index");
        }




        [HttpPost]
        public async Task<IActionResult> View(EditStudent model)
        {
            var student = await studentsDbContext.Student.FindAsync(model.Id);

            if(student != null)
            {
                student.Name = model.Name;
                student.RollNO = model.RollNO;
                student.Class = model.Class;
                student.DOB = model.DOB;

                await studentsDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");       
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditStudent model)
        {
            var student = await studentsDbContext.Student.FindAsync(model.Id);

            if (student != null)
            {
                studentsDbContext.Student.Remove(student);
                await studentsDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }



    }
}
