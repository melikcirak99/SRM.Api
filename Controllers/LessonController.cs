using Microsoft.AspNetCore.Mvc;
using SRM.Api.Data.Abstract;
using SRM.Api.Data.Concrete;
using SRM.Api.Entites;
using SRM.Api.Models.ViewModels;

namespace SRM.Api.Controllers
{
    /// <summary>
    /// Dersleri yönettiğimiz controller
    /// </summary>
    /// 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private ILessonRepository lessonRepository;
        public LessonController(ILessonRepository lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var models = lessonRepository.GetAll();
            return Ok(models.ToList());
        }


        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await lessonRepository.GetAsync(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLessonAsync(Lesson_Create_VM model)
        {
            var inserted = new Lesson()
            {
                Name = model.Name,
            };
            await lessonRepository.AddAsync(inserted);
            return Ok(inserted);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLessonAsync(Lesson_Update_VM model)
        {
            var updated = await lessonRepository.GetAsync(model.Id);
            updated.Name = model.Name;
            await lessonRepository.UpdateAsync(updated);
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await lessonRepository.RemoveAsync(id);
            return Ok();
        }
    }
}
