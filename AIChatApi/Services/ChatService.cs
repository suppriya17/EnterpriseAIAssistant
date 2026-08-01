using Azure.Core;
using EnterpriseAIAssistant.API.Interfaces;
using EnterpriseAIAssistant.DTOs;
using EnterpriseAIAssistant.Interfaces;
using EnterpriseAIAssistant.Models;

namespace EnterpriseAIAssistant.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<ChatResponseDto>> GetChatHistroyAsync()
        {
            var chatHistory = await _chatRepository.GetChatHistoryAsync();
            var result = chatHistory.Select(chat => new ChatResponseDto
            {
                Id = chat.Id,
                UserMessage = chat.UserMessage,
                AIResponse = chat.AIResponse,
                Model = chat.Model,
                CreatedDate = chat.CreatedDate
            }).ToList();
            return result; 
        }

        public async Task SaveChatHistoryAsync(ChatRequestDto requestDto)
        {
            if (string.IsNullOrEmpty(requestDto.Message))
            {
                throw new ArgumentException("Message cannot be empty.");
            }
            var chatHistory = new ChatHistory
            {
                UserMessage = requestDto.Message,
                AIResponse = string.Empty,
                Model = string.Empty,
            };

            await _chatRepository.SaveChatHistoryAsync(chatHistory);
        }
    }
}
