
var data = {};
var labsClient = angular.module("softlabs", ['ui.router'])
labsClient.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');
    $stateProvider
    .state("home", {
        url: '/home',
        templateUrl: "../views/home.html",
        controler:"homeCtrl"
        
    })
    
 
    .state("order", {
        url: '/order',
        
        templateUrl: "../views/order.html",
       
      
    })
       .state("order.general", {
           
           url: '/general',
           templateUrl: "../views/steps/GeneralInfo.html",
           parent: "order",
           controller: "generalCtrl"
           
       })
     .state("order.functional", {
         url: '/functional',
         parent: "order",
         templateUrl: "../views/steps/functional.html",
         
     })
      .state("order.design", {
          url: '/design',
          parent: "order",
         templateUrl: "../views/steps/Design.html",
        
      })
         .state("order.summary", {
             url: '/summary',
             parent: "order",
             templateUrl: "../views/steps/summary.html",
           
         })
     
       
}); 
labsClient.service('orderService', ["$http",function ($http) {
    var data = {};
    return {
        data: data,
        isGeneral:false,
        sendOrder: function (data) {
            $http.post("/api/order", data)
            .success(function (data, status, headers) {
                alert("Thanks!! Your order is sended!!")
            })
            .error(function (data, status, header) {
                alert(status+"  "+data)
            });

        },
        sendMessage: function (data) {
            $http.post("/home/AddMessage", data)
            .success(function (data, status, headers) {
                alert("Thanks!! Your message is sended!!")
            })
            .error(function (data, status, header) {
                alert(status)
            });

        }
    };
}]);
labsClient.controller('homeCtrl',['$scope','$http','orderService',function ($scope, $http,orderService){

        
    $scope.contactSend = function () {
        if ($scope.contactForm.$valid) {
            var data = JSON.stringify({
                Name : $scope.name,
                Email: $scope.email,
                Message : $scope.message

            });
            orderService.sendMessage(data);
        }
    }

}])

labsClient.controller('generalCtrl', ["$scope", "$http","orderService","$state", function ($scope, $http,orderService,$state) {
    
    $scope.generalSend= function () {

       
        if ($scope.generalForm.$valid) {
            

            orderService.data = {
                FullName: $scope.fullname,
                Email: $scope.email,
                Phone: $scope.phone,
                Description: $scope.description,
                SiteType: $scope.type,
                IsAuth: undefined,
                IsChat: undefined,
                IsForum: undefined,
                FuncDescription: undefined
            };
            orderService.isGeneral = true;
            
            console.log(orderService);
           $state.go('order.functional');

         
        }

    };
}]);

labsClient.controller('functionalCtrl', ['$scope', 'orderService',"$state", function ($scope, orderService,$state) {
    if (orderService.isGeneral) {
        $scope.functionalSend = function () {
            orderService.data.IsAuth = $scope.isAuth;
            orderService.data.IsChat = $scope.isChat;
            orderService.data.IsForum = $scope.isForum;
            orderService.data.FuncDescription = $scope.funcDescription;
            $state.go('order.design');
            console.log(orderService);
        }
    }
    else {
        alert("Please Type your general Iafo")
    }

   
}]);
labsClient.controller('designCtrl', ['$scope', 'orderService', "$state", function ($scope, orderService,$state) {
    if (orderService.isGeneral) {
        $scope.designSend = function () {
            orderService.data.Color1 = $scope.color1;
            orderService.data.Color2 = $scope.color2;
            orderService.data.Color3 = $scope.color3;
            $state.go('order.summary');
            console.log(orderService);
        }
    }
    else {
        alert("Please Type your general Iafo")
    }
}]);

labsClient.controller('summaryCtrl', ['$scope', 'orderService', "$state", function ($scope, orderService, $state) {
    if (orderService.isGeneral) {
        $scope.summarySend = function () {
            orderService.data.PrimaryPrice = $scope.primaryPrice;
            orderService.sendOrder(JSON.stringify(orderService.data));
            console.log(orderService);
        }
        
    }
    else {
        alert("Please Type your general Iafo")
    }

}]);
