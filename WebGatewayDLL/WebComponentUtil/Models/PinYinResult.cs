using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentUtil.Models
{
    [Serializable]
    public class PinYinResult : PinYinSource
    {
        public int Contrast
        {
            get;
            set;
        }

        public string Debug
        {
            get;
            set;
        }
    }
    [Serializable]
    public class CacheFirstPinYin : PinYinSource
    {
        public List<string> SearchList
        {
            get;
            set;
        }
    }
    [Serializable]
    public class PinYinSource
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

}
