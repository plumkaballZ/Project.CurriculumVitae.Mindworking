using CV.MW.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.Repository
{
    public class EducationRepo : _IBaseRepo<Education>
    {
        private List<Education> _educationTable = new List<Education>()
        {
            new Education(){
                Id = "1",
                Name = "Datamatiker",
                StartDate = new DateTime(2012, 01, 01),
                EndDate = new DateTime(2015, 01, 01),
                City = "Grenaa"
            },

             new Education(){
                Id = "2",
                Name = "HTX",
                StartDate = new DateTime(2009, 01, 01),
                EndDate = new DateTime(2012, 01, 01),
                City = "Haderslev"
            }
        };
        public bool Create(Education entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Education> GetAll()
        {
            return _educationTable;
        }

        public Education GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
