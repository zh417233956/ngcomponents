using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WebComponentWebAPI.Models;

namespace WebComponentWebAPI.Utilitys
{
    /// <summary>
    /// 拼音文字库帮助类
    /// </summary>
    public class PinYinLibraryHelper
    {
        public List<PinYinResult> GetPinYinAndHanZiResult(List<PinYinSource> pinyinSourceList, string searchText, int pageSize, out int count, int page = 1, bool isDebug = false)
        {
            try
            {
                string typeString = "UserSelectionData";
                #region 初始化数据构造
                string error = "";
                SetHanZi(typeString, pinyinSourceList, ref error);
                SetPinYin(typeString, pinyinSourceList, ref error);
                SetFirstPinYin(typeString, pinyinSourceList, ref error);
                #endregion

                if (page < 1)
                {
                    page = 1;
                }
                List<PinYinResult> list = new List<PinYinResult>();
                int.TryParse(searchText, out int _);
                if (searchText.Length < 2 && !Regex.IsMatch(searchText, "[\\u4e00-\\u9fa5]+$"))
                {
                    count = 0;
                    return new List<PinYinResult>();
                }
                searchText = PinYinHelper.GetNumberPinYin(searchText);
                list.AddRange(GetHanzi(typeString, searchText));
                list.AddRange(GetPinYin(typeString, searchText));
                list.AddRange(GetFirstPinYin(typeString, searchText));
                List<PinYinResult> list2 = new List<PinYinResult>();
                for (int i = 0; i < list.Count; i++)
                {
                    PinYinResult yinSoResult = list[i];
                    PinYinResult pinYinResult = list2.FirstOrDefault((PinYinResult e) => e.ID == yinSoResult.ID);
                    if (pinYinResult == null)
                    {
                        list2.Add(yinSoResult);
                    }
                    else
                    {
                        pinYinResult.Contrast += yinSoResult.Contrast;
                        if (isDebug)
                        {
                            PinYinResult pinYinResult2 = pinYinResult;
                            pinYinResult2.Debug = pinYinResult2.Debug + "; " + yinSoResult.Debug;
                        }
                        else
                        {
                            pinYinResult.Debug = "";
                        }
                    }
                }
                count = list2.Count;
                return (from u in list2
                        orderby u.Contrast descending, u.Name.Length, u.Name
                        select u).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                //var logStr= "拼音日志", "typestring=" + typeString + "<span style='color:red'>错误:获取拼音结果出现错误! HanZiList.Count=" + HanZiListAll[typeString].Count + "&PinYinList.Count=" + PinYinListAll[typeString].Count + "&FirstPinYinList.Count=" + FirstPinYinListAll[typeString].Count + "</span>";
                throw ex;
            }
        }

        #region 辅助方法 处理汉字
        private ConcurrentDictionary<string, List<CacheFirstPinYin>> _HanZiListAll;
        private ConcurrentDictionary<string, List<CacheFirstPinYin>> HanZiListAll
        {
            get
            {
                if (_HanZiListAll == null)
                {
                    _HanZiListAll = new ConcurrentDictionary<string, List<CacheFirstPinYin>>();
                }
                return _HanZiListAll;
            }
        }
        private List<PinYinResult> GetHanzi(string typeString, string name)
        {
            List<PinYinResult> list = new List<PinYinResult>();
            for (int j = 0; j < HanZiListAll[typeString].Count; j++)
            {
                CacheFirstPinYin cacheFirstPinYin;
                try
                {
                    cacheFirstPinYin = HanZiListAll[typeString][j];
                }
                catch
                {
                    continue;
                }
                if (cacheFirstPinYin != null && cacheFirstPinYin.SearchList != null && cacheFirstPinYin.SearchList.Any((string s) => s == name))
                {
                    list.Add(new PinYinResult
                    {
                        ID = cacheFirstPinYin.ID,
                        Name = cacheFirstPinYin.Name,
                        Contrast = 40,
                        Debug = "相等汉字" + 40
                    });
                }
            }
            string text = name;
            foreach (char i in text)
            {
                for (int l = 0; l < HanZiListAll[typeString].Count; l++)
                {
                    CacheFirstPinYin cacheFirstPinYin2;
                    try
                    {
                        cacheFirstPinYin2 = HanZiListAll[typeString][l];
                    }
                    catch
                    {
                        continue;
                    }
                    if (cacheFirstPinYin2 != null && cacheFirstPinYin2.SearchList != null && cacheFirstPinYin2.SearchList.Any((string s) => s.Count((char c) => c == i) == name.Count((char c) => c == i)))
                    {
                        list.Add(new PinYinResult
                        {
                            ID = cacheFirstPinYin2.ID,
                            Name = cacheFirstPinYin2.Name,
                            Contrast = 40,
                            Debug = "包含汉字" + 40
                        });
                        int num = cacheFirstPinYin2.SearchList.Min((string s) => s.IndexOf(i));
                        list.Add(new PinYinResult
                        {
                            ID = cacheFirstPinYin2.ID,
                            Name = cacheFirstPinYin2.Name,
                            Contrast = num * -1 * 2,
                            Debug = "汉字位置" + num * -1 * 2
                        });
                        for (int m = 0; m < name.Length - 1; m++)
                        {
                            string value = name[m].ToString() + name[m + 1].ToString();
                            if (cacheFirstPinYin2.Name.Contains(value))
                            {
                                list.Add(new PinYinResult
                                {
                                    ID = cacheFirstPinYin2.ID,
                                    Name = cacheFirstPinYin2.Name,
                                    Contrast = 15,
                                    Debug = "汉字连续" + 15
                                });
                            }
                        }
                    }
                }
            }
            return list;
        }

        private void SetHanZi(string typeString, List<PinYinSource> pinyinList, ref string error)
        {
            try
            {
                HanZiListAll[typeString] = new List<CacheFirstPinYin>();
                for (int i = 0; i < pinyinList.Count; i++)
                {
                    PinYinSource pinYinSource = pinyinList[i];
                    string name = pinYinSource.Name;
                    name = PinYinHelper.GetNumberPinYin(name);
                    CacheFirstPinYin cacheFirstPinYin = new CacheFirstPinYin();
                    cacheFirstPinYin.ID = pinYinSource.ID;
                    cacheFirstPinYin.Name = pinYinSource.Name;
                    cacheFirstPinYin.SearchList = new List<string>
                    {
                        pinYinSource.Name
                    };
                    if (name != pinYinSource.Name)
                    {
                        cacheFirstPinYin.SearchList.Add(name);
                    }
                    HanZiListAll[typeString].Add(cacheFirstPinYin);
                }
            }
            catch (Exception)
            {
                //LogHelper.WriteCustom("拼音日志", "typestring=" + typeString + "<span style='color:red'>错误:SetHanZi方法错误!count=" + HanZiListAll[typeString].Count + "</span>", 2, ex);
                error = error + "  SetHanZi方法错误!count=" + HanZiListAll[typeString].Count;
            }
        }

        #endregion 辅助方法 处理汉字

        #region 辅助方法 汉字转拼音
        private ConcurrentDictionary<string, List<CacheFirstPinYin>> _PinYinListAll;
        private ConcurrentDictionary<string, List<CacheFirstPinYin>> PinYinListAll
        {
            get
            {
                if (_PinYinListAll == null)
                {
                    _PinYinListAll = new ConcurrentDictionary<string, List<CacheFirstPinYin>>();
                }
                return _PinYinListAll;
            }
        }

        private List<PinYinResult> GetPinYin(string typeString, string hanziName)
        {
            List<string> list = PinYinHelper.ZhToPinYinList(hanziName);
            List<PinYinResult> list2 = new List<PinYinResult>();
            foreach (string item in list)
            {
                for (int j = 0; j < PinYinListAll[typeString].Count; j++)
                {
                    CacheFirstPinYin cacheFirstPinYin;
                    try
                    {
                        cacheFirstPinYin = PinYinListAll[typeString][j];
                    }
                    catch
                    {
                        continue;
                    }
                    if (cacheFirstPinYin != null && cacheFirstPinYin.SearchList != null && cacheFirstPinYin.SearchList.Any((string s) => s == item))
                    {
                        list2.Add(new PinYinResult
                        {
                            ID = cacheFirstPinYin.ID,
                            Name = cacheFirstPinYin.Name,
                            Contrast = 35,
                            Debug = "拼音相等" + 35
                        });
                    }
                }
                string[] nameArray = (from p in item.Split('\'')
                                      where p != ""
                                      select p).ToArray();
                string[] array = nameArray;
                foreach (string i in array)
                {
                    for (int l = 0; l < PinYinListAll[typeString].Count; l++)
                    {
                        CacheFirstPinYin cacheFirstPinYin2;
                        try
                        {
                            cacheFirstPinYin2 = PinYinListAll[typeString][l];
                        }
                        catch
                        {
                            continue;
                        }
                        if (cacheFirstPinYin2 != null && cacheFirstPinYin2.SearchList != null && cacheFirstPinYin2.SearchList.Any((string s) => s.Split('\'').Count((string c) => c == i) == nameArray.Count((string c) => c == i)))
                        {
                            list2.Add(new PinYinResult
                            {
                                ID = cacheFirstPinYin2.ID,
                                Name = cacheFirstPinYin2.Name,
                                Contrast = 35,
                                Debug = "拼音包含字符" + 35
                            });
                            int num = cacheFirstPinYin2.SearchList.Min((string s) => s.IndexOf(i));
                            list2.Add(new PinYinResult
                            {
                                ID = cacheFirstPinYin2.ID,
                                Name = cacheFirstPinYin2.Name,
                                Contrast = num * -1,
                                Debug = "拼音位置" + num * -1
                            });
                            for (int m = 0; m < nameArray.Length - 1; m++)
                            {
                                string lianxu = nameArray[m] + nameArray[m + 1];
                                if (cacheFirstPinYin2.SearchList.Any((string s) => s.Replace("'", "").Contains(lianxu)))
                                {
                                    list2.Add(new PinYinResult
                                    {
                                        ID = cacheFirstPinYin2.ID,
                                        Name = cacheFirstPinYin2.Name,
                                        Contrast = 15,
                                        Debug = "拼音连续" + 15
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return list2;
        }

        private void SetPinYin(string typeString, List<PinYinSource> pinyinSourceList, ref string error)
        {
            try
            {
                PinYinListAll[typeString] = new List<CacheFirstPinYin>();
                for (int i = 0; i < pinyinSourceList.Count; i++)
                {
                    PinYinSource pinYinSource = pinyinSourceList[i];
                    string name = pinYinSource.Name;
                    name = PinYinHelper.GetNumberPinYin(name);
                    List<string> searchList = PinYinHelper.ZhToPinYinList(name);
                    CacheFirstPinYin cacheFirstPinYin = new CacheFirstPinYin();
                    cacheFirstPinYin.ID = pinYinSource.ID;
                    cacheFirstPinYin.Name = pinYinSource.Name;
                    cacheFirstPinYin.SearchList = searchList;
                    PinYinListAll[typeString].Add(cacheFirstPinYin);
                }
            }
            catch (Exception)
            {
                //LogHelper.WriteCustom("拼音日志", "typestring=" + typeString + "<span style='color:red'>错误:SetPinYin方法错误!count=" + PinYinListAll[typeString].Count + "</span>", 2, ex);
                error = error + "  SetPinYin方法错误!count=" + PinYinListAll[typeString].Count;
            }
        }


        #endregion 辅助方法 汉字转拼音

        #region 辅助方法 获取首字母
        private ConcurrentDictionary<string, List<CacheFirstPinYin>> _FirstPinYinListAll;
        private ConcurrentDictionary<string, List<CacheFirstPinYin>> FirstPinYinListAll
        {
            get
            {
                if (_FirstPinYinListAll == null)
                {
                    _FirstPinYinListAll = new ConcurrentDictionary<string, List<CacheFirstPinYin>>();
                }
                return _FirstPinYinListAll;
            }
        }
        private List<PinYinResult> GetFirstPinYin(string typeString, string name)
        {
            List<string> first = GetFirst(name);
            if (first == null)
            {
                return new List<PinYinResult>();
            }
            IEnumerable<CacheFirstPinYin> source = from f in (from py in first
                                                              where py != null
                                                              select py).SelectMany((string py) => from f in FirstPinYinListAll[typeString]
                                                                                                   where f != null && f.SearchList != null && (from s in f.SearchList
                                                                                                                                               where s != null
                                                                                                                                               select s).Any((string s) => s.Contains(py))
                                                                                                   select new
                                                                                                   {
                                                                                                       Value = f,
                                                                                                       MinIndex = f.SearchList.Min((string s) => s.IndexOf(py))
                                                                                                   })
                                                   orderby f.MinIndex
                                                   select f.Value;
            return (from l in source
                    group l by new
                    {
                        l.ID,
                        l.Name
                    } into f
                    select new PinYinResult
                    {
                        ID = f.Key.ID,
                        Name = f.Key.Name,
                        Contrast = 20,
                        Debug = "首字母" + 20
                    }).ToList();
        }
        private List<string> GetFirst(string name)
        {
            List<string> source = PinYinHelper.ZhToPinYinList(name);
            return (from pinyin in source
                    select (from p in pinyin.Split('\'')
                            where p != ""
                            select p).Aggregate("", (string current, string py) => current + py[0].ToString())).ToList();
        }
        private void SetFirstPinYin(string typeString, List<PinYinSource> pinyinSourceList, ref string error)
        {
            try
            {
                FirstPinYinListAll[typeString] = new List<CacheFirstPinYin>();
                for (int i = 0; i < pinyinSourceList.Count; i++)
                {
                    PinYinSource pinYinSource = pinyinSourceList[i];
                    string name = pinYinSource.Name;
                    name = PinYinHelper.GetNumberPinYin(name);
                    CacheFirstPinYin cacheFirstPinYin = new CacheFirstPinYin();
                    cacheFirstPinYin.ID = pinYinSource.ID;
                    cacheFirstPinYin.Name = pinYinSource.Name;
                    cacheFirstPinYin.SearchList = GetFirst(name);
                    FirstPinYinListAll[typeString].Add(cacheFirstPinYin);
                }
            }
            catch (Exception)
            {
                //LogHelper.WriteCustom("拼音日志", "typestring=" + typeString + "<span style='color:red'>错误:  SetFirstPinYin方法错误!count = " + FirstPinYinListAll[typeString].Count + "</span>", 2, ex);
                error = error + "  SetFirstPinYin方法错误!count=" + FirstPinYinListAll[typeString].Count;
            }
        }

        #endregion 辅助方法 获取首字母
    }
}
