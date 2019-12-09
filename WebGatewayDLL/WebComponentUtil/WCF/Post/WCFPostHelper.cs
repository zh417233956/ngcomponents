using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WebComponentUtil.Utilitys;
using WebComponentUtil.WCF.Models;

namespace WebComponentUtil.WCF.Post
{
    public static class WCFPostHelper
    {
        /// <summary>
        /// 网络请求
        /// </summary>
        /// <param name="EntityName"></param>
        /// <param name="Method"></param>
        /// <param name="RemoteAddress"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Post(string RemoteAddress, string content)
        {
            var headers = new Dictionary<string, string>();
            var result = HttpClientHelper.HttpPost(RemoteAddress, content, "text/xml", 60);
            return result;
        }

        /// <summary>
        /// 网络请求
        /// </summary>
        /// <param name="EntityName"></param>
        /// <param name="Method"></param>
        /// <param name="RemoteAddress"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static DefaultResult<T> Post<T>(string EntityName, string Method, string RemoteAddress, string content)
        {
            var result = Post(RemoteAddress, content);
            
            var resObj = new DefaultResult<T>();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);//Load加载XML文件，LoadXML加载XML字符串
                XmlElement root = xmlDoc.DocumentElement;
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);

                XmlNode xnode = root.FirstChild;
                var values = xnode.ChildNodes[0].LastChild.ChildNodes;

              
                resObj.Debug = values[1].LastChild.Value;
                resObj.RETData = values[3].LastChild.Value;
                resObj.RetInt = int.Parse(values[4].LastChild.Value);
                resObj.RunTime = double.Parse(values[5].LastChild.Value);
            }
            catch (Exception)
            {
            }
            return resObj;
        }

        /*
         * 
         <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
            <s:Body>
            <GetIdListLockResponse xmlns="http://tempuri.org/">
                <GetIdListLockResult xmlns:a="http://schemas.datacontract.org/2004/07/TT.Common.Frame.Model" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                <a:Data i:nil="true" />
                <a:Debug>dEBQtXrHbQ6A5RdUlZOLK%2BHPxDZ7BokX59dbOpCm9hSEeBfrdsVEsIe%2BjcoqCor%2B4C8EPBJ0Mk3%2BT/e8/evvcCMS/NcJPR00tMb3lWpzEV8k767Z3g9Ar%2B5PCeO1Vu79Un3m87ZPxPodX%2BaayCR1I3yI/FnACrE5RwKbVZ8iU4gh5xA6WteUp2Zvhb3fTrX2Ern3N4UBYxriE4yqB4e6Pfjis/mz27iYg/IPw1TqDzrlnlyABxwehpcWG0hnFbTRNluuFLWHTegqaE5Zzj9XCleKSCdCUJfCtsOnAeUXgiiskU58VVcc9o9ewLtmjWKNewUTa/7T%2BOiCAxxynAelhK9fUCCu2oVmfxdD%2BdjMU6HVIxugNhSqB7JN6/oq7vGrHKtr5wRd6gv9RWug/Xxw6%2B0mVBFBYTherMg2I/%2B/CGUmEKvAshCpL4KXauoJKS9UWfO8qcqTr%2BErlCNOb2gqImgpcJ3l3ZH80ktry3rZ6oWAQ22weoEnzXraGH7R76Agk3oRbWkOFaI9cmlUDc93lhIGYVdyGk%2B3Y2jIbpGluHgPKnUtPHmUgd%2B0JMQk/ccr1sSZ0lRbtwF2CmlLtKPgIMm3eN9stR1aXdM7jlLUPxvVrNkWVVh9zOIbC3h%2BOhQnOd5OGA1GPw/9bGXXaKj7n2DgxCgS8J/fAYvWUX0wmeH7LQFnBSiHKJonRfUoerTWiDuALP1M5tzhCO4yckAu%2B08qMQktVB9XmKthd9Fo77Y1HRl5RTAH95O9gp1LvuHh1mYqv2Io4M24MJyNWkWU1JkGOrP0zZERypHmvq5yfilupDVdsByg7e/CXF4HYryWUpRpt9N97BLsOjUhT0I=</a:Debug>
                <a:Key i:nil="true" />
                <a:RETData>dEBQtXrHbQ6A5RdUlZOLK%2BHPxDZ7BqX0ARB9%2BZPcFIM31MZ2wBK/hBlskY460RQE6xuiXx62yFCJ7QuRK0OP4ZMtYlWI6h/vip3NzYTOq2FZSkDtXQc%2Br598NkTOXrN/1zM/ZgJ3RC49lkmy165vL5oBPHLasBsWidYAZeG6bDqjjcvTsky8W4BpVBjIPc1ejS2cY/QuQ9L9UYpJ%2B1tI%2BOm2dM%2BkxbDKTBMEV59SR4r1u%2BCzDYm6nYDkcCnXD5xBWi3v6Rs9wjQepJohl2Jw5u3/JkPxCF3DdJ06ZGMwuGnoz6VtKU1LSIWR6w2n8caP5cYR%2Bq5v0Srvosp6GuRBuDNvqFvu3L9dvEOEC3OLHF0UkPWZCTCtnv7tnaZylwnjk9gRZ1tun9rHJDJ1SUHs2V%2B6zqMetJixh5Bhy/iSOXqmWB57d1C6yVPb2cG7kdq0VZBbPFyU881BvO3DSv0=</a:RETData>
                <a:RetInt>76</a:RetInt>
                <a:RunTime>18.5018</a:RunTime>
                </GetIdListLockResult>
            </GetIdListLockResponse>
            </s:Body>
        </s:Envelope>

         */
    }
}
