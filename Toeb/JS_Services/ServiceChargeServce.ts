interface IServiceChargeResource extends ng.resource.IResourceClass<any> {
    getServiceCharges: any;
    update: any;
    resetServiceCharges: any;
}

class ServiceChargeResource {
    static $inject = ["$resource"];

    constructor($resource: ng.resource.IResourceService) {}

    public static factory($resource: ng.resource.IResourceService): IServiceChargeResource {

        var getServiceCharges = {
            url: "api/serviceCharges",
            method: "GET",
            isArray: true
        }

        var update = {
            method: "PUT"
        }

        var resetServiceCharges = {
            url: "api/serviceCharge/resetServiceCharges",
            method: "PUT",
            isArray: false
        }

        var service = <IServiceChargeResource> $resource("api/serviceCharge/:id",
            { id: "@id" },
            {
                update: update,
                resetServiceCharges: resetServiceCharges,
                getServiceCharges: getServiceCharges
            });
        return service;
    }
}

angular.module("app").factory("ServiceChargeResource", ServiceChargeResource.factory);