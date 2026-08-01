using EnterpriseAIAssistant.API.DTOs;
using EnterpriseAIAssistant.API.Interfaces;
using EnterpriseAIAssistant.Models;
using System.Text.Json;

namespace EnterpriseAIAssistant.API.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly IHttpClientFactory _httpClientFActory;
        private readonly IConfiguration _configuration;
        private readonly IChatRepository _chatRepository;
        public OpenAIService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IChatRepository chatRepository)
        {
            _httpClientFActory = httpClientFactory;
            _configuration = configuration;
            _chatRepository = chatRepository;
        }
          
        public async Task<string> GetChatResponseAsync(string message)
        {
            var apiKey = _configuration["OpenAI:ApiKey"];
            var model = _configuration["OpenAI:Model"];
            var client = _httpClientFActory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",apiKey);

            var request = new OpenAIRequestDto
            {
                Model = model!,
                Messages = new List<OpenAIMessageDto>
                {
                    new OpenAIMessageDto{
                    Role = "user",
                    Content = message
                    }
                }
            };

            var jsonRequest = JsonSerializer.Serialize(request);

            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseJson = await response.Content.ReadAsStringAsync();
            var openAIResponse = JsonSerializer.Deserialize<OpenAIResponseDto>(responseJson);
            if (openAIResponse==null|| openAIResponse.Choices ==null|| openAIResponse.Choices.Count==0)
            {
                throw new Exception("No resonse received from OpenAI");
            }
            var aiResponse = openAIResponse!.Choices[0].Message.Content;

            var chatHistory = new ChatHistory
            {
                UserMessage = message,
                AIResponse = aiResponse,
                Model = openAIResponse.Model,
                PromptTokens = openAIResponse.UsageDto.PromptTokens,
                CompletionTokens = openAIResponse.UsageDto.CompletionTokens,
                TotalTokens = openAIResponse.UsageDto.TotalTokens
            };
            await _chatRepository.SaveChatHistoryAsync(chatHistory);
            return aiResponse;
        }
    }
}
