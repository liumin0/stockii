﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;


namespace Stockii
{
    /// <summary>
    /// 调用REST Web Service
    /// </summary>
    class Http
    {
        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static String Get(String url, Dictionary<string, string> args) 
        {
            if (args.ContainsKey("sortname") && args["sortname"].Equals("stock_id"))
                args["sortname"] = "stockId";
            if (args.ContainsKey("sortname") && args["sortname"].Equals("start_date"))
                args["sortname"] = "startdate";
            if (args.ContainsKey("sortname") && args["sortname"].Equals("end_date"))
                args["sortname"] = "enddate";

            StringBuilder data = new StringBuilder();
            int i = 0;
            foreach (var arg in args)
            {
                if (i == 0)
                    data.Append("?" + arg.Key + "=" + HttpUtility.UrlEncode(arg.Value));
                else
                    data.Append("&" + arg.Key + "=" + HttpUtility.UrlEncode(arg.Value));

                ++i;
            }

            url += data.ToString();

            Console.WriteLine(url);

            // Create the web request
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 60000;

            // Get response
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    // Console application output
                    return reader.ReadToEnd();
                }
            }catch (WebException ex)
            {
                if(ex.Response == null || ex.Status != WebExceptionStatus.ProtocolError)
                    throw;

                throw ex;
            }
        }

        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static String Post(String url, Dictionary<string, string> args)
        {
            if (args.ContainsKey("sortname") && args["sortname"].Equals("stock_id"))
                args["sortname"] = "stockId";
            if (args.ContainsKey("sortname") && args["sortname"].Equals("start_date"))
                args["sortname"] = "startdate";
            if (args.ContainsKey("sortname") && args["sortname"].Equals("end_date"))
                args["sortname"] = "enddate";
            //Console.WriteLine(url);
            Uri address = new Uri(url);

            // Create the web request
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Timeout = 60000;

            // Create the data we want to send
            StringBuilder data = new StringBuilder();
            int i = 0;
            foreach (var arg in args)
            {
                if (i == 0)
                    data.Append(arg.Key + "=" + HttpUtility.UrlEncode(arg.Value));
                else
                    data.Append("&"+arg.Key + "=" + HttpUtility.UrlEncode(arg.Value));

                ++i;
            }

            // Create a byte array of the data we want to send
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());

            // Set the content length in the request headers
            request.ContentLength = byteData.Length;

            // Write data
            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            // Get response
             try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    // Console application output
                    return reader.ReadToEnd();
                }
            }
             catch (WebException ex)
             {
                 if (ex.Response == null || ex.Status != WebExceptionStatus.ProtocolError)
                     throw;

                 throw ex;
             }
        }
    }
}
