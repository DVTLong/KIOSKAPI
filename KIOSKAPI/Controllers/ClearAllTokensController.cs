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
    public class ClearAllTokensController : ApiController
    {
        private QLKIOSKEntities db = new QLKIOSKEntities();

        // POST: api/ClearAllTokens/
        /// <summary>
        /// Clear token of all kiosks
        /// </summary>
        /// <param name="f">password</param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult ClearAllTokens(FormDataCollection f)
        {
            string password = f["password"];
            if (password == null)
            {
                return BadRequest("Null password");
            }
            string storepass = ConfigurationManager.AppSettings["pass"].ToString();
            if (!password.Equals(storepass))
            {
                return Unauthorized();
            }

            try
            {
                List<KIOSK> kiosks = db.KIOSKs.ToList();

                if (ModelState.IsValid)
                {
                    foreach (KIOSK k in kiosks)
                    {
                        k.MaToken = null;
                    }

                    db.SaveChanges();
                    return Ok("Cleared");
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
