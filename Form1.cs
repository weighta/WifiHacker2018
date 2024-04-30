// Decompiled with JetBrains decompiler
// Type: WifiHacker.Form1
// Assembly: WifiHacker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 20B0797F-6870-4120-A735-0CC261EC7D03
// Assembly location: C:\Users\ROXTerm\Desktop\LoggedNetworks\WifiHacker.exe

using NativeWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WifiHacker
{
  public class Form1 : Form
  {
    private Random ran = new Random();
    private Algorithm rda = new Algorithm();
    private DateTime date = DateTime.Now;
    private Stats ls;
    private DirectoryInfo dirname = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
    private SpeechSynthesizer synth = new SpeechSynthesizer();
    private int newssids;
    private string fileName = "WiFiBingo.WFB";
    private string saveSSIDName = "DumpedSSIDS";
    private byte[] savedata;
    private byte[] sectionData = new byte[0];
    private int pingtime;
    private Color listviewcolor = Color.Black;
    private byte[] header;
    private string headerTitle = "WFB";
    private int prevCollections;
    private int totalCollections;
    private int numberOfSections;
    private int sectionssids;
    private int collectionsRecord;
    private string sectionCreationDate;
    private int[] sectionDateChecksums;
    private int ssidUsedIndex;
    private List<string> wifis = new List<string>();
    private List<string> ssids = new List<string>();
    private List<string> used = new List<string>();
    private string savedir;
    private int sub;
    private int ms;
    private int failed;
    private int savefailures;
    private int d;
    private int derivative;
    private float integral;
    private bool speak;
    private bool thread = true;
    private Color meter = Color.Green;
    private IContainer components;
    private ListView listView1;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private System.Windows.Forms.Timer timer1;
    private ColumnHeader columnHeader4;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private Label label2;
    private Label label3;
    private TextBox textBox1;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private Label label1;
    private PictureBox pictureBox1;
    private Button button1;
    private TreeView treeView1;
    private Label label5;
    private Label label6;
    private Label label7;
    private CheckBox checkBox3;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label14;
    private CheckBox checkBox4;
    private Label label15;
    private Chart chart1;
    private Label label16;
    private Panel panel1;
    private System.Windows.Forms.Timer timer2;
    private Button button3;
    private System.Windows.Forms.Timer timer3;
    private CheckBox checkBox5;
    private CheckBox checkBox6;
    private Chart chart2;
    private Chart chart3;
    private Label label4;
    private CheckBox checkBox7;
    private System.Windows.Forms.Timer timer4;
    private CheckBox checkBox8;

    public Form1()
    {
      InitializeComponent();
      ls.derivativeInterval = 2;
      ls.ms1 = 0;
      ls.pings1 = 0;
      ls.minArray = new int[12];
      ls.openStats = false;
      ls.numSSIDSWritten = 0;
      ls.sectionNames = new List<string>();
    }

    private string GetStringForSSID(Wlan.Dot11Ssid ssid) => Encoding.ASCII.GetString(ssid.SSID, 0, (int) ssid.SSIDLength);

    private void wifilister()
    {
      WlanClient wlanClient = new WlanClient();
      ++ls.pings;
      while (true)
      {
        date = DateTime.Now;
        d = 0;
        try
        {
          wlanClient = new WlanClient();
          ls.failedstreak = 0;
          ls.pbeststreak = 0;
        }
        catch
        {
          ++ls.failedclients;
          ++ls.failedstreak;
          ++ls.beststreak;
          ++ls.pbeststreak;
          if (ls.pbeststreak > ls.beststreak)
            ls.beststreak = ls.pbeststreak;
          Invoke(new Action(() => label8.Text = "Total Errors: " + ls.failedclients));
          Invoke(new Action(() => label9.Text = "Current Errors: " + ls.failedstreak));
          Invoke(new Action(() => label10.Text = "Best Recovery: " + ls.beststreak));
        }
        foreach (WlanClient.WlanInterface wlanInterface in wlanClient.Interfaces)
        {
          try
          {
            ls.packetSize = 0;
            foreach (Wlan.WlanAvailableNetwork availableNetwork in wlanInterface.GetAvailableNetworkList((Wlan.WlanGetAvailableNetworkFlags) 0))
            {
              string stringForSsid = GetStringForSSID(availableNetwork.dot11Ssid);
              if (!wifis.Contains(stringForSsid))
              {
                ++d;
                ListViewItem item = new ListViewItem(stringForSsid);
                wifis.Add(stringForSsid);
                item.SubItems.Add(availableNetwork.dot11DefaultCipherAlgorithm.ToString());
                wifis.Add(availableNetwork.dot11DefaultCipherAlgorithm.ToString());
                item.SubItems.Add(((object) availableNetwork.dot11DefaultAuthAlgorithm).ToString() + "%");
                wifis.Add(((object) availableNetwork.dot11DefaultAuthAlgorithm).ToString() + "%");
                item.SubItems.Add(availableNetwork.numberOfBssids.ToString());
                List<string> wifis1 = wifis;
                uint num1 = availableNetwork.numberOfBssids;
                string str1 = num1.ToString();
                wifis1.Add(str1);
                ListViewItem.ListViewSubItemCollection subItems = item.SubItems;
                num1 = availableNetwork.wlanSignalQuality;
                string text = num1.ToString() + "%";
                subItems.Add(text);
                List<string> wifis2 = wifis;
                num1 = availableNetwork.wlanSignalQuality;
                string str2 = num1.ToString();
                wifis2.Add(str2);
                item.SubItems.Add(DateTime.Now.ToString("T"));
                wifis.Add(DateTime.Now.ToString("T"));
                Invoke(new Action(() => listView1.Items.Add(item)));
                speak = true;
                int num2 = (int) ((double) (wifis.Count / 6) * 3.59999990463257);
                meter = getColor(num2);
                progresscircle(num2, meter);
                if (checkBox2.Checked)
                {
                  if (speak)
                    synth.Speak(wifis[wifis.Count - 6]);
                  speak = false;
                }
                ++ls.packetSize;
              }
            }
            perMinute(ls.packetSize);
          }
          catch
          {
            Invoke(new Action(() => textBox1.Text = "WiFi Scanner is Disabled"));
          }
        }
        ms = wifis.Count<string>() / 6;
        if (checkBox1.Checked)
        {
          sectionDataCreator();
          savesave();
        }
        if (checkBox3.Checked)
        {
          ls.newpercent = Math.Round((double) newssids / (double) ms * 100.0);
          integral += (float) ms;
          Invoke(new Action(() => label2.Text = "Networks: " + (object) ms));
          Invoke(new Action(() => chart1.Series["DiscoveredWiFis"].Points.AddXY((object) "", (object) ms)));
          Invoke(new Action(() => chart1.Series["NewWiFis"].Points.AddXY((object) "", (object) newssids)));
          plotDerivative();
          Invoke(new Action(() => chart3.Series["Series1"].Points.Clear()));
          Invoke(new Action(() => chart3.Series["Series1"].Points.AddXY((object) "", (object) ls.newpercent)));
          Invoke(new Action(() => chart3.Series["Series1"].Points.AddXY((object) "", (object) (100.0 - ls.newpercent))));
          Invoke(new Action(() => label1.Text = "Total WiFi's Collected: " + (object) totalCollections));
          Invoke(new Action(() => label5.Text = "New WiFis: " + (object) newssids));
          Invoke(new Action(() => label7.Text = "# Pings: " + (object) ls.pings));
          Invoke(new Action(() => label13.Text = "Integral: " + (object) integral));
          Invoke(new Action(() => label14.Text = "Null Ratio: " + (object) (100.0 - ls.newpercent) + "%"));
          Invoke(new Action(() => label15.Text = "New Ratio: " + (object) ls.newpercent + "%"));
          if (d > derivative)
            derivative = d;
          Invoke(new Action(() => label11.Text = "Derivative: " + (object) derivative));
        }
        if (checkBox4.Checked)
          listBoxOverload();
        savesave();
        Thread.Sleep(5000);
        ++ls.pings;
        pingtime = 5;
      }
    }

    private void loadsave()
    {
      string creationDate = "";
      string username = "";
      ls.pings = 0;
      ls.failedclients = 0;
      ls.failedstreak = 0;
      ls.beststreak = 0;
      ls.pbeststreak = 0;
      savedir = "SavedNetworks";
      if (!Directory.Exists(savedir))
        Directory.CreateDirectory(savedir);
      if (File.Exists(savedir + "\\" + fileName))
      {
        try
        {
          savedata = File.ReadAllBytes(savedir + "\\" + fileName);
          if (Convert.ToChar(savedata[0]).ToString() + Convert.ToChar(savedata[1]).ToString() + Convert.ToChar(savedata[2]).ToString() == "WFB")
          {
            for (int index = 4; index < 14; ++index)
              creationDate += ((char) savedata[index]).ToString();
            for (int index = 32; index < 64; ++index)
            {
              if (savedata[index] >= (byte) 32)
                username += ((char) savedata[index]).ToString();
            }
            prevCollections |= (int) savedata[14] << 8;
            prevCollections |= (int) savedata[15];
            for (int index = 16; index < 20; ++index)
              totalCollections |= (int) savedata[index] << 24 - index % 16 * 8;
            numberOfSections |= (int) savedata[20] << 8;
            numberOfSections |= (int) savedata[21];
            sectionDateChecksums = new int[numberOfSections];
            collectionsRecord |= (int) savedata[22] << 8;
            collectionsRecord |= (int) savedata[23];
            for (int index = 64; index < 64 + numberOfSections * 16; index += 16)
              sectionDateChecksums[(index - 64) / 16] = (int) savedata[index] << 24 | (int) savedata[index + 1] << 16 | (int) savedata[index + 2] << 8 | (int) savedata[index + 3];
            date = DateTime.Now;
            if (!((IEnumerable<int>) sectionDateChecksums).Contains<int>(Convert.ToInt32(date.ToString("MM")) << 24 | Convert.ToInt32(date.ToString("dd")) << 16 | Convert.ToInt32(date.ToString("yyyy"))))
            {
              savedata = sectioncreator(savedata);
              Invoke(new Action(() => label16.Text = "New section created"));
            }
            for (int index1 = numberOfSections * 16 + 64; index1 < savedata.Length; index1 += 64)
            {
              string str = "";
              for (int index2 = index1; index2 < index1 + 32; ++index2)
              {
                if (savedata[index2] >= (byte) 32)
                  str += ((char) savedata[index2]).ToString();
              }
              ssids.Add(str);
            }
            sectionssids += (int) savedata[(numberOfSections - 1) * 16 + 72] << 8 | (int) savedata[(numberOfSections - 1) * 16 + 73];
          }
          else
            createsavefile();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Error reading save file. The file is currently being used or is corrupted." + Environment.NewLine + Environment.NewLine + (object) ex);
          Close();
        }
      }
      else
        createsavefile();
      savesave();
      Invoke(new Action(() => Text = "WiFi Bingo: User: " + username + ", Created " + creationDate));
      Invoke(new Action(() => label6.Text = "# Previous Logged: " + (object) prevCollections));
      Invoke(new Action(() => label1.Text = "Total WiFi's Collected: " + (object) totalCollections));
    }

    private void savesave()
    {
      savedata[14] = (byte) (wifis.Count<string>() / 6 >> 8);
      savedata[15] = (byte) (wifis.Count<string>() / 6);
      for (int index = 16; index < 20; ++index)
        savedata[index] = (byte) (totalCollections >> 24 - index % 16 * 8);
      savedata[20] = (byte) (numberOfSections >> 8);
      savedata[21] = (byte) numberOfSections;
      savedata[(numberOfSections - 1) * 16 + 72] = (byte) (sectionssids >> 8);
      savedata[(numberOfSections - 1) * 16 + 73] = (byte) sectionssids;
      savedata[22] = (byte) (collectionsRecord >> 8);
      savedata[23] = (byte) collectionsRecord;
      byte[] bytes = new byte[savedata.Length + sectionData.Length];
      savedata.CopyTo((Array) bytes, 0);
      sectionData.CopyTo((Array) bytes, savedata.Length);
      savedata = bytes;
      try
      {
        File.WriteAllBytes(savedir + "\\" + fileName, bytes);
      }
      catch
      {
        ++savefailures;
        Invoke(new Action(() => label12.Text = "Save Failures: " + (object) savefailures));
      }
      sectionData = new byte[0];
    }

    private void progresscircle(int deg, Color stick)
    {
      int num1 = 90;
      float num2 = (float) Math.PI / 180f * (float) deg;
      float num3 = (float) Math.PI / 180f * (float) (deg - 2);
      int num4 = 120;
      int num5 = 78;
      Point hypoldendingpoint = new Point();
      Point hypnewendingpoint = new Point();
      hypoldendingpoint = new Point((int) ((double) num4 + Math.Cos((double) num3) * (double) num5), num4 - (int) (Math.Sin((double) num3) * (double) num5));
      hypnewendingpoint = new Point((int) ((double) num4 + Math.Cos((double) num2) * (double) num5), num4 - (int) (Math.Sin((double) num2) * (double) num5));
      Point deletehypotenusestart = new Point(num4, num4);
      Invoke(new Action(() => pictureBox1.CreateGraphics().DrawLine(new Pen(stick, 3f), deletehypotenusestart, hypoldendingpoint)));
      Point hypotenusestart = new Point(num4, num4);
      Invoke(new Action(() => pictureBox1.CreateGraphics().DrawLine(new Pen(stick, 3f), deletehypotenusestart, hypoldendingpoint)));
      Invoke(new Action(() => pictureBox1.CreateGraphics().DrawLine(new Pen(stick, 3f), hypotenusestart, hypnewendingpoint)));
      Point x = new Point(0, num4);
      Point x2 = new Point(num4 * 2, num4);
      Invoke(new Action(() => pictureBox1.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2f), x, x2)));
      Point y = new Point(num4, 0);
      Point y2 = new Point(num4, num4 * 2);
      Invoke(new Action(() => pictureBox1.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2f), y, y2)));
      Point oldarc = new Point();
      Point newarc = new Point();
      oldarc = new Point((int) ((double) num4 + Math.Cos((double) num3) * (double) num1), num4 - (int) (Math.Sin((double) num3) * (double) num1));
      newarc = new Point((int) ((double) num4 + Math.Cos((double) num2) * (double) num1), num4 - (int) (Math.Sin((double) num2) * (double) num1));
      Invoke(new Action(() => pictureBox1.CreateGraphics().DrawLine(new Pen(Brushes.Gold, 4f), oldarc, newarc)));
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listView1.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = listView1.SelectedIndices[0];
      if (selectedIndex < 0)
        return;
      textBox1.Text = listView1.Items[selectedIndex].Text;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      loadsave();
      thread = false;
      chart1.ChartAreas["WiFis"].AxisX.MajorGrid.LineColor = Color.White;
      new Thread(new ThreadStart(wifilister)).Start();
    }

    private void button1_Click_3(object sender, EventArgs e)
    {
      if (!ls.openStats)
      {
        ls.sectionNames.Clear();
        moverankpanel(!ls.openStats);
        string[] strArray = new string[12]
        {
          "Jan",
          "Feb",
          "Mar",
          "Apr",
          "May",
          "June",
          "July",
          "Aug",
          "Sept",
          "Oct",
          "Nov",
          "Dec"
        };
        for (int index1 = 0; index1 < numberOfSections; ++index1)
        {
          string str = "";
          for (int index2 = index1 * 16 + 74; index2 < index1 * 16 + 80; ++index2)
          {
            if (savedata[index2] >= (byte) 32)
              str += ((char) savedata[index2]).ToString();
          }
          ls.sectionNames.Add(strArray[(int) savedata[index1 * 16 + 64] - 1] + " " + (object) savedata[index1 * 16 + 65] + ", " + (object) ((int) savedata[index1 * 16 + 66] << 8 | (int) savedata[index1 * 16 + 67]) + "(" + str + ")");
          ++ssidUsedIndex;
        }
        for (int index = 0; index < ls.sectionNames.Count; ++index)
          treeView1.Nodes.Add(ls.sectionNames[index]);
        checkBox7.Visible = !ls.openStats;
        checkBox8.Visible = !ls.openStats;
        ls.openStats = true;
        button1.Text = "Close Collections";
      }
      else
      {
        treeView1.Nodes.Clear();
        moverankpanel(!ls.openStats);
        used.Clear();
        ssidUsedIndex = 0;
        checkBox7.Visible = !ls.openStats;
        checkBox8.Visible = !ls.openStats;
        ls.openStats = false;
        button1.Text = "Load Collections";
      }
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (treeView1.SelectedNode.Index >= numberOfSections)
        return;
      List<string> stringList1 = new List<string>();
      List<string> stringList2 = new List<string>();
      List<int> times = new List<int>();
      List<string> timesString = new List<string>();
      int index1 = treeView1.SelectedNode.Index;
      int num1 = ((int) savedata[index1 * 16 + 68] << 24 | (int) savedata[index1 * 16 + 69] << 16 | (int) savedata[index1 * 16 + 70] << 8 | (int) savedata[index1 * 16 + 71]) + (numberOfSections - (index1 + 1)) * 16;
      int num2 = (int) savedata[index1 * 16 + 72] << 8 | (int) savedata[index1 * 16 + 73];
      char ch;
      for (int index2 = 0; index2 < num2; ++index2)
      {
        string str1 = "";
        string str2 = "";
        for (int index3 = 0; index3 < 32; ++index3)
        {
          if (savedata[index2 * 64 + num1 + index3] >= (byte) 32)
          {
            string str3 = str1;
            ch = (char) savedata[index2 * 64 + num1 + index3];
            string str4 = ch.ToString();
            str1 = str3 + str4;
          }
        }
        if (checkBox8.Checked)
        {
          int num3 = 0;
          string str5 = str2 + (object) savedata[index2 * 64 + num1 + 32] + ":" + (object) savedata[index2 * 64 + num1 + 33] + ":";
          int num4 = num3 + (int) savedata[index2 * 64 + num1 + 32] * 3600 + (int) savedata[index2 * 64 + num1 + 33] * 60;
          string str6;
          int num5;
          if (savedata[index2 * 64 + num1 + 34] >= (byte) 128)
          {
            str6 = str5 + (object) ((int) savedata[index2 * 64 + num1 + 34] - 128) + " PM";
            num5 = num4 + ((int) savedata[index2 * 64 + num1 + 34] - 128 + 43200);
          }
          else
          {
            str6 = str5 + (object) savedata[index2 * 64 + num1 + 34] + " AM";
            num5 = num4 + (int) savedata[index2 * 64 + num1 + 34];
          }
          times.Add(num5);
          timesString.Add(str6);
        }
        if (!checkBox8.Checked)
        {
          if (!stringList1.Contains(str1))
            stringList1.Add(str1);
        }
        else
          stringList1.Add(str1);
      }
      if (checkBox8.Checked)
      {
        List<string> ssids = new List<string>((IEnumerable<string>) stringList1);
        new Plot(times, timesString, ssids, ls.sectionNames[index1]).Show();
      }
      if (checkBox7.Checked)
        dumpSSIDS(stringList1, string.Concat((object) index1));
      stringList1.Sort();
      for (int index4 = 0; index4 < stringList1.Count<string>(); ++index4)
      {
        for (int index5 = 0; index5 < num2; ++index5)
        {
          string str7 = "";
          for (int index6 = num1 + index5 * 64; index6 < num1 + index5 * 64 + 32; ++index6)
          {
            if (savedata[index6] >= (byte) 32)
            {
              string str8 = str7;
              ch = (char) savedata[index6];
              string str9 = ch.ToString();
              str7 = str8 + str9;
            }
          }
          if (str7 == stringList1[index4])
          {
            string str10 = "";
            string str11 = "Cipher: ";
            string str12 = "Auth: ";
            string str13 = str10 + (object) savedata[num1 + index5 * 64 + 32] + ":" + (object) savedata[num1 + index5 * 64 + 33] + ":";
            string str14 = savedata[num1 + index5 * 64 + 34] < (byte) 128 ? str13 + (object) savedata[num1 + index5 * 64 + 34] + " AM" : str13 + (object) ((int) savedata[num1 + index5 * 64 + 34] - 128) + " PM";
            stringList2.Add(str14);
            stringList2.Add("Range: " + (object) savedata[num1 + index5 * 64 + 35] + "%");
            stringList2.Add("#BSSIDS: " + (object) savedata[num1 + index5 * 64 + 36]);
            for (int index7 = num1 + index5 * 64 + 37; index7 < num1 + index5 * 64 + 48; ++index7)
            {
              if (savedata[index7] >= (byte) 32)
              {
                string str15 = str11;
                ch = (char) savedata[index7];
                string str16 = ch.ToString();
                str11 = str15 + str16;
              }
            }
            stringList2.Add(str11);
            for (int index8 = num1 + index5 * 64 + 48; index8 < num1 + index5 * 64 + 64; ++index8)
            {
              if (savedata[index8] >= (byte) 32)
              {
                string str17 = str12;
                ch = (char) savedata[index8];
                string str18 = ch.ToString();
                str12 = str17 + str18;
              }
            }
            stringList2.Add(str12);
            index5 = num2;
          }
        }
      }
      for (int index9 = 0; index9 < stringList1.Count<string>(); ++index9)
      {
        if (!used.Contains(stringList1[index9]))
        {
          TreeNode node = new TreeNode(stringList1[index9]);
          for (int index10 = 0; index10 < 5; ++index10)
            node.Nodes.Add(stringList2[index9 * 5 + index10]);
          treeView1.Nodes[index1].Nodes.Add(node);
          used.Add(stringList1[index9]);
        }
      }
    }

    private byte[] sectioncreator(byte[] data)
    {
      byte[] numArray = new byte[data.Length + 16];
      for (int index = 0; index < numberOfSections * 16 + 64; ++index)
        numArray[index] = data[index];
      numArray[numberOfSections * 16 + 64] = (byte) Convert.ToInt32(date.ToString("MM"));
      numArray[numberOfSections * 16 + 65] = (byte) Convert.ToInt32(date.ToString("dd"));
      numArray[numberOfSections * 16 + 66] = (byte) (Convert.ToInt32(date.ToString("yyyy")) >> 8);
      numArray[numberOfSections * 16 + 67] = (byte) Convert.ToInt32(date.ToString("yyyy"));
      numArray[numberOfSections * 16 + 68] = (byte) (numArray.Length >> 24);
      numArray[numberOfSections * 16 + 69] = (byte) (numArray.Length >> 16);
      numArray[numberOfSections * 16 + 70] = (byte) (numArray.Length >> 8);
      numArray[numberOfSections * 16 + 71] = (byte) numArray.Length;
      for (int index = numberOfSections * 16 + 64; index < data.Length; ++index)
        numArray[index + 16] = data[index];
      ++numberOfSections;
      return numArray;
    }

    private void sectionDataCreator()
    {
      for (int index1 = ls.numSSIDSWritten * 6; index1 < wifis.Count<string>(); index1 += 6)
      {
        if (!ssids.Contains(wifis[index1]))
        {
          ssids.Add(wifis[index1]);
          int num = 0;
          if (DateTime.Now.ToString("tt") == "PM")
            num = 128;
          byte[] numArray = new byte[sectionData.Length + 64];
          sectionData.CopyTo((Array) numArray, 0);
          for (int index2 = numArray.Length - 64; index2 < numArray.Length - 64 + wifis[index1].Length; ++index2)
            numArray[index2] = (byte) wifis[index1][index2 - (numArray.Length - 64)];
          numArray[numArray.Length - 32] = (byte) Convert.ToInt32(DateTime.Now.ToString("hh"));
          numArray[numArray.Length - 31] = (byte) Convert.ToInt32(DateTime.Now.ToString("mm"));
          numArray[numArray.Length - 30] = (byte) (Convert.ToInt32(DateTime.Now.ToString("ss")) | num);
          numArray[numArray.Length - 29] = (byte) Convert.ToInt32(wifis[index1 + 4]);
          numArray[numArray.Length - 28] = (byte) Convert.ToInt32(wifis[index1 + 3]);
          for (int index3 = numArray.Length - 27; index3 < numArray.Length - 27 + wifis[index1 + 1].Length; ++index3)
            numArray[index3] = (byte) wifis[index1 + 1][index3 - (numArray.Length - 27)];
          for (int index4 = numArray.Length - 16; index4 < numArray.Length - 16 + wifis[index1 + 2].Length; ++index4)
            numArray[index4] = (byte) wifis[index1 + 2][index4 - (numArray.Length - 16)];
          sectionData = numArray;
          ++totalCollections;
          ++newssids;
          ++sectionssids;
          ++ls.numSSIDSWritten;
        }
      }
      if (ms <= collectionsRecord)
        return;
      collectionsRecord = ms;
    }

    private void createsavefile()
    {
      Invoke(new Action(() => label16.Text = "Creating new save file..." + Environment.NewLine));
      string name = dirname.Name;
      header = new byte[64];
      for (int index = 0; index < headerTitle.Length; ++index)
        header[index] = (byte) headerTitle[index];
      DateTime dateTime = new DateTime();
      string str = DateTime.Now.ToString("MM/dd/yyyy");
      for (int index = 4; index < str.Length + 4; ++index)
        header[index] = (byte) str[index - 4];
      for (int index = 32; index < name.Length + 32; ++index)
        header[index] = (byte) name[index - 32];
      try
      {
        File.WriteAllBytes(savedir + "\\" + fileName, header);
        savedata = sectioncreator(File.ReadAllBytes(savedir + "\\" + fileName));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Save file is being used by another process: " + (object) ex, "WiFi Save Creator");
      }
      Invoke(new Action(() => label16.Text = "New save file created." + Environment.NewLine));
    }

    private void dumpSSIDS(List<string> exportList, string listName)
    {
      string str = saveSSIDName + listName;
      List<string> stringList = new List<string>();
      string[] strArray = new string[0];
      for (int index1 = 0; index1 < exportList.Count<string>(); ++index1)
      {
        bool flag = true;
        for (int index2 = 0; index2 < strArray.Length; ++index2)
        {
          if (exportList[index1].Contains(strArray[index2]))
          {
            flag = false;
            index2 = strArray.Length;
          }
        }
        if (!stringList.Contains(exportList[index1]) & flag)
          stringList.Add(exportList[index1]);
      }
      stringList.Sort();
      string path = savedir + "\\" + str + ".txt";
      File.WriteAllText(path, "");
      for (int index = 0; index < stringList.Count; ++index)
        File.AppendAllText(path, stringList[index] + Environment.NewLine);
      label16.Text = str + " Saved";
    }

    private void listBoxOverload()
    {
      if (listView1.Items.Count <= 50)
        return;
      Invoke(new Action(() => listView1.BackColor = Color.White));
      Invoke(new Action(() => listView1.Items.Clear()));
      Invoke(new Action(() => listView1.BackColor = listviewcolor));
    }

    private void moverankpanel(bool lorr)
    {
      if (lorr)
      {
        for (int i = 637; i > 460; i -= 5)
        {
          Invoke(new Action(() => panel1.Location = new Point(i, panel1.Location.Y)));
          Thread.Sleep(10);
        }
      }
      else
      {
        for (int i = 460; i < 637; i += 9)
          Invoke(new Action(() => panel1.Location = new Point(i, panel1.Location.Y)));
      }
    }

    private Color getColor(int i)
    {
      if (i <= 45)
        return Color.Lime;
      if (i > 45 && i <= 90)
        return Color.Yellow;
      if (i > 90 && i <= 135)
        return Color.Orange;
      if (i > 135 && i <= 180)
        return Color.Red;
      if (i > 180 && i <= 270)
        return Color.Magenta;
      if (i > 270 && i <= 360)
        return Color.DarkViolet;
      if (i > 360 && i <= 450)
        return Color.Blue;
      if (i > 450 && i <= 540)
        return Color.Gray;
      if (i > 540 && i <= 585)
        return Color.DarkGray;
      if (i > 585 && i <= 945)
        return Color.Black;
      if (i > 1080 && i <= 1440)
        return Color.Green;
      if (i > 1440 && i <= 1800)
        return Color.GreenYellow;
      if (i > 1800 && i <= 2160)
        return Color.DarkOrange;
      if (i > 2160 && i <= 2520)
        return Color.Crimson;
      if (i > 2520 && i <= 2880)
        return ranColor();
      if (i > 2880 && i <= 3240)
        return Color.SaddleBrown;
      if (i > 3240 && i <= 3600)
        return Color.Crimson;
      if (i > 3600 && i <= 3960)
        return Color.DarkGray;
      if (i > 3960 && i <= 4320)
        return Color.Gray;
      if (i > 4320 && i <= 4680)
        return Color.DimGray;
      if (i > 4680 && i <= 5040 || i <= 5040)
        return ranColor();
      return i % 720 <= 360 ? Color.FromArgb((i + ls.pings) % 256, (i + 85) % 256, (i + 170 + newssids) % 256) : Color.Turquoise;
    }

    private Color ranColor() => Color.FromArgb(ran.Next(0, 256), ran.Next(0, 256), ran.Next(0, 256));

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
      chart1.Visible = checkBox3.Checked;
      chart2.Visible = checkBox3.Checked;
      chart3.Visible = checkBox3.Checked;
    }

    private void timer2_Tick_1(object sender, EventArgs e)
    {
      --pingtime;
      if (pingtime <= 0)
        pingtime = 5;
      Invoke(new Action(() => label3.Text = "pinging in " + (object) pingtime));
    }

    private void button3_Click(object sender, EventArgs e) => dumpSSIDS(ssids, "");

    private void speakStats() => synth.Speak("Statistics WiFi's logged: " + (object) ms + ". Integral " + (object) integral + ". New WiFi " + (object) newssids);

    private void clickDesktop(string ClickSide, int x, int y, int manyClick, int Speed)
    {
    }

    private void plotDerivative()
    {
      Invoke(new Action(() => chart2.Series["dWiFi/dx"].Points.AddXY((object) "", (object) Statistics.Slope(ls.pings1, ls.pings, ls.ms1, ms))));
      Invoke(new Action(() => chart2.Series["dNew/dx"].Points.AddXY((object) "", (object) Statistics.Slope(ls.pings1, ls.pings, ls.newssids1, newssids))));
      if (ls.pings % ls.derivativeInterval != 0)
        return;
      ls.ms1 = ms;
      ls.newssids1 = newssids;
      ls.pings1 = ls.pings;
    }

    private void perMinute(int New)
    {
      int Sum = 0;
      for (int index = 1; index < ls.minArray.Length; ++index)
        ls.minArray[index - 1] = ls.minArray[index];
      ls.minArray[ls.minArray.Length - 1] = New;
      for (int index = 0; index < ls.minArray.Length; ++index)
        Sum += ls.minArray[index];
      Invoke(new Action(() => label4.Text = "# Min: " + Sum));
    }

    private void timer3_Tick_1(object sender, EventArgs e) => speakStats();

    private void checkBox5_CheckedChanged(object sender, EventArgs e)
    {
      speakStats();
      if (checkBox5.Checked)
        timer3.Enabled = true;
      else
        timer3.Enabled = false;
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void timer4_Tick(object sender, EventArgs e) => clickDesktop("LEFT", 1140, 750, 1, -1);

    private void checkBox6_CheckedChanged(object sender, EventArgs e) => timer4.Enabled = checkBox6.Checked;

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
    }

    private void button1_Click_2(object sender, EventArgs e)
    {
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void timer3_Tick(object sender, EventArgs e)
    {
    }

    private void button2_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      ChartArea chartArea1 = new ChartArea();
      Legend legend1 = new Legend();
      Series series1 = new Series();
      Series series2 = new Series();
      ChartArea chartArea2 = new ChartArea();
      Legend legend2 = new Legend();
      Series series3 = new Series();
      Series series4 = new Series();
      ChartArea chartArea3 = new ChartArea();
      Series series5 = new Series();
      listView1 = new ListView();
      columnHeader1 = new ColumnHeader();
      columnHeader2 = new ColumnHeader();
      columnHeader3 = new ColumnHeader();
      columnHeader4 = new ColumnHeader();
      columnHeader5 = new ColumnHeader();
      columnHeader6 = new ColumnHeader();
      timer1 = new System.Windows.Forms.Timer(components);
      checkBox1 = new CheckBox();
      checkBox2 = new CheckBox();
      label2 = new Label();
      label3 = new Label();
      textBox1 = new TextBox();
      label1 = new Label();
      pictureBox1 = new PictureBox();
      button1 = new Button();
      treeView1 = new TreeView();
      label5 = new Label();
      label6 = new Label();
      label7 = new Label();
      checkBox3 = new CheckBox();
      label8 = new Label();
      label9 = new Label();
      label10 = new Label();
      label11 = new Label();
      label12 = new Label();
      label13 = new Label();
      label14 = new Label();
      checkBox4 = new CheckBox();
      label15 = new Label();
      chart1 = new Chart();
      label16 = new Label();
      panel1 = new Panel();
      timer2 = new System.Windows.Forms.Timer(components);
      button3 = new Button();
      timer3 = new System.Windows.Forms.Timer(components);
      checkBox5 = new CheckBox();
      checkBox6 = new CheckBox();
      chart2 = new Chart();
      chart3 = new Chart();
      label4 = new Label();
      checkBox7 = new CheckBox();
      timer4 = new System.Windows.Forms.Timer(components);
      checkBox8 = new CheckBox();
      ((ISupportInitialize) pictureBox1).BeginInit();
      chart1.BeginInit();
      panel1.SuspendLayout();
      chart2.BeginInit();
      chart3.BeginInit();
      SuspendLayout();
      listView1.Activation = ItemActivation.OneClick;
      listView1.BackColor = Color.Black;
      listView1.Columns.AddRange(new ColumnHeader[6]
      {
        columnHeader1,
        columnHeader2,
        columnHeader3,
        columnHeader4,
        columnHeader5,
        columnHeader6
      });
      listView1.ForeColor = Color.White;
      listView1.GridLines = true;
      listView1.HideSelection = false;
      listView1.HoverSelection = true;
      listView1.LabelEdit = true;
      listView1.LabelWrap = false;
      listView1.Location = new Point(0, 0);
      listView1.Name = "listView1";
      listView1.Size = new Size(495, 198);
      listView1.TabIndex = 3;
      listView1.UseCompatibleStateImageBehavior = false;
      listView1.View = View.Details;
      listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);
      columnHeader1.Text = "SSID";
      columnHeader1.Width = 137;
      columnHeader2.Text = "Encryption";
      columnHeader2.Width = 63;
      columnHeader3.Text = "Auth";
      columnHeader3.TextAlign = HorizontalAlignment.Center;
      columnHeader3.Width = 106;
      columnHeader4.Text = "#BSSIDs";
      columnHeader4.Width = 56;
      columnHeader5.Text = "Range";
      columnHeader5.Width = 44;
      columnHeader6.Text = "Logged";
      columnHeader6.Width = 87;
      timer1.Interval = 1000;
      timer1.Tick += new EventHandler(timer1_Tick);
      checkBox1.AutoSize = true;
      checkBox1.Checked = true;
      checkBox1.CheckState = CheckState.Checked;
      checkBox1.ForeColor = Color.LightCyan;
      checkBox1.Location = new Point(382, 216);
      checkBox1.Name = "checkBox1";
      checkBox1.Size = new Size(113, 17);
      checkBox1.TabIndex = 4;
      checkBox1.Text = "Log Wifi Networks";
      checkBox1.UseVisualStyleBackColor = true;
      checkBox2.AutoSize = true;
      checkBox2.ForeColor = Color.LightCyan;
      checkBox2.Location = new Point(382, 250);
      checkBox2.Name = "checkBox2";
      checkBox2.Size = new Size(60, 17);
      checkBox2.TabIndex = 6;
      checkBox2.Text = "Speak:";
      checkBox2.UseVisualStyleBackColor = true;
      checkBox2.CheckedChanged += new EventHandler(checkBox2_CheckedChanged);
      label2.AutoSize = true;
      label2.ForeColor = Color.LightCyan;
      label2.Location = new Point(507, 22);
      label2.Name = "label2";
      label2.Size = new Size(62, 13);
      label2.TabIndex = 9;
      label2.Text = "# Networks";
      label3.AutoSize = true;
      label3.BackColor = Color.Transparent;
      label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label3.ForeColor = Color.FromArgb(192, (int) byte.MaxValue, (int) byte.MaxValue);
      label3.Location = new Point(116, 266);
      label3.Name = "label3";
      label3.Size = new Size(71, 15);
      label3.TabIndex = 10;
      label3.Text = "pinging in 5";
      textBox1.BackColor = Color.FromArgb((int) byte.MaxValue, 192, 128);
      textBox1.Location = new Point(1, 198);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(379, 20);
      textBox1.TabIndex = 11;
      label1.AutoSize = true;
      label1.BackColor = Color.Transparent;
      label1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      label1.ForeColor = Color.Gray;
      label1.Location = new Point(5, 31);
      label1.Name = "label1";
      label1.Size = new Size(175, 17);
      label1.TabIndex = 12;
      label1.Text = "Total WiFi's Collected: ";
      label1.Click += new EventHandler(label1_Click);
      pictureBox1.BackColor = Color.Transparent;
      pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      pictureBox1.Location = new Point(499, -22);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(270, 251);
      pictureBox1.TabIndex = 14;
      pictureBox1.TabStop = false;
      button1.Location = new Point(506, 232);
      button1.Name = "button1";
      button1.Size = new Size(104, 23);
      button1.TabIndex = 15;
      button1.Text = "Load Collections";
      button1.UseVisualStyleBackColor = true;
      button1.Click += new EventHandler(button1_Click_3);
      treeView1.BackColor = SystemColors.InactiveCaptionText;
      treeView1.ForeColor = Color.Turquoise;
      treeView1.Location = new Point(743, -1);
      treeView1.Name = "treeView1";
      treeView1.Size = new Size(173, 489);
      treeView1.TabIndex = 17;
      treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
      label5.AutoSize = true;
      label5.ForeColor = Color.LightCyan;
      label5.Location = new Point(658, 22);
      label5.Name = "label5";
      label5.Size = new Size(39, 13);
      label5.TabIndex = 18;
      label5.Text = "# New";
      label6.AutoSize = true;
      label6.ForeColor = Color.LightCyan;
      label6.Location = new Point(511, 201);
      label6.Name = "label6";
      label6.Size = new Size(58, 13);
      label6.TabIndex = 19;
      label6.Text = "# Previous";
      label7.AutoSize = true;
      label7.ForeColor = Color.LightCyan;
      label7.Location = new Point(658, 200);
      label7.Name = "label7";
      label7.Size = new Size(43, 13);
      label7.TabIndex = 21;
      label7.Text = "# Pings";
      checkBox3.AutoSize = true;
      checkBox3.Checked = true;
      checkBox3.CheckState = CheckState.Checked;
      checkBox3.ForeColor = Color.LightCyan;
      checkBox3.Location = new Point(382, 233);
      checkBox3.Name = "checkBox3";
      checkBox3.Size = new Size(81, 17);
      checkBox3.TabIndex = 22;
      checkBox3.Text = "Diagnostics";
      checkBox3.UseVisualStyleBackColor = true;
      checkBox3.CheckedChanged += new EventHandler(checkBox3_CheckedChanged);
      label8.AutoSize = true;
      label8.BackColor = Color.Transparent;
      label8.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label8.ForeColor = Color.Red;
      label8.Location = new Point(6, 71);
      label8.Name = "label8";
      label8.Size = new Size(102, 17);
      label8.TabIndex = 23;
      label8.Text = "Client Errors: 0";
      label9.AutoSize = true;
      label9.BackColor = Color.Transparent;
      label9.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label9.ForeColor = Color.Red;
      label9.Location = new Point(6, 90);
      label9.Name = "label9";
      label9.Size = new Size(114, 17);
      label9.TabIndex = 24;
      label9.Text = "Current Errors: 0";
      label10.AutoSize = true;
      label10.BackColor = Color.Transparent;
      label10.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label10.ForeColor = Color.Red;
      label10.Location = new Point((int) sbyte.MaxValue, 71);
      label10.Name = "label10";
      label10.Size = new Size(116, 17);
      label10.TabIndex = 25;
      label10.Text = "Best Recovery: 0";
      label11.AutoSize = true;
      label11.BackColor = Color.Black;
      label11.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label11.ForeColor = Color.Silver;
      label11.Location = new Point(45, 291);
      label11.Name = "label11";
      label11.Size = new Size(73, 15);
      label11.TabIndex = 27;
      label11.Text = "Derivative: 0";
      label12.AutoSize = true;
      label12.BackColor = Color.Transparent;
      label12.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label12.ForeColor = Color.Red;
      label12.Location = new Point((int) sbyte.MaxValue, 90);
      label12.Name = "label12";
      label12.Size = new Size(110, 17);
      label12.TabIndex = 28;
      label12.Text = "Save Failures: 0";
      label13.AutoSize = true;
      label13.BackColor = Color.Black;
      label13.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label13.ForeColor = Color.Silver;
      label13.Location = new Point(45, 305);
      label13.Name = "label13";
      label13.Size = new Size(61, 15);
      label13.TabIndex = 29;
      label13.Text = "Integral: 0";
      label14.AutoSize = true;
      label14.BackColor = Color.Black;
      label14.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label14.ForeColor = Color.Silver;
      label14.Location = new Point(44, 320);
      label14.Name = "label14";
      label14.Size = new Size(99, 15);
      label14.TabIndex = 30;
      label14.Text = "Null Ratio: 100%";
      checkBox4.AutoSize = true;
      checkBox4.Checked = true;
      checkBox4.CheckState = CheckState.Checked;
      checkBox4.ForeColor = Color.LightCyan;
      checkBox4.Location = new Point(382, 199);
      checkBox4.Name = "checkBox4";
      checkBox4.Size = new Size(109, 17);
      checkBox4.TabIndex = 31;
      checkBox4.Text = "Refresh Overload";
      checkBox4.UseVisualStyleBackColor = true;
      label15.AutoSize = true;
      label15.BackColor = Color.Black;
      label15.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      label15.ForeColor = Color.Silver;
      label15.Location = new Point(44, 335);
      label15.Name = "label15";
      label15.Size = new Size(88, 15);
      label15.TabIndex = 32;
      label15.Text = "New Ratio: 0%";
      chart1.BackColor = Color.DarkGray;
      chart1.BorderlineColor = Color.DimGray;
      chart1.BorderSkin.BorderColor = Color.DarkGray;
      chartArea1.BackColor = Color.Black;
      chartArea1.BackSecondaryColor = Color.White;
      chartArea1.BorderColor = Color.Maroon;
      chartArea1.Name = "WiFis";
      chart1.ChartAreas.Add(chartArea1);
      legend1.Name = "Legend1";
      chart1.Legends.Add(legend1);
      chart1.Location = new Point(-22, 269);
      chart1.Name = "chart1";
      chart1.Palette = ChartColorPalette.EarthTones;
      series1.BorderColor = Color.White;
      series1.ChartArea = "WiFis";
      series1.ChartType = SeriesChartType.Line;
      series1.LabelForeColor = Color.BlanchedAlmond;
      series1.Legend = "Legend1";
      series1.Name = "DiscoveredWiFis";
      series1.YValuesPerPoint = 2;
      series2.ChartArea = "WiFis";
      series2.Color = Color.Fuchsia;
      series2.Legend = "Legend1";
      series2.Name = "NewWiFis";
      chart1.Series.Add(series1);
      chart1.Series.Add(series2);
      chart1.Size = new Size(464, 214);
      chart1.TabIndex = 20;
      chart1.Text = "chart1";
      label16.AutoSize = true;
      label16.BackColor = Color.Transparent;
      label16.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      label16.ForeColor = Color.FromArgb(0, 192, 0);
      label16.Location = new Point(7, 10);
      label16.Name = "label16";
      label16.Size = new Size(73, 17);
      label16.TabIndex = 33;
      label16.Text = "Welcome";
      panel1.BackColor = Color.Black;
      panel1.Controls.Add((Control) label16);
      panel1.Controls.Add((Control) label12);
      panel1.Controls.Add((Control) label8);
      panel1.Controls.Add((Control) label9);
      panel1.Controls.Add((Control) label10);
      panel1.Controls.Add((Control) label1);
      panel1.Location = new Point(637, 370);
      panel1.Name = "panel1";
      panel1.Size = new Size(268, 117);
      panel1.TabIndex = 34;
      timer2.Enabled = true;
      timer2.Interval = 1000;
      timer2.Tick += new EventHandler(timer2_Tick_1);
      button3.Location = new Point(506, 261);
      button3.Name = "button3";
      button3.Size = new Size(104, 23);
      button3.TabIndex = 35;
      button3.Text = "Dump SSIDS";
      button3.UseVisualStyleBackColor = true;
      button3.Click += new EventHandler(button3_Click);
      timer3.Interval = 50000;
      timer3.Tick += new EventHandler(timer3_Tick_1);
      checkBox5.AutoSize = true;
      checkBox5.ForeColor = Color.LightCyan;
      checkBox5.Location = new Point(439, 250);
      checkBox5.Name = "checkBox5";
      checkBox5.Size = new Size(50, 17);
      checkBox5.TabIndex = 36;
      checkBox5.Text = "Stats";
      checkBox5.UseVisualStyleBackColor = true;
      checkBox5.CheckedChanged += new EventHandler(checkBox5_CheckedChanged);
      checkBox6.AutoSize = true;
      checkBox6.ForeColor = Color.LightCyan;
      checkBox6.Location = new Point(203, 264);
      checkBox6.Name = "checkBox6";
      checkBox6.Size = new Size(79, 17);
      checkBox6.TabIndex = 38;
      checkBox6.Text = "SuperScan";
      checkBox6.UseVisualStyleBackColor = true;
      checkBox6.CheckedChanged += new EventHandler(checkBox6_CheckedChanged);
      chart2.BackColor = Color.DarkGray;
      chart2.BorderlineColor = Color.DarkGray;
      chartArea2.Area3DStyle.LightStyle = LightStyle.None;
      chartArea2.BackColor = Color.Black;
      chartArea2.Name = "ChartArea1";
      chartArea2.Position.Auto = false;
      chartArea2.Position.Height = 100f;
      chartArea2.Position.Width = 60f;
      chart2.ChartAreas.Add(chartArea2);
      legend2.ForeColor = Color.White;
      legend2.IsTextAutoFit = false;
      legend2.Name = "Legend1";
      legend2.Position.Auto = false;
      legend2.Position.Height = 16.45783f;
      legend2.Position.Width = 20.54196f;
      legend2.Position.X = 60.45804f;
      legend2.Position.Y = 3f;
      legend2.TitleForeColor = Color.Gray;
      legend2.TitleSeparatorColor = Color.Silver;
      chart2.Legends.Add(legend2);
      chart2.Location = new Point(278, 317);
      chart2.Name = "chart2";
      chart2.Palette = ChartColorPalette.Bright;
      series3.ChartArea = "ChartArea1";
      series3.ChartType = SeriesChartType.Spline;
      series3.Legend = "Legend1";
      series3.Name = "dWiFi/dx";
      series3.YValuesPerPoint = 4;
      series4.ChartArea = "ChartArea1";
      series4.ChartType = SeriesChartType.Spline;
      series4.Legend = "Legend1";
      series4.Name = "dNew/dx";
      chart2.Series.Add(series3);
      chart2.Series.Add(series4);
      chart2.Size = new Size(567, 167);
      chart2.TabIndex = 39;
      chart2.Text = "chart2";
      chart3.BackColor = Color.Transparent;
      chartArea3.Area3DStyle.Enable3D = true;
      chartArea3.BackColor = Color.Transparent;
      chartArea3.Name = "ChartArea1";
      chartArea3.Position.Auto = false;
      chartArea3.Position.Height = 30f;
      chartArea3.Position.Width = 30f;
      chart3.ChartAreas.Add(chartArea3);
      chart3.Location = new Point(617, 276);
      chart3.Name = "chart3";
      chart3.Palette = ChartColorPalette.Excel;
      series5.ChartArea = "ChartArea1";
      series5.ChartType = SeriesChartType.Doughnut;
      series5.Name = "Series1";
      series5.YValuesPerPoint = 2;
      chart3.Series.Add(series5);
      chart3.Size = new Size(300, 300);
      chart3.TabIndex = 40;
      chart3.Text = "chart3";
      label4.AutoSize = true;
      label4.ForeColor = Color.LightCyan;
      label4.Location = new Point(350, 335);
      label4.Name = "label4";
      label4.Size = new Size(34, 13);
      label4.TabIndex = 41;
      label4.Text = "# Min";
      checkBox7.AutoSize = true;
      checkBox7.ForeColor = Color.LightCyan;
      checkBox7.Location = new Point(616, 236);
      checkBox7.Name = "checkBox7";
      checkBox7.Size = new Size(94, 17);
      checkBox7.TabIndex = 42;
      checkBox7.Text = "Export Clicked";
      checkBox7.UseVisualStyleBackColor = true;
      checkBox7.Visible = false;
      timer4.Interval = 3000;
      timer4.Tick += new EventHandler(timer4_Tick);
      checkBox8.AutoSize = true;
      checkBox8.ForeColor = Color.LightCyan;
      checkBox8.Location = new Point(616, 253);
      checkBox8.Name = "checkBox8";
      checkBox8.Size = new Size(83, 17);
      checkBox8.TabIndex = 43;
      checkBox8.Text = "Draw Graph";
      checkBox8.UseVisualStyleBackColor = true;
      checkBox8.Visible = false;
      AutoScaleDimensions = new SizeF(6f, 13f);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = SystemColors.ActiveCaptionText;
      ClientSize = new Size(915, 488);
      Controls.Add((Control) checkBox8);
      Controls.Add((Control) checkBox7);
      Controls.Add((Control) label4);
      Controls.Add((Control) panel1);
      Controls.Add((Control) treeView1);
      Controls.Add((Control) chart3);
      Controls.Add((Control) chart2);
      Controls.Add((Control) checkBox6);
      Controls.Add((Control) label14);
      Controls.Add((Control) label11);
      Controls.Add((Control) label13);
      Controls.Add((Control) checkBox5);
      Controls.Add((Control) label15);
      Controls.Add((Control) button3);
      Controls.Add((Control) checkBox4);
      Controls.Add((Control) checkBox3);
      Controls.Add((Control) label7);
      Controls.Add((Control) label6);
      Controls.Add((Control) label5);
      Controls.Add((Control) button1);
      Controls.Add((Control) listView1);
      Controls.Add((Control) textBox1);
      Controls.Add((Control) label3);
      Controls.Add((Control) label2);
      Controls.Add((Control) checkBox2);
      Controls.Add((Control) checkBox1);
      Controls.Add((Control) pictureBox1);
      Controls.Add((Control) chart1);
      ForeColor = Color.Black;
      Name = nameof (Form1);
      Text = "WiFi Bingo";
      Load += new EventHandler(Form1_Load);
      ((ISupportInitialize) pictureBox1).EndInit();
      chart1.EndInit();
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      chart2.EndInit();
      chart3.EndInit();
      ResumeLayout(false);
      PerformLayout();
    }
  }
}
