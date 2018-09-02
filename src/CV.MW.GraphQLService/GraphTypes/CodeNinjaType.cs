using CV.MW.DTOs;
using CV.MW.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.Types
{
    public class CodeNinjaType : ObjectGraphType<Developer>
    {
        public CodeNinjaType(SkillRepo skillRepo)
        {
            Name = "CodeNinja";

            Field(n => n.Id).Description("id");
            Field(n => n.Name, nullable: false).Description("name");
            Field(n => n.LastName, nullable: false).Description("lastname");

            Field<ListGraphType<SkillType>>(
               "skills",
               resolve: context => skillRepo.GetByDeveloperUid(context.Source.Uid)
           );

            Interface<GraphEntityInterface>();
        }
    }
}
