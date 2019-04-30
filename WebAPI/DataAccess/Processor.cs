//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Processor
    {
        public byte ID { get; set; }
        public string Name { get; set; }
        public string MerchantConfigTable { get; set; }
        public string InterfaceConfigTable { get; set; }
        public string PendingTable { get; set; }
        public string SettledTable { get; set; }
        public string TestCardNum { get; set; }
        public short BatchUploadPort { get; set; }
        public string BatchUploadPath { get; set; }
        public Nullable<byte> AccountTypeSettlement { get; set; }
        public Nullable<byte> AccountTypeReserve { get; set; }
        public bool MultiCurrencyEnabled { get; set; }
        public bool SettleContinuously { get; set; }
        public int BatchCutOffTimeInMinutes { get; set; }
        public byte DccType { get; set; }
        public bool SupportsCP { get; set; }
        public string ExternalCode { get; set; }
        public bool Active { get; set; }
        public string BusinessName { get; set; }
        public decimal MaxTransactionAmount { get; set; }
        public int ProcessingSystemID { get; set; }
        public Nullable<int> CloseMessageDelayDays { get; set; }
        public bool SupportsRecurringBilling { get; set; }
        public bool IsStandardConfig { get; set; }
        public bool DisplayForMerchantSelfConfig { get; set; }
        public bool AllowVoidAfterBatching { get; set; }
        public short MaxTransCountPerBatch { get; set; }
    }
}
