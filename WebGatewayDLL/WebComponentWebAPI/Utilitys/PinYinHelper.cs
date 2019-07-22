using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WebComponentWebAPI.Utilitys
{
    /// <summary>
    /// 拼音帮助类
    /// </summary>
    public class PinYinHelper
    {
        private static ConcurrentDictionary<string, string> _YingWenToPinYin_Result;

        private static ConcurrentDictionary<string, List<string>> _ZhToPinYinList_Result;

        private static ConcurrentDictionary<string, string> _NumberToZi_Result;

        private static ConcurrentDictionary<string, string> _GetNumberPinYin_Result;

        private static ConcurrentDictionary<string, string> YingWenToPinYin_Result
        {
            get
            {
                if (_YingWenToPinYin_Result == null)
                {
                    _YingWenToPinYin_Result = new ConcurrentDictionary<string, string>();
                }
                return _YingWenToPinYin_Result;
            }
        }

        private static ConcurrentDictionary<string, List<string>> ZhToPinYinList_Result
        {
            get
            {
                if (_ZhToPinYinList_Result == null)
                {
                    _ZhToPinYinList_Result = new ConcurrentDictionary<string, List<string>>();
                }
                return _ZhToPinYinList_Result;
            }
        }

        private static ConcurrentDictionary<string, string> NumberToZi_Result
        {
            get
            {
                if (_NumberToZi_Result == null)
                {
                    _NumberToZi_Result = new ConcurrentDictionary<string, string>();
                }
                return _NumberToZi_Result;
            }
        }

        private static ConcurrentDictionary<string, string> GetNumberPinYin_Result
        {
            get
            {
                if (_GetNumberPinYin_Result == null)
                {
                    _GetNumberPinYin_Result = new ConcurrentDictionary<string, string>();
                }
                return _GetNumberPinYin_Result;
            }
        }

        private static string YingWenToPinYin(string str)
        {
            if (YingWenToPinYin_Result.ContainsKey(str))
            {
                return YingWenToPinYin_Result[str];
            }
            string text = "";
            string text2 = Regex.Replace(str.Trim().ToUpper(), "\\s", "");
            for (int i = 0; i < text2.Length; i++)
            {
                if (i != 0 && (text2[i] == 'A' || text2[i] == 'O' || text2[i] == 'E' || text2[i] == 'I' || text2[i] == 'U' || text2[i] == 'V') && text2[i - 1] != 'A' && text2[i - 1] != 'O' && text2[i - 1] != 'E' && text2[i - 1] != 'I' && text2[i - 1] != 'U' && text2[i - 1] != 'V')
                {
                    text += text2[i].ToString();
                }
                else if (i != 0 && text2[i] == 'G' && text2[i - 1] == 'N' && i + 1 == text2.Length)
                {
                    text += text2[i].ToString();
                }
                else
                {
                    if (i > 0 && i < text2.Length - 1 && text2[i] == 'G')
                    {
                        if (text2[i - 1] == 'N' && text2[i + 1] != 'A' && text2[i + 1] != 'O' && text2[i + 1] != 'E' && text2[i + 1] != 'I' && text2[i + 1] != 'U' && text2[i + 1] != 'V')
                        {
                            text += text2[i].ToString();
                            continue;
                        }
                        if (text2[i + 1] == 'A' || text2[i + 1] == 'O' || text2[i + 1] == 'E' || text2[i + 1] == 'I' || text2[i + 1] == 'U' || text2[i + 1] == 'V')
                        {
                            text = text + "'" + text2[i].ToString();
                            continue;
                        }
                    }
                    if (i > 0 && i < text2.Length - 1 && text2[i] == 'N')
                    {
                        if (text2[i - 1] != 'A' && text2[i - 1] != 'O' && text2[i - 1] != 'E' && text2[i - 1] != 'I' && text2[i - 1] != 'U' && text2[i - 1] != 'V')
                        {
                            text = text + "'" + text2[i].ToString();
                            continue;
                        }
                        if (text2[i + 1] != 'A' && text2[i + 1] != 'O' && text2[i + 1] != 'E' && text2[i + 1] != 'I' && text2[i + 1] != 'U' && text2[i + 1] != 'V')
                        {
                            text += text2[i].ToString();
                            continue;
                        }
                    }
                    text = text + "'" + text2[i].ToString();
                }
            }
            text = text.Replace("I'U", "IU");
            text = text.Replace("I'E", "IE");
            text = text.Replace("U'E", "UE");
            text = text.Replace("E'R", "ER");
            text = text.Replace("A'I", "AI");
            text = text.Replace("E'I", "EI");
            text = text.Replace("U'I", "UI");
            text = text.Replace("A'O", "AO");
            text = text.Replace("O'U", "OU");
            text = text.Replace("U'O", "UO");
            text = text.Replace("Z'H", "ZH");
            text = text.Replace("C'H", "CH");
            text = text.Replace("S'H", "SH");
            text = text.Replace("A'N", "AN");
            text = text.Replace("I'A", "IA");
            text = text.Replace("E'N", "EN");
            text = text.Replace("U'N", "UN");
            text = text.Replace("V'N", "VN");
            text = text.Replace("O'N", "ON");
            text = text.Replace("U'A", "UA");
            text = text.Replace("I'N", "IN");
            text = text.Replace("I'AN", "IAN");
            text = text.Replace("U'AN", "UAN");
            text = text.Replace("I'ANG", "IANG");
            while (text.Contains("''"))
            {
                text = text.Replace("''", "'");
            }
            if (text.Length > 0 && text.Last() == '\'')
            {
                text = text.Remove(text.Length - 1);
            }
            YingWenToPinYin_Result[str] = text;
            return text;
        }

        public static List<string> ZhToPinYinList(string str)
        {
            if (ZhToPinYinList_Result.ContainsKey(str))
            {
                return ZhToPinYinList_Result[str];
            }
            List<string> list = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                List<string> list2 = null;
                if (Regex.IsMatch(str[i].ToString(CultureInfo.InvariantCulture), "[\\u4e00-\\u9fa5]+$"))
                {
                    list2 = ToPinYinList(str[i]);
                }
                else if ((str[i] >= '0' && str[i] <= '9') || (str[i] >= '０' && str[i] <= '９'))
                {
                    string text = "";
                    for (; i < str.Length && ((str[i] >= '0' && str[i] <= '9') || (str[i] >= '０' && str[i] <= '９')); i++)
                    {
                        if (str[i] >= '0' && str[i] <= '9')
                        {
                            text += str[i].ToString();
                        }
                        else if (str[i] >= '０' && str[i] <= '９')
                        {
                            text += Convert.ToChar(str[i] - 65296 + 48).ToString();
                        }
                    }
                    i--;
                    string text2 = NumberToZi(text);
                    list2 = new List<string>();
                    for (int j = 0; j < text2.Length; j++)
                    {
                        list2.AddRange(ToPinYinList(text2[j]));
                    }
                }
                else if ((str[i] >= 'ａ' && str[i] <= 'ｚ') || (str[i] >= 'Ａ' && str[i] <= 'Ｚ') || (str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
                {
                    string text3 = "";
                    for (; i < str.Length && ((str[i] >= 'ａ' && str[i] <= 'ｚ') || (str[i] >= 'Ａ' && str[i] <= 'Ｚ') || (str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z')); i++)
                    {
                        if (str[i] >= 'ａ' && str[i] <= 'ｚ')
                        {
                            text3 += Convert.ToChar(str[i] - 65345 + 65).ToString();
                        }
                        else if (str[i] >= 'Ａ' && str[i] <= 'Ｚ')
                        {
                            text3 += Convert.ToChar(str[i] - 65313 + 65).ToString();
                        }
                        else if (str[i] >= 'A' && str[i] <= 'Z')
                        {
                            text3 += str[i].ToString();
                        }
                        else if (str[i] >= 'a' && str[i] <= 'z')
                        {
                            text3 += str[i].ToString(CultureInfo.InvariantCulture).ToUpper();
                        }
                    }
                    i--;
                    list2 = new List<string>
                    {
                        text3
                    };
                }
                if (list2 != null)
                {
                    for (int k = 0; k < list2.Count; k++)
                    {
                        list2[k] += "'";
                    }
                    list = ((list.Count == 0) ? list2 : GetUnion(list, list2));
                }
            }
            list = (list ?? new List<string>());
            list = (from r in list
                    select YingWenToPinYin(r)).ToList();
            ZhToPinYinList_Result[str] = list;
            return list;
        }

        private static List<string> ToPinYinList(char chr)
        {
            if (ChineseChar.IsValidChar(chr))
            {
                ChineseChar chineseChar = new ChineseChar(chr);
                List<string> list = new List<string>();
                for (int i = 0; i < chineseChar.PinyinCount; i++)
                {
                    string item = chineseChar.Pinyins[i].Substring(0, chineseChar.Pinyins[i].Length - 1);
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
            return null;
        }

        private static string NumberToZi(string number)
        {
            if (NumberToZi_Result.ContainsKey(number))
            {
                return NumberToZi_Result[number];
            }
            if (number.Length > 10)
            {
                number = number.Substring(0, 10);
            }
            string[] array = new string[12]
            {
                "",
                "十",
                "百",
                "千",
                "万",
                "十",
                "百",
                "千",
                "亿",
                "十",
                "百",
                "千"
            };
            string text = "";
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != '0' || text.Length <= 1 || text[text.Length - 1] != "零一二三四五六七八九"[0])
                {
                    text += "零一二三四五六七八九"[number[i] - 48].ToString();
                    if (number[i] != '0')
                    {
                        text += array[number.Length - i - 1];
                    }
                }
            }
            if (text.Length > 1 && text[text.Length - 1] == "零一二三四五六七八九"[0])
            {
                text = text.Substring(0, text.Length - 1);
            }
            text = text.Replace("一十", "十");
            NumberToZi_Result[number] = text;
            return text;
        }

        private static List<string> GetUnion(List<string> list1, List<string> list2)
        {
            List<string> list3 = new List<string>();
            foreach (string item in list1)
            {
                list3.AddRange(from t1 in list2
                               select item + t1);
            }
            return list3;
        }

        public static string GetNumberPinYin(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            if (GetNumberPinYin_Result.ContainsKey(name))
            {
                return GetNumberPinYin_Result[name];
            }
            string text = "";
            List<string> list = new List<string>();
            for (int i = 0; i < name.Length; i++)
            {
                if ((name[i] >= '0' && name[i] <= '9') || (name[i] >= '０' && name[i] <= '９'))
                {
                    text += name[i].ToString();
                }
                if ((i == name.Length - 1 || ((name[i + 1] < '0' || name[i + 1] > '9') && (name[i + 1] < '０' || name[i + 1] > '９'))) && !string.IsNullOrEmpty(text))
                {
                    list.Add(text);
                    text = "";
                }
            }
            string text2 = name;
            foreach (string item in list)
            {
                text2 = text2.Replace(item, NumberToZi(item));
            }
            GetNumberPinYin_Result[name] = text2;
            return text2;
        }
    }
}

