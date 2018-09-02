using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.Helpers
{
    public class CodeNinjaSchema : Schema
    {
        public CodeNinjaSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<CodeNinjaQueries>();
        }
    }
}
