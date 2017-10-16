angular.module("StationListApp", [])
	.controller("StationListCtrl",
		function($scope, $http) {
			$scope.working = false;
			$scope.title = "Initializing...";
			$scope.stations = [];

			$scope.loadStations = function() {
				$scope.working = true;
				$scope.title = "Loading stations...";
				$scope.stations = [];

				$http.get("/api/stations").then(function(result) {
					$scope.stations = result.data;
					$scope.title = "Here is the station list.";
					$scope.working = false;
				}).catch(function() {
					$scope.title = "Unable to load stations.";
					$scope.working = false;
				});
			}
		});