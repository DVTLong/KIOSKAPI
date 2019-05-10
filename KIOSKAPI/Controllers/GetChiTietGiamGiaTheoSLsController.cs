using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class GetChiTietGiamGiaTheoSLsController : ApiController
    {
        private QLKIOSKEntities db = new QLKIOSKEntities();

        // GET: api/GetChiTietGiamGiaTheoSL/
        /// <summary>
        /// Lấy danh sách chi tiết giảm giá theo số lượng
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <param name="makm">mã khuyễn mãi</param>
        /// <returns>v_api_ChiTietGiamGiaTheoSL</returns>

        [AllowAnonymous]
        public IHttpActionResult GetChiTietGiamGiaTheoSL(string token, string makiosk, int makm)
        {
            List<v_api_ChiTietGiamGiaTheoSL> chiTietGiamGiaTheoSLs = new List<v_api_ChiTietGiamGiaTheoSL>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    List<sp_api_getChiTietGiamGiaTheoSL_Result> sp_result = db.sp_api_getChiTietGiamGiaTheoSL(makm).ToList();
                    foreach (sp_api_getChiTietGiamGiaTheoSL_Result item in sp_result)
                    {
                        chiTietGiamGiaTheoSLs.Add(new v_api_ChiTietGiamGiaTheoSL()
                        {
                            STT = item.STT,
                            MaKM = item.MaKM,
                            MaMH = item.MaMH,
                            DonGia = item.DonGia,
                            TrangThai = item.TrangThai,
                            SLMuaToiThieu = item.SLMuaToiThieu,
                            Giam = item.Giam
                        });
                    }
                    return Ok(chiTietGiamGiaTheoSLs);
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
