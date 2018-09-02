using CV.MW.GraphQLService.Types;
using CV.MW.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CV.MW.GraphQLService.Helpers
{
    public class CodeNinjaQueries : ObjectGraphType<object>
    {
        public CodeNinjaQueries(DeveloperRepo devRepo, SkillRepo skillRepo)
        {
            Name = "Query";
            Field<CodeNinjaType>(
                "Ervin", 
                resolve: context => devRepo.GetByName("Ervin"));

            //Func<ResolveFieldContext, string, object> func = (context, id) => GetErvinCodeNinja();

            //FieldDelegate<CodeNinjaType>(
            //     "codeNinja",
            //     arguments: new QueryArguments(
            //         new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id" }
            //     ),
            //     resolve: func
            // );
        }
    }
}
