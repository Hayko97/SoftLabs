var labsClient = angular.module("labsAdmin", ['ui.router'])

labsClient.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/messages');
    $stateProvider
 
    .state("messages", {
        url: '/messages',
        templateUrl: "../views/Admin/messages.html",
        controller: "messagesCtrl"
    })
    .state("orders", {
        url: '/orders',
        templateUrl: "../views/Admin/orders.html",
        controller: "ordersCtrl"
    })


});

labsClient.controller('messagesCtrl', ['$scope','$http', function ($scope,$http) {
    
  
    $http.get("/home/GetMessages")
            .success(function (data, status, headers) {
                $scope.messages = data;

            })
            .error(function (data, status, header) {

            });

    $scope.deleteMessage = function (id) {
        $http.delete("home/DeleteMessage/" + id)
           .success(function (data, status, headers) {
            $("#" + id).remove();
        })
            .error(function (data, status, header, config) {
                
               
            });
    }
   
}]);
labsClient.controller('ordersCtrl', ['$scope', '$http', function ($scope, $http) {
    
    $http.get("/api/order")
             .success(function (data, status, headers) {
                 console.log(data);
                 $scope.orders = data;
                 $scope.curr = 0;
                 return data;
             })
             .error(function (data, status, header) {
                 alert(status + "  " + data)
             });

    $scope.deleteOrder = function (id) {
        $http.delete("api/order/" + id).success(function (data, status, headers) {
            $("#" + id).remove();
        })
            .error(function (data, status, header, config) {
                
               
            });
    }
}]);