using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleGo
{
  public static class UserSession
  {
    public static string AccessToken { get; set; }
    public static string UserName { get; set; }
    public static string DisplayName { get; set; }
    public static string LogoUrl { get; set; }

    public static bool IsLoggedIn
    {
      get { return !string.IsNullOrWhiteSpace(AccessToken); }
    }

    public static void Clear()
    {
      AccessToken = null;
      UserName = null;
      DisplayName = null;
      LogoUrl = null;
    }
  }
}
