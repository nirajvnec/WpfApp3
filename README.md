To host an Angular 14 application and a .NET 7 Web API on IIS 10, you will need to follow these steps:

Step 1: Install IIS and required components

Open the "Control Panel" and go to "Programs and Features."
Click "Turn Windows features on or off."
Enable "Internet Information Services (IIS)" by ticking the checkbox.
Expand the IIS node and enable the following features:
Web Management Tools:
IIS Management Console
World Wide Web Services:
Application Development Features:
.NET Extensibility 4.8 (or later)
ASP.NET 4.8 (or later)
ISAPI Extensions
ISAPI Filters
Click "OK" to install the selected features.
Step 2: Install the .NET Core Hosting Bundle

Download the .NET Core Hosting Bundle for .NET 7 from the official Microsoft website: https://dotnet.microsoft.com/download/dotnet/7.0
Install the hosting bundle by following the installation wizard.
Step 3: Publish Angular 14 and .NET 7 Web API projects

Publish your Angular 14 application:
Open the terminal and navigate to the Angular project directory.
Run ng build --prod to create a production build in the "dist" folder.
Publish your .NET 7 Web API application:
Open the terminal and navigate to the Web API project directory.
Run dotnet publish --configuration Release --output ./publish to create a release build in the "publish" folder.
Step 4: Configure IIS

Open IIS Manager and create a new website by right-clicking "Sites" and selecting "Add Website."
Set the website name, physical path (Angular project's "dist" folder), binding information, and click "OK."
Create a new application under the website for the Web API by right-clicking the website and selecting "Add Application."
Set the alias and physical path (Web API project's "publish" folder), then click "OK."
Step 5: Configure the Web API application

Select the Web API application, and double-click "Authentication" in the Features view.
Ensure "Anonymous Authentication" is enabled.
Go back to the Features view and double-click "Handler Mappings."
Find and select the "aspNetCore" handler, then click "Edit" in the Actions pane.
In the "Executable" field, enter the path to the .NET 7 runtime (e.g., "C:\Program Files\dotnet\dotnet.exe").
In the "Arguments" field, enter the path to your published Web API .dll file (e.g., "C:\inetpub\wwwroot\YourWebAPI\YourWebAPI.dll").
Click "OK" to save the changes.
Step 6: Configure Angular to use the Web API

Update the "environment.prod.ts" file in your Angular project to point to the Web API's URL (e.g., "https://yourwebsite.com/WebAPI").
Rebuild the Angular application using ng build --prod and copy the updated "dist" folder to the IIS website's physical path.
At this point, your Angular 14 application and .NET 7 Web API should be hosted on IIS 10. Test your application by navigating to your website's URL.


public async Task<List<string>> GetAttributeNamesAsync()
{
    List<UserPermission> userPermissions = await PostPermissionedDataAsync<UserPermission>();

    // Extract the AttributeName property values and return them as a list
    List<string> attributeNames = userPermissions.Select(up => up.AttributeName).ToList();
    return attributeNames;
}



public async Task<List<T>> PostPermissionedDataAsync<T>()
{
    // ...
    List<UserPermission> userPermissions;
    string json;

    try
    {
        // ...
        userPermissions = JsonConvert.DeserializeObject<List<UserPermission>>(json) ?? new List<UserPermission>();
    }
    // ...

    if (typeof(T) == typeof(string))
    {
        // Extract the AttributeName property values and return them as a list
        var attributeNames = userPermissions.Select(up => up.AttributeName).ToList();
        return attributeNames as List<T>;
    }
    
    return userPermissions as List<T>;
}


public async Task<List<T>> PostPermissionedDataAsync<T>()
{
    // ...
    List<UserPermission> userPermissions;
    string json;

    try
    {
        // ...
        userPermissions = JsonConvert.DeserializeObject<List<UserPermission>>(json) ?? new List<UserPermission>();
    }
    // ...

    return userPermissions as List<T>;
}



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
