﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTA_CS.Entities
{
    public class Route : IEntity
    {
        public int id { get; set; }

        public Bus Bus { get; set; }
    }
}