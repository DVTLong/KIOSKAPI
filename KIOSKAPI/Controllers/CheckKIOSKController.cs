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
    public class CheckKIOSKController : ApiController
    {
        private QLKIOSKEntities db = new QLKIOSKEntities();

        /// <summary>
        /// Check kiosk and token if it's valid
        /// </summary>
        /// <param name="f">mako;matoken</param>
        /// <returns>OK if valid</returns>
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult IsValid(FormDataCollection f)
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

                if (k != null)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return NotFound();
        }
    }
}
