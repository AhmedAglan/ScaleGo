using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleGo
{
  public partial class LoginForm : Form
  {
    private static readonly HttpClient _httpClient = new HttpClient();

    private string LoginApiUrl =>
      ConfigLoader.Config.apiSettings.BaseUrl +
      ConfigLoader.Config.apiSettings.LoginEndpoint;

    private string CompanyID =>
      ConfigLoader.Config.apiSettings.CompanyID;

    private string Language =>
      ConfigLoader.Config.apiSettings.Language;
    public LoginForm()
    {
      InitializeComponent();
      System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
    }

    public class LoginRequest
    {
      public string userName { get; set; }
      public string password { get; set; }
    }

    public class LoginResponse
    {
      public bool success { get; set; }
      public int id { get; set; }
      public string message { get; set; }
      public LoginData data { get; set; }
    }

    public class LoginData
    {
      public LoginUserSession userSession { get; set; }
    }

    public class LoginUserSession
    {
      public string accessToken { get; set; }
      public string username { get; set; }
      public string logoUrl { get; set; }
      public string displayName { get; set; }
    }

    private async Task<LoginResponse> CallLoginApi(string userName, string password)
    {
      var requestObj = new LoginRequest
      {
        userName = userName,
        password = password
      };

      var json = JsonConvert.SerializeObject(requestObj);

      using (var request = new HttpRequestMessage(HttpMethod.Post, LoginApiUrl))
      {
        request.Headers.Accept.Clear();
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        request.Headers.Add("CompanyID", CompanyID);
        request.Headers.Add("Language", Language);

        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        using (var response = await _httpClient.SendAsync(request))
        {
          var responseContent = await response.Content.ReadAsStringAsync();

          if (string.IsNullOrWhiteSpace(responseContent))
            throw new Exception("Empty response from server");

          var result = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

          if (result == null)
            throw new Exception("Invalid response from server");

          return result;
        }
      }
    }


    private async void btnLogin_Click(object sender, EventArgs e)
    {
      string userName = txtUserName.Text.Trim();
      string password = txtPassword.Text;

      if (string.IsNullOrWhiteSpace(userName))
      {
        lblMsg.Text = "من فضلك أدخل اسم المستخدم";
        txtUserName.Focus();
        return;
      }

      if (string.IsNullOrWhiteSpace(password))
      {
        lblMsg.Text = "من فضلك أدخل كلمة المرور";
        txtPassword.Focus();
        return;
      }

      btnLogin.Enabled = false;

      try
      {
        lblMsg.Text = "جاري تسجيل الدخول...";

        var result = await CallLoginApi(userName, password);

        if (result.success && result.data != null && result.data.userSession != null)
        {
          UserSession.AccessToken = result.data.userSession.accessToken;
          UserSession.UserName = result.data.userSession.username;
          UserSession.DisplayName = result.data.userSession.displayName;
          UserSession.LogoUrl = result.data.userSession.logoUrl;

          lblMsg.Text = "تم تسجيل الدخول بنجاح";

          this.DialogResult = DialogResult.OK;
          this.Close();
        }
        else
        {
          lblMsg.Text = string.IsNullOrWhiteSpace(result.message)
            ? "اسم المستخدم أو كلمة المرور غير صحيح"
            : result.message;
        }
      }
      catch (Exception ex)
      {
        lblMsg.Text = "Error: " + ex.Message;
      }
      finally
      {
        btnLogin.Enabled = true;
      }
    }
  }
}