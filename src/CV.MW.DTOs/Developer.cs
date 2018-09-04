using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.DTOs
{
    public class Developer : dbEntity
    {
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }

        public Skill[] Skills { get; set; }
        public Education[] Educations { get; set; }

    }
}
