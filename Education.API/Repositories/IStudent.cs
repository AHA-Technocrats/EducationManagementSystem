using Education.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Repositories
{
    public interface IStudent
    {
        Task<IActionResult> GetAllStudent();
        Task<IActionResult> GetStudent(int Id);
        Task<IActionResult> AddStudent(Students Students);
        Task<IActionResult> DeleteStudent(int Id);
        Task<IActionResult> UpdateStudent(Students Students);
    }
}
