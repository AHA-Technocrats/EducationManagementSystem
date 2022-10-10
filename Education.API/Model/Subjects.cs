using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Education.API.Model
{
    public class Subjects
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Subject Name")]
        [Required(ErrorMessage = "Subject Name is required")]
        public string SubjectName { get; set; }
    }
}
