angular.module("StationDistanceApp", [])
	.controller("StationDistanceCtrl", function ($scope, $http) {
		$scope.stationA = "";
		$scope.stationB = "";
		$scope.distance = 0;
		$scope.working = false;
		$scope.clearBtnActive = false;
		$scope.calculateBtnActive = false;
		$scope.showDistance = false;
		$scope.title = "Initializing...";
		$scope.stations = [];

		$scope.loadStations = function () {
			$scope.working = true;
			$scope.clearBtnActive = false;
			$scope.calculateBtnActive = false;
			$scope.showDistance = false;
			$scope.distance = -1;
			$scope.title = "Loading stations...";
			$scope.stations = [];

			$http.get("/api/stations").then(function (result) {
				$scope.stations = result.data;
				$scope.title = "Please select two stations to calculate the distance between them.";
				$scope.working = false;
			}).catch(function () {
				$scope.title = "Unable to load stations.";
				$scope.working = false;
			});			
		}

		$scope.calculateDistance = function () {
			$scope.working = true;
			$scope.title = "Calculating Distations...";

			var apiRoute = "api/stations/" + $scope.stationA + "/distance/" + $scope.stationB;

			$http.get(apiRoute).then(function (result) {
				var unRoundedDistance = result.data.distance;
				$scope.distance = Math.round(100*unRoundedDistance)/100 + " miles";
				$scope.showDistance = true;
				$scope.title = "Distance calculated";
				$scope.working = false;
			}).catch(function () {
				$scope.title = "Unable to find distance.";
				$scope.working = false;
			});
		}

		$scope.checkButtons = function () {
			$scope.clearBtnActive = true;

			if ($scope.stationA !== "" && $scope.stationB !== "") {
				$scope.calculateBtnActive = true;
			}
		}

		$scope.clearStations = function() {
			$scope.stationA = "";
			$scope.stationB = "";
			$scope.distance = 0;
			$scope.showDistance = false;
			$scope.clearBtnActive = false;
			$scope.calculateBtnActive = false;
			$scope.title = "Please select two stations to calculate the distance between them.";
		}
	});