using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Education.API.Model
{
    public class Grades
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Grade Name")]
        [Required(ErrorMessage = "Grade Name is required")]
        public string Grade { get; set; }
    }
}
