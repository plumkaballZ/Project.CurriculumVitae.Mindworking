using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService
{
    public class TestSchema : Schema
    {
        public TestSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<TestQuery>();
        }
    }
}
