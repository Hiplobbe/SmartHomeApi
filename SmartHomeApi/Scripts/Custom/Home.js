var HomeApp = angular.module('HomeApp', []);

HomeApp.controller('HomeController', function ($scope, $http) {   
    $scope.timerStarted = false;
    $scope.timeleft = 10;

    $http.get("/GetHomes")
        .then(function (response) {
            $scope.HomeList = response.data;
        });

    $scope.LoadInfo = function () {
        $http({
            url: "homes/" + $scope.SelectedOption + "/data",
            method: "GET",
            params: { id: $scope.SelectedOption}
        })
            .then(function (response) {      
                for (var i = 0; i < response.data.Rooms.length; i++) {
                    response.data.Rooms[i].Properties = $scope.dynamicWrite(response.data.Rooms[i]);
                }

                $scope.SelectedHome = response.data;
                if (!$scope.timerStarted) {
                    $scope.startTimer();

                    $scope.timerStarted = true;
                }                
            });
    };

    $scope.startTimer = function () {
        $scope.interval = setInterval(() => {
            if ($scope.timeLeft > 0) {
                $scope.timeLeft--;
            }
            else {
                $scope.timeLeft = 10;

                $scope.LoadInfo();
            }
        }, 1000);
    };

    $scope.dynamicWrite = function (room) {
        if (room === undefined) {
            return [];
        }

        var properties = Object.keys(room);

        var returnArray = [];

        for (prop of properties) {
            var obj = { Name: prop, Value: room[prop] };

            if (prop === "Temperature") {
                obj.Value = room[prop] + " °C";
            }

            if (prop !== "$$hashKey") {
                returnArray.push(obj);
            }            
        }

        return returnArray;
    };
});