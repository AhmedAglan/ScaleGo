using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleGo
{
  public partial class Form1 : Form
  {
    Scale scale = new Scale();
    public Form1()
    {
      InitializeComponent();
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

    private void btnUpdateWeight_Click(object sender, EventArgs e)
    {
      //test
      string msg;
      if(txtAWB.Text.Length<3)
      {
        msg="Please enter a valid AWB number";
        lblMsg.Text = msg;
        txtAWB.SelectAll();
        txtAWB.Focus();
        return;
      }

      if (!string.IsNullOrEmpty(txtWeight.Text))
      {
        try
        {
          var wght = Convert.ToDecimal(txtWeight.Text);
          msg=$"Shipment number: {txtAWB.Text} , Weight: {wght}";
          lblMsg.Text = msg;
          txtAWB.Text = "";
          txtAWB.Focus();
        }
        catch (Exception)
        {
        }
      }
      else
      {
        msg="No weight data available to update";
        lblMsg.Text = msg;
      }
    }
  }
}
