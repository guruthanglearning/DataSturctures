//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIAuth.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Engagement
    {
        public int EngagementId { get; set; }
        public string EngagementName { get; set; }
        public string EngagementDescription { get; set; }
        public string CRMOpportunityID { get; set; }
        public string CRMOpportunityName { get; set; }
        public Nullable<int> PartnerOrganizationID { get; set; }
        public string ProjectDivision { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedOn { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public byte EngagementTypeID { get; set; }
        public string Skey { get; set; }
        public Nullable<int> CreatedByUserID { get; set; }
        public bool isSelfServe { get; set; }
    }
}
