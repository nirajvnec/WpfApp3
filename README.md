<app-dropdowns [label]="labelForQueues" [options]="availableReportQueueOptions"></app-dropdowns>
<app-dropdowns [label]="labelForPriorities" [options]="priorityOptions"></app-dropdowns>

import { Component } from '@angular/core';

@Component({
  selector: 'app-parent-component',
  templateUrl: './parent-component.component.html',
  styleUrls: ['./parent-component.component.scss']
})
export class ParentComponent {
  labelForQueues = 'Queue';
  labelForPriorities = 'Priority';

  availableReportQueueOptions = ['Option 1', 'Option 2', 'Option 3'];
  priorityOptions = ['High', 'Medium', 'Low'];
}

import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-dropdowns',
  templateUrl: './dropdowns.component.html',
  styleUrls: ['./dropdowns.component.scss']
})
export class DropdownsComponent {
  @Input() label: string = 'Dropdown';
  @Input() options: string[];
}



import { Component } from '@angular/core';

@Component({
  selector: 'app-parent-component',
  templateUrl: './parent-component.component.html',
  styleUrls: ['./parent-component.component.scss']
})
export class ParentComponent {
  availableReportQueueOptions = ['Option 1', 'Option 2', 'Option 3'];
  priorityOptions = ['High', 'Medium', 'Low'];
}

<app-dropdowns [options]="availableReportQueueOptions"></app-dropdowns>
<app-dropdowns [options]="priorityOptions"></app-dropdowns>

import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-dropdowns',
  templateUrl: './dropdowns.component.html',
  styleUrls: ['./dropdowns.component.scss']
})
export class DropdownsComponent {
  @Input() options: string[];
}


<mat-form-field appearance="fill">
  <mat-label>Dropdown</mat-label>
  <mat-select>
    <mat-option *ngFor="let option of options" [value]="option">
      {{ option }}
    </mat-option>
  </mat-select>
</mat-form-field>

import { Component } from '@angular/core';

@Component({
  selector: 'app-my-component',
  templateUrl: './my-component.component.html',
  styleUrls: ['./my-component.component.scss']
})
export class MyComponent {
  availableReportQueueOptions = ['Option 1', 'Option 2', 'Option 3'];
  priorityOptions = ['High', 'Medium', 'Low'];
}

<div class="container">
  <div class="row">
    <div class="col-md-6">
      <mat-form-field appearance="fill">
        <mat-label>Available Report Queue Options</mat-label>
        <mat-select>
          <mat-option *ngFor="let option of availableReportQueueOptions" [value]="option">
            {{ option }}
          </mat-option>
        </mat-select>
      </mat-form-field>
    </div>
    <div class="col-md-6">
      <mat-form-field appearance="fill">
        <mat-label>Priority Options</mat-label>
        <mat-select>
          <mat-option *ngFor="let option of priorityOptions" [value]="option">
            {{ option }}
          </mat-option>
        </mat-select>
      </mat-form-field>
    </div>
  </div>
</div>




import { NO_ERRORS_SCHEMA, NgModule } from '@angular/core';

@NgModule({
  // Other properties
  schemas: [NO_ERRORS_SCHEMA],
})
export class AppModule { }


import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

@NgModule({
  // Other properties
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }


import { MatSelectModule } from '@angular/material/select';

@NgModule({
  imports: [
    // Other imports
    MatSelectModule
  ],
  // Other properties
})
export class AppModule { }


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a sample dictionary
        Dictionary<string, List<string>> sampleDictionary = new Dictionary<string, List<string>>
        {
            {"key1", new List<string> {"value1", "value2"}},
            {"key2", new List<string> {"value3", "value4"}},
            {"key3", new List<string> {"value5", "value6"}}
        };

        // Convert the dictionary values into a single list using the extension method
        List<string> valuesList = sampleDictionary.ValuesToList();

        // Print the list to the console
        Console.WriteLine("Values in the list:");
        foreach (string value in valuesList)
        {
            Console.WriteLine(value);
        }
    }
}

public static class DictionaryExtensions
{
    public static List<string> ValuesToList(this Dictionary<string, List<string>> dictionary)
    {
        List<string> valuesList = dictionary.Values.SelectMany(v => v).ToList();
        return valuesList;
    }
}




using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a sample dictionary
        Dictionary<string, List<string>> sampleDictionary = new Dictionary<string, List<string>>
        {
            {"key1", new List<string> {"value1", "value2"}},
            {"key2", new List<string> {"value3", "value4"}},
            {"key3", new List<string> {"value5", "value6"}}
        };

        // Convert the dictionary values into a single list
        List<string> valuesList = ConvertDictionaryValuesToList(sampleDictionary);

        // Print the list to the console
        Console.WriteLine("Values in the list:");
        foreach (string value in valuesList)
        {
            Console.WriteLine(value);
        }
    }

    public static List<string> ConvertDictionaryValuesToList(Dictionary<string, List<string>> dictionary)
    {
        List<string> valuesList = dictionary.Values.SelectMany(v => v).ToList();
        return valuesList;
    }
}






public static List<string> ConvertDictionaryValuesToList(Dictionary<string, List<string>> dictionary)
{
    List<string> valuesList = dictionary.Values.SelectMany(v => v).ToList();
    return valuesList;
}




using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a sample dictionary
        Dictionary<string, List<string>> sampleDictionary = new Dictionary<string, List<string>>
        {
            {"key1", new List<string> {"value1", "value2"}},
            {"key2", new List<string> {"value3", "value4"}},
            {"key3", new List<string> {"value5", "value6"}}
        };

        // Convert the dictionary keys into a list
        List<string> keysList = ConvertDictionaryKeysToList(sampleDictionary);

        // Print the list to the console
        Console.WriteLine("Keys in the list:");
        foreach (string key in keysList)
        {
            Console.WriteLine(key);
        }
    }

    public static List<string> ConvertDictionaryKeysToList(Dictionary<string, List<string>> dictionary)
    {
        List<string> keysList = dictionary.Keys.ToList();
        return keysList;
    }
}







using System;
using System.Collections.Generic;
using System.Linq;

public static List<string> ConvertDictionaryKeysToList(Dictionary<string, List<string>> dictionary)
{
    List<string> keysList = dictionary.Keys.ToList();
    return keysList;
}







using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
// ...

public class ReportRunControllerTests
{
    [Fact]
    public async Task GetReportQueues_ReturnsOkStatus()
    {
        // Arrange
        var mockedAuraSync = Substitute.For<IAuraSync>();
        var mockedMarsXmlService = Substitute.For<IMarsXmlService>();
        var mockedAppSettings = Substitute.For<IOptions<AppSettings>>();
        var mockedUserContext = Substitute.For<IUserContext>();

        var desiredReturnValue = new Dictionary<string, List<string>>
        {
            { "Key1", new List<string> { "Value1", "Value2" } },
            { "Key2", new List<string> { "Value3", "Value4" } }
        };

        mockedAuraSync.GwattributeValueAsync().Returns(Task.FromResult(desiredReturnValue));

        var controller = new ReportRunController(mockedMarsXmlService, mockedAppSettings, mockedUserContext, mockedAuraSync);

        // Act
        var response = await controller.GetReportQueues();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(response);
        Assert.Equal(200, okResult.StatusCode);
    }
}



var response = await controller.GetReportQueues();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(response);
        Assert.Equal(200, okResult.StatusCode);

using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
// ...

// Arrange
var mockedAuraSync = Substitute.For<IAuraSync>();

// Set up the desired return value for GwattributeValueAsync
var desiredReturnValue = new Dictionary<string, List<string>>
{
    { "Key1", new List<string> { "Value1", "Value2" } },
    { "Key2", new List<string> { "Value3", "Value4" } }
};

mockedAuraSync.GwattributeValueAsync().Returns(Task.FromResult(desiredReturnValue));

// Use mockedAuraSync as a parameter when instantiating the class containing the GetReportQueues method


api/ReportRun/GetReportQueues

using Xunit;
using NSubstitute;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;

public class WebUserContextTests
{
    [Fact]
    public void TestUserName()
    {
        // Arrange
        var userContext = Substitute.For<IUserContext>();
        userContext.UserName.Returns("test_username");

        var httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        httpContextAccessor.HttpContext.User.Identity.Name.Returns("test_username");

        // Act
        // Use the mocked userContext object in your tests
        string userName = userContext.UserName;

        // Assert
        Assert.Equal("test_username", userName);
    }

    [Fact]
    public void TestWebUserContextWithMockedAccessor()
    {
        // Arrange
        var httpContextAccessor = Substitute.For<IHttpContextAccessor>();

        var fakeIdentity = new GenericIdentity("domain\\username");
        var fakePrincipal = new GenericPrincipal(fakeIdentity, null);
        httpContextAccessor.HttpContext.User.Returns(fakePrincipal);

        var webUserContext = new WebUserContext(httpContextAccessor);

        // Act
        string userName = webUserContext.UserName;

        // Assert
        Assert.Equal("username", userName);
    }
}



using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, WebUserContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// ...

app.Run();




using System;
using Microsoft.AspNetCore.Http;

public class WebUserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WebUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserName
    {
        get
        {
            HttpContext context = _httpContextAccessor.HttpContext;
            if (context?.User?.Identity?.Name is not null and var tempName)
            {
                Console.WriteLine(tempName);
                return tempName.IndexOf("\\") > 0 ? tempName[tempName.IndexOf("\\")..] : tempName;
            }

            return string.Empty;
        }
    }
}


public interface IUserContext
{
    string UserName { get; }
}

// Add global usings at the beginning of your file, outside the namespace (if any).
global using System;
global using System.Web;

public class WebUserContext : IUserContext
{
    public HttpContext Context { get; init; }

    public string UserName
    {
        get
        {
            if (Context?.User?.Identity?.Name is not null and var tempName)
            {
                Console.WriteLine(tempName);
                return tempName.IndexOf("\\") > 0 ? tempName[tempName.IndexOf("\\")..] : tempName;
            }

            return string.Empty;
        }
    }
}





To host an Angular 14 application and a .NET 7 Web API on a Red Hat Enterprise Linux (RHEL) server using Nginx, follow these steps:

Step 1: Install .NET 7 SDK and Runtime
1. Register the Microsoft repository and install required dependencies by running the following commands:
   ```
   sudo rpm -Uvh https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm
   sudo yum update
   ```
2. Install the .NET 7 SDK and Runtime:
   ```
   sudo yum install dotnet-sdk-7.0
   sudo yum install aspnetcore-runtime-7.0
   ```

Step 2: Install Node.js and Angular CLI
1. Install Node.js from the NodeSource repository:
   ```
   curl -sL https://rpm.nodesource.com/setup_16.x | sudo bash -
   sudo yum install nodejs
   ```
2. Install Angular CLI globally:
   ```
   sudo npm install -g @angular/cli
   ```

Step 3: Publish Angular 14 and .NET 7 Web API projects
1. Publish your Angular 14 application:
   - Open the terminal and navigate to the Angular project directory.
   - Run `ng build --prod` to create a production build in the "dist" folder.
2. Publish your .NET 7 Web API application:
   - Open the terminal and navigate to the Web API project directory.
   - Run `dotnet publish --configuration Release --output ./publish` to create a release build in the "publish" folder.

Step 4: Install and configure Nginx
1. Install Nginx:
   ```
   sudo yum install epel-release
   sudo yum install nginx
   ```
2. Create a new Nginx configuration file for your application, e.g., `/etc/nginx/conf.d/yourapp.conf` and add the following configuration:
   ```
   server {
       listen 80;
       server_name yourdomain.com;
   
       location / {
           root /path/to/angular/dist/folder;
           try_files $uri $uri/ /index.html;
       }
   
       location /api {
           proxy_pass http://localhost:5000;
           proxy_http_version 1.1;
           proxy_set_header Upgrade $http_upgrade;
           proxy_set_header Connection keep-alive;
           proxy_set_header Host $host;
           proxy_cache_bypass $http_upgrade;
       }
   }
   ```
   Replace "yourdomain.com" with your domain and update the paths to the Angular "dist" folder and Web API "publish" folder accordingly.

3. Remove the default Nginx configuration:
   ```
   sudo rm /etc/nginx/conf.d/default.conf
   ```
4. Test the Nginx configuration and restart the service:
   ```
   sudo nginx -t
   sudo systemctl restart nginx
   ```

Step 5: Configure the .NET 7 Web API to run as a service
1. Create a new service file `/etc/systemd/system/yourapp.service` with the following content:
   ```
   [Unit]
   Description=.NET 7 Web API App
   After=network.target

   [Service]
   WorkingDirectory=/path/to/webapi/publish/folder
   ExecStart=/usr/bin/dotnet /path/to/webapi/publish/folder/YourWebAPI.dll
   Restart=always
   RestartSec=10
   SyslogIdentifier=dotnet-yourapp
   User=www-data
   Environment=ASPNETCORE_ENVIRONMENT=Production
   Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

   [Install]
   WantedBy=multi-user.target
   ```
   Update the paths to the Web

API "publish" folder accordingly and replace "YourWebAPI.dll" with your Web API DLL file name.

Step 6: Start and enable the .NET 7 Web API service
1. Reload the systemd daemon to recognize the new service file:
   ```
   sudo systemctl daemon-reload
   ```
2. Start and enable the .NET 7 Web API service to run on startup:
   ```
   sudo systemctl start yourapp.service
   sudo systemctl enable yourapp.service
   ```

Step 7: Configure the firewall
1. If you have a firewall enabled on your RHEL server, you will need to open the required ports for Nginx:
   ```
   sudo firewall-cmd --permanent --zone=public --add-service=http
   sudo firewall-cmd --permanent --zone=public --add-service=https
   sudo firewall-cmd --reload
   ```

Step 8: Configure Angular to use the Web API
1. Update the "environment.prod.ts" file in your Angular project to point to the Web API's URL (e.g., "http://yourdomain.com/api").
2. Rebuild the Angular application using `ng build --prod` and copy the updated "dist" folder to the configured Nginx root directory.

Your Angular 14 application and .NET 7 Web API should now be hosted on a RHEL server using Nginx. Test your application by navigating to your website's URL. If you encounter any issues, check the Nginx error logs in `/var/log/nginx/` and the .NET Web API logs using `journalctl -u yourapp.service`.






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
