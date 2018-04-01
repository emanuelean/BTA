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

        public Bus(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public int ID { get; set; }

        public string Name { get; set; }
    }
}