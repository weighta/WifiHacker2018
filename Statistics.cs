// Decompiled with JetBrains decompiler
// Type: WifiHacker.Statistics
// Assembly: WifiHacker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 20B0797F-6870-4120-A735-0CC261EC7D03
// Assembly location: C:\Users\ROXTerm\Desktop\LoggedNetworks\WifiHacker.exe

namespace WifiHacker
{
  internal class Statistics
  {
    public static double Slope(int x1, int x2, int y1, int y2) => (double) (y2 - y1) / (double) (x2 - x1);
  }
}
