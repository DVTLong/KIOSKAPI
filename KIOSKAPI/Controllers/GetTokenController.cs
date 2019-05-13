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
    public class GetTokenController : ApiController
    {
        // GET: api/GetToken/
        /// <summary>
        /// Generate new token for kiosk
        /// </summary>
        /// <param name="apikey"></param>
        /// <param name="makiosk"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public IHttpActionResult GetToken(string apikey, string makiosk)
        {
            if (apikey == null || makiosk == null)
            {
                return BadRequest("Null parameters");
            }            

            string token = string.Empty;
            if (!ValidateRequest.APIKeyIsValid(apikey))
            {
                return Unauthorized();
            }

            QLKIOSKEntities db = new QLKIOSKEntities();

            try
            {
                v_kiosk_constr kIOSK = db.v_kiosk_constr.SingleOrDefault(x => x.MAKO.Equals(makiosk));
                if (kIOSK == null)
                {
                    return NotFound();
                }


                token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                token = MD5Gen.CreateMD5(token);

                if (ModelState.IsValid)
                {
                    db.sp_api_SetToken(makiosk, token);
                    return Ok(token);
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