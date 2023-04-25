
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
