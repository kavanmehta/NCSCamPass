//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReceptionProcam.EntityModel
{
    using System;
    
    public partial class uspGetAllAuditDetails_Result
    {
        public int Id { get; set; }
        public Nullable<int> AssetId { get; set; }
        public Nullable<int> EmpId { get; set; }
        public string AssetModelName { get; set; }
        public Nullable<int> AssetCompanyID { get; set; }
        public Nullable<int> AssetTypeID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<bool> IsIssued { get; set; }
        public string LicesenceNo { get; set; }
        public Nullable<System.DateTime> ManufacturingDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<System.DateTime> AssetIssueDateTime { get; set; }
        public Nullable<System.DateTime> AssetSubmitDateTime { get; set; }
        public Nullable<bool> IsSubmited { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> Year { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> AssetAuditDateTime { get; set; }
        public Nullable<bool> IsAudited { get; set; }
    }
}