using EnterpriseAIAssistant.DTOs;
using EnterpriseAIAssistant.Models;

namespace EnterpriseAIAssistant.API.Interfaces
{
    public interface IChatRepository
    {
        Task SaveChatHistoryAsync(ChatHistory chatHistory);
        Task<List<ChatHistory>> GetChatHistoryAsync();
    }
}
