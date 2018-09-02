using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CV.MW.DTOs;
using CV.MW.GraphQLService;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CV.MW.WebService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<TestQuery>();
            services.AddSingleton<ISchema, TestSchema>();

            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
                _.ExposeExceptions = true;
            }).AddUserContextBuilder(httpContext => httpContext.User); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>("/graphql");

            //// use graphql-playground at default url /ui/playground
            //app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            //{
            //    Path = "/ui/playground"
            //});

            //app.UseGraphQL<ISchema>("/graphql");

            //app.Run(async (context) =>
            //{
            //    TestDataObject test = new TestDataObject();
            //    await context.Response.WriteAsync("CV.MW.WebService::Running " + test.TestString);
            //});
        }
    }
}
