using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace batchHandle
{
    class httpPost
    {
        static string url = "https://10.24.67.127:1688/es-service/api/updateIncidentHandleStatusBySoar";
        static string content = "{'executeType':'其他处置','executeTypeId':3,'tags':'3','incidentId':'incidentId222','advice':'advice333','handleStatusId':'2','handleStatus':'处置完成'}";
       
        /// <summary>
        ///  发送POST包
        /// </summary>
        /// <param name="incidentId">告警事件</param>
        /// <param name="advice">处置建议</param>
        /// <param name="token">用户token</param>
        /// <returns>网页内容</returns>
        public static string Post(string incidentId, string advice, string token)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //一定要有这一句
            ServicePointManager.CertificatePolicy = new AcceptAllCertificatePolicy();


            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Headers.Add("token", token.Trim());

            #region 添加Post 参数
            content = content.Replace("incidentId222", incidentId);
            content = content.Replace("advice333", advice);

            byte[] data = Encoding.UTF8.GetBytes(content);
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
            string result = "";
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
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
}
