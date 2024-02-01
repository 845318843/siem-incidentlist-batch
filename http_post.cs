using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace batchHandle
{
    class http_post
    {


        public static string Post(string url,string content,string token)
        {
            content = content.Replace("'", "\"");
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //一定要有这一句
            ServicePointManager.CertificatePolicy = new AcceptAllCertificatePolicy();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json;charset=utf8;";
            req.Headers.Add("token", token.Trim());

            #region 添加Post 参数
            Encoding encoding = Encoding.GetEncoding("utf-8");
            byte[] data = encoding.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            string response_result = "";
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                response_result = reader.ReadToEnd();
            }
            return response_result;
        }
    }

    internal class AcceptAllCertificatePolicy : ICertificatePolicy
    {
        public AcceptAllCertificatePolicy()
        {
        }

        public bool CheckValidationResult(ServicePoint sPoint,
           X509Certificate cert, WebRequest wRequest, int certProb)
        {
            // Always accept
            return true;
        }
    }
}
