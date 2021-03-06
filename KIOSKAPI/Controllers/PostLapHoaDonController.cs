﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using EntityFrameworkExtras.EF6;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class PostLapHoaDonController : ApiController
    {
        // POST: api/PostLapHoaDon/
        /// <summary>
        /// Lập hóa đơn
        /// </summary>
        /// <param name="f">token, makiosk, MaSSC, MaHTTT, cthdTableTypes</param>
        /// <returns></returns>

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult PostLapHoaDon(LapHoaDonRequestCollection r)
        {
            string token = r.Token;
            string makiosk = r.MaKIOSK;

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            QLKIOSKClientEntities db = ClientDBInstance.GetDBInstance(makiosk);

            string maSSC = r.MaSSC;
            int maHTTT = Convert.ToInt32(r.MaHTTT);
            List<CTHDTableType> cthd = r.CTHDTableType;
                                               

            try
            {
                if (ModelState.IsValid)
                {
                    var proc = new SP_LapHoaDon()
                    {
                        NgayLap = DateTime.Now,
                        GioLap = DateTime.Now.TimeOfDay,
                        MaSSC = maSSC,
                        MaKO = makiosk,
                        MaHTTT = maHTTT,
                        CTHDTableTypes = cthd
                    };

                    db.Database.ExecuteStoredProcedure(proc);
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
