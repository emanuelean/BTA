using BTA_CS.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;

namespace BTA_API
{
    class Program
    {
        public static IEnumerable<Bus> GET(string url)
        {
            List<Bus> model = new List<Bus>();
            var client = new HttpClient();
            var task = client.GetAsync(url)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  model = JsonConvert.DeserializeObject<List<Bus>>(jsonString.Result);

              });
            task.Wait();


                //IEnumerable<Bus> model = new List<Bus>();
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //try
                //{
                //    WebResponse response = request.GetResponse();
                //    using (Stream responseStream = response.GetResponseStream())
                //    {
                //        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                //        //string content = new StreamReader(responseStream, Encoding.Unicode).ReadToEnd();
                //        //Console.WriteLine(content);



                //        //model = (List<Bus>)Newtonsoft.Json.JsonConvert.DeserializeObject(reader.ReadToEnd(), typeof(List<Bus>));
                //        /* JsonConvert.DeserializeObject<IEnumerable<Bus>>(reader.ReadToEnd())*/;
                //        foreach (var elem in model)
                //            Console.WriteLine(elem.id+" "+elem.name);
                //    }
                //}
                //catch (WebException ex)
                //{
                //    WebResponse errorResponse = ex.Response;
                //    using (Stream responseStream = errorResponse.GetResponseStream())
                //    {
                //        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                //        String errorText = reader.ReadToEnd();
                //        // log errorText
                //    }
                //    //throw;
                //}

                return model;
        }

        static void Main(string[] args)
        {
            IEnumerable<Bus> bus = new List<Bus>();

            bus = GET("http://localhost:8081/BTA-CS/db.json");


            foreach (var elem in bus)
                Console.WriteLine(elem.id + " " + elem.name);
        }
    }
}
