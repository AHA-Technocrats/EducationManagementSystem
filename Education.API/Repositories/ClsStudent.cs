using Education.API.Contexts;
using Education.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.API.Repositories
{
    public class ClsStudent : IStudent
    {

        private readonly EducationDbContext educationDbContext;
        private readonly ILogger<ClsCourse> logger;

        public ClsStudent(EducationDbContext educationDbContext, ILogger<ClsCourse> logger)
        {
            this.educationDbContext = educationDbContext;
            this.logger = logger;
        }
        public async Task<IActionResult> AddStudent(Students students)
        {
            dynamic? result;
            try
            {
                await this.educationDbContext.Students.AddAsync(students);
                result = await this.educationDbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in AddStudent " + ex.Message);
                result = null;
            }
            return (IActionResult)result;
        }

        public async Task<IActionResult> DeleteStudent(int Id)
        {

            dynamic? result;
            try
            {
                var existingStudent = await this.educationDbContext.Students.FirstOrDefaultAsync(x => x.ID == Id);

                if (existingStudent != null)
                {
                    this.educationDbContext.Students.Remove(existingStudent);
                    result = await this.educationDbContext.SaveChangesAsync();

                }
                else
                {
                    result = "Student not found";
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return (IActionResult)result;
        }

        public async Task<IActionResult> GetAllStudent()
        {
            dynamic? result;
            try
            {
                result = await this.educationDbContext.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in GetAllStudent " + ex.Message);
                result = null;

            }

            return (IActionResult)result;
        }

        public async Task<IActionResult> GetStudent(int Id)
        {

            dynamic? result;
            try
            {
                if (Id == 0)
                {
                    result = "Please pass the student Id";

                }

                result = await this.educationDbContext.Students.FirstOrDefaultAsync(x => x.ID == Id);
                if (result == null)
                {
                    result = "Student not found";

                }

                return (IActionResult)result;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in GetStudent " + ex.Message);
                result = null;
                return (IActionResult)result;
            }
        }

        public async Task<IActionResult> UpdateStudent(Students students)
        {
            dynamic? result;
            try
            {
                var existingStudent = await this.educationDbContext.Students.FirstOrDefaultAsync(x => x.ID == students.ID);

                if (existingStudent != null)
                {
                    existingStudent.StudentName = students.StudentName;
                    existingStudent.RegistrationNumber = students.RegistrationNumber;
                    existingStudent.Birthday = students.Birthday;
                    result = await this.educationDbContext.SaveChangesAsync();

                }
                else
                {
                    result = "Student not found";
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
