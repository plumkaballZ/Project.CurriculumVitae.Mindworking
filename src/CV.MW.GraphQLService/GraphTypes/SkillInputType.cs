using CV.MW.DTOs;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.GraphTypes
{
    public class SkillInputType : InputObjectGraphType<Skill>
    {
        public SkillInputType()
        {
            Name = "SkillInput";
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<StringGraphType>("lvl");
        }
    }
}
