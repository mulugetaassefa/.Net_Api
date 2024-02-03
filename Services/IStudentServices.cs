
using AdvisoryApp.Models;
namespace AdvisoryApp.Services
{
    public interface IStudentServices
    {
        List<Student> Get();
        Student Get(string id);
       Student Create(Student student);
        Student Authenticate(string username, string password);
        void Update(string id, Student student);
        void Remove(string id);
    }
}
