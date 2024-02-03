
using MongoDB.Driver;
using AdvisoryApp.Models;
using AdvisoryApp.DataBaseSetting;
namespace AdvisoryApp.Services
{
    public class StudentServices :IStudentServices
    {
                   private readonly IMongoCollection<Student> _Students;

           public StudentServices(IStudentDataBaseSettings settings, IMongoClient mongoClient)
            {
                var database = mongoClient.GetDatabase(settings.DatabaseName);
               _Students = database.GetCollection<Student>(settings.StudentCollectionName);
            }
            

            public Student Create(Student Student)
            {
                _Students.InsertOne(Student);
                return Student;
            }

          public List<Student> Get()
            {
                return _Students.Find(Student => true).ToList();
            }

            public Student Get(string id)
            {
                return _Students.Find(Student => Student.Id == id).FirstOrDefault();
            }

        public Student Authenticate(string username, string password)
        {
            var Student = _Students.Find(a => a.UserName == username).FirstOrDefault();

            if (Student != null && Student.Password == password)
            {
                // Authentication successful, return the admin details
                return Student;
            }

            // If the username or password is incorrect, return null
           return null;
        }
       

        public void Remove(string id)
            {
               _Students.DeleteOne(Student => Student.Id == id);
            }

            public void Update(string id, Student updatedStudent)
            {
                updatedStudent.Id = id; 
               _Students.ReplaceOne(student => student.Id == id, updatedStudent);
            }  
    }  
    
}
