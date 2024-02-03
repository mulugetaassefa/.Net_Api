using AdvisoryApp.Models;

namespace AdvisoryApp.Services
{
    public interface IPostServices
    {

        List<Post> Get();
        Post Get(string id);
        Post Create(Post post);
        void Update(string id, Post post);
        void Remove(string id);
    }
}
