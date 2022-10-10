using Education.API.Contexts;
using Education.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.API.Repositories
{
    public class ClsTeacher : ITeacher
    {

        private readonly EducationDbContext educationDbContext;
        private readonly ILogger<ClsCourse> logger;

        public ClsTeacher(EducationDbContext educationDbContext, ILogger<ClsCourse> logger)
        {
            this.educationDbContext = educationDbContext;
            this.logger = logger;
        }
        public async Task<IActionResult> AddTeacher(Teachers Teachers)
        {
            dynamic? result;
            try
            {
                await this.educationDbContext.Teachers.AddAsync(Teachers);
                result = await this.educationDbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in AddTeacher " + ex.Message);
                result = null;
            }
            return (IActionResult)result;
        }

        public async Task<IActionResult> DeleteTeacher(int Id)
        {

            dynamic? result;
            try
            {
                var existingTeacher = await this.educationDbContext.Teachers.FirstOrDefaultAsync(x => x.ID == Id);

                if (existingTeacher != null)
                {
                    this.educationDbContext.Teachers.Remove(existingTeacher);

                    result = await this.educationDbContext.SaveChangesAsync();

                }
                else
                {
                    result = "Teacher not found";
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return (IActionResult)result;
        }

        public async Task<IActionResult> GetAllTeacher()
        {
            dynamic? result;
            try
            {
                result = await this.educationDbContext.Teachers.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in GetAllTeacher " + ex.Message);
                result = null;

            }

            return (IActionResult)result;
        }

        public async Task<IActionResult> GetTeacher(int Id)
        {

            dynamic? result;
            try
            {
                if (Id == 0)
                {
                    result = "Please pass the teacher Id";

                }

                result = await this.educationDbContext.Teachers.FirstOrDefaultAsync(x => x.ID == Id);
                if (result == null)
                {
                    result = "Teacher not found";

                }

                return (IActionResult)result;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in GetTeacher " + ex.Message);
                result = null;
                return (IActionResult)result;
            }
        }

        public async Task<IActionResult> UpdateTeacher(Teachers Teacher)
        {
            dynamic? result;
            try
            {
                var existingTeacher = await this.educationDbContext.Teachers.FirstOrDefaultAsync(x => x.ID == Teacher.ID);

                if (existingTeacher != null)
                {
                   existingTeacher.TeacherName = Teacher.TeacherName;
                   existingTeacher.Salary = Teacher.Salary;
                   existingTeacher.Birthday = Teacher.Birthday;

                    result = await this.educationDbContext.SaveChangesAsync();

                }
                else
                {
                    result = "Subject not found";
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return (IActionResult)result;
        }
    }
}
