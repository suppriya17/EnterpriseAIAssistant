namespace EnterpriseAIAssistant.DTOs
{
    public class ChatResponseDto
    {
        public long Id { get; set; }
        public string UserMessage { get; set; } = string.Empty;
        public string AIResponse { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
