using ShopSmartPhoneConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmartPhone.Models.BUS
{
    public class ManufacturerBus
    {
        public static IEnumerable<Categogy> getListManufacturer()
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<Categogy>("SELECT * FROM Manufacturer WHERE Status = 1");
            }
        }
    }
}