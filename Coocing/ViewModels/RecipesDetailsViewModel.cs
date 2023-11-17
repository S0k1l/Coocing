using Coocing.Models;

namespace Coocing.ViewModels
{
    public class RecipesDetailsViewModel
    {
        public RecipesViewModel Recipes { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public int ComentId { get; set; }
    }
}
