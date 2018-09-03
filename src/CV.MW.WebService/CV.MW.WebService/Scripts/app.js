function InitApp() {
    _app = new App();
}
var App = /** @class */ (function () {
    function App() {
        console.log('app.ctor()');
        //let xhr = new XMLHttpRequest();
        //xhr.open("GET", "");
        //xhr.setRequestHeader("Content-Type", "application/json");
    }
    return App;
}());
var AjaxHelper;
(function (AjaxHelper) {
    var CustomerApiClient = /** @class */ (function () {
        function CustomerApiClient() {
        }
        return CustomerApiClient;
    }());
    AjaxHelper.CustomerApiClient = CustomerApiClient;
    var CustomerUI = /** @class */ (function () {
        function CustomerUI() {
        }
        return CustomerUI;
    }());
    AjaxHelper.CustomerUI = CustomerUI;
})(AjaxHelper || (AjaxHelper = {}));
//# sourceMappingURL=app.js.map