using Microsoft.AspNetCore.Mvc;
using SRM.Api.Data.Abstract;
using SRM.Api.Entites;
using SRM.Api.Models.ViewModels;

namespace SRM.Api.Controllers
{
    /// <summary>
    /// Öğrenci ve ders ilişkilerini yönettiğimiz controller
    /// </summary>
    /// 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentLessonController : ControllerBase
    {
        private IStudentLessonRepository studentLessonRepository;
        public StudentLessonController(IStudentLessonRepository studentLessonRepository)
        {
            this.studentLessonRepository = studentLessonRepository;
        }

        /// <summary>
        /// Öğrenciye ders ataması yapıyoruz
        /// </summary>
        /// <param name="model">öğrenci ve ders id değerleri</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddLessonToStudentAsync(Student_Lesson_Create_VM model)
        {
            var inserted = new StudentLesson()
            {
                StudentId = model.StudentId,
                LessonId = model.LessonId,  
            };
            await studentLessonRepository.AddAsync(inserted);
            return Ok(inserted);
        }
    }
}
