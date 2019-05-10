﻿using System;
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

        // GET: api/ClearToken/
        /// <summary>
        /// Xóa token
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="makiosk">kiosk</param>
        /// <returns></returns>
        [AllowAnonymous]
        public IHttpActionResult ClearToken(string token, string makiosk)
        {
            if (ValidateRequest.IsValid(token, makiosk))
            {
                return BadRequest();
            }

            try
            {
                KIOSK k = db.KIOSKs.SingleOrDefault(x => x.MAKO.Equals(makiosk));

                if (k != null && ModelState.IsValid)
                {
                    k.MaToken = null;

                    db.SaveChanges();
                    return Ok();
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
