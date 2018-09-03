using CV.MW.DTOs;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.GraphTypes
{
    public class SkillType: ObjectGraphType<Skill>
    {
        public SkillType()
        {
            Name = "Skill";

            Field(n => n.Id).Description("id");
            Field(n => n.Name, nullable: false).Description("name");
            Field(n => n.Lvl, nullable: false).Description("lvl");
            //Field(n => n.Type, nullable: false).Description("skillType");

            Field<SkillTypeEnum>("type", "Type");

            Interface<GraphEntityInterface>();
        }
    }
}
