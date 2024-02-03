
using System.Numerics;
using AdvisoryApp.Models;

namespace AdvisoryApp.Services
{
    public interface IAdvisorServices
    {
        List<Advisor> Get();
        Advisor Get(string id);

        Advisor Create(Advisor advisor);
        Advisor Authenticate(string username, string password);
        void Update(string id, Advisor advisor);
        void Remove(string id);
    }
}
