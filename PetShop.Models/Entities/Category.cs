using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
    }
}
