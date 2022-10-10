using Education.API.Model;
using Education.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private readonly ITeacher iTeacher;
        public TeacherController(ITeacher iTeacher)
        {
            this.iTeacher = iTeacher;
        }


        // Get All Teachers
        [HttpGet]
        public Task<IActionResult> GetAllTeacher()
        {
            var result = this.iTeacher.GetAllTeacher();

            return result;
        }

        // Get Single Teacher
        [HttpGet]
       [Route("{id:int}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            dynamic? result;
            result = this.iTeacher.GetTeacher(id);

            return result;
        }

        // Add Teacher
        [HttpPost]
         public async Task<IActionResult> AddTeacher([FromBody] Teachers teacher)
        {

            await this.iTeacher.AddTeacher(teacher);

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.ID });

        }

        // Update Teacher
        [HttpPut]
       public async Task<IActionResult> UpdateTeacher([FromBody] Teachers teacher)
        {
            dynamic result;
            result = await this.iTeacher.UpdateTeacher(teacher);

            return result;

        }


        // Delete Teacher
        [HttpDelete]
       [Route("{id:int}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {

            dynamic result;
            result = await this.iTeacher.DeleteTeacher(id);

            return result;

        }
    }
}
