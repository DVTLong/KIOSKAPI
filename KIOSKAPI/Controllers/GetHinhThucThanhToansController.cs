using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class GetHinhThucThanhToansController : ApiController
    {
        private QLKIOSKEntities db = new QLKIOSKEntities();

        // GET: api/GetHinhThucThanhToans/
        /// <summary>
        /// Lấy danh sách hình thức thanh toán
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">makiosk</param>
        /// <returns>v_api_HinhThucThanhToan</returns>

        [AllowAnonymous]
        public IHttpActionResult GetHinhThucThanhToans(string token, string makiosk)
        {
            List<v_api_HinhThucThanhToan> hinhThucThanhToans = new List<v_api_HinhThucThanhToan>();

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    hinhThucThanhToans = db.v_api_HinhThucThanhToan.ToList();
                    return Ok(hinhThucThanhToans);
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
