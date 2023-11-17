using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coocing.Models
{
    public class Recipes
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<CourseRecipes> CourseRecipes { get; set; }
        public ICollection<Coments> Coments { get; set; }
    }
}
