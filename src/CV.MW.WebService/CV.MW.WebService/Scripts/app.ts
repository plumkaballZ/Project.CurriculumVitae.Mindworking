declare var _app: any;


function InitApp() {
    _app = new App();
}

class App {
    constructor() {
        console.log('app Ctor');

        let xhr = new XMLHttpRequest();
        xhr.open("GET", "");
        xhr.setRequestHeader("Content-Type", "application/json");
    }
}

module AjaxHelper {

    export class CustomerApiClient {

    }

    export class CustomerUI {

    }
}