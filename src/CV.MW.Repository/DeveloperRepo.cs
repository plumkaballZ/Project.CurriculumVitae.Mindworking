using CV.MW.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.MW.Repository
{
    public class DeveloperRepo : _IBaseRepo<Developer>
    {
        private List<Developer> _devTable = new List<Developer>() { new Developer() {
            Id = "1",
            Name = "Ervin",
            LastName = "Færgemand",
            Age = 28,
            Role = "CodeNinja",
            Uid = Guid.NewGuid()
        } };

        public IEnumerable<Developer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Developer GetById(string id)
        {
            return _devTable.FirstOrDefault();
        }
    }
}
