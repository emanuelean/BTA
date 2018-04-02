using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTA_CS.Entities
{
    public class Bus : IEntity
    {
        private int v1;
        private string v2;
        
        public int id { get; set; }

        public string name { get; set; }
    }
}