using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmartPhone.Models.ViewModels
{
    public class DetailProduct
    {
        public int ID { get; set; }

        public string ProductName { get; set; }

        public string Image { get; set; }

        public decimal? Price { get; set; }

        public int? CategogyID { get; set; }

        public int? ManufacturerID { get; set; }

        public string Description { get; set; }

        public string Specifications { get; set; }

        public string Warranty { get; set; }

        public string Accessories { get; set; }

        public int Evaluate { get; set; }

        public bool? Status { get; set; }

        public string CategogyName { get; set; }

        public string ManufacturerName { get; set; }
    }
}