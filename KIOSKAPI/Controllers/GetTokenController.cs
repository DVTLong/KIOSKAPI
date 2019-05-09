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
        private QLKIOSKEntities db = new QLKIOSKEntities();



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
            string stored_apikey = ConfigurationManager.AppSettings["apikey"].ToString();
            if (!apikey.Equals(stored_apikey))
            {
                return Unauthorized();
            }

            KIOSK kIOSK = db.KIOSKs.SingleOrDefault(x=>x.MAKO.Equals(makiosk));
            if (kIOSK == null)
            {
                return NotFound();
            }

            

            try
            {
                token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                token = MD5Gen.CreateMD5(token);

                if (ModelState.IsValid)
                {
                    kIOSK.MaToken = token;
                    db.SaveChanges();
                    return Ok(token);
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