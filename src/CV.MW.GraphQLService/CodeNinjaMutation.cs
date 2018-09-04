using CV.MW.DTOs;
using CV.MW.GraphQLService.GraphTypes;
using CV.MW.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService
{
    public class CodeNinjaMutation : ObjectGraphType
    {
        public CodeNinjaMutation(SkillRepo skillRepo)
        {
            Name = "Mutation";

            Field<SkillType>(
                "createSkill",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SkillInputType>> { Name = "skill" }
                ),
                resolve: context =>
                {
                    var skill = context.GetArgument<Skill>("skill");
                    return skillRepo.Create(skill);
                });
        }
    }
}
