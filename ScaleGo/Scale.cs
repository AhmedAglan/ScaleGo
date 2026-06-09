using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Reflection;

namespace ScaleGo
{
  public class Scale
  {
    SerialPort mySerialPort;
    public void OpenPort(string PortID)
    {
      try
      {
        string PortName = "";
        if (PortID != "")
        {
          PortName="COM" + PortID;
        }
        else
        {
          PortName = ConfigLoader.Config.PortName;
        }
          mySerialPort = new SerialPort(PortName)
          {
            BaudRate = ConfigLoader.Config.BaudRate,
            Parity = ConfigLoader.Config.Parity,
            StopBits = ConfigLoader.Config.StopBits,
            DataBits = ConfigLoader.Config.DataBits,
            Handshake = ConfigLoader.Config.Handshake
          };

        mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        mySerialPort.Open();
        IsPortOpened = true;
      }
      catch (Exception ex)
      {
        IsPortOpened = false;
      }

    }
    public void ClosePort()
    {
      try
      {
        if (mySerialPort != null && mySerialPort.IsOpen)
        {
          mySerialPort.Close();
          IsPortOpened = false;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {

        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();

        if (indata==LastMessage )
        {
          return;
        }
        LastMessage = indata;

        string b = string.Empty;

        for (int i = 0; i < indata.Length; i++)
        {
          if (Char.IsDigit(indata[i]) || indata[i].ToString() == ".")
            b += indata[i];
        }

        HasWeight = double.TryParse(b, out double n);
        Weight = n;

      }
      catch (Exception)
      {

        throw;
      }

    }
    public double Weight { get; set; }
    public bool HasWeight { get; set; }
    public bool IsPortOpened { get; set; }
    public string LastMessage { get; set; }
  }
}
