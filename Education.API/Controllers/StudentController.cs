using Education.API.Model;
using Education.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudent iStudent;
        public StudentController(IStudent iStudent)
        {
            this.iStudent = iStudent;
        }


        // Get All Students
        [HttpGet]
        public Task<IActionResult> GetAllStudents()
        {
            var result = this.iStudent.GetAllStudent();

            return result;
        }

        // Get Single Student
        [HttpGet]
       [Route("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            dynamic? result;
            result = this.iStudent.GetStudent(id);

            return result;
        }

        // Add Student
        [HttpPost]
        [ActionName("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] Students student)
        {

            await this.iStudent.AddStudent(student);

            return CreatedAtAction(nameof(GetStudent), new { id = student.ID });

        }

        // Update Student
        [HttpPut]
       public async Task<IActionResult> UpdateStudent([FromBody] Students student)
        {
            dynamic result;
            result = await this.iStudent.UpdateStudent(student);

            return result;

        }


        // Delete Student
        [HttpDelete]
       [Route("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            dynamic result;
            result = await this.iStudent.DeleteStudent(id);

            return result;

        }
    }
}
