using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace DAL
{
    public class CheckAdminCredentialDAL : ICheckAdminCredentialDAL
    {
        /// <summary>
        /// This method is used for checking the login.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool CheckAdminCredential(Nullable<System.Guid> tenantId,string UserName,string Password)
        {
            bool result = false;
            TrainingWheelsAdminDbEntities TrainingWheelsEntity = new TrainingWheelsAdminDbEntities();
            //accessing sp using entity framework db entity context.
            result = Convert.ToBoolean(TrainingWheelsEntity.SP_CheckCred(tenantId, UserName, Password).Select(s=>s.ToString()).FirstOrDefault());
            return result;
        }
    }
}
