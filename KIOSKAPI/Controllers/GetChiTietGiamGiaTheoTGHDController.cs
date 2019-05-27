using KIOSKAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KIOSKAPI.Controllers
{
    public class GetChiTietGiamGiaTheoTGHDController : ApiController
    {
        // GET: api/GetChiTietGiamGiaTheoTGHD/
        /// <summary>
        /// Lấy danh sách chi tiết giảm giá theo TGHD
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <param name="makm">mã khuyến mãi</param>i
        /// <returns>v_api_ChiTietGiamGiaTheoTGHD</returns>

        [AllowAnonymous]
        public IHttpActionResult GetChiTietGiamGiaTheoTGHD(string token, string makiosk, int makm)
        {
            List<v_api_ChiTietGiamGiaTheoTGHD> chiTietGiamGiaTheoTGHDs = new List<v_api_ChiTietGiamGiaTheoTGHD>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            QLKIOSKClientEntities db = ClientDBInstance.GetDBInstance(makiosk);

            try
            {
                if (ModelState.IsValid)
                {
                    List<sp_api_getChiTietGiamGiaTheoTGHD_Result> sp_result = db.sp_api_getChiTietGiamGiaTheoTGHD(makm).ToList();
                    foreach (sp_api_getChiTietGiamGiaTheoTGHD_Result item in sp_result)
                    {
                        chiTietGiamGiaTheoTGHDs.Add(new v_api_ChiTietGiamGiaTheoTGHD()
                        {
                            STT = item.STT,
                            MaKM = item.MaKM,
                            TongTriGiaToiThieu = item.TongTriGiaToiThieu,
                            Giam = item.Giam
                        });
                    }
                    return Ok(chiTietGiamGiaTheoTGHDs);
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
