using Education.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Repositories
{
    public interface IGrades
    {
        Task<dynamic> GetAllGrades();
        Task<IActionResult> GetGrade(int Id);
        Task<IActionResult> AddGrades(Grades Grades);
        Task<dynamic> DeleteGrades(int Id);
        Task<dynamic> UpdateGrades(Grades Grades);
    }
}
