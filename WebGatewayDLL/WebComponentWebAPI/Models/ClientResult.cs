using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentWebAPI.Models
{
    public class ClientResult
    {
        public int flag { get; set; }
        public object data { get; set; }
        public string debug { get; set; }

        public static ClientResult Ok(object Result)
        {
            return new ClientResult
            {
                flag = 1,
                data = Result,
                debug = ""
            };
        }
        public static ClientResult Error(string Result)
        {
            return new ClientResult
            {
                flag = 0,
                data = "",
                debug = Result
            };
        }
    }
}
