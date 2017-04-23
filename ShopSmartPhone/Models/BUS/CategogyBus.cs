using ShopSmartPhoneConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmartPhone.Models.BUS
{
    public class CategogyBus
    {
        public static IEnumerable<Categogy> getListCategogy()
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<Categogy>("SELECT * FROM Categogy WHERE Status = 1");
            }
        }
    }
}