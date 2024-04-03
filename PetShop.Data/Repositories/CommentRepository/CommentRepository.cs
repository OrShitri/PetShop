using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data.Repositories.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MyContext _myContext;

        public CommentRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task AddComment(Comment comment)
        {
            await _myContext.Comments!.AddAsync(comment);
            await _myContext.SaveChangesAsync();
        }

        public async Task EditComment(int id, string comment)
        {
            var commentInDb = await _myContext.Comments!.FindAsync(id);
            commentInDb!.Comments = comment;
            await _myContext.SaveChangesAsync();
        }

        public async Task RemoveComment(int id)
        {
            var comment = await _myContext.Comments!.FindAsync(id);
            _myContext.Comments.Remove(comment!);
            await _myContext.SaveChangesAsync();
        }

        public async Task RemoveAllComments(int id)
        {
            var commentsById = await GetComment(id);
            foreach (var comment in commentsById)
            {
                _myContext.Comments!.Remove(comment);
            }
        }

        public async Task<IEnumerable<Comment>> GetComment(int id)
        {
            return await _myContext.Comments!.Where(m => m.AnimalId == id).ToListAsync();
        }

        public async Task<Comment> GetAnimalIdByCommentId(int id)
        {
            return await _myContext.Comments!.FirstAsync(m => m.CommentId == id);
        }

        public async Task<int> GetNumberOfCommentByAnimalId(Animal animal)
        {
            return await _myContext.Comments!.CountAsync(m => m.AnimalId == animal.AnimalId);
        }
    }
}
