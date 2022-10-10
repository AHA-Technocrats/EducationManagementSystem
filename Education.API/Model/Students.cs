using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Education.API.Model
{
    public class Students
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Student Name is required")]
        public string StudentName { get; set; }

        [Display(Name = "Student Birthday")]
        [Required(ErrorMessage = "Birthday is required")]
        public string Birthday { get; set; }

        [Display(Name = "Student Registration Number")]
        [Required(ErrorMessage = "Student Registration Number is required")]
        public string RegistrationNumber { get; set; }
    }
}
