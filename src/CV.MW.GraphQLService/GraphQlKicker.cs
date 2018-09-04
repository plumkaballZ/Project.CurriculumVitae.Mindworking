using CV.MW.Repository;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService
{
    public class GraphQLKicker
    {
        public GraphQLKicker()
        {

        }


        public void Kick(IServiceCollection srv)
        {
            srv.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            //srv.AddSingleton<DeveloperRepo>();
            //srv.AddSingleton<SkillRepo>();

            //srv.AddSingleton<CodeNinjaQueries>();
            //srv.AddSingleton<CodeNinjaType>();
            //srv.AddSingleton<SkillType>();

            //srv.AddSingleton<GraphEntityInterface>();
            //srv.AddSingleton<ISchema, CodeNinjaSchema>();
        }

    }
}
