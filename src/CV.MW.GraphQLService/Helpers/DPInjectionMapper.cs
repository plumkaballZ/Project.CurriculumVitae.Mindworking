using CV.MW.GraphQLService.GraphTypes;
using CV.MW.Repository;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.MW.GraphQLService.Helpers
{
    public class DPInjectionMapper
    {
        private IServiceCollection _srvCollection;

        public DPInjectionMapper(IServiceCollection srv)
        {
            srv.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            //repos
            srv.AddSingleton<DeveloperRepo>();
            srv.AddSingleton<SkillRepo>();
            srv.AddSingleton<EducationRepo>();

            //graphql stuff
            srv.AddSingleton<CodeNinjaQueries>();
            srv.AddSingleton<CodeNinjaMutation>();

            //grapgql types
            srv.AddSingleton<CodeNinjaType>();
            srv.AddSingleton<SkillType>();
            srv.AddSingleton<EducationType>();

            //input type -> for create data
            srv.AddSingleton<SkillInputType>();

            //more grapql stuff
            srv.AddSingleton<GraphEntityInterface>();

            srv.AddSingleton<SkillTypeEnum>();
            srv.AddSingleton<ISchema, CodeNinjaSchema>();

            _srvCollection = srv;
        }

        public IServiceCollection GetServiceCollection()
        {
            return _srvCollection;
        }
    }
}
