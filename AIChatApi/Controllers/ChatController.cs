using EnterpriseAIAssistant.API.Interfaces;
using EnterpriseAIAssistant.DTOs;
using EnterpriseAIAssistant.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAIAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IOpenAIService _openAIService;
        public ChatController(IChatService chatService,IOpenAIService openAIService)
        {
            _chatService = chatService;
            _openAIService = openAIService;
        }


        [HttpPost]
        public async Task<IActionResult> SaveChat(ChatRequestDto requestDto)
        {
          await  _chatService.SaveChatHistoryAsync(requestDto);

            return Ok(new
            {
                Message= "Chat saved successfully.",
                Success = true,
            });

        }
        [HttpGet]
        public async Task<string> GetChatResponseAsync(string message)
        {
           return await _openAIService.GetChatResponseAsync(message);

        }

        [HttpGet("chathistory")]
        public async Task<IActionResult> GetChatHistoryAsync()
        {
            var chatHistory =  await _chatService.GetChatHistroyAsync();

            return Ok(chatHistory);

        }
    }
}
