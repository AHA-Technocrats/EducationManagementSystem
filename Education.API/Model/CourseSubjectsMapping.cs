using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Education.API.Model
{
    public class CourseSubjectsMapping
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Subjects")]
        public int SubjectID { get; set; }
        public Subjects Subjects { get; set; }

        [ForeignKey("Courses")]
        public int CourseID { get; set; }
        public Courses Courses { get; set; }
    }
}
