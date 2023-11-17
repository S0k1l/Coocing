using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coocing.Models
{
    public class Coments
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int RecipesId { get; set; }
        public Recipes Recipes { get; set; }
    }
}
