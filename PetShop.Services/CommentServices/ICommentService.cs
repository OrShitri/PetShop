using PetShop.Models;

namespace PetShop.Services.CommentServices
{
    public interface ICommentService
    {
        Task AddComment(Comment comment);

        Task EditComment(int id, string comment);

        Task RemoveComment(int id);

        Task RemoveAllComments(int id);

        Task<IEnumerable<Comment>> GetComment(int id);

        Task<int> GetAnimalIdByCommentId(int id);
    }
}
