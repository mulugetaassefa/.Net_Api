using AdvisoryApp.DataBaseSetting;
using AdvisoryApp.Models;
using MongoDB.Driver;
namespace AdvisoryApp.Services
{
    public class AdvisorServices : IAdvisorServices
    {
        private readonly IMongoCollection<Advisor> _Advisors;

      
        public AdvisorServices(IAdvisorDataBaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _Advisors = database.GetCollection<Advisor>(settings.AdvisorCollectionName);
        }
     
        public Advisor Create(Advisor Advisor)
        {
            _Advisors.InsertOne(Advisor);
            return Advisor;
        }

        public List<Advisor> Get()
        {
            return _Advisors.Find(Advisor => true).ToList();
        }

        public Advisor Get(string id)
        {
            return _Advisors.Find(Advisor => Advisor.Id == id).FirstOrDefault();
        }

        public Advisor Authenticate(string username, string password)
        {
            var Advisor= _Advisors.Find(d => d.UserName == username).FirstOrDefault();

            if (Advisor != null && Advisor.Password == password)
            {
                // Authentication successful, return the admin details
                return Advisor;
            }

            // If the username or password is incorrect, return null
            return null;
        }

        public void Remove(string id)
        {
            _Advisors.DeleteOne(Advisor => Advisor.Id == id);
        }

        public void Update(string id, Advisor updatedAdvisor)
        {
            updatedAdvisor.Id = id;
            _Advisors.ReplaceOne(Advisor => Advisor.Id == id, updatedAdvisor);
        }
    }
}
