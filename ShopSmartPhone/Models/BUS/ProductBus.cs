using PetaPoco;
using ShopSmartPhone.Models.ViewModels;
using ShopSmartPhoneConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmartPhone.Models.BUS
{
    public class ProductBus
    {
        public static IEnumerable<Product> getListProduct()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<Product>("Select * from Product");
        }

        public static Page<Product> getListProductPage(int pageNumber, int itemPerPage)
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Page<Product>(pageNumber, itemPerPage, "Select * from Product");
        }

        public static DetailProduct getDetailProduct(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.SingleOrDefault<DetailProduct>("Select sp.*, l.CategogyName, h.ManufacturerName from Product sp, Categogy l, Manufacturer h WHERE sp.CategogyID = l.ID and sp.ManufacturerID = h.ID and sp.Status = 1 and sp.ID = @0", id);
            }
        }
    }
}