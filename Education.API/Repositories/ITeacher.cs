using Education.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Repositories
{
    public interface ITeacher
    {
        Task<IActionResult> GetAllTeacher();
        Task<IActionResult> GetTeacher(int Id);
        Task<IActionResult> AddTeacher(Teachers Teachers);
        Task<IActionResult> DeleteTeacher(int Id);
        Task<IActionResult> UpdateTeacher(Teachers Teachers);
    }
}
