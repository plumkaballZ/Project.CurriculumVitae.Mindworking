using CV.MW.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.MW.Repository
{
    public class SkillRepo : _IBaseRepo<Skill>
    {
        private List<Skill> _skillTable = new List<Skill>()
        {
            new Skill() { Id = "1", Name = "C#", Lvl = 7, Type = 1 },
            new Skill() { Id = "2", Name = "VB", Lvl = 5, Type = 1 },
            new Skill() { Id = "3", Name = "C++", Lvl = 4, Type = 1 },
            new Skill() { Id = "4", Name = "Java", Lvl = 3, Type = 1 },
            new Skill() { Id = "5", Name = ".NET Core", Lvl = 7, Type = 4 },
            new Skill() { Id = "6", Name = "SQL", Lvl = 7, Type = 2 },
            new Skill() { Id = "7", Name = "Git", Lvl = 7, Type = 4},
            new Skill() { Id = "8", Name = "SCRUM", Lvl = 3, Type = 3 }
            };

        public IEnumerable<Skill> GetAll()
        {
            return _skillTable;
        }

        public Skill GetById(string id)
        {
            return _skillTable.FirstOrDefault(s => s.Id == id);
        }
    }
}
