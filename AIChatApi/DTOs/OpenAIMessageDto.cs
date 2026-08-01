using System.Text.Json.Serialization;
namespace EnterpriseAIAssistant.API.DTOs
{
    public class OpenAIMessageDto
    {
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }
}
