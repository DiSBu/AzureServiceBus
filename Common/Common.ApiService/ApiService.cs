using Common.Logger;
using Common.Model.MessageModels;
using Common.Model.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Common.ApiService
{
    public class ApiService : IApiService
    {
        private ITokenCreationHandler _tokenCreationHandler;
        private ILoggingService _logger;
        private readonly IOptionsMonitor<ConsumerServiceSettings> _consumerServiceSettings;

        public ApiService(ITokenCreationHandler tokenCreationHandler, ILoggingService logger, IOptionsMonitor<ConsumerServiceSettings> consumerServiceSettings)
        {
            _tokenCreationHandler = tokenCreationHandler;
            _logger = logger;
            _consumerServiceSettings = consumerServiceSettings;
            _logger.LogInformation($"ApiService is Configured with Issuer: { _consumerServiceSettings.CurrentValue.ApiUrl } ");
        }

        public bool CallApiEndpoint(AzureMessage azureMessage)
        {
            return APIPost<bool>(JsonConvert.SerializeObject(azureMessage), $"api/endpoint");
        }

        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(_consumerServiceSettings.CurrentValue.ApiUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenCreationHandler.CreateToken());
            return client;
        }

        private T APIPost<T>(string values, string endpoint)
        {
            HttpClient client = GetHttpClient();
            HttpContent content = new StringContent(values, Encoding.UTF8, "application/json");

            string requestUri = $"{_consumerServiceSettings.CurrentValue.ApiUrl}{endpoint}";
            var response = client.PostAsync(requestUri, content).Result;
            if(response.StatusCode==System.Net.HttpStatusCode.Unauthorized)
            {
                string message = $"Unauthorized call to {requestUri}";
                _logger.LogWarning(message);
                throw new UnauthorizedAccessException(message);
            }

            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}