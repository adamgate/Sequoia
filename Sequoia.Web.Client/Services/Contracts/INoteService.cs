using Sequoia.Core.Models;

namespace Sequoia.Web.Client.Services.Contracts
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNotesByUserIdAsync(int userId);
        Task<Note> GetNoteByIdAsync(int noteId);
        Task CreateNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteByIdAsync(int noteId);
    }
}
