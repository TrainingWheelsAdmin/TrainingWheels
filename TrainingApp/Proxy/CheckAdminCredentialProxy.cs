using Service;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class CheckAdminCredentialProxy
    {
        private ICheckAdminCredentialService checkAdminCredentialService;

        //DI using constructor
        public CheckAdminCredentialProxy(ICheckAdminCredentialService checkAdminCredentialService)
        {
            this.checkAdminCredentialService = checkAdminCredentialService;
        }

        public bool CheckAdminCredential(Nullable<System.Guid> tenantId, string UserName, string Password)
        {
            return this.checkAdminCredentialService.CheckAdminCredential(tenantId,UserName,Password);
        }
    }
}
