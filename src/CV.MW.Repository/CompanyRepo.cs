using CV.MW.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.Repository
{
    public class CompanyRepo : _IBaseRepo<Company>
    {
        private List<Company> _companyTable = new List<Company>()
        {
            new Company(){Id = "1", Name = "Sport Solution A/S", Description ="As intern"},
            new Company(){Id = "2", Name = "eMino Software ApS", Description = "As intern"},
            new Company(){Id = "3", Name ="My Own Company", Description ="2-3 months after education as school project"},
            new Company(){Id = "4", Name = "FlexPos", Description = "As full-stack software developer"}
        };
        public bool Create(Company entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll()
        {
            return _companyTable;
        }

        public Company GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
