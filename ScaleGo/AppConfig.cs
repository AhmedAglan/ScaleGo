using Newtonsoft.Json;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace ScaleGo
{
  public class AppConfig
  {
    public string PortName { get; set; }
    public int BaudRate { get; set; }
    public Parity Parity { get; set; }
    public StopBits StopBits { get; set; }
    public int DataBits { get; set; }
    public Handshake Handshake { get; set; }

    public ApiSettings apiSettings { get; set; }

    public class ApiSettings
    {
      public string BaseUrl { get; set; }
      public string UpdateWeightEndpoint { get; set; }
      public string LoginEndpoint { get; set; }
      public string CompanyID { get; set; }
      public string Language { get; set; }
    }
  }

  public static class ConfigLoader
  {
    private static AppConfig _config;

    public static AppConfig Config
    {
      get
      {
        if (_config == null)
        {
          var path = Path.Combine(Application.StartupPath, "ScaleInfo.json");
          var json = File.ReadAllText(path); _config = JsonConvert.DeserializeObject<AppConfig>(json);
        }

        return _config;
      }
    }
  }
}