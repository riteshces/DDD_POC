﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entity
{
    public class InvoiceDetails
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductTotal { get; set; }
    }
}
