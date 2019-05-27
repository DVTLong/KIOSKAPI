using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class GetAllMatHangsController : ApiController
    {
        // GET: api/GetAllMatHangs/
        /// <summary>
        /// Lấy danh sách tất cả mặt hàng
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <returns>v_api_MatHang</returns>

        [AllowAnonymous]
        public IHttpActionResult GetAllMatHangs(string token, string makiosk)
        {
            List<v_api_MatHang> matHangs = new List<v_api_MatHang>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            QLKIOSKClientEntities db = ClientDBInstance.GetDBInstance(makiosk);

            try
            {
                if (ModelState.IsValid)
                {
                    List<sp_api_getAllMatHang_Result> sp_result = db.sp_api_getAllMatHang(makiosk).ToList();
                    foreach (sp_api_getAllMatHang_Result item in sp_result)
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
    }
}