using AdvisoryApp.Models;
using AdvisoryApp.Services;
using Microsoft.AspNetCore.Mvc;


namespace AdvisoryApp.Controllers
{ 
   [Route("api/[controller]")]
   [ApiController]
public class StudentsController : ControllerBase
    {
    private readonly IStudentServices studentService;

    public StudentsController(IStudentServices studentService)
    {
        this.studentService = studentService;
    }
    // GET: api/<StudentsController>
    [HttpGet]
    public ActionResult<List<Student>> Get()
    {
        return studentService.Get();
    }

    // GET api/<studentsController>/5
    [HttpGet("{id}")]
    public ActionResult<Student> Get(string id)
    {
        var student = studentService.Get(id);

        if ( student == null)
        {
            return NotFound($"student with Id = {id} not found");
        }

        return student;
    }

    [HttpPost("Authenticate")]
    public IActionResult Authenticate([FromBody] Login login)
    {
        var student = studentService.Authenticate(login.UserName, login.Password);

        if ( student == null)
        {
            return Unauthorized("Invalid username or password");
        }

        // If authentication succeeds, return some token or a success message
        // You may consider using JWT tokens or other authentication mechanisms here

        // For example, return a success message with the admin details
        return Ok(new { Message = "Authentication successful", student = student });
    }

    // POST api/<StudentsController>
    [HttpPost]
    public async Task<ActionResult<Student>> Post([FromForm] Student student, IFormFile photo)
    {
        if (photo != null)
        {
            var fileName = $"{student.Id}_{photo.FileName}";
            var filePath = Path.Combine("wwwroot", "photos", "students", fileName); // Specify the directory where photos will be saved

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }

            var photoUrl = $"/wwwroot/photos/Patients/{fileName}"; // Constructing the URL where the photo will be accessible

            student.PhotoUrl = photoUrl; // Save the photo URL to the Student model
        }

        studentService.Create(student);

        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }


    // PUT api/<StudntController>/5

    [HttpPut("{id}")]
    public async Task<ActionResult<Student>> Put(string id, [FromForm] Student updatedPatient, IFormFile photo)
    {
        var existingPatient = studentService.Get(id);
        if (existingPatient == null)
        {
            return NotFound($"student with Id = {id} not found");
        }

        if (photo != null)
        {
            var fileName = $"{updatedPatient.Id}_{photo.FileName}";
            var filePath = Path.Combine("wwwroot", "photos", "student", fileName); // Specify the directory where photos will be saved

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }

            var photoUrl = $"/wwwroot/photos/Patients/{fileName}"; // Constructing the URL where the photo will be accessible

            updatedPatient.PhotoUrl = photoUrl; // Save the photo URL to the Student model
        }

        studentService.Update(id, updatedPatient);

        return Ok($"student with Id = {id} updated");
    }

    // DELETE api/<studentController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        var student = studentService.Get(id);

        if (  student == null)
        {
            return NotFound($"studnt with Id = {id} not found");
        }

        studentService.Remove(id);

        return Ok($"student with Id = {id} deleted");
    }
}
}
