// Decompiled with JetBrains decompiler
// Type: WifiHacker.Stats
// Assembly: WifiHacker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 20B0797F-6870-4120-A735-0CC261EC7D03
// Assembly location: C:\Users\ROXTerm\Desktop\LoggedNetworks\WifiHacker.exe

using System.Collections.Generic;

namespace WifiHacker
{
  internal struct Stats
  {
    public double newpercent;
    public int ms1;
    public int newssids1;
    public int pings;
    public int pings1;
    public int failedclients;
    public int failedstreak;
    public int beststreak;
    public int pbeststreak;
    public int derivativeInterval;
    public int[] minArray;
    public int packetSize;
    public bool openStats;
    public int numSSIDSWritten;
    public List<string> sectionNames;
  }
}
