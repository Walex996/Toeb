var ServiceChargeResource = (function () {
    function ServiceChargeResource($resource) {
    }
    ServiceChargeResource.factory = function ($resource) {
        var getServiceCharges = {
            url: "api/serviceCharges",
            method: "GET",
            isArray: true
        };
        var update = {
            method: "PUT"
        };
        var resetServiceCharges = {
            url: "api/serviceCharge/resetServiceCharges",
            method: "PUT",
            isArray: false
        };
        var service = $resource("api/serviceCharge/:id", { id: "@id" }, {
            update: update,
            resetServiceCharges: resetServiceCharges,
            getServiceCharges: getServiceCharges
        });
        return service;
    };
    ServiceChargeResource.$inject = ["$resource"];
    return ServiceChargeResource;
}());
angular.module("app").factory("ServiceChargeResource", ServiceChargeResource.factory);
//# sourceMappingURL=ServiceChargeServce.js.map