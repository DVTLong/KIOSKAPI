using System;
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
    public class PostNapTienController : ApiController
    {
        // POST: api/PostLapHoaDon/
        /// <summary>
        /// Lập hóa đơn
        /// </summary>
        /// <param name="f">token, makiosk, MaSSC, MaHTTT, cthdTableTypes</param>
        /// <returns></returns>

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult PostNapTien(NapTienRequestCollection r)
        {
            string token = r.Token;
            string makiosk = r.MaKIOSK;

            if (!ValidateRequest.IsValid(token, makiosk))
            {
                return Unauthorized();
            }

            QLKIOSKClientEntities db = ClientDBInstance.GetDBInstance(makiosk);

            string maSSC = r.MaSSC;
            List<ChiTietNapTableType> ctnt = r.ChiTietNapTableType;


            try
            {
                if (ModelState.IsValid)
                {
                    var proc = new sp_NapTien()
                    {
                        NgayNap = DateTime.Now,
                        GioNap = DateTime.Now.TimeOfDay,
                        MaSSC = maSSC,
                        MaKO = makiosk,
                        ChiTietNapTableType = ctnt
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
