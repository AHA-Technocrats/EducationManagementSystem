using System.ComponentModel.DataAnnotations;

namespace Education.API.Model
{
    public class Courses
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Course Name")]
        [Required(ErrorMessage ="Course Name is required")]
        public string CourseName { get; set; }

    }
}
