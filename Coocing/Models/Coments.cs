using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coocing.Models
{
    public class Coments
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [ForeignKey("Recipes")]
        public int RecipesId { get; set; }
        public Recipes Recipes { get; set; }
    }
}
