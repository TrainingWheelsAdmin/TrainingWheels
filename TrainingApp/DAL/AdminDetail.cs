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
    
    public partial class AdminDetail
    {
        public System.Guid AdminDetail_Id { get; set; }
        public System.Guid AdminDetail_AdminScopeId { get; set; }
        public string AdminDetail_Name { get; set; }
        public string AdminDetail_Description { get; set; }
        public System.DateTime AdminDetail_AddedOn { get; set; }
        public System.Guid AdminDetail_AddedBy { get; set; }
        public Nullable<System.DateTime> AdminDetail_UpdatedOn { get; set; }
        public Nullable<System.Guid> AdminDetail_UpdatedBy { get; set; }
        public bool AdminDetail_Status { get; set; }
    
        public virtual AdminScope AdminScope { get; set; }
    }
}