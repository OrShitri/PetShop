using PetShop.Models;

namespace PetShop.Data.Repositories.CommentRepository
{
    public interface ICommentRepository
    {
        Task AddComment(Comment comment);

        Task EditComment(int id, string comment);

        Task RemoveComment(int id);

        Task RemoveAllComments(int id);

        Task<IEnumerable<Comment>> GetComment(int id);

        Task<Comment> GetAnimalIdByCommentId(int id);

        Task<int> GetNumberOfCommentByAnimalId(Animal animal);
    }
}
