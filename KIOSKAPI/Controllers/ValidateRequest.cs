using System;
using System.Collections.Generic;
using System.Configuration;
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
                    v_kiosk_constr k = db.v_kiosk_constr.SingleOrDefault(x => x.MAKO.Equals(makiosk) && x.MaToken.Equals(token));

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

        public static bool APIKeyIsValid(string apikey)
        {
            string stored_apikey = ConfigurationManager.AppSettings["apikey"].ToString();
            if (apikey.Equals(stored_apikey))
            {
                return true;
            }

            return false;
        }
    }
}