using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WeddingOrganizer.Web.Models
{
    public class GuestModel
    {
        public int GuestID { get; set; }
        public string Name { get; set; }

        [DisplayName("# Attn.")]
        public int NumberofPeople { get; set; }
        public string Address { get; set; }

        [DisplayName("Add. 2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        [DisplayName("Home Ph.")]
        public string HomePhone { get; set; }

        [DisplayName("Cell")]
        public string CellPhone { get; set; }

        [DisplayName("RSVP")]
        public bool RSVPRecieved { get; set; }

    }
}