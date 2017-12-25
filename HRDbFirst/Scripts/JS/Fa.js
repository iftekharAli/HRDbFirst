var app = angular.module('myApp', []);
app.factory('httpFactory', function ($http) {




    return {

        geturl: function (url, qs) {
            return $http.get(url,qs).then(function (response) {
                return (response.data);
            });
        }

      

    };

});