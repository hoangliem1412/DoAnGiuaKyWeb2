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
            return db.Query<Product>("Select * from Product WHERE Status = 1");
        }
        public static Product GetProduct(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.SingleOrDefault<Product>("SELECT * FROM Product WHERE ID=@0 AND Status = 1", id);
            }
        }

        public static IEnumerable<MoreImage> getListImage(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<MoreImage>("SELECT * FROM MoreImage WHERE Product_ID = @0", id);
            }
        }
        public static DetailProduct DetailProduct(int id)
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.SingleOrDefault<DetailProduct>("Select sp.*, l.CategogyName, h.ManufacturerName from Product sp, Categogy l, Manufacturer h WHERE sp.CategogyID = l.ID and sp.ManufacturerID = h.ID and sp.Status = 1 and sp.ID = @0", id);
        }
        public static IEnumerable<Categogy> GetListCategogy()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<Categogy>("Select * FROM Categogy WHERE Status = 1");
        }

        public static IEnumerable<Manufacturer> GetListManufacturer()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<Manufacturer>("SELECT * FROM Manufacturer WHERE Status = 1");
        }

        public static void Insert(Product sp)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Insert(sp);
            }
        }

        public static void InsertImage(MoreImage mi)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Insert(mi);
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
                db.Update<Product>("SET Status = 0 WHERE ID=@0", id);
            }
        }


        public static IEnumerable<Product> ListOfCategories(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<Product>("SELECT * FROM Product WHERE CategogyID = @0 and Status = True", id);
            }
        }
        public static IEnumerable<Product> ListOfManufacturer(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<Product>("SELECT * FROM Product WHERE ManufacturerID = @0 and Status = True", id);
            }
        }

        public static void InsertSpecification(Specification spe)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Insert(spe);
            }
        }

        public static int getIDProductNew()
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                var query = db.Query<Product>("SELECT * FROM Product ORDER BY ID DESC");
                return query.First().ID;
            }
        }

        public static Specification GetSpecification(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.SingleOrDefault<Specification>("SELECT * FROM Specifications WHERE ProductID = @0", id);
            }
        }

        public static void UpdateSpecification(Specification spec)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Update(spec);
            }
        }
    }
}