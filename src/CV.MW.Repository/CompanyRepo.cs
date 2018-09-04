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
            new Company(){Id = "1", Name = "Sport Solution A/S"},
            new Company(){Id = "2", Name = "eMino Software ApS"},
            new Company(){Id = "3", Name ="My Own Company"},
            new Company(){Id = "4", Name = "FlexPos"}
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
