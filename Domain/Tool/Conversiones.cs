using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

using System;
using System.IO;




namespace Domain.Tool
{
    public class Conversiones
    {
           

            public static string SerializarObjetoAjson(object obj, ref string mensaje)
            {
                try
                {
                    return JsonConvert.SerializeObject(obj);
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }

                return null;
            }

            public static T DeserializarJsonAobjeto<T>(string json, ref string mensaje)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }

                return default(T);
            }

            public static bool StringEsHtml(string str)
            {
                try
                {
                    Regex regex = new Regex("<\\s*([^ >]+)[^>]*>.*?<\\s*/\\s*\\1\\s*>");
                    bool flag = regex.IsMatch(str);
                    if (!flag)
                    {
                        regex = new Regex("<[^>]+>");
                        flag = regex.IsMatch(str);
                    }

                    return flag;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public static int NullToInt0(object obj)
            {
                try
                {
                    if (Convert.IsDBNull(obj))
                    {
                        return 0;
                    }

                    if (obj == null)
                    {
                        return 0;
                    }

                    return int.Parse(obj.ToString());
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            public static string NullToString(object obj)
            {
                try
                {
                    if (Convert.IsDBNull(obj))
                    {
                        return "";
                    }

                    if (obj == null)
                    {
                        return "";
                    }

                    return obj.ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }

            public static double NullToDouble0(object obj)
            {
                try
                {
                    if (Convert.IsDBNull(obj))
                    {
                        return 0.0;
                    }

                    if (obj == null)
                    {
                        return 0.0;
                    }

                    return double.Parse(obj.ToString());
                }
                catch (Exception)
                {
                    return 0.0;
                }
            }

            public static decimal NullToDecimal0(object obj)
            {
                try
                {
                    if (Convert.IsDBNull(obj))
                    {
                        return 0m;
                    }

                    if (obj == null)
                    {
                        return 0m;
                    }

                    return decimal.Parse(obj.ToString());
                }
                catch (Exception)
                {
                    return 0m;
                }
            }

            public static object NullToDBNull(object obj)
            {
                try
                {
                    if (obj == null)
                    {
                        return DBNull.Value;
                    }

                    return obj;
                }
                catch (Exception)
                {
                    return DBNull.Value;
                }
            }
        }
    
}
