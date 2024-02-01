using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace batchHandle
{
    class Business
    {
        static string query_url = "https://10.24.67.127:1688/es-service/api/queryIncident";
        static string update_url = "https://10.24.67.127:1688/es-service/api/updateIncidentHandleStatusBySoar";
        string token = "";

        static string[] advices = {
                "对该IP进行溯源后，发现并未受到影响。",
                "跟踪发现，该攻击并未持续，未受到影响",
                "在边界设备上将其加入黑名单封30分钟" };

        public Business(string input_t)
        {
            token = input_t;
        }

        /// <summary>
        ///  随机抽一条未处置的事件处置
        /// </summary>
        /// <returns></returns>
        public string Query_30day_incident()
        {
            string content = "{'queryInfo':[{'field':'create_time','opt':'between','valType':'datetimerange','value':'1704175514190_@#@_1706767514190_@#@_30d','eventAttr':'','label':''}],'pageSize':6000,'pageNum':1,'simpleConditionsZH':'','source':3,'customQuery':'','sort':[{'field':'severity,create_time','order':'desc'}]}";
            content = content.Replace("'", "\"");
            string response_result = http_post.Post(query_url, content, token);
            string[] arr = response_result.Split('}');
            for (int i = 0;i<arr.Length;i++)
            {
                 if(arr[i].Contains("处置完成"))
                 {
                    continue;
                 }
                 else if(arr[i].Contains("es_index_id"))
                 {
                    Match match = Regex.Match(arr[i], "es_index_id\":\"([^\"]*)");
                    string incident_id = "";
                    if (match.Success)
                    {
                        Console.WriteLine(match.Groups[1].Value);
                        incident_id = match.Groups[1].Value;
                    }
                    return incident_id;
                 }
            }
            return "";
        }


        /// <summary>
        ///  只处置最新的一条安全事件(作废方法)
        /// </summary>
        /// <returns></returns>
        public string Query_latest_incident()
        {
            string content = "{'queryInfo':[{'field':'create_time','opt':'between','valType':'datetimerange','value':'1706149985000_@#@_1706754785999_@#@_absolute_time','eventAttr':'','label':'事件创建时间'}],'pageSize':1,'pageNum':1,'simpleConditionsZH':'','source':3,'customQuery':'事件处置状态 = \'待处置\'','sort':[{'field':'severity,create_time','order':'desc'}]}";
            //content = "{'queryInfo':[{'field':'id','opt':'like','value':'','valType':'input','extendAttr':''}],'pageSize':1,'pageNum':1,'sort':[{'field':'severity,create_time','order':'desc'}]}";
            content = content.Replace("'", "\"");
            string response_result = http_post.Post(query_url, content, token);
            Match match = Regex.Match(response_result, "es_index_id\":\"([^\"]*)");
            string incident_id = "";
            if (match.Success)
            {
                Console.WriteLine(match.Groups[1].Value);
                incident_id = match.Groups[1].Value;
            }
            return incident_id;
        }


        /// <summary>
        ///  更新指定安全事件为已处置
        /// </summary>
        /// <param name="incidentId"></param>
        /// <returns></returns>
        public bool Update_incident(string incidentId)
        {
            string content = "{'executeType':'其他处置','executeTypeId':3,'tags':'3','incidentId':'incidentId222','advice':'advice333','handleStatusId':'2','handleStatus':'处置完成'}";
            Random random = new Random();
            string advice = advices[random.Next(1, 10) % 3];

            #region 修改 Post 参数
            content = content.Replace("incidentId222", incidentId);
            content = content.Replace("advice333", advice);
            #endregion

            if (!http_post.Post(update_url, content, token).Contains("成功"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///  判断当前时间是否在工作时间段内
        /// </summary>
        /// <returns></returns>
        public bool Check_time()
        {
            string strWeekNow = this.m_GetWeekNow();//当前周几
                                                    ////判断是否有休息日
            string[] RestDay = _strRestDay.Split(',');
            if (RestDay.Contains(strWeekNow))
            {
                return false;
            }
            dspWorkingDayAM = DateTime.Parse(_strWorkingDayAM).TimeOfDay;
            dspWorkingDayPM = DateTime.Parse(_strWorkingDayPM).TimeOfDay;

            TimeSpan dspNow = DateTime.Now.TimeOfDay;
            if (dspNow > dspWorkingDayAM && dspNow < dspWorkingDayPM)
            {
                return true;
            }
            return false;
        }


        #region  休息时间不处置安全事件
        //获取当前周几
        private string _strWorkingDayAM = "08:30";//工作时间上午08:00
        private string _strWorkingDayPM = "17:30";
        private string _strRestDay = "6,7";//周几休息日 周六周日为 6,7
        private TimeSpan dspWorkingDayAM;//工作时间上午08:00
        private TimeSpan dspWorkingDayPM;

        private string m_GetWeekNow()
        {
            string strWeek = DateTime.Now.DayOfWeek.ToString();
            switch (strWeek)
            {
                case "Monday":
                    return "1";
                case "Tuesday":
                    return "2";
                case "Wednesday":
                    return "3";
                case "Thursday":
                    return "4";
                case "Friday":
                    return "5";
                case "Saturday":
                    return "6";
                case "Sunday":
                    return "7";
            }
            return "0";
        }
        #endregion

    }
}
