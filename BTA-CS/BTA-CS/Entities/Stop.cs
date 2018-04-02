using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTA_CS.Entities
{
    public class Stop : IEntity
    {
        public int id { get; set; }

        public String name { get; set; }
        public float latitide { get; set; }
        public float longitude { get; set; }

        public int busID { get; set; }
        public Bus Bus { get; set; }
    }
}