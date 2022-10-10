using Education.API.Contexts;
using Education.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.API.Repositories
{
    public class ClsSubject : ISubject
    {

        private readonly EducationDbContext educationDbContext;
        private readonly ILogger<ClsCourse> logger;

        public ClsSubject(EducationDbContext educationDbContext, ILogger<ClsCourse> logger)
        {
            this.educationDbContext = educationDbContext;
            this.logger = logger;
        }
        public async Task<IActionResult> AddSubject(Subjects subject)
        {
            dynamic? result;
            try
            {
                await this.educationDbContext.Subjects.AddAsync(subject);
                result = await this.educationDbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in AddSubject " + ex.Message);
                result = null;
            }
            return (IActionResult)result;
        }

        public async Task<IActionResult> DeleteSubject(int Id)
        {

            dynamic? result;
            try
            {
                var existingSubject = await this.educationDbContext.Subjects.FirstOrDefaultAsync(x => x.ID == Id);

                if (existingSubject != null)
                {
                    this.educationDbContext.Subjects.Remove(existingSubject);

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

        public async Task<IActionResult> GetAllSubject()
        {
            dynamic? result;
            try
            {
                result = await this.educationDbContext.Subjects.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in GetAllSubject " + ex.Message);
                result = null;

            }

            return (IActionResult)result;
        }

        public async Task<IActionResult> GetSubject(int Id)
        {

            dynamic? result;
            try
            {
                if (Id == 0)
                {
                    result = "Please pass the student Id";

                }

                result = await this.educationDbContext.Subjects.FirstOrDefaultAsync(x => x.ID == Id);
                if (result == null)
                {
                    result = "Subject not found";

                }

                return (IActionResult)result;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in GetSubject " + ex.Message);
                result = null;
                return (IActionResult)result;
            }
        }

        public async Task<IActionResult> UpdateSubject(Subjects subject)
        {
            dynamic? result;
            try
            {
                var existingSubject = await this.educationDbContext.Subjects.FirstOrDefaultAsync(x => x.ID == subject.ID);

                if (existingSubject != null)
                {
                    existingSubject.SubjectName = subject.SubjectName;
                   
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
