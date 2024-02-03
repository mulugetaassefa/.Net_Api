using AdvisoryApp.Models;
using AdvisoryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvisoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatServices chatService;

        public ChatsController(IChatServices chatService)
        {
            this.chatService = chatService;
        }

        // GET: api/Chats
        [HttpGet]
        public ActionResult<List<Chat>> Get()
        {
            return chatService.Get();
        }

        // GET: api/Chats/{id}
        [HttpGet("{id}")]
        public ActionResult<Chat> Get(string id)
        {
            var chat = chatService.Get(id);

            if (chat == null)
            {
                return NotFound($"Chat with Id = {id} not found");
            }

            return chat;
        }

        // POST: api/Chats
        [HttpPost]
        

        // PUT: api/Chats/{id}

        [HttpPut("{id}")]
        public ActionResult<Chat> Put(string id, [FromForm] Chat updatedChat)
        {
            var existingChat = chatService.Get(id);

            if (existingChat == null)
            {
                return NotFound($"Chat with Id = {id} not found");
            }

            chatService.Update(id, updatedChat);

            return Ok($"Chat with Id = {id} updated");
        }

        // DELETE: api/Chats/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var chat = chatService.Get(id);

            if (chat == null)
            {
                return NotFound($"Chat with Id = {id} not found");
            }

            chatService.Remove(id);

            return Ok($"Chat with Id = {id} deleted");
        }
    }
}
