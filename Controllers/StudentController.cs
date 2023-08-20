using Microsoft.AspNetCore.Mvc;
using SRM.Api.Data.Abstract;
using SRM.Api.Data.Concrete;
using SRM.Api.Entites;
using SRM.Api.Models.ViewModels;

namespace SRM.Api.Controllers
{
    /// <summary>
    /// Öğrencileri yönettiğimiz controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var models = studentRepository
                .GetAllOrderByRank()
                .Select(x => new
                {
                    rank = x.CalculateRanking(),
                    name = x.Name,
                    lastName = x.LastName,
                });
            return Ok(models);
        }


        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var model = await studentRepository.GetAsync(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(Student_Create_VM model)
        {
            //çok uzatmamak adına mapper kullanmadım :)
            var inserted = new Student()
            {
                Name = model.Name,
                LastName = model.LastName,
            };
            await studentRepository.AddAsync(inserted);
            return Ok(inserted);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync(Student_Update_VM model)
        {
            var updated = await studentRepository.GetAsync(model.Id);
            updated.Name = model.Name;
            updated.LastName = model.LastName;
            await studentRepository.UpdateAsync(updated);
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await studentRepository.RemoveAsync(id);
            return Ok();
        }

       

    }
}
