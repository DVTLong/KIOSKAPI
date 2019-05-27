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

            QLKIOSKClientEntities db = ClientDBInstance.GetDBInstance(makiosk);

            try
            {
                if (ModelState.IsValid)
                {
                    List<sp_api_getHinhThucThanhToan_Result> sp_result = db.sp_api_getHinhThucThanhToan().ToList();
                    foreach (sp_api_getHinhThucThanhToan_Result item in sp_result)
                    {
                        hinhThucThanhToans.Add(new v_api_HinhThucThanhToan()
                        {
                            MaHTTT = item.MaHTTT,
                            TenHTTT = item.TenHTTT,
                            ImageHTTT = item.ImageHTTT
                        });
                    } 
                    return Ok(hinhThucThanhToans);
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
