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
        /// <param name="f">apikey;mako</param>
        /// <returns>token</returns>
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult GetToken(FormDataCollection f)
        {
            string apikey = f["apikey"];
            string mako = f["mako"];

            if (apikey == null || mako == null)
            {
                return BadRequest("Null parameters");
            }

            string token = string.Empty;
            string storekey = ConfigurationManager.AppSettings["apikey"].ToString();
            if (!apikey.Equals(storekey))
            {
                return Unauthorized();
            }

            KIOSK kIOSK = db.KIOSKs.SingleOrDefault(x=>x.MAKO.Equals(mako));
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