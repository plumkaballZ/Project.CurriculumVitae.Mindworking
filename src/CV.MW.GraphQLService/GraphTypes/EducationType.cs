using CV.MW.DTOs;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.GraphTypes
{
    public class EducationType : ObjectGraphType<Education>
    {
        public EducationType()
        {
            Name = "Education";
            Field(n => n.Id).Description("id");
            Field(n => n.Name, nullable: false).Description("name");

            Field(n => n.StartDate, nullable: false).Description("startDate");
            Field(n => n.EndDate, nullable: false).Description("endDate");
        }
    }
}
