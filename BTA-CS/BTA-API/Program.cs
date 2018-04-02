using BTA_CS.Controllers;
using BTA_CS.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BTA_API
{
    class Program
    {
        public static List<Bus> GET(string url)
        {
            var model = new List<Bus>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    

                    model = JsonConvert.DeserializeObject<List<Bus>>(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                //throw;
            }

            return model;
        }

        static void Main(string[] args)
        {
            var bus = new List<Bus>();
            bus = GET("http://localhost:3000/buses");
        }
    }
}
