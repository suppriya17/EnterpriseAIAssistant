using EnterpriseAIAssistant.API.Interfaces;
using EnterpriseAIAssistant.API.Data;
using EnterpriseAIAssistant.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAIAssistant.API.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ChatRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<ChatHistory>> GetChatHistoryAsync()
        {
           return await _applicationDbContext.ChatHistories.OrderByDescending(x=>x.CreatedDate).ToListAsync();
        }

        public async Task SaveChatHistoryAsync(ChatHistory chatHistory)
        {
           await _applicationDbContext.AddAsync(chatHistory);
           await _applicationDbContext.SaveChangesAsync();

        }
    }
}
