using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class GetQuangCaosController : ApiController
    {
        // GET: api/GetQuangCaos/
        /// <summary>
        /// Lấy danh sách quảng cáo
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <returns>v_api_QuangCao</returns>

        [AllowAnonymous]
        public IHttpActionResult GetQuangCaos(string token, string makiosk)
        {
            List<v_api_QuangCao> quangCaos = new List<v_api_QuangCao>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            QLKIOSKClientEntities db = ClientDBInstance.GetDBInstance(makiosk);

            try
            {
                if (ModelState.IsValid)
                {
                    List<sp_api_getQuangCao_Result> sp_result = db.sp_api_getQuangCao(makiosk).ToList();
                    foreach (sp_api_getQuangCao_Result item in sp_result)
                    {
                        quangCaos.Add(new v_api_QuangCao()
                        {
                            SoHD = item.SoHD,
                            MAKO = item.MAKO,
                            MaQC = item.MaQC,
                            NgayBDQC = item.NgayBDQC,
                            NgayKTQC = item.NgayKTQC,
                            NoiDung = item.NoiDung,
                            ImageQC = item.ImageQC,
                            ThoiLuong = item.ThoiLuong
                        });
                    }
                    return Ok(quangCaos);
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