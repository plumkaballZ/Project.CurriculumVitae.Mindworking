declare var _app: App;
declare var $: any;

var _queryManager: QueryManager;

function InitApp() {
    _queryManager = new QueryManager();
    _app = new App();
} 

class App {
    private _graphQLApiClient: GraphQLApiClient;
   

    constructor() {
        this._graphQLApiClient = new GraphQLApiClient('https://localhost:44385/graphql?');
        this._graphQLApiClient.SendQuery(_queryManager.GetDeveloperInfo(), this.popDevTable);
        this._graphQLApiClient.SendQuery(_queryManager.GetSkillsList(), this.popSkillsTable);
        this._graphQLApiClient.SendQuery(_queryManager.GetSingleStringById(), this.popSingleSkill);
    }

    popDevTable(obj: any): void {

        obj.data.ervin.query = _queryManager.GetDeveloperInfo();

        $('#devTable').bootstrapTable({
            data: [
                obj.data.ervin
            ]
        });
    }

    popSkillsTable(obj: any) {
        obj.data.ervin.skills[0].query = _queryManager.GetSkillsList();
        $('#skillsTable').bootstrapTable({
            data: obj.data.ervin.skills
        });
    }
    popSingleSkill(obj: any) {
        obj.data.skill.query = _queryManager.GetSingleStringById();
        $('#singleSkillTable').bootstrapTable({
            data: [
                obj.data.skill
            ]
         
        });
    }
}

class GraphQLApiClient {

    private _url: string;

    constructor(url: string) {
        this._url = url;
    }

    public SendQuery(query: string, callBack: any) {
        this.callGraphQL("query=", "POST", query, callBack);
    }

    private callGraphQL(url: string, httpMode: string, query: any, callBack: any) {
        let xhttp = new XMLHttpRequest();

        xhttp.open(httpMode, this._url + url + query, true);

        xhttp.setRequestHeader("Content-Type", "application/json");
        xhttp.send();

        xhttp.onload = function (response: any) {
            let data = response.target.response;
            callBack(JSON.parse(data));
        };
    }

}

class QueryManager {
    public GetDeveloperInfo(): string {
        return "{ervin{id name lastName age role}}";
    }
    public GetSkillsList(): string {
        return "{ ervin { skills{ name lvl, type } } }";
    }
    public GetSingleStringById(): string {
        return `{skill(id:"1"){name, type}}`;
    }
}