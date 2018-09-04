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
            AddValue("Database", "Database", 2);
            AddValue("ProjectManagement", ".ProjectManagement", 3);
            AddValue("Frameworks", ".Frameworks", 4);
            AddValue("VersionControl", ".VersionControl", 5);
            AddValue("NotYetDefined", "Unknown", 99);
        }
    }
}
