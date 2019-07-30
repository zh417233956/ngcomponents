using System;
using System.Collections.Generic;
using System.Text;
using WebComponentWebAPI.ConfigCenter;
using WebComponentWebAPI.Utilitys;
using WebComponentWebAPI.WCF.Models;

namespace WebComponentWebAPI.WCF.Post
{
    public class WCFService<Entity> : IWCFService<Entity>
    {
        ICCHelper _ccHelper;
        Config config;

        private string Xml_Body_Temp= "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><{0} xmlns=\"http://tempuri.org/\">{1}<otherString>{2}</otherString></{0}></s:Body></s:Envelope>";
        private string Xml_Filters_Temp = "<filters xmlns:a=\"http://schemas.datacontract.org/2004/07/TT.Common.Frame.Model\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">{0}</filters>";
        private string Xml_Filter_Temp = "<a:CommonFilterModel><a:Filter>=</a:Filter><a:ListValue i:nil=\"true\" xmlns:b=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\"/><a:Name>{0}</a:Name><a:Value>{1}</a:Value></a:CommonFilterModel>";
        private string Xml_Orders_Temp= "<orders xmlns:a=\"http://schemas.datacontract.org/2004/07/WebComponentWebAPI.WCF.Models\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">{0}</orders>";
        private string Xml_Order_Temp = "<a:CommonOrderModel><a:Name>{0}</a:Name><a:Order>{1}</a:Order></a:CommonOrderModel>";
        private string Xml_IdList_Temp = "<{0} xmlns:a=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">{1}</{0}>";
        private string Xml_Id_Temp = "<a:int>{0}</a:int>";

        public string RemoteAddress { get; set; }
        public WCFService(ICCHelper ccHelper)
        {
            _ccHelper = ccHelper;
            config = _ccHelper.GetConfig();
        }
        public WCFService(string RemoteAddress)
        {
            RemoteAddress = config.WCFHost + RemoteAddress;
            this.RemoteAddress = RemoteAddress;
        }
        public void SetRemoteAddress(string RemoteAddress)
        {
            RemoteAddress = config.WCFHost + RemoteAddress;
            this.RemoteAddress = RemoteAddress;
        }

        public DefaultResult<List<int>> GetIdList(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString)
        {
            string xml_Content = GetXmlKeyContent(new List<KeyValuePair<string, object>>() {
                new KeyValuePair<string, object>("page",page),
                new KeyValuePair<string, object>("pagesize",pagesize)
            });
            string xml_Filters = string.Format(Xml_Filters_Temp, GetXmlFilter(filters));
            string xml_Orders = string.Format(Xml_Orders_Temp, GetXmlOrders(orders));
            string xml = string.Format(Xml_Body_Temp, "GetIdList", xml_Content + xml_Filters + xml_Orders, otherString);

            var result = WCFPostHelper.Post<List<int>>(typeof(Entity).Name, "GetIdList", RemoteAddress, xml);


            return result;
        }

        public DefaultResult<List<int>> GetIdListLock(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString)
        {
            string xml_Content = GetXmlKeyContent(new List<KeyValuePair<string, object>>() {
                new KeyValuePair<string, object>("page",page),
                new KeyValuePair<string, object>("pagesize",pagesize)
            });
            string xml_Filters = string.Format(Xml_Filters_Temp, GetXmlFilter(filters));
            string xml_Orders = string.Format(Xml_Orders_Temp, GetXmlOrders(orders));
            string xml = string.Format(Xml_Body_Temp, "GetIdListLock", xml_Content + xml_Filters + xml_Orders, otherString);

            var result = WCFPostHelper.Post<List<int>>(typeof(Entity).Name, "GetIdListLock", RemoteAddress, xml);


            return result;
        }

        public DefaultResult<List<Entity>> GetListByQuery(int page, int pagesize, List<CommonFilterModel> filters, List<CommonOrderModel> orders, string otherString)
        {
            string xml_Content = GetXmlKeyContent(new List<KeyValuePair<string, object>>() {
                new KeyValuePair<string, object>("page",page),
                new KeyValuePair<string, object>("pagesize",pagesize)
            });
            string xml_Filters = string.Format(Xml_Filters_Temp, GetXmlFilter(filters));
            string xml_Orders = string.Format(Xml_Orders_Temp, GetXmlOrders(orders));
            string xml = string.Format(Xml_Body_Temp, "GetListByQuery", xml_Content + xml_Filters + xml_Orders, otherString);

            var result= WCFPostHelper.Post<List<Entity>>(typeof(Entity).Name, "GetListByQuery", RemoteAddress, xml);


            return result;
        }

        public DefaultResult<Entity> GetModelByID(int id, string otherString)
        {
            string xml_Content = GetXmlKeyContent(new List<KeyValuePair<string, object>>() {
                new KeyValuePair<string, object>("id",id),
            });
            string xml = string.Format(Xml_Body_Temp, "GetModelByID", xml_Content , otherString);

            var result = WCFPostHelper.Post<Entity>(typeof(Entity).Name, "GetModelByID", RemoteAddress, xml);
            return result;
        }

        public DefaultResult<List<Entity>> GetModelByIDS(List<int> idlist, string otherString)
        {
            string xml_Content = string.Format(Xml_IdList_Temp, "idlist", GetXmlIdListContent(idlist));
            string xml = string.Format(Xml_Body_Temp, "GetModelByIDS", xml_Content, otherString);

            var result = WCFPostHelper.Post<List<Entity>>(typeof(Entity).Name, "GetModelByIDS", RemoteAddress, xml);
            return result;
        }
        
       

        private string GetXmlKeyContent(List<KeyValuePair<string,object>> list)
        {
            string result = "";
            foreach (var item in list)
            {
                result += $"<{item.Key}>{item.Value}</{item.Key}>";
            }
            return result;
        }

        private string GetXmlOrders(List<CommonOrderModel> orders)
        {
            string result = "";
            foreach (var item in orders)
            {
                result +=string.Format(Xml_Order_Temp,item.Name,item.Order);
            }
            return result;
        }

        private string GetXmlFilter(List<CommonFilterModel> filters)
        {
            string result = "";
            foreach (var item in filters)
            {
                result += string.Format(Xml_Filter_Temp, item.Name, item.Value);
            }
            return result;
        }
        private string GetXmlIdListContent(List<int> list)
        {
            string result = "";
            foreach (var item in list)
            {
                result += string.Format(Xml_Id_Temp, item);
            }
            return result;
        }

        /*
         <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
            <s:Body>
                <GetIdList xmlns="http://tempuri.org/">
                    <page>1</page>
                    <pagesize>10</pagesize>
                    <filters xmlns:a="http://schemas.datacontract.org/2004/07/TT.Common.Frame.Model" 
                        xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                        <a:CommonFilterModel>
                            <a:Filter>=</a:Filter>
                            <a:ListValue i:nil="true" 
                                xmlns:b="http://schemas.microsoft.com/2003/10/Serialization/Arrays"/>
                            <a:Name>orgid</a:Name>
                            <a:Value>22</a:Value>
                        </a:CommonFilterModel>
                    </filters>
                    <orders xmlns:a="http://schemas.datacontract.org/2004/07/TT.Common.Frame.Model" 
                        xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                        <a:CommonOrderModel>
                            <a:Name>UserId</a:Name>
                            <a:Order>0</a:Order>
                        </a:CommonOrderModel>
                    </orders>
                    <otherString>passkey$bc$v2019$ac$debug$bc$1$ac$connkey$bc$new</otherString>
                </GetIdList>
            </s:Body>
        </s:Envelope>
         * 
         <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
            <s:Body>
                <GetListByQuery xmlns="http://tempuri.org/">
                    <page>1</page>
                    <pagesize>50</pagesize>
                    <filters xmlns:a="http://schemas.datacontract.org/2004/07/WebComponentWebAPI.WCF.Models" 
                        xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                        <a:CommonFilterModel>
                            <a:Filter>=</a:Filter>
                            <a:ListValue i:nil="true" 
                                xmlns:b="http://schemas.microsoft.com/2003/10/Serialization/Arrays"/>
                            <a:Name>DicClassID</a:Name>
                            <a:Value>77</a:Value>
                        </a:CommonFilterModel>
                        <a:CommonFilterModel>
                            <a:Filter>=</a:Filter>
                            <a:ListValue i:nil="true" 
                                xmlns:b="http://schemas.microsoft.com/2003/10/Serialization/Arrays"/>
                            <a:Name>isdel</a:Name>
                            <a:Value>0</a:Value>
                        </a:CommonFilterModel>
                    </filters>
                    <orders xmlns:a="http://schemas.datacontract.org/2004/07/WebComponentWebAPI.WCF.Models" 
                        xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                        <a:CommonOrderModel>
                            <a:Name>DicID</a:Name>
                            <a:Order>0</a:Order>
                        </a:CommonOrderModel>
                    </orders>
                    <otherString>passkey$bc$v2019$ac$debug$bc$1$ac$connkey$bc$new</otherString>
                </GetListByQuery>
            </s:Body>
        </s:Envelope>
         * 
         <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
            <s:Body>
                <GetListByQueryResponse xmlns="http://tempuri.org/">
                    <GetListByQueryResult xmlns:a="http://schemas.datacontract.org/2004/07/TT.Common.Frame.Model" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                        <a:Data i:nil="true" />
                        <a:Debug>dcBTtZr[ba6M5NdNlZOLK%2BHPxDZ7BsL%2BSTroecXocwFkVlqUx3qHWliwgzcKu%2ByEpEMa7VqUc1EfmyEKsSeqRQL4HAAc8O%2BztOPTdRt8vtPAav5S1iuP4ad2ZPc4HN3JxAJKeSKXLXMrDVc/EJGmW6RNIBzTGD%2BKD1D8/VZQBg8cSAbDqkV6a%2BJ4P5etv%2BChWahJirTQU5FFiEJJ38Ke9jlMgzY6tXUFeqnsmsBJAXJ9WTPYMIH8tEOJvg%2Bxrpa5TMdDBdJf87Zt/y6Idm6dUQo2qbmBmq1r8FHSCYBTONV5j/0tbmF8PVpcuhyO8eScmZAmY3MwfEkFthJv//9ero%2BmQFLW5uHvJmJ9nCGFacpssIDdp7EHifa%2BU/PDFBI9eIhJYvXxRO4RXatJgdNc7DIg4lqRuVBGB/w8Yaybcrke0Bb8s1o%2BYvL3tnQFHVsiYREUZpHQcDp1DcVKhwpCXrdcaDfcc5XyJs32Ayj34e2MFBajHZCZ%2BPVfgOu7TsOUb0d1Y5uiOWA/i/87/wPCF2wvp0koHq5OGqxxauB%2BLRsugUCs8v21layO5v3mM%2BZpG3XBxdL9BJb81U7P%2BZkGFGUBArKxGIH1zJx%2BdgiQDLIMGimZeatBVbqBBElzIlUZiQ3R%2BZj%2BIt5QUBCoflDqG3rhwLe%2BNLnpTVebt7hO7fkUZxfb0VlYHLzdA8v37Smq9XXLl9k6hbAjxo02lXA83ExeejMqUomiYzz%2BqkvEY37jkEYERvQELpfYhlogd%2B9JbptAOolQ5/RoowGM96exsrdQvOiNoDsQ3icxzwdSngEAX97HFRd1JSGU6V5AvCxZgoGHkRk%2Bbh3JoFsPMMMlnmMAoYYL7nXlz%2BU3S8LYBALnW8kkop96c7lbAZOXXR59mUAN7aAlW0Pn1X5xh2DdSa4tafP6uqiRA8L6f/MPkgzdlbK3v4uwvLOocvh2oVSwqnQKEDf3lrZRffaTwzJY1GrpGE3ckBoDMCF1u8q6SmZM2gpz9/JJFmsVpmQ4Gmz4xkjrOXMHlfrDQKs1PE32BLQNHmUOMs2ExAoeOFPz</a:Debug>
                        <a:Key i:nil="true" />
                        <a:RETData>dcBTtZr[ba6M5NdNlZOLK%2BHPxDZ7BvUYUi19EtkRsFi9tSWrjQ0dLogl7JwSM2Pe1ylPYJ3mW4/6O4ujfxcXkQsPq0ESfjHUKsZkJYNLfzvFd603N%2BUfEGrD4rDN6R2yqgGEVQrukuyDwwUpFoA=</a:RETData>
                        <a:RetInt>0</a:RetInt>
                        <a:RunTime>4.9998</a:RunTime>
                    </GetListByQueryResult>
                </GetListByQueryResponse>
            </s:Body>
        </s:Envelope>
         * 
         * 
         */
    }
}
