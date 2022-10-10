using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Education.API.Model
{
    public class Teachers
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Teacher Name")]
        [Required(ErrorMessage = "Teacher Name is required")]
        public string TeacherName { get; set; }

        [Display(Name = "Teacher Birthday")]
        [Required(ErrorMessage = "Birthday is required")]
        public string Birthday { get; set; }

        [Display(Name = "Teacher Salary")]
        [Required(ErrorMessage = "Teacher salary is required")]
        public decimal Salary { get; set; }
    }
}
