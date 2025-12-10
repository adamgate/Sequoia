using System.Net.Http.Json;

using Sequoia.Core.Models;
using Sequoia.Web.Client.Services.Contracts;

namespace Sequoia.Web.Client.Services.Implementations
{
    public class NoteService : INoteService
    {
        private HttpClient _httpClient;

        public NoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Note>> GetNotesByUserIdAsync(int userId)
        {
            var route = $"api/user/{userId}/notes";
            return await _httpClient.GetFromJsonAsync<IEnumerable<Note>>(route);
        }
    }
}
