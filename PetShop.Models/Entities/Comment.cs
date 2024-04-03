using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public virtual int AnimalId { get; set; }

        [StringLength(500)]
        [MinLength(4, ErrorMessage = "Comment must be at least 4 characters long")]
        [Required(ErrorMessage = "Please enter your Comment")]
        public string? Comments { get; set; }
    }
}
