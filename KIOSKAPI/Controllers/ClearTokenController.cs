using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Description;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class ClearTokenController : ApiController
    {

        // GET: api/ClearToken/
        /// <summary>
        /// Xóa token
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">kiosk</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult ClearToken(string token, string makiosk)
        {
            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return BadRequest();
            }

            QLKIOSKEntities db = new QLKIOSKEntities();

            try
            {
                v_kiosk_constr k = db.v_kiosk_constr.SingleOrDefault(x => x.MAKO.Equals(makiosk));

                if (k != null && ModelState.IsValid)
                {
                    db.sp_api_SetToken(makiosk, null);
                    return Ok();
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
