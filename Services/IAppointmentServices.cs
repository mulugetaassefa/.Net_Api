 using AdvisoryApp.Models;
 
namespace AdvisoryApp.Services
{
    public interface IAppointmentServices
    {
       List<Appointment> Get();
        Appointment Get(string id);
        Appointment  Create(Appointment appointment);
        void Update(string id, Appointment appointment);
        void Remove(string id); 
    }
}
