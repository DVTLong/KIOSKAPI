using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class GetMatHangsController : ApiController
    {
        private QLKIOSKEntities db = new QLKIOSKEntities();

        // GET: api/GetMatHangs/
        /// <summary>
        /// Lấy danh sách mặt hàng
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <param name="malmh">mã loại mặt hàng</param>
        /// <param name="maba">mã buổi ăn</param>
        /// <returns>v_api_MatHang</returns>

        [AllowAnonymous]
        public IHttpActionResult GetMatHangs(string token, string makiosk, int malmh, int maba)
        {
            List<v_api_MatHang> matHangs = new List<v_api_MatHang>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    List<sp_api_getMatHang_Result> sp_result = db.sp_api_getMatHang(makiosk, malmh, maba).ToList();
                    foreach (sp_api_getMatHang_Result item in sp_result)
                    {
                        matHangs.Add(new v_api_MatHang()
                        {
                            MaMH = item.MaMH,
                            TenMH = item.TenMH,
                            SoLuongTon = item.SoLuongTon,
                            DonGia = item.DonGia,
                            MaDV = item.MaDV,
                            TenDV = item.TenDV,
                            TrangThai = item.TrangThai,
                            ImageMH = item.ImageMH,
                            MaLMH = item.MaLMH,
                            TenLMH = item.TenLMH,
                            SoHD = item.SoHD
                        });
                    }
                    return Ok(matHangs);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

            return BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
