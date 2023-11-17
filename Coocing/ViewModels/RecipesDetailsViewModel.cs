using Coocing.Models;

namespace Coocing.ViewModels
{
    public class RecipesDetailsViewModel
    {
        public RecipesViewModel Recipes { get; set; }

        public List<ComentsViewModel> Coments { get; set; }
    }
}
