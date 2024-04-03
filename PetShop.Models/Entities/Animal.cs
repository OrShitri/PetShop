using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [MaxLength(20, ErrorMessage = "Name can be a maximum of 20 characters")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [Required(ErrorMessage = "Please enter a Name")]
        public string? Name { get; set; }

        [Range(1, 400, ErrorMessage = "Age must be between 1 and 400 years")]
        [Required(ErrorMessage = "Please enter an Age")]
        public int Age { get; set; }

        [Display(Name = "Picture")]
        public string? PictureName { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        [Display(Name = "Category")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public virtual int CategoryId { get; set; }

    }
}
