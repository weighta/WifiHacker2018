// Decompiled with JetBrains decompiler
// Type: WifiHacker.Program
// Assembly: WifiHacker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 20B0797F-6870-4120-A735-0CC261EC7D03
// Assembly location: C:\Users\ROXTerm\Desktop\LoggedNetworks\WifiHacker.exe

using System;
using System.Windows.Forms;

namespace WifiHacker
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
