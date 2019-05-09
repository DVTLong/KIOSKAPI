using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class GetLoaiMatHangsController : ApiController
    {
        private QLKIOSKEntities db = new QLKIOSKEntities();

        // GET: api/GetLoaiMatHangs/
        /// <summary>
        /// Lấy danh sách loại mặt hàng
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <returns>v_api_LoaiMatHang</returns>

        [AllowAnonymous]
        public IHttpActionResult GetLoaiMatHangs(string token, string makiosk)
        {
            List<v_api_LoaiMatHang> loaiMatHangs = new List<v_api_LoaiMatHang>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            try
            {               
                if (ModelState.IsValid)
                {
                    List<sp_api_getLoaiMatHang_Result> sp_result = db.sp_api_getLoaiMatHang(makiosk).ToList();
                    foreach (sp_api_getLoaiMatHang_Result item in sp_result)
                    {
                        loaiMatHangs.Add(new v_api_LoaiMatHang()
                        {
                            MaLMH = item.MaLMH,
                            TenLMH = item.TenLMH,
                            ImageLMH = item.ImageLMH,
                            SoHD = item.SoHD
                        });
                    }
                    return Ok(loaiMatHangs);
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
