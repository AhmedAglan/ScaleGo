using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ScaleGo.AppConfig;

namespace ScaleGo
{
  public partial class Form1 : Form
  {

    private static readonly HttpClient _httpClient = new HttpClient();

    private static string ApiUrl => 
      ConfigLoader.Config.apiSettings.BaseUrl +
      ConfigLoader.Config.apiSettings.UpdateWeightEndpoint;
    private string CompanyID =>
      ConfigLoader.Config.apiSettings.CompanyID;

    private string Language =>
      ConfigLoader.Config.apiSettings.Language;
    public class UpdateShipmentWeightRequest
    {
      public string awb { get; set; }
      public decimal weight { get; set; }
    }

    public class GeneralResponse
    {
      public bool Success { get; set; }
      public string Message { get; set; }
      public object Data { get; set; }
    }

    private void ApplyMainStyle()
    {
      BackColor = AppTheme.BackColor;
      Font = AppTheme.DefaultFont;
      ForeColor = AppTheme.Text;
      Text = "ScaleGo v1.1";

      AppTheme.BuildHeader(this, "ScaleGo v1.1");

      label1.Text = "AWB";
      label1.Font = AppTheme.DefaultFont;
      label1.ForeColor = AppTheme.Text;

      AppTheme.StyleTextBox(txtAWB);
      AppTheme.StyleTextBox(txtWeight, true);

      txtWeight.Font = AppTheme.WeightFont;
      txtWeight.TextAlign = HorizontalAlignment.Center;

      AppTheme.StyleSecondaryButton(btnConnectScale);
      AppTheme.StylePrimaryButton(btnUpdateWeight);

      btnConnectScale.Size = new Size(150, 40);
      btnUpdateWeight.Size = new Size(260, 44);

      btnConnectScale.Location = new Point(40, 90);
      txtWeight.Location = new Point(210, 92);
      txtWeight.Size = new Size(170, 40);

      label1.Location = new Point(40, 155);
      txtAWB.Location = new Point(210, 150);
      txtAWB.Size = new Size(260, 32);

      btnUpdateWeight.Location = new Point(40, 205);

      lblMsg.Location = new Point(500, 90);
      lblMsg.Size = new Size(250, 160);
      lblMsg.TextAlign = ContentAlignment.MiddleCenter;
      lblMsg.Font = AppTheme.DefaultFont;
      lblMsg.ForeColor = AppTheme.MutedText;

      ClientSize = new Size(800, 330);
    }
    private async Task<string> CallUpdateShipmentWeightApi(string awb, decimal weight)
    {
      var requestObj = new UpdateShipmentWeightRequest
      {
        awb = awb,
        weight = weight
      };

      var json = JsonConvert.SerializeObject(requestObj);

      using (var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl))
      {
        request.Headers.Accept.Clear();
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        request.Headers.Add("CompanyID", CompanyID);
        request.Headers.Add("AccessToken", UserSession.AccessToken);
        request.Headers.Add("Language", Language);
        request.Headers.Add("SectionID", "-3");
        request.Headers.Add("DeviceID", "ScaleGo");

        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        using (var response = await _httpClient.SendAsync(request))
        {
          var responseContent = await response.Content.ReadAsStringAsync();

          if (string.IsNullOrWhiteSpace(responseContent))
          {
            if (response.IsSuccessStatusCode)
              return "تم تحديث الوزن بنجاح";

            return "API Error: HTTP " + (int)response.StatusCode;
          }

          try
          {
            var result = JsonConvert.DeserializeObject<GeneralResponse>(responseContent);

            if (result != null && !string.IsNullOrWhiteSpace(result.Message))
              return result.Message;
          }
          catch
          {
          }

          if (response.IsSuccessStatusCode)
            return responseContent;

          return string.Format(
            "API Error: HTTP {0}{1}{2}",
            (int)response.StatusCode,
            Environment.NewLine,
            responseContent);
        }
      }
    }

    Scale scale = new Scale();
    public Form1()
    {
      InitializeComponent();
      System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
      DoubleBuffered = true;
    }

    private void btnConnectScale_Click(object sender, EventArgs e)
    {
      try
      {
        if (!tmrGetWeight.Enabled)
        {
          scale = new Scale();

          if (!scale.IsPortOpened)
          {
            scale.OpenPort();
          }

          tmrGetWeight.Enabled = true;
          txtAWB.Focus();
          btnConnectScale.Text = "Disconnect Scale";
        }
        else
        {
          tmrGetWeight.Enabled = false;
          if (scale != null && scale.IsPortOpened)
          {
            scale.ClosePort();
          }
          btnConnectScale.Text = "Connect Scale";
        }

      }
      catch (Exception)
      {

        throw;
      }

    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        tmrGetWeight.Enabled = false;

        if (scale != null && scale.IsPortOpened)
        {
          scale.ClosePort();
        }
      }
      catch (Exception)
      {


      }
    }

    private void tmrGetWeight_Tick(object sender, EventArgs e)
    {
      try
      {
        if (scale.IsPortOpened && scale.HasWeight)
        {
          var wght = scale.Weight;
          txtWeight.Text = wght.ToString();

          txtWeight.BackColor = Color.FromArgb(220, 252, 231);

          var flashTimer = new Timer();
          flashTimer.Interval = 250;
          flashTimer.Tick += (s, ev) =>
          {
            txtWeight.BackColor = AppTheme.ReadOnlyBack;
            flashTimer.Stop();
            flashTimer.Dispose();
          };
          flashTimer.Start();

        }
      }
      catch (Exception)
      {


      }
    }

    private async void btnUpdateWeight_Click(object sender, EventArgs e)
    {
#if DEBUG
      txtWeight.Text = "0.620";
      txtAWB.Text = "EDC00935147EG";
#endif

      string msg;

      if (txtAWB.Text.Trim().Length < 3)
      {
        msg = "Please enter a valid AWB number";
        AppTheme.ShowStatus(lblMsg, msg, isError: true);
        txtAWB.SelectAll();
        txtAWB.Focus();
        return;
      }

      if (string.IsNullOrWhiteSpace(txtWeight.Text))
      {
        msg = "No weight data available to update";
        AppTheme.ShowStatus(lblMsg, msg, isError: true);
        return;
      }

      decimal wght;
      if (!decimal.TryParse(txtWeight.Text.Trim(), out wght))
      {
        msg = "Invalid weight value";
        AppTheme.ShowStatus(lblMsg, msg, isError: true);
        return;
      }

      if (wght <= 0)
      {
        msg = "Weight must be greater than zero";
        AppTheme.ShowStatus(lblMsg, msg, isError: true);
        return;
      }

      btnUpdateWeight.Enabled = false;

      try
      {
        AppTheme.ShowStatus(lblMsg, "جاري تحديث الوزن...");

        string awb = txtAWB.Text.Trim();
        string apiResult = await CallUpdateShipmentWeightApi(awb, wght);

        AppTheme.ShowStatus(lblMsg, apiResult, isSuccess: true);

        txtAWB.Text = "";
        txtAWB.Focus();
        txtAWB.SelectAll();
      }
      catch (Exception ex)
      {
        AppTheme.ShowStatus(lblMsg, "Error: " + ex.Message, isError: true);
      }
      finally
      {
        btnUpdateWeight.Enabled = true;
      }
    }


    private void Form1_Load(object sender, EventArgs e)
    {
      ApplyMainStyle();

      if (!UserSession.IsLoggedIn)
      {
        MessageBox.Show("يجب تسجيل الدخول أولاً");
        Close();
        return;
      }

      AppTheme.ShowStatus(lblMsg, "مرحبًا " + UserSession.DisplayName, isSuccess: true);
    }

  }

}
