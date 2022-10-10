using Education.API.Model;
using Education.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : Controller
    {

        private readonly IGrades iGrades;

        public GradesController(IGrades iGrades)
        {
            this.iGrades = iGrades;
        }



        // Get All Grades
        [HttpGet]
        public Task<dynamic> GetAllGrades()
        {
            var result = this.iGrades.GetAllGrades  ();

            return result;
        }

        // Get Single Grade
        [HttpGet]
       [Route("{id:int}")]
        public async Task<IActionResult> GetGrade(int id)
        {
            dynamic? result;
            result = this.iGrades.GetGrade(id);

            return result;
        }

        // Add Grade
        [HttpPost]
        public async Task<IActionResult> AddGrade([FromBody] Grades grades)
        {

            await this.iGrades.AddGrades(grades);

            return Ok(grades);

        }

        // Update Grade
        [HttpPut]

       public async Task<IActionResult> UpdateGrade([FromBody] Grades grades)
        {
            dynamic result;
            result = await this.iGrades.UpdateGrades(grades);

            return result;

        }


        // Delete Grade
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteGreade(int id)
        {

           // dynamic result;
         await this.iGrades.DeleteGrades(id);

            return Ok(200);

        }
    }
}
