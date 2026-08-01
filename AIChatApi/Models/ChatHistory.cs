namespace EnterpriseAIAssistant.Models
{
    public class ChatHistory
    {
        public long Id { get; set; }

        public string UserMessage { get; set; } = string.Empty;

        public string AIResponse { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int PromptTokens { get; set; }

        public int CompletionTokens { get; set; }

        public int TotalTokens { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
