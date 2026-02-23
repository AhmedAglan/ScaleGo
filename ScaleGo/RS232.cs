using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace ScaleGo
{
 public  class RS232
  {
    public string PortName { get; set; }
    public int BaudRate { get; set; }
    public Parity Parity { get; set; }
    public StopBits StopBits { get; set; }
    public int DataBits { get; set; }
    public Handshake Handshake { get; set; }
  }
}
