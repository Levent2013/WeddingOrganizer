//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingOrganizer.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guest
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public Nullable<int> NumberofPeople { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<int> Zip { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public Nullable<bool> RSVPRecieved { get; set; }
    }
}