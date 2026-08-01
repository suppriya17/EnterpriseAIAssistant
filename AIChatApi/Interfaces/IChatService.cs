using EnterpriseAIAssistant.DTOs;

namespace EnterpriseAIAssistant.Interfaces
{
    public interface IChatService
    {
         Task SaveChatHistoryAsync(ChatRequestDto chatRequestDto);
         Task <List<ChatResponseDto>> GetChatHistroyAsync();
    }
}
