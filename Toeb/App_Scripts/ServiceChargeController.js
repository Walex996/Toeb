var ServiceChargeCtrl = (function () {
    function ServiceChargeCtrl($scope, ServiceChargeService) {
        this.$scope = $scope;
        this.ServiceChargeService = ServiceChargeService;
        var id;
        this.$scope.showCreate = "";
        this.getAllServiceCharges();
        this.getServiceCharge(id);
        this.createServiceCharge();
        this.deleteServiceCharge(id);
    }
    ServiceChargeCtrl.prototype.getAllServiceCharges = function () {
        var _this = this;
        return this.ServiceChargeService.query().$promise.then(function (data) {
            _this.$scope.serviceCharges = data;
        });
    };
    ServiceChargeCtrl.prototype.getServiceCharge = function (id) {
        var _this = this;
        return this.ServiceChargeService.query(id).$promise.then(function (data) {
            _this.$scope.serviceCharge = data;
        }, function (error) {
            console.log(error.data.message);
        });
    };
    ServiceChargeCtrl.prototype.createServiceCharge = function () {
        var _this = this;
        this.ServiceChargeService.save(this.$scope.serviceCharge).$promise.then(function (data) {
            _this.getAllServiceCharges();
        }, function (error) {
            console.log(error.data.message);
        });
    };
    ServiceChargeCtrl.prototype.deleteServiceCharge = function (id) {
        var _this = this;
        this.ServiceChargeService.delete({ id: id }).$promise.then(function (data) {
            _this.getAllServiceCharges();
        }, function (error) {
            console.log(error.data.message);
        });
    };
    ServiceChargeCtrl.prototype.showCreate = function () {
        this.$scope.showCreate = "show create form";
    };
    ServiceChargeCtrl.$inject = ["$scope", "ServiceChargeResource"];
    return ServiceChargeCtrl;
}());
angular.module("app").controller("ServiceChargeCtrl", ServiceChargeCtrl);
//# sourceMappingURL=ServiceChargeController.js.map