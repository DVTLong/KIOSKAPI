using KIOSKAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace KIOSKAPI.Controllers
{
    public class ClientDBInstance
    {
        public static QLKIOSKClientEntities GetDBInstance(string makiosk)
        {
            using (QLKIOSKEntities dbmain = new QLKIOSKEntities())
            {
                v_kiosk_constr k = dbmain.v_kiosk_constr.FirstOrDefault(x =>x.MAKO.Equals(makiosk));
                if (k == null)
                {
                    return null;
                }

                string constrInfo = k.ConnectStr;
                char[] seperators = { ';' };
                string[] splits = constrInfo.Split(seperators);
                string instanceName = splits[0];
                string userID = splits[1];
                string password = splits[2];

                QLKIOSKClientEntities db = new QLKIOSKClientEntities();
                db.ChangeDatabase(initialCatalog: "QLKIOSK", userId: userID, password: password, dataSource: instanceName);
                return db; 
            }
        }
    }
}