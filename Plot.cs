// Decompiled with JetBrains decompiler
// Type: WifiHacker.Plot
// Assembly: WifiHacker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 20B0797F-6870-4120-A735-0CC261EC7D03
// Assembly location: C:\Users\ROXTerm\Desktop\LoggedNetworks\WifiHacker.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WifiHacker
{
  public class Plot : Form
  {
    private List<int> times;
    private List<int> newTimes;
    private List<string> timesString;
    private List<string> ssids;
    private string saveDir;
    private string name;
    private int start;
    private int range;
    private IContainer components;
    private Chart chart1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Panel panel1;
    private Label label5;
    private Label label4;
    private TextBox textBox2;
    private TextBox textBox1;
    private RichTextBox richTextBox1;
    private Label label6;

    public Plot(List<int> times, List<string> timesString, List<string> ssids, string name)
    {
        this.name = name;
        this.times = times;
        this.timesString = timesString;
        this.ssids = ssids;
      saveDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\LoggedNetworks";
      InitializeComponent();
    }

    private void plotTimes()
    {
      newTimes = new List<int>((IEnumerable<int>) times);
      newTimes.Sort();
      File.WriteAllText(saveDir + "\\TIMES.txt", "");
      for (int index = 0; index < newTimes.Count; ++index)
        File.AppendAllText(saveDir + "\\TIMES.txt", newTimes[index].ToString() + Environment.NewLine);
      if (newTimes.Count == 0)
        return;
      int integral = 0;
      range = newTimes[newTimes.Count - 1] - newTimes[0];
      this.start = newTimes[0];
      int j = 0;
      int start = this.start;
      while (start < newTimes[newTimes.Count - 1] - 5)
      {
        if (newTimes[j] >= start && newTimes[j] <= start + 5)
        {
          j++;
          integral += j;
        }
        else
        {
          Invoke(new Action(() => chart1.Series["#Networks"].Points.AddXY((object) "", (object) j)));
          start += 5;
        }
      }
      Invoke(new Action(() => label1.Text = "Plotting... DONE!"));
      Invoke(new Action(() => label2.Text = timesString[0]));
      Invoke(new Action(() => label3.Text = timesString[timesString.Count - 1]));
      Invoke(new Action(() => label4.Text = "#Networks: " + (object) newTimes.Count));
      Invoke(new Action(() => label5.Text = "Integral: " + (object) integral));
      Invoke(new Action(() => label6.Text = "Plots: " + (object) (range / 5)));
    }

    private void startPlot()
    {
      Invoke(new Action(() => Text = name));
      new Thread(new ThreadStart(plotTimes)).Start();
    }

    private void Plot_Load(object sender, EventArgs e) => startPlot();

    private void textBox2_TextChanged(object sender, EventArgs e) => listRange();

    private void textBox1_TextChanged(object sender, EventArgs e) => listRange();

    private void listRange()
    {
      try
      {
        richTextBox1.Clear();
        int num1 = Convert.ToInt32(textBox1.Text) * 5;
        int num2 = Convert.ToInt32(textBox2.Text) * 5;
        for (int index1 = num1; index1 < num2; ++index1)
        {
          if (newTimes.Contains(start + index1))
          {
            for (int index2 = 0; index2 < newTimes.Count; ++index2)
            {
              if (newTimes[index2] == start + index1)
              {
                RichTextBox richTextBox1 = this.richTextBox1;
                richTextBox1.Text = richTextBox1.Text + timesString[index2] + " " + ssids[index2] + Environment.NewLine;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        richTextBox1.Text = string.Concat((object) ex);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }
        private void InitializeComponent()
        {
            ChartArea chartArea = new ChartArea();
            Legend legend = new Legend();
            Series series = new Series();
            chart1 = new Chart();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            label4 = new Label();
            chart1.BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            chart1.BackColor = Color.Transparent;
            chart1.BorderlineColor = Color.Transparent;
            chartArea.AxisX.TitleForeColor = Color.Orange;
            chartArea.AxisX2.TitleForeColor = Color.Orange;
            chartArea.AxisY.TitleForeColor = Color.Orange;
            chartArea.AxisY2.LineColor = Color.FromArgb((int)byte.MaxValue, 192, 128);
            chartArea.AxisY2.TitleForeColor = Color.Orange;
            chartArea.BackColor = Color.Transparent;
            chartArea.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea);
            legend.Name = "Legend1";
            chart1.Legends.Add(legend);
            chart1.Location = new Point(-19, 3);
            chart1.Name = "chart1";
            chart1.Palette = ChartColorPalette.Fire;
            series.ChartArea = "ChartArea1";
            series.ChartType = SeriesChartType.Line;
            series.Legend = "Legend1";
            series.Name = "#Networks";
            chart1.Series.Add(series);
            chart1.Size = new Size(1046, 583);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(759, 504);
            label1.Name = "label1";
            label1.Size = new Size(78, 17);
            label1.TabIndex = 1;
            label1.Text = "Plotting...";
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            label2.Location = new Point(53, 544);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 2;
            label2.Text = "init";
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            label3.Location = new Point(827, 545);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 3;
            label3.Text = "final";
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add((Control)label6);
            panel1.Controls.Add((Control)textBox2);
            panel1.Controls.Add((Control)textBox1);
            panel1.Controls.Add((Control)richTextBox1);
            panel1.Controls.Add((Control)label5);
            panel1.Controls.Add((Control)label4);
            panel1.Location = new Point(891, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 517);
            panel1.TabIndex = 4;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(3, 54);
            label6.Name = "label6";
            label6.Size = new Size(36, 13);
            label6.TabIndex = 5;
            label6.Text = "Plots: ";
            textBox2.Location = new Point(62, 205);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(53, 20);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);
            textBox1.Location = new Point(6, 205);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(53, 20);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            richTextBox1.Location = new Point(0, 231);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(295, 283);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(3, 32);
            label5.Name = "label5";
            label5.Size = new Size(45, 13);
            label5.TabIndex = 1;
            label5.Text = "Integral:";
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(3, 10);
            label4.Name = "label4";
            label4.Size = new Size(62, 13);
            label4.TabIndex = 0;
            label4.Text = "#Networks:";
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1055, 571);
            Controls.Add((Control)label1);
            Controls.Add((Control)panel1);
            Controls.Add((Control)label3);
            Controls.Add((Control)label2);
            Controls.Add((Control)chart1);
            Name = nameof(Plot);
            Text = "Program";
            Load += new EventHandler(Plot_Load);
            chart1.EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
