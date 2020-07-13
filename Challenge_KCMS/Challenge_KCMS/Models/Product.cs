using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_KCMS.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        //category
    }
}
