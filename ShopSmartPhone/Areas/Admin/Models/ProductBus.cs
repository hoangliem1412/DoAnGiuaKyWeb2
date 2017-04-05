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
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<SanPham>("Select * from SanPham");
        }
        public static SanPham GetSanPham(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.SingleOrDefault<SanPham>("SELECT * FROM SanPham WHERE ID=@0", id);
            }
        }

        public static DetailProduct ChiTietSanPham(int id)
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.SingleOrDefault<DetailProduct>("Select sp.*, l.TenLoai, h.TenHang from SanPham sp, LoaiSanPham l, HangSanXuat h WHERE sp.LoaiSanPham = l.ID and sp.HangSanXuat = h.ID and sp.ID = @0", id);
        }
        public static IEnumerable<LoaiSanPham> GetListLoaiSanPham()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<LoaiSanPham>("Select * FROM LoaiSanPham");
        }

        public static IEnumerable<HangSanXuat> GetListHangSanXuat()
        {
            var db = new ShopSmartPhoneConnectionDB();
            return db.Query<HangSanXuat>("SELECT * FROM HangSanXuat");
        }

        public static void Insert(SanPham sp)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Insert(sp);
            }
        }

        public static void Update(int id, SanPham sp)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Update<SanPham>("SET TenSanPham=@0, HinhAnh=@1, Gia=@2, LoaiSanPham=@3, HangSanXuat=@4, Mota=@5, ThongSoKyThuat=@6, BaoHanh=@7, PhuKien=@8, DanhGia=@9 WHERE ID=@10", sp.TenSanPham, sp.HinhAnh, sp.Gia, sp.LoaiSanPham, sp.HangSanXuat, sp.Mota, sp.ThongSoKyThuat, sp.BaoHanh, sp.PhuKien, sp.DanhGia, id);
            }
        }

        public static void UpdateNoImage(int id, SanPham sp)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Update<SanPham>("SET TenSanPham=@0, Gia=@1, LoaiSanPham=@2, HangSanXuat=@3, Mota=@4, ThongSoKyThuat=@5, BaoHanh=@6, PhuKien=@7, DanhGia=@8 WHERE ID=@9", sp.TenSanPham, sp.Gia, sp.LoaiSanPham, sp.HangSanXuat, sp.Mota, sp.ThongSoKyThuat, sp.BaoHanh, sp.PhuKien, sp.DanhGia, id);
            }
        }

        public static void Delete(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                db.Delete<SanPham>("Where ID=@0", id);
            }
        }

        public static IEnumerable<SanPham> ListOfCategories(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<SanPham>("SELECT * FROM SanPham WHERE LoaiSanPham = @0", id);
            }
        }
        public static IEnumerable<SanPham> ListOfManufacturer(int id)
        {
            using (var db = new ShopSmartPhoneConnectionDB())
            {
                return db.Query<SanPham>("SELECT * FROM SanPham WHERE HangSanXuat = @0", id);
            }
        }
    }
}