using System.Text.Json.Serialization;
namespace EnterpriseAIAssistant.API.DTOs
{
    public class OpenAIRequestDto
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("messages")]
        public List<OpenAIMessageDto> Messages { get; set; } = new();

    }
}
