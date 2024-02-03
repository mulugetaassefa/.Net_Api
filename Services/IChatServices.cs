using AdvisoryApp.Models;

namespace AdvisoryApp.Services
{
    public interface IChatServices
    {
        List<Chat> Get();
        Chat Get(string id);
        Chat Create(Chat chat);
        void Update(string id, Chat chat);
        void Remove(string id);
    }
}
