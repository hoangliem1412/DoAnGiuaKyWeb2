using ShopSmartPhone.Areas.Admin.ViewModels;
using ShopSmartPhoneConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmartPhone.Areas.Admin.Models
{
    public class ProductBus
    {
        public static IEnumerable<Product> DanhSach()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<Product>("Select * from Product");
        }
        public static Product GetProduct(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.SingleOrDefault<Product>("SELECT * FROM Product WHERE ID=@0", id);
            }
        }

        public static DetailProduct DetailProduct(int id)
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.SingleOrDefault<DetailProduct>("Select sp.*, l.TenLoai, h.TenHang from Product sp, Categogy l, Manufacturer h WHERE sp.Categogy = l.ID and sp.Manufacturer = h.ID and sp.ID = @0", id);
        }
        public static IEnumerable<Categogy> GetListCategogy()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<Categogy>("Select * FROM Categogy");
        }

        public static IEnumerable<Manufacturer> GetListManufacturer()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<Manufacturer>("SELECT * FROM Manufacturer");
        }

        public static void Insert(Product sp)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Insert(sp);
            }
        }

        public static void Update(int id, Product sp)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Update<Product>("SET ProductName=@0, Image=@1, Price=@2, CategogyID=@3, ManufacturerID=@4, Description=@5, Specifications=@6, Warranty=@7, Accessories=@8, Evaluate=@9 WHERE ID=@10", sp.ProductName, sp.Image, sp.Price, sp.CategogyID, sp.ManufacturerID, sp.Description, sp.Specifications, sp.Warranty, sp.Accessories, sp.Evaluate, id);
            }
        }

        public static void UpdateNoImage(int id, Product sp)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Update<Product>("SET ProductName=@0, Price=@1, CategogyID=@2, ManufacturerID=@3, Description=@4, Specifications=@5, Warranty=@6, Accessories=@7, Evaluate=@8 WHERE ID=@9", sp.ProductName, sp.Price, sp.CategogyID, sp.ManufacturerID, sp.Description, sp.Specifications, sp.Warranty, sp.Accessories, sp.Evaluate, id);
            }
        }

        public static void Delete(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Delete<Product>("Where ID=@0", id);
            }
        }

        public static IEnumerable<Product> ListOfCategories(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<Product>("SELECT * FROM Product WHERE Categogy = @0 and Status = True", id);
            }
        }
        public static IEnumerable<Product> ListOfManufacturer(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<Product>("SELECT * FROM Product WHERE Manufacturer = @0 and Status = True", id);
            }
        }
    }
}