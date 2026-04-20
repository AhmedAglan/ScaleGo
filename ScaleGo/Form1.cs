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
      txtAWB.Text = "EDC03080196EG";
#endif

      string msg;

      if (txtAWB.Text.Trim().Length < 3)
      {
        msg = "Please enter a valid AWB number";
        lblMsg.Text = msg;
        txtAWB.SelectAll();
        txtAWB.Focus();
        return;
      }

      if (string.IsNullOrWhiteSpace(txtWeight.Text))
      {
        msg = "No weight data available to update";
        lblMsg.Text = msg;
        return;
      }

      decimal wght;
      if (!decimal.TryParse(txtWeight.Text.Trim(), out wght))
      {
        msg = "Invalid weight value";
        lblMsg.Text = msg;
        return;
      }

      if (wght <= 0)
      {
        msg = "Weight must be greater than zero";
        lblMsg.Text = msg;
        return;
      }

      btnUpdateWeight.Enabled = false;

      try
      {
        lblMsg.Text = "جاري تحديث الوزن...";

        string awb = txtAWB.Text.Trim();
        string apiResult = await CallUpdateShipmentWeightApi(awb, wght);

        lblMsg.Text = apiResult;

        txtAWB.Text = "";
        txtAWB.Focus();
        txtAWB.SelectAll();
      }
      catch (Exception ex)
      {
        lblMsg.Text = "Error: " + ex.Message;
      }
      finally
      {
        btnUpdateWeight.Enabled = true;
      }
    }


    private void Form1_Load(object sender, EventArgs e)
    {
      if (!UserSession.IsLoggedIn)
      {
        MessageBox.Show("يجب تسجيل الدخول أولاً");
        Close();
        return;
      }

      lblMsg.Text = "مرحبًا " + UserSession.DisplayName;
    }
  }

}
