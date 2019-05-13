using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class GetDotKhuyenMaisController : ApiController
    {
        // GET: api/GetDotKhuyenMais/
        /// <summary>
        /// Lấy danh sách đợt khuyến mãi (đang khuyến mãi)
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <returns>v_api_DotKhuyenMai</returns>

        [AllowAnonymous]
        public IHttpActionResult GetDotKhuyenMais(string token, string makiosk)
        {
            List<v_api_DotKhuyenMai> dotKhuyenMais = new List<v_api_DotKhuyenMai>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            QLKIOSKClientEntities db = ClientDBInstance.GetDBInstance(makiosk);

            try
            {
                if (ModelState.IsValid)
                {
                    List<sp_api_getDotKhuyenMai_Result> sp_result = db.sp_api_getDotKhuyenMai(makiosk).ToList();
                    foreach (sp_api_getDotKhuyenMai_Result item in sp_result)
                    {
                        dotKhuyenMais.Add(new v_api_DotKhuyenMai()
                        {
                            MaKM = item.MaKM,
                            NgayTao = item.NgayTao,
                            NgayBD = item.NgayBD,
                            NgayKT = item.NgayKT,
                            SoHD = item.SoHD
                        });
                    }
                    return Ok(dotKhuyenMais);
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
