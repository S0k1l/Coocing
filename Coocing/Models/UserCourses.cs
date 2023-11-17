using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coocing.Models
{
    public class UserCourses
    {
        [Key]
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
