using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coocing.Models
{
    public class CourseRecipes
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int RecipesId { get; set; }
        public Recipes Recipes { get; set; }
    }
}
