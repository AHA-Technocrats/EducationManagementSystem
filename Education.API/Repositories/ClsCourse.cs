using Education.API.Contexts;
using Education.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.API.Repositories
{
    public class ClsCourse : ICourse
    {

        private readonly EducationDbContext educationDbContext;
        private readonly ILogger<ClsCourse> logger;

        public ClsCourse(EducationDbContext educationDbContext, ILogger<ClsCourse> logger)
        {
            this.educationDbContext = educationDbContext;
            this.logger = logger;
        }

        public async Task<dynamic> DeleteCourse(int Id)
        {

            dynamic? result;
            try
            {
                var existingCourse = await this.educationDbContext.Courses.FirstOrDefaultAsync(x => x.ID == Id);

                if (existingCourse != null)
                {
                     this.educationDbContext.Courses.Remove(existingCourse);

                    result= await this.educationDbContext.SaveChangesAsync();

                   // result = "Deleted";
                }
                else
                {
                    result = "Course not found";
                }
            }
            catch (Exception ex)
            {
                result = "0";
            }

            return result;
        }


       
       public async Task<dynamic> UpdateCourse(Courses course)
        {
            dynamic? result;
            try
            {
                var existingCourse = await this.educationDbContext.Courses.FirstOrDefaultAsync(x => x.ID == course.ID);

                if (existingCourse != null)
                {
                    existingCourse.CourseName = course.CourseName;
                    result= await this.educationDbContext.SaveChangesAsync();
                   
                }
                else
                {
                    result = "Course not found";
                }
            }
            catch(Exception ex)
            {
                result = null;
            }

            return result;
        }

        async  Task<IActionResult> ICourse.AddCourse(Courses course)
        {
            dynamic? result=null;
            try
            {
                await this.educationDbContext.Courses.AddAsync(course);
                 await this.educationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error in AddCourse " + ex.Message);
                result = null;
            }
           return result;
        }

        async Task<dynamic> ICourse.GetAllCourses()
        {
           dynamic? result;
            try
            {
                result = await this.educationDbContext.Courses.ToListAsync();
            }
            catch(Exception ex)
            {
                logger.LogInformation("Error in GetAllCourses " + ex.Message);
                result = null;
               
            }
              
            return result;
        }

        async Task<IActionResult> ICourse.GetCourse(int Id)
        {
            dynamic? result;
            try
            {
                if (Id == 0)
                {
                    result = "Please pass the course Id";
                 
                }

                result = await this.educationDbContext.Courses.FirstOrDefaultAsync(x => x.ID == Id);
                if (result == null)
                {
                    result = "Course not found";
                 
                }

                return (IActionResult)result;
            }
            catch(Exception ex)
            {
                logger.LogInformation("Error in GetCourse " + ex.Message);
                result = null;
                return (IActionResult)result;
            }
           
        }

    }
}
