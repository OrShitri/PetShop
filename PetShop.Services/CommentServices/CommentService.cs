using PetShop.Data.Repositories.CommentRepository;
using PetShop.Models;

namespace PetShop.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task AddComment(Comment comment)
        {
            await _repository.AddComment(comment);
        }

        public async Task EditComment(int id, string comment)
        {
            await _repository.EditComment(id, comment);
        }

        public async Task RemoveComment(int id)
        {
            await _repository.RemoveComment(id);
        }

        public async Task RemoveAllComments(int id)
        {
            await _repository.RemoveAllComments(id);
        }

        public async Task<IEnumerable<Comment>> GetComment(int id)
        {
            return await _repository.GetComment(id);
        }

        public async Task<int> GetAnimalIdByCommentId(int id)
        {
            var comment = await _repository.GetAnimalIdByCommentId(id);
            return comment.AnimalId;
        }

    }
}
