//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TenantAddress
    {
        public System.Guid TenantAddress_Id { get; set; }
        public System.Guid TenantAddress_TenantId { get; set; }
        public string TenantAddress_CompanyName { get; set; }
        public Nullable<int> TenantAddress_DoorNo { get; set; }
        public string TenantAddress_StreetName { get; set; }
        public string TenantAddress_CityName { get; set; }
        public string TenantAddress_CountryName { get; set; }
        public string TenantAddress_ContactNumber { get; set; }
        public string TenantAddress_EmailId { get; set; }
        public string TenantAddress_ContactPersonName { get; set; }
        public bool TenantAddress_Status { get; set; }
    
        public virtual TenantDetail TenantDetail { get; set; }
    }
}
