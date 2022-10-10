using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Education.API.Model
{
    public class TeacherStudentsMapping
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Teachers")]
        public int TeacherID { get; set; }
        public Teachers Teachers { get; set; }

        [ForeignKey("Students")]
        public int StudentID { get; set; }
        public Students Students { get; set; }
    }
}
