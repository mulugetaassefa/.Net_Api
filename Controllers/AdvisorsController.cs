using AdvisoryApp.Models;
using AdvisoryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdvisoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorsController : ControllerBase
    {
        private readonly IAdvisorServices advisorService;

        public AdvisorsController(IAdvisorServices advisorService)
        {
            this.advisorService = advisorService;
        }

        // GET: api/Advisors
        [HttpGet]
        public ActionResult<List<Advisor>> Get()
        {
            var advisors = advisorService.Get();
            return advisors;
        }

        // GET: api/Advisors/{id}
        [HttpGet("{id}")]
        public ActionResult<Advisor> Get(string id)
        {
            var advisor = advisorService.Get(id);

            if (advisor == null)
            {
                return NotFound($"Advisor with Id = {id} not found");
            }

            return advisor;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Login login)
        {
            var advisor = advisorService.Authenticate(login.UserName, login.Password);

            if (advisor == null)
            {
                return Unauthorized("Invalid username or password");
            }

            // If authentication succeeds, return some token or a success message
            // You may consider using JWT tokens or other authentication mechanisms here

            // For example, return a success message with the advisor details
            return Ok(new { Message = "Authentication successful", Advisor = advisor });
        }

        // POST: api/Advisors
        [HttpPost]
        public async Task<ActionResult<Advisor>> Post([FromForm] Advisor advisor, IFormFile photo)
        {
            if (photo != null)
            {
                var fileName = $"{advisor.Id}_{photo.FileName}";
                var filePath = Path.Combine("wwwroot", "photos", "Advisors", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/photos/Advisors/{fileName}"; // Constructing the URL where the photo will be accessible

                advisor.PhotoUrl = photoUrl; // Save the photo URL to the Advisor model
            }

            advisorService.Create(advisor);

            return CreatedAtAction(nameof(Get), new { id = advisor.Id }, advisor);
        }

        // PUT: api/Advisors/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Advisor>> Put(string id, [FromForm] Advisor updatedAdvisor, IFormFile photo)
        {
            var existingAdvisor = advisorService.Get(id);

            if (existingAdvisor == null)
            {
                return NotFound($"Advisor with Id = {id} not found");
            }

            if (photo != null)
            {
                var fileName = $"{updatedAdvisor.Id}_{photo.FileName}";
                var filePath = Path.Combine("wwwroot", "photos", "Advisors", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/photos/Advisors/{fileName}"; // Constructing the URL where the photo will be accessible

                updatedAdvisor.PhotoUrl = photoUrl; // Save the photo URL to the Advisor model
            }

            advisorService.Update(id, updatedAdvisor);

            return Ok($"Advisor with Id = {id} updated");
        }

        // DELETE: api/Advisors/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var advisor = advisorService.Get(id);

            if (advisor == null)
            {
                return NotFound($"Advisor with Id = {id} not found");
            }

            advisorService.Remove(id);

            return Ok($"Advisor with Id = {id} deleted");
        }
    }
}