//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniProject_TrainReservation
{
    using System;
    
    public partial class ViewCancellations_Result
    {
        public int CancellationDetailId { get; set; }
        public int BookingId { get; set; }
        public int SeatsCancelled { get; set; }
        public decimal RefundAmount { get; set; }
        public System.DateTime CancellationDate { get; set; }
        public object Cancellation_Id { get; internal set; }
    }
}
