using ShopSmartPhoneConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmartPhone.Areas.Admin.Models
{
    public class ManufacturerBus
    {
        public static IEnumerable<Manufacturer> getListManufacturer()
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<Manufacturer>("SELECT * FROM Manufacturer");
            }
        }
    }
}