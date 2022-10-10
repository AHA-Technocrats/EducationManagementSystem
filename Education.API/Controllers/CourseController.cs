using Education.API.Model;
using Education.API.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Education.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
       
        private readonly ICourse iCourse;
        public CourseController(ICourse iCourse)
        {
            this.iCourse = iCourse;
        }


        // Get All Courses
        [HttpGet]   
        public  Task<dynamic> GetAllCourses()
        {
           var cource= this.iCourse.GetAllCourses();

            return cource;
        }

        // Get Single Course
        [HttpGet]
       [Route("{id:int}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            dynamic? result;
              result = this.iCourse.GetCourse(id);
               
             return result;
        }

        // Add Course
        [HttpPost]
       public async Task<IActionResult> AddCourse([FromBody] Courses course)
        {
           
             await this.iCourse.AddCourse(course);

           return Ok(course);
          // return CreatedAtAction(nameof(GetCourse), new { id = course.ID });

        }

        // Update Course
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] Courses course)
        {
           // dynamic result;
             await this.iCourse.UpdateCourse(course);

            return Ok(course);
          //  return result;

        }


        // Delete Course
        [HttpDelete]
       [Route("{id:int}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {

           
             await this.iCourse.DeleteCourse(id);

            return Ok(200);
           // return result;

        }
    }
 }

