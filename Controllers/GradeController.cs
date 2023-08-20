using Microsoft.AspNetCore.Mvc;
using SRM.Api.Data.Abstract;
using SRM.Api.Entites;
using SRM.Api.Models.ViewModels;

namespace SRM.Api.Controllers
{

    /// <summary>
    ///Öğrencilere ait notları yönettiğimiz controller. 
    /// </summary>
    /// 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private IGradeRepository gradeRepository;
        public GradeController(IGradeRepository gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var models = gradeRepository.GetAll();
            return Ok(models.ToList());
        }


        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await gradeRepository.GetAsync(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGradeAsync(Grade_Create_VM model)
        {
            //çok uzatmamak adına mapper kullanmadım :)
            var inserted = new Grade()
            {
                Point = model.Point,
                LessonId = model.LessonId,
                StudentId = model.StudentId,
            };
            await gradeRepository.AddAsync(inserted);
            return Ok(inserted);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGradeAsync(Grade_Update_VM model)
        {
            var updated = await gradeRepository.GetAsync(model.Id);
            updated.Point = model.Point;
            await gradeRepository.UpdateAsync(updated);
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGradeAsync(int id)
        {
            await gradeRepository.RemoveAsync(id);
            return Ok();
        }
    }
}
