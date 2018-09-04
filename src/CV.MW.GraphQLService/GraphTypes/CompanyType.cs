using CV.MW.DTOs;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.GraphTypes
{
    public class CompanyType : ObjectGraphType<Company>
    {
        public CompanyType()
        {
            Name = "Company";
            Field(n => n.Id).Description("id");
            Field(n => n.Name, nullable: false).Description("name");
            Field(n => n.Description, nullable: false).Description("description");
        }
    }
}
