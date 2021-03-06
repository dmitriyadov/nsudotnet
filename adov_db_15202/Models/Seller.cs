﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adov_db_15202.Models
{
    public class Seller
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }
        public virtual ICollection<Sale> Sales{ get; set; }
    }
}