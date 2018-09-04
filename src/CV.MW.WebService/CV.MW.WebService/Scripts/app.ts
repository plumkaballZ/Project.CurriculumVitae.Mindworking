declare var _app: App;
declare var $: any;

declare var localUrl: string;

function InitApp() {
    localUrl = window.location.href;
    _app = new App();
}

class App {
    constructor() {
        var queryManager: QueryManager = new QueryManager();


        var devTable = new GraphQLDataTable('#devTable')
        devTable.SendQueryWithCallBack(queryManager.GetDeveloperInfo(), devTable_fallBackFunc)

        var skillsTable = new GraphQLDataTable('#skillsTable')
        skillsTable.SendQueryWithCallBack(queryManager.GetSkillsList(), skillsTable_fallBackFunc)

        var singleSkillTable = new GraphQLDataTable('#singleSkillTable')
        singleSkillTable.SendQueryWithCallBack(queryManager.GetSingleStringById(), singleSkillTable_fallBackFunc)

        var educationTable = new GraphQLDataTable('#educationTable')
        educationTable.SendQueryWithCallBack(queryManager.GetListOfEducations(), educationsTable_fallBackFunc)

        var educationTable = new GraphQLDataTable('#companyTable')
        educationTable.SendQueryWithCallBack(queryManager.GetAllCompanies(), companyTable_fallBackFunc)
    }
}

class GraphQLDataTable {

    private _grapQLClient: GraphQLApiClient;
    private _id: string;

    constructor(id: string) {

        this._grapQLClient = new GraphQLApiClient(localUrl + 'graphql?');
        this._id = id;
    }

    public SendQueryWithCallBack(query: string, fallBack: any): void {
        this._grapQLClient.SendQuery(query, fallBack);
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

            var jsonObj = JSON.parse(data)
            jsonObj.query = query;

            callBack(jsonObj);
        };
    }
}

class QueryManager {
    public GetDeveloperInfo(): string {
        return "{ervin{id name lastName age role}}";
    }
    public GetSkillsList(): string {
        return "{ ervin { skills{ name lvl type } } }";
    }
    public GetSingleStringById(): string {
        return `{skill(id:"1"){name type}}`;
    }
    public GetListOfEducations(): string {
        return "{ ervin { educations { name startDate endDate} } }";
    }
    public GetAllData(): string {
        return "{ ervin { id name educations { id name } skills { id name } } }";
    }
    public GetAllCompanies(): string {
        return "{ ervin { companies{ name description } } }";
    }
}

//callback fucntions :D

function devTable_fallBackFunc(obj: any): void {
    obj.data.ervin.query = obj.query;
    popTable('#devTable', [obj.data.ervin]);
}

function skillsTable_fallBackFunc(obj: any): void {
    obj.data.ervin.skills[0].query = obj.query;
    popTable('#skillsTable', obj.data.ervin.skills);
}

function singleSkillTable_fallBackFunc(obj: any): void {
    obj.data.skill.query = obj.query;
    popTable('#singleSkillTable', [obj.data.skill]);
}

function educationsTable_fallBackFunc(obj: any): void {
    obj.data.ervin.educations[0].query = obj.query;
    popTable('#educationTable', obj.data.ervin.educations);
}

function companyTable_fallBackFunc(obj: any): void {
    obj.data.ervin.companies[0].query = obj.query;
    popTable('#companyTable', obj.data.ervin.companies);
}

function popTable(tableId: string, data: any) {
    $(tableId).bootstrapTable({
        data: data
    });
}





