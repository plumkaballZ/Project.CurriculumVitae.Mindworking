using CV.MW.DTOs;
using CV.MW.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.GraphTypes
{
    public class CodeNinjaType : ObjectGraphType<Developer>
    {
        public CodeNinjaType(SkillRepo skillRepo, EducationRepo educationRepo, CompanyRepo companyRepo)
        {
            Name = "CodeNinja";

            Field(n => n.Id).Description("id");
            Field(n => n.Name, nullable: false).Description("name");
            Field(n => n.LastName, nullable: false).Description("lastname");
            Field(n => n.Age, nullable: false).Description("age");
            Field(n => n.Role, nullable: false).Description("Role");

            Field<ListGraphType<SkillType>>("skills", resolve: context => skillRepo.GetAll());
            Field<ListGraphType<EducationType>>("educations", resolve: context => educationRepo.GetAll());
            Field<ListGraphType<CompanyType>>("companies", resolve: context => companyRepo.GetAll());

            Interface<GraphEntityInterface>();
        }
    }
}
