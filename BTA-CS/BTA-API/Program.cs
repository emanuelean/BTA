using BTA_CS.Controllers;
using BTA_CS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTA_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("x");

            //busMap = new System.Collections.Generic.Dictionary<int, Location>();
            //InitMessageQueue("BTA", "localhost");
            //while (true)
            //{
            //    ConsumeQueue();
            //}
            
            BusController BUS = new BusController();
            var bus = BUS.GetBus(70);

            Console.WriteLine(bus.Id);


            //Console.ReadLine();
        }
    }
}
