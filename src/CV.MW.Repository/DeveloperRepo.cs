using CV.MW.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.Repository
{
    public class DeveloperRepo
    {
        public Developer GetByName(string name)
        {
            return new Developer() {
                Id = "1",
                Name = "Ervin",
                LastName = "Færgemand",
                Age = 28,
                Uid = Guid.NewGuid()
            };
        }
    }
}
