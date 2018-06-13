using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ICheckAdminCredentialDAL
    {
        /// <summary>
        /// This method is used for checking the login.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        bool CheckAdminCredential(Nullable<System.Guid> tenantId, string UserName, string Password);
    }
}
