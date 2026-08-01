using System.Text.Json.Serialization;

namespace EnterpriseAIAssistant.API.DTOs
{
    public class OpenAIResponseDto
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("choices")]
        public List<ChoiceDTO> Choices { get; set; } = new();

        [JsonPropertyName("usage")]
        public UsageDto UsageDto { get; set; } = new();
    }
}
