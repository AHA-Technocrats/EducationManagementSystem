using Education.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Repositories
{
    public interface ICourse
    {
        Task<dynamic> GetAllCourses();
        Task<IActionResult> GetCourse(int Id);
        Task<IActionResult> AddCourse(Courses Course);
        Task<dynamic> DeleteCourse(int Id);
        Task<dynamic> UpdateCourse(Courses Course);
    }
}
