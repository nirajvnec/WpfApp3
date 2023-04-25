
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Microsoft.Extensions.Options;

public class ApiServiceTests
{
    private readonly ApiService _apiService;
    private readonly HttpClient _httpClient;
    private readonly IOptions<AppSettings> _appSettings;

    public ApiServiceTests()
    {
        _appSettings = Substitute.For<IOptions<AppSettings>>();
        _appSettings.Value.Returns(new AppSettings { /* set your app settings properties here */ });

        var httpMessageHandler = new FakeHttpMessageHandler();
        _httpClient = new HttpClient(httpMessageHandler);

        _apiService = new ApiService(_appSettings, _httpClient);
    }

    [Fact]
    public async Task GetDataAsync_ReturnsExpectedData()
    {
        // Arrange
        string requestUri = "https://api.example.com/data";
        var expectedData = new MyDataModel { /* set expected data properties here */ };

        // Act
        var result = await _apiService.GetDataAsync<MyDataModel>(requestUri);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(JsonConvert.SerializeObject(expectedData), JsonConvert.SerializeObject(result));
    }

    [Fact]
    public async Task PostDataAsync_ReturnsExpectedData()
    {
        // Arrange
        string requestUri = "https://api.example.com/data";
        string userName = "testUser";
        string catId = "testCat";
        var expectedData = new MyDataModel { /* set expected data properties here */ };

        // Act
        var result = await _apiService.PostDataAsync<MyDataModel>(requestUri, userName, catId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(JsonConvert.SerializeObject(expectedData), JsonConvert.SerializeObject(result));
    }
}

public class FakeHttpMessageHandler : HttpMessageHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(JsonConvert.SerializeObject(new MyDataModel { /* set expected data properties here */ }))
        };
        return await Task.FromResult(response);
    }
}


public class AppSettings
{
    public string SecurityServerConnectionString { get; set; }
    public int SecurityServerApplicationId { get; set; }
    public string SecurityServerEnvironmentSwitch { get; set; }
}

{
  // ...
  "AppSettings": {
    "SecurityServerConnectionString": "your_connection_string",
    "SecurityServerApplicationId": 1,
    "SecurityServerEnvironmentSwitch": "your_environment_switch"
  }
}
