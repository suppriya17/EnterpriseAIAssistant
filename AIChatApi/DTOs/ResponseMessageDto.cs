using System.Text.Json.Serialization;

namespace EnterpriseAIAssistant.API.DTOs
{
    public class ResponseMessageDto
    {
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }
}
