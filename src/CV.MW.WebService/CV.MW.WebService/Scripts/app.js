var _queryManager;
var _tablePopulater;
function InitApp() {
    _queryManager = new QueryManager();
    _tablePopulater = new TablePopulater();
    _app = new App();
}
function populateTable(tableId, data) {
    $(tableId).bootstrapTable({
        data: data
    });
}
var App = /** @class */ (function () {
    function App() {
        var graphQLApiClient = new GraphQLApiClient('https://localhost:44385/graphql?');
        graphQLApiClient.SendQuery(_queryManager.GetDeveloperInfo(), _tablePopulater.devTable);
        graphQLApiClient.SendQuery(_queryManager.GetSkillsList(), _tablePopulater.skillsTable);
        graphQLApiClient.SendQuery(_queryManager.GetSingleStringById(), _tablePopulater.singleSkillTable);
        graphQLApiClient.SendQuery(_queryManager.GetListOfEducations(), _tablePopulater.educationsTable);
        graphQLApiClient.SendQuery(_queryManager.GetAllData(), _tablePopulater.finalTable);
    }
    return App;
}());
var GraphQLApiClient = /** @class */ (function () {
    function GraphQLApiClient(url) {
        this._url = url;
    }
    GraphQLApiClient.prototype.SendQuery = function (query, callBack) {
        this.callGraphQL("query=", "POST", query, callBack);
    };
    GraphQLApiClient.prototype.callGraphQL = function (url, httpMode, query, callBack) {
        var xhttp = new XMLHttpRequest();
        xhttp.open(httpMode, this._url + url + query, true);
        xhttp.setRequestHeader("Content-Type", "application/json");
        xhttp.send();
        xhttp.onload = function (response) {
            var data = response.target.response;
            callBack(JSON.parse(data));
        };
    };
    return GraphQLApiClient;
}());
var QueryManager = /** @class */ (function () {
    function QueryManager() {
    }
    QueryManager.prototype.GetDeveloperInfo = function () {
        return "{ervin{id name lastName age role}}";
    };
    QueryManager.prototype.GetSkillsList = function () {
        return "{ ervin { skills{ name lvl type } } }";
    };
    QueryManager.prototype.GetSingleStringById = function () {
        return "{skill(id:\"1\"){name type}}";
    };
    QueryManager.prototype.GetListOfEducations = function () {
        return "{ ervin { educations { name startDate endDate} } }";
    };
    QueryManager.prototype.GetAllData = function () {
        return "{ ervin { id name educations { id name } skills { id name } } }";
    };
    return QueryManager;
}());
var TablePopulater = /** @class */ (function () {
    function TablePopulater() {
    }
    TablePopulater.prototype.devTable = function (obj) {
        obj.data.ervin.query = _queryManager.GetDeveloperInfo();
        populateTable('#devTable', [obj.data.ervin]);
    };
    TablePopulater.prototype.skillsTable = function (obj) {
        obj.data.ervin.skills[0].query = _queryManager.GetSkillsList();
        populateTable('#skillsTable', obj.data.ervin.skills);
    };
    TablePopulater.prototype.singleSkillTable = function (obj) {
        obj.data.skill.query = _queryManager.GetSingleStringById();
        populateTable('#singleSkillTable', [obj.data.skill]);
    };
    TablePopulater.prototype.educationsTable = function (obj) {
        obj.data.ervin.educations[0].query = _queryManager.GetListOfEducations();
        populateTable('#educationTable', obj.data.ervin.educations);
    };
    TablePopulater.prototype.finalTable = function (obj) {
        //console.log(obj);
        //var finalObj = [
        //    obj.Ervin,
        //    obj.educations
        //]
        //populateTable('#finalTable', finalObj)
        //populateTable('#finalTable', obj.data.ervin.skills)
        //obj.data.ervin.educations[0].query = _queryManager.GetAllData();
        //populateTable('#educationTable', obj.data.ervin.educations)
    };
    return TablePopulater;
}());
//# sourceMappingURL=app.js.map