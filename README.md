using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class FakeHttpMessageHandler : HttpMessageHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = new StringContent(JsonConvert.SerializeObject(
                new UserPermission(
                    "0413.1426.1500.5500.5509.5504", // TechIDValue
                    "READ ONLY", // RightName
                    "INDSPA874601", // ScopeValueSet
                    "LOCATION_RO", // AttributeName
                    "REPORTS_ALL" // AttributeValue
                )
            ))
        };

        return await Task.FromResult(response);
    }
}




public record UserPermission(
    string TechIDValue,
    string RightName,
    string ScopeValueSet,
    string AttributeName,
    string AttributeValue
);

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// ...

public async Task<List<T>> PostPermissionedDataAsync<T>()
{
    var requestData = new
    {
        LoginName = "nnkuma152",
        IctoID = "ICTO-22866"
    };

    ServicePointManager.Expect100Continue = true;
    ServicePointManager.DefaultConnectionLimit = 9999;
    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

    using var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
    HttpResponseMessage response;
    List<UserPermission> userPermissions;
    string json;

    try
    {
        response = await _httpClient.PostAsync(_appSettings.Voluo.AuraSyncGetPermissionApiEndPoint, content);
        json = await response.Content.ReadAsStringAsync();
        userPermissions = JsonConvert.DeserializeObject<List<UserPermission>>(json);
    }
    catch (Exception ex)
    {
        // Handle exceptions here
        throw;
    }

    return userPermissions as List<T>;
}





using Newtonsoft.Json;
using MarsNet.Models.Services;

// ...

string json = "{\"name\":\"value\"}";

// Option 1: Deserialize to a single object
UserPermission userPermission = JsonConvert.DeserializeObject<UserPermission>(json);

// Option 2: Deserialize to a list, handling the single object case
List<UserPermission> userPermissions;
try
{
    userPermissions = JsonConvert.DeserializeObject<List<UserPermission>>(json);
}
catch (JsonSerializationException)
{
    userPermissions = new List<UserPermission> { JsonConvert.DeserializeObject<UserPermission>(json) };
}




private static IOptions<AppSettings> GetAppSettingsOptions()
{
    string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "DEV";

    var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.unittests.json")
        .AddJsonFile($"appsettings.unittests.{environmentName}.json", optional: true); // Load environment-specific settings

    var configuration = configurationBuilder.Build();

    var appSettingsSection = configuration.GetSection(environmentName);

    var appSettings = appSettingsSection.Get<AppSettings>();
    var appSettingsOptions = Options.Create(appSettings);

    return appSettingsOptions;
}





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
