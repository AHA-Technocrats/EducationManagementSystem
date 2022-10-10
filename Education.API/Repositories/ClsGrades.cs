using Education.API.Contexts;
using Education.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.API.Repositories
{
    public class ClsGrades : IGrades
    {

        private readonly EducationDbContext educationDbContext;
        private readonly ILogger<ClsGrades> logger;

        public ClsGrades(EducationDbContext educationDbContext, ILogger<ClsGrades> logger)
        {
            this.educationDbContext = educationDbContext;
            this.logger = logger;
        }
        public async Task<IActionResult> AddGrades(Grades crades)
        {
            dynamic? result = null;
            try
            {
                await this.educationDbContext.Grades.AddAsync(crades);
                await this.educationDbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in AddGrades " + ex.Message);
                result = null;
            }
            return result;
        }

        public async  Task<dynamic> DeleteGrades(int Id)
        {

            dynamic? result;
            try
            {
                var existingGrade = await this.educationDbContext.Grades.FirstOrDefaultAsync(x => x.ID == Id);

                if (existingGrade != null)
                {

                    result = await this.educationDbContext.SaveChangesAsync();

                }
                else
                {
                    result = "Grade not found";
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        public async Task<dynamic> GetAllGrades()
        {
            dynamic? result;
            try
            {
                result = await this.educationDbContext.Grades.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in GetAllGrades " + ex.Message);
                result = null;

            }

            return result;
        }

        public async Task<IActionResult> GetGrade(int Id)
        {

            dynamic? result;
            try
            {
                if (Id == 0)
                {
                    result = "Please pass the grade Id";

                }

                result = await this.educationDbContext.Grades.FirstOrDefaultAsync(x => x.ID == Id);
                if (result == null)
                {
                    result = "Grade not found";

                }

                return (IActionResult)result;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in GetGrade " + ex.Message);
                result = null;
                return (IActionResult)result;
            }
        }

        public async Task<dynamic> UpdateGrades(Grades crades)
        {
            dynamic? result;
            try
            {
                var existingGrade = await this.educationDbContext.Grades.FirstOrDefaultAsync(x => x.ID == crades.ID);

                if (existingGrade != null)
                {
                    existingGrade.Grade = crades.Grade;
                    result = await this.educationDbContext.SaveChangesAsync();

                }
                else
                {
                    result = "Grade not found";
                }
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }
    }
}
