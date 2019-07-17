using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using WebComponentWebAPI.Configs;

namespace WebComponentWebAPI.WCF
{
    /// <summary>
    /// wcf解密帮助类
    /// </summary>
    public class SecretHelper
    {
        private static readonly ILog _log = LogManager.GetLogger(ConfigManager.repository.Name, typeof(SecretHelper));

        /// <summary>
        /// 解密返回的实体
        /// </summary>
        /// <param name="result"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static object Decrypt_v2019(object result, string key, string iv)
        {
            if (result == null)
            {
                return null;
            }
            var resultType = result.GetType();
            var RETData_Property = resultType.GetProperty("RETData");
            var Data_Property = resultType.GetProperty("Data");
            var Debug_Property = resultType.GetProperty("Debug");
            var RETData = Convert.ToString(RETData_Property.GetValue(result, null));
            if (!string.IsNullOrWhiteSpace(RETData) && key != null && iv != null)
            {
                string xml_data = DESDecryptString(RETData, key, iv);
                var data_type = (result.GetType()).GetGenericArguments()[0];
                var doc = new XmlDocument();
                try
                {
                    doc.LoadXml((string)xml_data);
                }
                catch (Exception exx)
                {
                    throw new Exception("解密时加载XML失败", exx);
                }
                var nodes = doc.DocumentElement.ChildNodes.Cast<XmlElement>();
                var mappding_node = nodes.FirstOrDefault(n => n.Name == "M");
                Dictionary<string, string> asDict = null;
                if (mappding_node != null)
                {
                    asDict = new Dictionary<string, string>();
                    foreach (XmlElement m_node in mappding_node.ChildNodes)
                    {
                        asDict[m_node.InnerText] = m_node.Name;
                    }
                }
                var data_node = nodes.FirstOrDefault(n => n.Name == "D");
                if (data_node != null)
                {
                    Data_Property.SetValue(result, Activator.CreateInstance(data_type), null);
                }
                if (data_node.ChildNodes.Count > 0)
                    switch (data_node.FirstChild.Name)
                    {
                        case "E"://实体
                            var entity_type = data_type;
                            if (entity_type.IsGenericType)
                            {
                                entity_type = entity_type.GetGenericArguments()[0];
                            }
                            var list_type = typeof(List<>);
                            list_type = list_type.MakeGenericType(entity_type);//实体类型
                            dynamic list = Activator.CreateInstance(list_type);//new List

                            foreach (XmlElement e_node in data_node.ChildNodes)
                            {
                                var entity = Activator.CreateInstance(entity_type); //new Entity
                                foreach (XmlElement col_node in e_node.ChildNodes)
                                {
                                    var property_name = col_node.Name;
                                    if (asDict != null && asDict.ContainsKey(property_name))
                                    {
                                        property_name = asDict[property_name];
                                    }
                                    var property = entity_type.GetProperty(property_name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                                    if (property != null)
                                    {
                                        object value = col_node.InnerText;
                                        var property_type = property.PropertyType;
                                        if (property.PropertyType.IsGenericType)
                                        {
                                            property_type = property.PropertyType.GetGenericArguments()[0];
                                            if (value.Equals(""))
                                                value = null;
                                        }
                                        if (value != null)
                                        {
                                            object obj_value;
                                            if (property_type == typeof(byte[]))
                                                obj_value = Convert.FromBase64String(Convert.ToString(value));
                                            else
                                                obj_value = Convert.ChangeType(value, property_type);

                                            property.SetValue(entity, obj_value, null);
                                        }
                                    }
                                }
                                list.Add((dynamic)entity);
                            }
                            if (data_type.IsGenericType)
                            {
                                Data_Property.SetValue(result, list, null);
                            }
                            else
                            {
                                Data_Property.SetValue(result, ((dynamic)list)[0], null);
                            }
                            break;
                        case "I"://int类型
                            var int_list = new List<int>();
                            foreach (XmlElement i_node in data_node.ChildNodes)
                            {
                                int_list.Add(Convert.ToInt32(i_node.InnerText));
                            }
                            if (data_type == typeof(List<int>))
                            {
                                Data_Property.SetValue(result, int_list, null);
                            }
                            else
                            {
                                Data_Property.SetValue(result, int_list[0], null);
                            }
                            break;
                        case "L"://集合
                            var str_list = new List<List<string>>();
                            foreach (XmlElement l_node in data_node.ChildNodes)
                            {
                                var inner_list = new List<string>();
                                foreach (XmlElement item in l_node.ChildNodes)
                                {
                                    inner_list.Add(item.InnerText);
                                }
                                str_list.Add(inner_list);
                            }
                            Data_Property.SetValue(result, str_list, null);
                            break;
                    }
                RETData_Property.SetValue(result, null, null);

                var Debug = Convert.ToString(Debug_Property.GetValue(result, null));

                var str = DESDecryptString(Debug, key, iv);
                if (!string.IsNullOrWhiteSpace(str))
                    Debug_Property.SetValue(result, str, null);
            }
            return result;
        }
        /// <summary>
        /// 具体解密字符串
        /// </summary>
        /// <param name="encryptedValue"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        static string DESDecryptString(string encryptedValue, string key, string iv)
        {
            encryptedValue = encryptedValue.Replace("%2B", "+");
            if (encryptedValue.Length < 0x10)
            {
                return "";
            }
            encryptedValue = string.Join(string.Empty
                , new string(new[]
                {
                    encryptedValue[0], encryptedValue[2], encryptedValue[4], encryptedValue[6], encryptedValue[8],
                    encryptedValue[10], encryptedValue[12], encryptedValue[14]
                }),
                encryptedValue.Substring(16, encryptedValue.Length - 16));
            key = key + "20444608";
            iv = iv + "60442215";
            key = key.Substring(0, 8);
            iv = iv.Substring(0, 8);
            try
            {
                var transform = new System.Security.Cryptography.DESCryptoServiceProvider
                {
                    Key = Encoding.UTF8.GetBytes(key),
                    IV = Encoding.UTF8.GetBytes(iv)
                }.CreateDecryptor();
                var buffer = Convert.FromBase64String(encryptedValue);
                var destination = new MemoryStream();
                var stream = new MemoryStream(buffer);
                var cryptoStream = new System.Security.Cryptography.CryptoStream(stream, transform, System.Security.Cryptography.CryptoStreamMode.Read);
                cryptoStream.CopyTo(destination);
                cryptoStream.Close();
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                destination.Position = 0L;
                return (string)formatter.Deserialize(destination);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
