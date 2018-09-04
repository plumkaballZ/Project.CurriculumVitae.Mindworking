using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.DTOs
{
    public class Education : dbEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
    }
}
