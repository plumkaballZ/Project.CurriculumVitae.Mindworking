using CV.MW.DTOs;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.Types
{
    public class GraphEntityInterface : InterfaceGraphType<dbEntity>
    {
        public GraphEntityInterface()
        {
            Name = "GraphEntity";
            Field(d => d.Id).Description("Id");
            Field(d => d.Name).Description("name");
        }
    }
}
