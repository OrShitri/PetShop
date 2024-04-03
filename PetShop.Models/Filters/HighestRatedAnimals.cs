using System.ComponentModel.DataAnnotations;

namespace PetShop.Models.Filters
{
    public class HighestRatedAnimals
    {
        public Animal? Animal { get; set; }

        [Display(Name = "Number Of Comments")]
        public int? RatingCount { get; set; }
    }
}
