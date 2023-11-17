using System.ComponentModel.DataAnnotations;

namespace Coocing.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public ICollection<UserCourses> Courses { get; set; }
        public ICollection<CourseRecipes> CourseRecipes { get; set; }
    }
}
