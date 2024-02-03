using MongoDB.Driver;
using AdvisoryApp.Models;
using AdvisoryApp.DataBaseSetting;

namespace AdvisoryApp.Services
{
    public class PostServices : IPostServices
    {
        private readonly IMongoCollection<Post> _posts;
        

       public PostServices(IpostDataBaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _posts = database.GetCollection<Post>(settings.PostCollectionName);
        }
        

        public Post Create(Post post)
        {
            _posts.InsertOne(post);
            return post;
        }

        public List<Post> Get()
        {
            return _posts.Find(post => true).ToList();
        }

        public Post Get(string id)
        {
            return _posts.Find(post => post.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _posts.DeleteOne(post => post.Id == id);
        }

        public void Update(string id, Post updatedPost)
        {
            updatedPost.Id = id;
            _posts.ReplaceOne(post => post.Id == id, updatedPost);
        }
    }
}
