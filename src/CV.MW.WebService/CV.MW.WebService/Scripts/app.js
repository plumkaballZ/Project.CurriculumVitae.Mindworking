var _queryManager;
function InitApp() {
    _queryManager = new QueryManager();
    _app = new App();
}
var App = /** @class */ (function () {
    function App() {
        this._graphQLApiClient = new GraphQLApiClient('https://localhost:44385/graphql?');
        this._graphQLApiClient.SendQuery(_queryManager.GetDeveloperInfo(), this.popDevTable);
        this._graphQLApiClient.SendQuery(_queryManager.GetSkillsList(), this.popSkillsTable);
        this._graphQLApiClient.SendQuery(_queryManager.GetSingleStringById(), this.popSingleSkill);
    }
    App.prototype.popDevTable = function (obj) {
        obj.data.ervin.query = _queryManager.GetDeveloperInfo();
        $('#devTable').bootstrapTable({
            data: [
                obj.data.ervin
            ]
        });
    };
    App.prototype.popSkillsTable = function (obj) {
        obj.data.ervin.skills[0].query = _queryManager.GetSkillsList();
        $('#skillsTable').bootstrapTable({
            data: obj.data.ervin.skills
        });
    };
    App.prototype.popSingleSkill = function (obj) {
        obj.data.skill.query = _queryManager.GetSingleStringById();
        $('#singleSkillTable').bootstrapTable({
            data: [
                obj.data.skill
            ]
        });
    };
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
        return "{ ervin { skills{ name lvl, type } } }";
    };
    QueryManager.prototype.GetSingleStringById = function () {
        return "{skill(id:\"1\"){name, type}}";
    };
    return QueryManager;
}());
//# sourceMappingURL=app.js.map