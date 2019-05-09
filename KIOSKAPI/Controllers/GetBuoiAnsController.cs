using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class GetBuoiAnsController : ApiController
    {
        private QLKIOSKEntities db = new QLKIOSKEntities();

        // GET: api/GetBuoiAns/
        /// <summary>
        /// Lấy danh sách buổi ăn
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <returns>v_api_BuoiAn</returns>

        [AllowAnonymous]
        public IHttpActionResult GetBuoiAns(string token, string makiosk)
        {
            List<v_api_BuoiAn> buoiAns = new List<v_api_BuoiAn>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    List<sp_api_getBuoiAn_Result> sp_result = db.sp_api_getBuoiAn(makiosk).ToList();
                    foreach (sp_api_getBuoiAn_Result item in sp_result)
                    {
                        buoiAns.Add(new v_api_BuoiAn()
                        {
                            MaBA = item.MaBA,
                            TenBA = item.TenBA,
                            GioBD = item.GioBD,
                            GioKT = item.GioKT,
                            SoHD = item.SoHD
                        });
                    }
                    return Ok(buoiAns);
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
