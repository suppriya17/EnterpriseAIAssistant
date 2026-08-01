using System.Text.Json.Serialization;

namespace EnterpriseAIAssistant.API.DTOs
{
    public class ChoiceDTO
    {
        [JsonPropertyName("message")]
        public ResponseMessageDto Message { get; set; } = new();
    }
}
