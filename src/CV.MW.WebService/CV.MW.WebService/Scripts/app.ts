declare var _app: App;
declare var $: any;

var _queryManager: QueryManager;
var _tablePopulater: TablePopulater;

function InitApp() {
    _queryManager = new QueryManager();
    _tablePopulater = new TablePopulater(); 
    _app = new App();
}

function populateTable(tableId: string, data: any) {

    $(tableId).bootstrapTable({
        data: data
    });
}

class App {
    constructor() {
        var graphQLApiClient = new GraphQLApiClient('https://localhost:44385/graphql?');

        graphQLApiClient.SendQuery(_queryManager.GetDeveloperInfo(), _tablePopulater.devTable);

        graphQLApiClient.SendQuery(_queryManager.GetSkillsList(), _tablePopulater.skillsTable);

        graphQLApiClient.SendQuery(_queryManager.GetSingleStringById(), _tablePopulater.singleSkillTable);

        graphQLApiClient.SendQuery(_queryManager.GetListOfEducations(), _tablePopulater.educationsTable);

        graphQLApiClient.SendQuery(_queryManager.GetAllData(), _tablePopulater.finalTable);
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
}



class TablePopulater {

    devTable(obj: any): void {
        obj.data.ervin.query = _queryManager.GetDeveloperInfo();
        populateTable('#devTable', [obj.data.ervin])
    }

    skillsTable(obj: any): void {
        obj.data.ervin.skills[0].query = _queryManager.GetSkillsList();
        populateTable('#skillsTable', obj.data.ervin.skills)
    }

    singleSkillTable(obj: any): void {
        obj.data.skill.query = _queryManager.GetSingleStringById();
        populateTable('#singleSkillTable', [obj.data.skill])
    }

    educationsTable(obj: any): void {
        obj.data.ervin.educations[0].query = _queryManager.GetListOfEducations();
        populateTable('#educationTable', obj.data.ervin.educations)
    }
    finalTable(obj: any): void {
        //console.log(obj);

        //var finalObj = [
        //    obj.Ervin,
        //    obj.educations
        //]

        //populateTable('#finalTable', finalObj)
        //populateTable('#finalTable', obj.data.ervin.skills)

        //obj.data.ervin.educations[0].query = _queryManager.GetAllData();
        //populateTable('#educationTable', obj.data.ervin.educations)
    }

}

