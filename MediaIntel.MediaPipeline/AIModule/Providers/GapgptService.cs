using MediaIntel.MediaPipeline.AIModule.Extensions;
using MediaIntel.MediaPipeline.AIModule.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MediaIntel.MediaPipeline.AIModule.Providers
{
    public class GapgptService : BaseAiService, IAiService
    {
        public GapgptService(AiModelOptions aiModelOptions) : base(aiModelOptions)
        {
        }

        public string ProviderName => "Gapgpt";

        public async Task<string> SendRequsetAsync(string prompt, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("", Method.Post);

            var requestData = new
            {
                model = _modelAI.ToApiModelString(),
                input = GetPrompt(prompt),
            };

            request.AddJsonBody(requestData, ContentType.Json);

            var response = await _client.ExecuteAsync(request, cancellationToken);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error: {response.ErrorMessage}, Status: {response.StatusCode}, Content: {response.Content}");
            }


            var jsonObj = JObject.Parse(response.Content!);

            var token = jsonObj.SelectToken("$..[?(@.type == 'output_text')].text");

            if (token != null)
            {
                return token.ToString();
            }

            throw new Exception("Could not find the required 'text' token in the API response.");
        }


    }
}
