namespace EnterpriseAIAssistant.API.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GetChatResponseAsync(string message);
    }
}
