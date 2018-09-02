using CV.MW.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.Repository
{
    public class SkillRepo
    {
        public IEnumerable<Skill> GetByDeveloperUid(Guid uid)
        {
            return new List<Skill>() {
                new Skill() { Name = "C#", Lvl = 7 },
                new Skill() { Name = "VB", Lvl = 5 },
                new Skill() { Name = "C++", Lvl = 4 },
                new Skill() { Name = "Java", Lvl = 3 },
                new Skill() { Name = ".NET Core", Lvl = 7 },
                new Skill() { Name = "SQL", Lvl = 7 },
                new Skill() { Name = "Git", Lvl = 7 },
                new Skill() { Name = "SCRUM", Lvl = 6 }
            };
        }
        public Skill GetById(string id)
        {
            return new Skill() { Id = "1", Name = "C#", Lvl = 10 };
        }
    }
}
