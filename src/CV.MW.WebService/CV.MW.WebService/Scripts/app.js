function InitApp() {
    localUrl = window.location.href;
    _app = new App();
}
var App = /** @class */ (function () {
    function App() {
        var queryManager = new QueryManager();
        var devTable = new GraphQLDataTable('#devTable');
        devTable.SendQueryWithCallBack(queryManager.GetDeveloperInfo(), devTable_fallBackFunc);
        var skillsTable = new GraphQLDataTable('#skillsTable');
        skillsTable.SendQueryWithCallBack(queryManager.GetSkillsList(), skillsTable_fallBackFunc);
        var singleSkillTable = new GraphQLDataTable('#singleSkillTable');
        singleSkillTable.SendQueryWithCallBack(queryManager.GetSingleStringById(), singleSkillTable_fallBackFunc);
        var educationTable = new GraphQLDataTable('#educationTable');
        educationTable.SendQueryWithCallBack(queryManager.GetListOfEducations(), educationsTable_fallBackFunc);
        var educationTable = new GraphQLDataTable('#companyTable');
        educationTable.SendQueryWithCallBack(queryManager.GetAllCompanies(), companyTable_fallBackFunc);
    }
    return App;
}());
var GraphQLDataTable = /** @class */ (function () {
    function GraphQLDataTable(id) {
        this._grapQLClient = new GraphQLApiClient(localUrl + 'graphql?');
        this._id = id;
    }
    GraphQLDataTable.prototype.SendQueryWithCallBack = function (query, fallBack) {
        this._grapQLClient.SendQuery(query, fallBack);
    };
    return GraphQLDataTable;
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
            var jsonObj = JSON.parse(data);
            jsonObj.query = query;
            callBack(jsonObj);
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
    QueryManager.prototype.GetAllCompanies = function () {
        return "{ ervin { companies{ name description } } }";
    };
    return QueryManager;
}());
//callback fucntions :D
function devTable_fallBackFunc(obj) {
    obj.data.ervin.query = obj.query;
    popTable('#devTable', [obj.data.ervin]);
}
function skillsTable_fallBackFunc(obj) {
    obj.data.ervin.skills[0].query = obj.query;
    popTable('#skillsTable', obj.data.ervin.skills);
}
function singleSkillTable_fallBackFunc(obj) {
    obj.data.skill.query = obj.query;
    popTable('#singleSkillTable', [obj.data.skill]);
}
function educationsTable_fallBackFunc(obj) {
    obj.data.ervin.educations[0].query = obj.query;
    popTable('#educationTable', obj.data.ervin.educations);
}
function companyTable_fallBackFunc(obj) {
    obj.data.ervin.companies[0].query = obj.query;
    popTable('#companyTable', obj.data.ervin.companies);
}
function popTable(tableId, data) {
    $(tableId).bootstrapTable({
        data: data
    });
}
//# sourceMappingURL=app.js.map