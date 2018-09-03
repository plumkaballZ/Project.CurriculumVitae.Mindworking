using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.GraphTypes
{
    public class SkillTypeEnum : EnumerationGraphType
    {
        public SkillTypeEnum()
        {
            Name = "SkillTypeEnum";
            Description = "SkillTypeEnum";
            AddValue("Coding", "Coding", 1);
            AddValue("Database", "Coding", 2);
            AddValue("ProjectManagement", ".Coding", 3);
        }
    }
    public enum SkillTypes
    {
        Coding = 1,
        Database = 2,
        ProjectManagement = 3
    }
}
