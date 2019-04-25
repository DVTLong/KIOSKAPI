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
        private QLKIOSKEntities db = new QLKIOSKEntities();

        // POST: api/ClearToken/
        /// <summary>
        /// Clear token of kiosk
        /// </summary>
        /// <param name="f">mako;matoken</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult ClearToken(FormDataCollection f)
        {
            string matoken = f["matoken"];
            string mako = f["mako"];

            if (matoken == null || mako == null)
            {
                return BadRequest("Null parameters");
            }

            try
            {
                KIOSK k = db.KIOSKs.SingleOrDefault(x => x.MAKO.Equals(mako) && x.MaToken.Equals(matoken));

                if (k != null && ModelState.IsValid)
                {
                    k.MaToken = null;

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
