using Education.API.Model;
using Education.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
        private readonly ISubject iSubject;
        public SubjectController(ISubject iSubject)
        {
            this.iSubject = iSubject;
        }


        // Get All Subject
        [HttpGet]
        public Task<IActionResult> GetAllSubject()
        {
            var result = this.iSubject.GetAllSubject();

            return result;
        }

        // Get Single Subject
        [HttpGet]
       [Route("{id:int}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            dynamic? result;
            result = this.iSubject.GetSubject(id);

            return result;
        }

        // Add Subject
        [HttpPost]
       public async Task<IActionResult> AddSubject([FromBody] Subjects subject)
        {

            await this.iSubject.AddSubject(subject);

            return CreatedAtAction(nameof(GetSubject), new { id = subject.ID });

        }

        // Update Subject
        [HttpPut]
       public async Task<IActionResult> UpdateSubject([FromBody] Subjects subject)
        {
            dynamic result;
            result = await this.iSubject.UpdateSubject(subject);

            return result;

        }


        // Delete Subject
        [HttpDelete]
      [Route("{id:int}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {

            dynamic result;
            result = await this.iSubject.DeleteSubject(id);

            return result;

        }
    }
}
