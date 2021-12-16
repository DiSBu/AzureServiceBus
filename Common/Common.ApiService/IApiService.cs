using Common.Model.MessageModels;

namespace Common.ApiService
{
    public interface IApiService
    {
        bool CallApiEndpoint(AzureMessage azureMessage);
    }
}