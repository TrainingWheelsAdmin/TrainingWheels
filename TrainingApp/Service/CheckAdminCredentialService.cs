using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DAL;
using System.IO;
using System.Reflection;
using ServiceContracts;

namespace Service
{
    public class CheckAdminCredentialService : ICheckAdminCredentialService
    {
        private string app_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public bool CheckAdminCredential(Nullable<System.Guid> tenantId, string UserName, string Password)
        {
            bool result = false;
            try
            {
                ICheckAdminCredentialDAL checkAdminCredentialDAL = new CheckAdminCredentialDAL();
                result = checkAdminCredentialDAL.CheckAdminCredential(tenantId, UserName, Password);
            }
            catch (Exception exception)
            {
                File.AppendAllText(app_path + "log.txt", exception.ToString());
            }
            return result;
        }
    }
}
