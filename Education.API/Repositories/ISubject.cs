using Education.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Repositories
{
    public interface ISubject
    {
        Task<IActionResult> GetAllSubject();
        Task<IActionResult> GetSubject(int Id);
        Task<IActionResult> AddSubject(Subjects Subjects);
        Task<IActionResult> DeleteSubject(int Id);
        Task<IActionResult> UpdateSubject(Subjects Subjects);
    }
}
