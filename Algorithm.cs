// Decompiled with JetBrains decompiler
// Type: WifiHacker.Algorithm
// Assembly: WifiHacker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 20B0797F-6870-4120-A735-0CC261EC7D03
// Assembly location: C:\Users\ROXTerm\Desktop\LoggedNetworks\WifiHacker.exe

using System;

namespace WifiHacker
{
  internal class Algorithm
  {
    private byte[] SBox = new byte[256]
    {
      (byte) 54,
      (byte) 209,
      (byte) 219,
      (byte) 29,
      (byte) 91,
      (byte) 208,
      (byte) 206,
      (byte) 223,
      (byte) 189,
      (byte) 132,
      (byte) 93,
      (byte) 42,
      (byte) 238,
      (byte) 165,
      (byte) 34,
      (byte) 4,
      (byte) 188,
      (byte) 225,
      (byte) 84,
      (byte) 25,
      (byte) 11,
      (byte) 167,
      (byte) 245,
      (byte) 239,
      (byte) 64,
      (byte) 228,
      (byte) 67,
      (byte) 43,
      (byte) 83,
      (byte) 215,
      (byte) 63,
      (byte) 218,
      (byte) 72,
      (byte) 251,
      (byte) 17,
      (byte) 128,
      (byte) 44,
      (byte) 234,
      (byte) 163,
      (byte) 52,
      (byte) 231,
      (byte) 182,
      (byte) 131,
      (byte) 154,
      (byte) 18,
      (byte) 96,
      (byte) 115,
      (byte) 250,
      (byte) 41,
      (byte) 229,
      (byte) 46,
      (byte) 26,
      (byte) 235,
      (byte) 138,
      (byte) 180,
      (byte) 105,
      (byte) 172,
      (byte) 79,
      (byte) 166,
      byte.MaxValue,
      (byte) 38,
      (byte) 243,
      (byte) 110,
      (byte) 143,
      (byte) 247,
      (byte) 177,
      (byte) 36,
      (byte) 241,
      (byte) 114,
      (byte) 85,
      (byte) 144,
      (byte) 24,
      (byte) 242,
      (byte) 246,
      (byte) 203,
      (byte) 50,
      (byte) 77,
      (byte) 122,
      (byte) 210,
      (byte) 82,
      (byte) 126,
      (byte) 10,
      (byte) 101,
      (byte) 74,
      (byte) 107,
      (byte) 33,
      (byte) 31,
      (byte) 124,
      (byte) 21,
      (byte) 6,
      (byte) 56,
      (byte) 217,
      (byte) 90,
      (byte) 142,
      (byte) 155,
      (byte) 118,
      (byte) 81,
      (byte) 88,
      (byte) 200,
      (byte) 28,
      (byte) 125,
      (byte) 152,
      (byte) 100,
      (byte) 12,
      (byte) 195,
      (byte) 60,
      (byte) 248,
      (byte) 0,
      (byte) 164,
      (byte) 116,
      (byte) 153,
      (byte) 183,
      (byte) 120,
      (byte) 7,
      (byte) 19,
      (byte) 45,
      (byte) 207,
      (byte) 204,
      (byte) 87,
      (byte) 213,
      (byte) 212,
      (byte) 103,
      (byte) 40,
      (byte) 30,
      (byte) 2,
      (byte) 224,
      (byte) 32,
      (byte) 16,
      (byte) 186,
      (byte) 86,
      (byte) 14,
      (byte) 127,
      (byte) 158,
      (byte) 147,
      (byte) 221,
      (byte) 176,
      (byte) 108,
      (byte) 13,
      (byte) 161,
      (byte) 222,
      (byte) 134,
      (byte) 20,
      (byte) 170,
      (byte) 253,
      (byte) 65,
      (byte) 145,
      (byte) 76,
      (byte) 191,
      (byte) 70,
      (byte) 48,
      (byte) 193,
      (byte) 190,
      (byte) 111,
      (byte) 240,
      (byte) 178,
      (byte) 75,
      (byte) 66,
      (byte) 1,
      (byte) 252,
      (byte) 249,
      (byte) 89,
      (byte) 205,
      (byte) 61,
      (byte) 230,
      (byte) 173,
      (byte) 133,
      (byte) 69,
      (byte) 254,
      (byte) 194,
      (byte) 159,
      (byte) 57,
      (byte) 99,
      (byte) 22,
      (byte) 244,
      (byte) 179,
      (byte) 136,
      (byte) 94,
      (byte) 5,
      (byte) 171,
      (byte) 156,
      (byte) 169,
      (byte) 232,
      (byte) 62,
      (byte) 211,
      (byte) 199,
      (byte) 121,
      (byte) 95,
      (byte) 130,
      (byte) 151,
      (byte) 216,
      (byte) 80,
      (byte) 106,
      (byte) 123,
      (byte) 148,
      (byte) 202,
      (byte) 227,
      (byte) 8,
      (byte) 102,
      (byte) 109,
      (byte) 49,
      (byte) 220,
      (byte) 3,
      (byte) 117,
      (byte) 197,
      (byte) 73,
      (byte) 236,
      (byte) 27,
      (byte) 23,
      (byte) 71,
      (byte) 174,
      (byte) 160,
      (byte) 139,
      (byte) 198,
      (byte) 146,
      (byte) 184,
      (byte) 157,
      (byte) 47,
      (byte) 135,
      (byte) 37,
      (byte) 140,
      (byte) 98,
      (byte) 181,
      (byte) 185,
      (byte) 59,
      (byte) 15,
      (byte) 141,
      (byte) 113,
      (byte) 137,
      (byte) 58,
      (byte) 97,
      (byte) 78,
      (byte) 51,
      (byte) 233,
      (byte) 35,
      (byte) 149,
      (byte) 39,
      (byte) 226,
      (byte) 162,
      (byte) 168,
      (byte) 196,
      (byte) 119,
      (byte) 68,
      (byte) 129,
      (byte) 112,
      (byte) 53,
      (byte) 104,
      (byte) 150,
      (byte) 187,
      (byte) 237,
      (byte) 9,
      (byte) 201,
      (byte) 55,
      (byte) 214,
      (byte) 175,
      (byte) 92,
      (byte) 192
    };
    private byte[] IBox = new byte[256]
    {
      (byte) 107,
      (byte) 157,
      (byte) 124,
      (byte) 201,
      (byte) 15,
      (byte) 177,
      (byte) 89,
      (byte) 113,
      (byte) 196,
      (byte) 249,
      (byte) 81,
      (byte) 20,
      (byte) 103,
      (byte) 137,
      (byte) 130,
      (byte) 224,
      (byte) 127,
      (byte) 34,
      (byte) 44,
      (byte) 114,
      (byte) 141,
      (byte) 88,
      (byte) 172,
      (byte) 207,
      (byte) 71,
      (byte) 19,
      (byte) 51,
      (byte) 206,
      (byte) 99,
      (byte) 3,
      (byte) 123,
      (byte) 86,
      (byte) 126,
      (byte) 85,
      (byte) 14,
      (byte) 233,
      (byte) 66,
      (byte) 218,
      (byte) 60,
      (byte) 235,
      (byte) 122,
      (byte) 48,
      (byte) 11,
      (byte) 27,
      (byte) 36,
      (byte) 115,
      (byte) 50,
      (byte) 216,
      (byte) 149,
      (byte) 199,
      (byte) 75,
      (byte) 231,
      (byte) 39,
      (byte) 244,
      (byte) 0,
      (byte) 251,
      (byte) 90,
      (byte) 170,
      (byte) 228,
      (byte) 223,
      (byte) 105,
      (byte) 162,
      (byte) 182,
      (byte) 30,
      (byte) 24,
      (byte) 144,
      (byte) 156,
      (byte) 26,
      (byte) 241,
      (byte) 166,
      (byte) 148,
      (byte) 208,
      (byte) 32,
      (byte) 204,
      (byte) 83,
      (byte) 155,
      (byte) 146,
      (byte) 76,
      (byte) 230,
      (byte) 57,
      (byte) 190,
      (byte) 96,
      (byte) 79,
      (byte) 28,
      (byte) 18,
      (byte) 69,
      (byte) 129,
      (byte) 118,
      (byte) 97,
      (byte) 160,
      (byte) 92,
      (byte) 4,
      (byte) 254,
      (byte) 10,
      (byte) 176,
      (byte) 186,
      (byte) 45,
      (byte) 229,
      (byte) 220,
      (byte) 171,
      (byte) 102,
      (byte) 82,
      (byte) 197,
      (byte) 121,
      (byte) 245,
      (byte) 55,
      (byte) 191,
      (byte) 84,
      (byte) 136,
      (byte) 198,
      (byte) 62,
      (byte) 152,
      (byte) 243,
      (byte) 226,
      (byte) 68,
      (byte) 46,
      (byte) 109,
      (byte) 202,
      (byte) 95,
      (byte) 240,
      (byte) 112,
      (byte) 185,
      (byte) 77,
      (byte) 192,
      (byte) 87,
      (byte) 100,
      (byte) 80,
      (byte) 131,
      (byte) 35,
      (byte) 242,
      (byte) 187,
      (byte) 42,
      (byte) 9,
      (byte) 165,
      (byte) 140,
      (byte) 217,
      (byte) 175,
      (byte) 227,
      (byte) 53,
      (byte) 211,
      (byte) 219,
      (byte) 225,
      (byte) 93,
      (byte) 63,
      (byte) 70,
      (byte) 145,
      (byte) 213,
      (byte) 133,
      (byte) 193,
      (byte) 234,
      (byte) 246,
      (byte) 188,
      (byte) 101,
      (byte) 110,
      (byte) 43,
      (byte) 94,
      (byte) 179,
      (byte) 215,
      (byte) 132,
      (byte) 169,
      (byte) 210,
      (byte) 138,
      (byte) 237,
      (byte) 38,
      (byte) 108,
      (byte) 13,
      (byte) 58,
      (byte) 21,
      (byte) 238,
      (byte) 180,
      (byte) 142,
      (byte) 178,
      (byte) 56,
      (byte) 164,
      (byte) 209,
      (byte) 253,
      (byte) 135,
      (byte) 65,
      (byte) 154,
      (byte) 174,
      (byte) 54,
      (byte) 221,
      (byte) 41,
      (byte) 111,
      (byte) 214,
      (byte) 222,
      (byte) 128,
      (byte) 247,
      (byte) 16,
      (byte) 8,
      (byte) 151,
      (byte) 147,
      byte.MaxValue,
      (byte) 150,
      (byte) 168,
      (byte) 104,
      (byte) 239,
      (byte) 203,
      (byte) 212,
      (byte) 184,
      (byte) 98,
      (byte) 250,
      (byte) 194,
      (byte) 74,
      (byte) 117,
      (byte) 161,
      (byte) 6,
      (byte) 116,
      (byte) 5,
      (byte) 1,
      (byte) 78,
      (byte) 183,
      (byte) 120,
      (byte) 119,
      (byte) 252,
      (byte) 29,
      (byte) 189,
      (byte) 91,
      (byte) 31,
      (byte) 2,
      (byte) 200,
      (byte) 134,
      (byte) 139,
      (byte) 7,
      (byte) 125,
      (byte) 17,
      (byte) 236,
      (byte) 195,
      (byte) 25,
      (byte) 49,
      (byte) 163,
      (byte) 40,
      (byte) 181,
      (byte) 232,
      (byte) 37,
      (byte) 52,
      (byte) 205,
      (byte) 248,
      (byte) 12,
      (byte) 23,
      (byte) 153,
      (byte) 67,
      (byte) 72,
      (byte) 61,
      (byte) 173,
      (byte) 22,
      (byte) 73,
      (byte) 64,
      (byte) 106,
      (byte) 159,
      (byte) 47,
      (byte) 33,
      (byte) 158,
      (byte) 143,
      (byte) 167,
      (byte) 59
    };

    public byte[] symmetricate(byte[] word)
    {
      this.rem(word.Length);
      byte[] numArray1 = new byte[word.Length + 1];
      word.CopyTo((Array) numArray1, 1);
      numArray1[0] = (byte) this.rem(numArray1.Length);
      byte[] numArray2 = new byte[numArray1.Length + this.rem(numArray1.Length)];
      numArray1.CopyTo((Array) numArray2, 0);
      return numArray2;
    }

    public byte[] desymmetricate(byte[] word)
    {
      int num = (int) word[0];
      byte[] numArray = new byte[word.Length - 1 - num];
      for (int index = 1; index < numArray.Length; ++index)
        numArray[index - 1] = word[index];
      return numArray;
    }

    public int rem(int size) => (64 - size % 64) % 64;

    public byte[] KHashingAlgorithm(string Key)
    {
      string str1 = "Ruthie";
      string str2 = "basketballru25";
      string str3 = Key;
      if (str3 == "")
        str3 = str1;
      string str4 = "";
      long num1 = 0;
      long a1 = 0;
      long d1 = 0;
      long length = (long) str3.Length;
      foreach (char ch in str3)
        d1 += (long) ch;
      foreach (char ch in str1)
        a1 += (long) ch;
      foreach (char ch in str2)
        num1 += (long) ch;
      Decimal a2 = 0M;
      Decimal b1 = 0M;
      for (int index1 = 0; (long) index1 < length; ++index1)
      {
        long x = (long) str3[index1];
        for (int index2 = 0; index2 < 6; ++index2)
          a2 += (Decimal) Math.Round(Math.Log((double) str1[index2], Math.Pow((double) x, 1.0 / 3.0)), 9);
        b1 += (Decimal) Math.Round(Math.Log((double) a1, Math.Pow((double) x, 0.25)), 9);
      }
      string str5 = str4 + this.df(a2, b1);
      Decimal a3 = 0M;
      Decimal b2 = 0M;
      for (int index3 = 0; (long) index3 < length; ++index3)
      {
        long x = (long) str3[index3];
        for (int index4 = 0; index4 < 6; ++index4)
        {
          a3 += (Decimal) Math.Round(Math.Acos(Math.Pow((double) x, 0.125) - 1.0) - Math.Log((double) str1[index4], Math.Pow((double) x, 2.0)), 10);
          b2 += (Decimal) Math.Round(1.0 / (Math.Atan((double) (x ^ (long) str1[index4])) + 1.0), 10);
        }
      }
      string str6 = str5 + this.df(a3, b2);
      Decimal a4 = 0M;
      Decimal b3 = 0M;
      for (int index5 = 0; (long) index5 < length; ++index5)
      {
        long x = (long) str3[index5];
        for (int index6 = 0; index6 < 6; ++index6)
        {
          a4 += (Decimal) Math.Round(Math.Sqrt(Math.Pow((double) x, 2.0) + Math.Pow((double) str1[index6], 2.0) - (double) (2L * x * (long) str1[index6]) * Math.Cos((double) d1)), 9);
          b3 += (Decimal) Math.Round(Math.Log(Math.Pow((double) (x * (long) str1[index6]), 0.25), Math.E), 9);
        }
      }
      string str7 = str6 + this.df(a4, b3);
      Decimal a5 = 0M;
      Decimal b4 = 0M;
      for (int index7 = 0; (long) index7 < length; ++index7)
      {
        Decimal d2 = 1M;
        long x = (long) str3[index7];
        for (int index8 = 0; index8 < 6; ++index8)
        {
          a5 += (Decimal) Math.Round(Math.Abs(Math.Sin(Math.Log((double) (x + (long) str1[index8] + d1 + 1L), Math.Pow((double) x, 0.2)))), 10);
          d2 *= (Decimal) (Math.Pow((double) x, 1.0 / 3.0) / (double) str1[index8] + 1.0);
        }
        b4 += Math.Round(d2, 10);
        a5 = Math.Round(1M / a5, 10);
      }
      string str8 = str7 + this.df(a5, b4);
      Decimal a6 = 0M;
      Decimal b5 = 0M;
      for (int index9 = 0; (long) index9 < length; ++index9)
      {
        long x = (long) str3[index9];
        for (int index10 = 0; index10 < 14; ++index10)
          a6 += (Decimal) (1.0 / (Math.Log((double) str2[index10], Math.Pow((double) x, 1.0 / 3.0)) + 1.0));
        for (int index11 = 0; index11 < 6; ++index11)
          b5 += (Decimal) Math.Abs(Math.Asin(Math.Sin((double) str1[index11]) * (Math.Pow((double) x, 0.125) - 1.0)));
      }
      string str9 = str8 + this.df(a6, b5);
      Decimal a7 = 0M;
      Decimal b6 = 0M;
      for (int index12 = 0; (long) index12 < length; ++index12)
      {
        long num2 = (long) str3[index12];
        for (int index13 = 0; index13 < 6; ++index13)
        {
          a7 += (Decimal) ((-Math.Cos(Math.Abs(Math.Cos(Math.Sqrt((double) num2))) * (double) str1[index13]) - -Math.Cos(-Math.Pow((double) (num2 * (long) str1[index13]), 0.25))) * Math.Log((double) str1[index13], (double) num2));
          b6 += (Decimal) (Math.Pow(Math.Abs(Math.Cos(Math.Sqrt((double) num2))), 1.0 / 3.0) * -1.0 * Math.Log((double) str1[index13], (double) num2));
        }
      }
      string str10 = str9 + this.df(a7, b6);
      Decimal a8 = 1M;
      Decimal b7 = 0M;
      for (int index14 = 0; (long) index14 < length; ++index14)
      {
        long num3 = (long) str3[index14];
        Decimal num4 = 1M;
        for (int index15 = 0; index15 < 6; ++index15)
          num4 *= (Decimal) Math.Pow(Math.Atan(Math.Pow((double) ((long) str1[index15] * num3), 0.25)) / Math.Log(Math.Abs(1.0 / Math.Sin(Math.Sqrt((double) (num3 * (long) str1[index15])) + (double) d1)), (double) num3), 1.0 / 3.0);
        b7 += (Decimal) ((Math.Sin((double) (25L * num3)) / (double) num3 - Math.Sin((double) (-25L * num3)) / (double) num3) * ((double) num3 - Math.Cos((double) (2L * num3)) / 2.0) - ((double) num3 - Math.Cos(2.0 * -Math.Pow((double) num3, 1.0 / 3.0)) / 2.0));
        a8 += num4;
      }
      string str11 = str10 + this.df(a8, b7);
      Decimal a9 = 1M;
      Decimal b8 = 0M;
      for (int index16 = 0; (long) index16 < length; ++index16)
      {
        long num5 = (long) str3[index16];
        Decimal num6 = 1M;
        Decimal num7 = 0M;
        for (int index17 = 0; index17 < 6; ++index17)
        {
          num6 *= (Decimal) Math.Abs(Math.Log10((double) (num5 * (long) str1[index17]) % Math.Ceiling(Math.Sqrt((double) (num5 * (long) str1[index17] + num5 + (long) str1[index17]))) / Math.Asin(Math.Pow(Math.Pow((double) (num5 * (long) str1[index17]) + Math.Cos((double) num5), 1.0 / 3.0) / (double) num5 + (double) str1[index17], 0.125) - 1.0) + Math.Pow((double) num5, 0.125)));
          num7 += (Decimal) (Math.Pow((double) num5, 2.0) + Math.Pow((double) str1[index17], 2.0) + (double) d1 + (double) a1) / (Decimal) Math.Abs(Math.Log((double) (num5 * (long) str1[index17] % ((num5 ^ (long) str1[index17]) + 6L) + (long) str1[index17]), (double) num5) + 1.0);
        }
        a9 += num6;
        b8 += num7;
      }
      string str12 = str11 + this.df(a9, b8);
      Decimal a10 = 0M;
      Decimal b9 = 0M;
      for (int index18 = 0; (long) index18 < length; ++index18)
      {
        long num8 = (long) str3[index18];
        for (int index19 = 0; index19 < 6; ++index19)
          a10 += (Decimal) (Math.Pow(Math.Abs(Math.Abs(Math.Sin((double) num8)) * Math.Pow((double) num8, 1.0 / 3.0)) / (double) num8, Math.Sin((double) (num8 * (long) str1[index19]))) * Math.Pow((double) num8, 5.0 / 6.0));
        b9 += (Decimal) ((Math.Pow((double) num8, 2.0) + Math.Pow((double) str1[(int) (Math.Floor(Math.Pow((double) num8, 1.0 / 3.0)) - 1.0)], 2.0)) / Math.Log10((double) (num8 * (long) str1[(int) (Math.Floor(Math.Pow((double) num8, 1.0 / 3.0)) - 1.0)])));
      }
      string str13 = str12 + this.df(a10, b9);
      Decimal a11 = 0M;
      Decimal b10 = 0M;
      for (int index20 = 0; (long) index20 < length; ++index20)
      {
        long num9 = (long) str3[index20];
        for (int index21 = 0; index21 < 6; ++index21)
        {
          a11 += (Decimal) (Math.Log((double) ((num9 ^ (long) str1[index21]) + 1L), (double) str1[index21]) / (Math.Sin((double) num9) + 1.0));
          b10 += (Decimal) (Math.Pow(Math.Abs(Math.Log((double) ((num9 ^ (long) str1[index21] ^ a1) + 1L), (double) str1[index21]) + (double) num9), 3.0) / ((double) ((int) Math.Pow((double) num9, 2.0) ^ (int) Math.Pow((double) str1[index21], 2.0)) * Math.Sin((double) num9) + 1.0));
        }
      }
      string str14 = str13 + this.df(a11, b10);
      Decimal a12 = 0M;
      Decimal b11 = 0M;
      for (int index = 0; (long) index < length; ++index)
      {
        long num10 = (long) str3[index];
        a12 += (Decimal) Math.Sinh(Math.Pow((double) num10, 1.0 / 3.0));
        b11 += (Decimal) Math.Pow(Math.Sqrt(Math.Cosh(Math.Pow((double) num10, 1.0 / 3.0))), 1.0 / Math.Sqrt((double) num10));
      }
      string str15 = str14 + this.df(a12, b11);
      Decimal a13 = 0M;
      Decimal b12 = 0M;
      for (int index22 = 0; (long) index22 < length; ++index22)
      {
        long num11 = (long) str3[index22];
        a13 += (Decimal) (Math.Sqrt((double) num11) * Math.Pow(Math.Pow((double) num11, 2.0) - (double) num11 + Math.Pow((double) num11, 3.0) + 25.0, (-Math.Sqrt((double) num11) * Math.Cos(8.53973422267357 * (double) num11) + 2.0 * Math.Sin((double) num11)) / (double) num11));
        for (int index23 = 0; index23 < 6; ++index23)
          b12 += (Decimal) Math.Abs((double) num11 * Math.Cos(Math.Log((double) num11, Math.E) / Math.Sqrt(Math.E * (double) str1[index23]) * (double) num11));
      }
      string str16 = str15 + this.df(a13, b12);
      Decimal b13 = 0M;
      Decimal num12 = 0M;
      Decimal num13 = 0M;
      for (int index24 = 0; (long) index24 < length; ++index24)
      {
        long num14 = (long) str3[index24];
        for (int index25 = 0; index25 < 6; ++index25)
          num13 += (Decimal) ((Math.Pow((double) num14, 2.0) + (double) str1[index25] + (double) a1 + (double) num14) / Math.Log(((double) num14 + Math.Pow((double) num14, 2.0) + Math.Pow((double) num14, 3.0)) % Math.Ceiling(Math.Sqrt((double) num14)) + (double) num14, Math.PI * (double) num14));
        b13 += (Decimal) Math.Abs(Math.Asin(Math.Pow((double) num14, 0.196078434586525) - 2.0));
        num12 += (Decimal) Math.Sqrt(Math.Abs(Math.Sin(Math.Sqrt((double) num14)) / Math.Log(9.0, (double) num14) + Math.Cos(Math.Sqrt((double) num14)) / Math.Log((double) num14, Math.E)));
      }
      Decimal a14 = num13 / (num12 + 1M);
      string str17 = str16 + this.df(a14, b13);
      Decimal a15 = 0M;
      Decimal b14 = 0M;
      for (int index = 0; (long) index < length; ++index)
      {
        long num15 = (long) str3[index];
        for (int a16 = (int) num15; (long) a16 < num15 + 6L; ++a16)
          a15 += (Decimal) Math.Abs(Math.Atan(Math.Pow((double) num15, 1.0 / Math.Tan((double) a16))));
        b14 += (Decimal) ((double) (num15 + 3L) - Math.Cos((double) (num15 + 3L)) - ((double) num15 - Math.Cos((double) num15)));
      }
      string str18 = str17 + this.df(a15, b14);
      Decimal a17 = 0M;
      Decimal b15 = 0M;
      for (int index26 = 0; (long) index26 < length; ++index26)
      {
        long num16 = (long) str3[index26];
        for (int index27 = (int) num16 % 10 + 2; (long) index27 < num16; ++index27)
        {
          a17 += (Decimal) (Math.Log(Math.Tanh(Math.Pow((double) index27, 1.0 / (double) num16)), 2.0) / ((Math.Log(1.0 + (Math.Pow((double) index27, 0.125) - 1.0)) - Math.Log(1.0 - (Math.Pow((double) index27, 0.125) - 1.0))) / 2.0 * Math.Sin((double) index27)));
          b15 += (Decimal) Math.Log10(1.0 / (Math.Atan((double) (num16 + 1L)) / Math.Tanh((double) (num16 + 1L)) * (Math.Pow((double) (num16 + 1L), 0.300000011920929) / Math.Cosh((double) (num16 + 1L)))));
        }
      }
      string str19 = str18 + this.df(a17, b15);
      Decimal a18 = 0M;
      Decimal b16 = 0M;
      Decimal num17 = 0M;
      long num18 = 0;
      for (int index28 = 0; index28 < 6; ++index28)
      {
        a18 = 0M;
        for (int index29 = 0; index29 < str3.Length; ++index29)
        {
          long x = (long) str3[index29];
          a18 = a18 + (Decimal) Math.Log((Math.Log10((double) x + Math.Sqrt((double) (x * x - 1L))) + Math.Atan((double) str1[index28])) / Math.Abs(Math.Log(Math.Abs(Math.Asin(Math.Pow((double) x, 0.196078434586525) - 2.0)), (double) str1[index28])) + 25.0, Math.E) + (Decimal) (0.5 * (Math.Pow((double) x, 2.0) + (double) (2L * x) + 2.0) - 0.5 * Math.Pow(0.5 * (double) (x + 1L), 2.0));
        }
        num17 += a18;
      }
      for (int index30 = 0; index30 < str3.Length; ++index30)
      {
        long a19 = (long) str3[index30];
        b16 = 1M;
        for (int index31 = (int) a19; (long) index31 < a19 + 5L; ++index31)
          b16 *= (Decimal) Math.Abs(Math.Asin(Math.Pow(Math.Abs(Math.Sin((double) a19) * (double) index31), 0.196078434586525) - 2.0) + Math.E) + 1M;
        num18 += (long) b16;
      }
      Decimal num19 = num17 / (Decimal) num18 + (Decimal) num18;
      return this.StringToByteArray(str19 + this.df(a18, b16));
    }

    public byte[] subBytes(byte[] word)
    {
      for (int index = 0; index < word.Length; index += 8)
      {
        word[index] = this.SBox[(int) word[index]];
        word[index + 1] = this.SBox[(int) word[index + 1]];
        word[index + 2] = this.SBox[(int) word[index + 2]];
        word[index + 3] = this.SBox[(int) word[index + 3]];
        word[index + 4] = this.SBox[(int) word[index + 4]];
        word[index + 5] = this.SBox[(int) word[index + 5]];
        word[index + 6] = this.SBox[(int) word[index + 6]];
        word[index + 7] = this.SBox[(int) word[index + 7]];
      }
      return word;
    }

    public byte[] invSubBytes(byte[] word)
    {
      for (int index = 0; index < word.Length; index += 8)
      {
        word[index] = this.IBox[(int) word[index]];
        word[index + 1] = this.IBox[(int) word[index + 1]];
        word[index + 2] = this.IBox[(int) word[index + 2]];
        word[index + 3] = this.IBox[(int) word[index + 3]];
        word[index + 4] = this.IBox[(int) word[index + 4]];
        word[index + 5] = this.IBox[(int) word[index + 5]];
        word[index + 6] = this.IBox[(int) word[index + 6]];
        word[index + 7] = this.IBox[(int) word[index + 7]];
      }
      return word;
    }

    public byte[] shiftColumns(byte[] word)
    {
      byte[] numArray1 = new byte[word.Length];
      byte[] numArray2 = new byte[64];
      byte[] numArray3 = new byte[64];
      for (int index1 = 0; index1 < numArray1.Length / 64; ++index1)
      {
        for (int index2 = index1 * 64; index2 < (index1 + 1) * 64; ++index2)
          numArray2[index2 % 64] = word[index2];
        for (int index3 = 0; index3 < 8; ++index3)
        {
          for (int index4 = index3; index4 < 64; index4 += 8)
            numArray3[index3 * 8 + (index4 - index3 * 8)] = numArray2[(index4 + index3 * 8) % 64];
        }
        numArray3.CopyTo((Array) numArray1, index1 * 64);
      }
      return numArray1;
    }

    public byte[] invShiftColumns(byte[] word)
    {
      byte[] numArray1 = new byte[word.Length];
      byte[] numArray2 = new byte[64];
      byte[] numArray3 = new byte[64];
      for (int index1 = 0; index1 < numArray1.Length / 64; ++index1)
      {
        for (int index2 = index1 * 64; index2 < (index1 + 1) * 64; ++index2)
          numArray2[index2 % 64] = word[index2];
        for (int index3 = 0; index3 < 8; ++index3)
        {
          for (int index4 = index3; index4 < 64; index4 += 8)
            numArray3[index3 * 8 + (index4 - index3 * 8)] = numArray2[(64 - Math.Abs(index3 * 8) + index4) % 64];
        }
        numArray3.CopyTo((Array) numArray1, index1 * 64);
      }
      return numArray1;
    }

    public byte[] RU25(byte[] word)
    {
      byte[] numArray1 = new byte[word.Length];
      for (int index1 = 0; index1 < word.Length / 64; ++index1)
      {
        byte[] numArray2 = new byte[64];
        byte[] numArray3 = new byte[64];
        byte[] numArray4 = new byte[16];
        for (int index2 = index1 * 64; index2 < index1 * 64 + 64; ++index2)
          numArray2[index2 - index1 * 64] = word[index2];
        for (int index3 = 0; index3 < 4; ++index3)
        {
          uint num1 = 0;
          uint x1 = 0;
          uint num2 = 0;
          uint x2 = 0;
          for (int index4 = index3 * 2; index4 < index3 * 2 + 4; ++index4)
          {
            int index5 = (index4 - index3 * 2) * 8 + index3 * 2;
            int num3 = (3 - (index4 - index3 * 2)) * 8;
            num1 |= (uint) numArray2[index5] << num3;
            x1 |= (uint) numArray2[index5 + 1] << num3;
            num2 |= (uint) numArray2[index5 + 32] << num3;
            x2 |= (uint) numArray2[index5 + 33] << num3;
          }
          uint num4 = this.lshift(x1, 19);
          uint num5 = this.lshift(x2, 9);
          uint x3 = this.lshift(num2 ^ num4 ^ num5, 5);
          uint num6 = this.lshift(num1 ^ num4 ^ this.lshift(x3, 1), 3);
          uint x4 = num4 ^ num6 ^ this.lshift(x3, 13);
          uint x5 = num5 ^ num6 ^ this.lshift(x3, 7);
          uint num7 = this.lshift(x4, 25);
          uint num8 = this.lshift(x5, 11);
          for (int index6 = 0; index6 < 4; ++index6)
          {
            numArray4[index6] = (byte) (num6 >> (3 - index6) * 8);
            numArray4[index6 + 4] = (byte) (num7 >> (3 - index6) * 8);
            numArray4[index6 + 8] = (byte) (x3 >> (3 - index6) * 8);
            numArray4[index6 + 12] = (byte) (num8 >> (3 - index6) * 8);
          }
          numArray4.CopyTo((Array) numArray3, index3 * 16);
        }
        numArray3.CopyTo((Array) numArray1, index1 * 64);
      }
      return numArray1;
    }

    public byte[] invRU25(byte[] word)
    {
      byte[] numArray1 = new byte[word.Length];
      byte[] numArray2 = new byte[64];
      byte[] numArray3 = new byte[16];
      for (int index1 = 0; index1 < word.Length / 64; ++index1)
      {
        byte[] numArray4 = new byte[64];
        for (int index2 = index1 * 64; index2 < index1 * 64 + 64; ++index2)
          numArray4[index2 - index1 * 64] = word[index2];
        for (int index3 = 0; index3 < 4; ++index3)
        {
          uint x1 = 0;
          uint x2 = 0;
          uint x3 = 0;
          uint x4 = 0;
          for (int index4 = 0; index4 < 4; ++index4)
          {
            int num = (3 - index4) * 8;
            x1 |= (uint) numArray4[index3 * 16 + index4] << num;
            x2 |= (uint) numArray4[index3 * 16 + index4 + 4] << num;
            x3 |= (uint) numArray4[index3 * 16 + index4 + 8] << num;
            x4 |= (uint) numArray4[index3 * 16 + index4 + 12] << num;
          }
          uint num1 = this.rshift(x4, 11);
          uint num2 = this.rshift(x2, 25);
          uint x5 = num1 ^ x1 ^ this.lshift(x3, 7);
          uint x6 = num2 ^ x1 ^ this.lshift(x3, 13);
          uint num3 = this.rshift(x1, 3) ^ x6 ^ this.lshift(x3, 1);
          uint num4 = this.rshift(x3, 5) ^ x6 ^ x5;
          uint num5 = this.rshift(x5, 9);
          uint num6 = this.rshift(x6, 19);
          for (int index5 = 0; index5 < 4; ++index5)
          {
            numArray3[index5] = (byte) (num3 >> (3 - index5) * 8);
            numArray3[index5 + 4] = (byte) (num6 >> (3 - index5) * 8);
            numArray3[index5 + 8] = (byte) (num4 >> (3 - index5) * 8);
            numArray3[index5 + 12] = (byte) (num5 >> (3 - index5) * 8);
          }
          numArray3.CopyTo((Array) numArray2, index3 * 16);
        }
        byte[] numArray5 = new byte[64];
        for (int index6 = 0; index6 < 4; ++index6)
        {
          for (int index7 = index6 * 2; index7 < index6 * 2 + 4; ++index7)
          {
            int index8 = (index7 - index6 * 2) * 8 + index6 * 2;
            numArray5[index8] = numArray2[index6 * 16 + (index7 - index6 * 2)];
            numArray5[index8 + 1] = numArray2[index6 * 16 + (index7 - index6 * 2) + 4];
            numArray5[index8 + 32] = numArray2[index6 * 16 + (index7 - index6 * 2) + 8];
            numArray5[index8 + 33] = numArray2[index6 * 16 + (index7 - index6 * 2) + 12];
          }
        }
        numArray5.CopyTo((Array) numArray1, index1 * 64);
      }
      return numArray1;
    }

    private uint lshift(uint x, int s) => x << s | x >> 32 - s;

    private uint rshift(uint x, int s) => x >> s | x << 32 - s;

    private byte[] StringToByteArray(string hex)
    {
      byte[] byteArray = new byte[hex.Length / 2];
      for (int index1 = 0; index1 < hex.Length; index1 += 2)
      {
        byte[] numArray = byteArray;
        int index2 = index1 / 2;
        char ch = hex[index1];
        string str1 = ch.ToString();
        ch = hex[index1 + 1];
        string str2 = ch.ToString();
        int int32 = (int) (byte) Convert.ToInt32(str1 + str2, 16);
        numArray[index2] = (byte) int32;
      }
      return byteArray;
    }

    private string df(Decimal a, Decimal b)
    {
      int y1 = (int) BitConverter.GetBytes(Decimal.GetBits(a)[3])[2];
      a *= (Decimal) (int) Math.Pow(10.0, (double) y1);
      int y2 = (int) BitConverter.GetBytes(Decimal.GetBits(b)[3])[2];
      b *= (Decimal) (int) Math.Pow(10.0, (double) y2);
      char[] charArray = ((ulong) Math.Abs(a) ^ (ulong) Math.Abs(b)).ToString("X8").ToCharArray();
      string str = "";
      for (int index = 1; index < 9; ++index)
      {
        try
        {
          str += charArray[index].ToString();
        }
        catch
        {
          str += "0";
        }
      }
      return Math.Abs(Convert.ToInt32(str, 16)).ToString("X8");
    }
  }
}
