using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICheckAdminCredentialService
    {
        bool CheckAdminCredential(Nullable<System.Guid> tenantId, string UserName, string Password);
    }
}
