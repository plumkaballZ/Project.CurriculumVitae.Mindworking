using GraphQL.Types;
using System;
using System.Threading.Tasks;

namespace CV.MW.GraphQLService
{
    public class TestQuery : ObjectGraphType<object>
    {
        public TestQuery()
        {
            Name = "Query";

            Field<AsdfTestInteface>("asdf", resolve: context => GetAsdfString());
        }
        public Task<testObj> GetAsdfString()
        {
            return Task.FromResult(new testObj());
        }
    }
    public class AsdfTestInteface : InterfaceGraphType<testObj>
    {
        public AsdfTestInteface()
        {
            Name = "asdfTest";
            Field(d => d.Id).Description("The id of the character.");
        }
    }
    public class testObj
    {
        public string Id { get; set; }

    }
}
