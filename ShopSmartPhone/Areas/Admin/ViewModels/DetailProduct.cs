using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSmartPhone.Areas.Admin.ViewModels
{
    public class DetailProduct
    {
        public int ID { get; set; }

        public string TenSanPham { get; set; }

        public string HinhAnh { get; set; }

        public decimal? Gia { get; set; }

        public int? LoaiSanPham { get; set; }

        public int? HangSanXuat { get; set; }

        public string Mota { get; set; }

        public string ThongSoKyThuat { get; set; }

        public string BaoHanh { get; set; }

        public string PhuKien { get; set; }

        public string DanhGia { get; set; }

        public string TenLoai { get; set; }

        public string TenHang { get; set; }
    }
}