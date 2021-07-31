﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSProject.Entities
{
    public class Booking
    {
        public int ID { get; set; }
        public int AccomodationID { get; set; }
        public Accomodation Accomodation { get; set; }
        public DateTime FromDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Duration { get; set; } //NoOfStayNights

    }
}
