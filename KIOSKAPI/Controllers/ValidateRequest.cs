using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KIOSKAPI.Models;

namespace KIOSKAPI.Controllers
{
    public class ValidateRequest
    {
        public static bool IsValid(string token, string makiosk)
        {

            if (token == null || makiosk == null)
            {
                return false;
            }

            try
            {
                using (QLKIOSKEntities db = new QLKIOSKEntities())
                {
                    KIOSK k = db.KIOSKs.SingleOrDefault(x => x.MAKO.Equals(makiosk) && x.MaToken.Equals(token));

                    if (k != null)
                    {
                        return true;
                    } 
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}