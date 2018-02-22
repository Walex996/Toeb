interface IServiceChargeCtrl extends ng.IScope {
    name: string;
    amount: number;
    account: any;
    isCompulsory: boolean;
    dateCreated: Date;
    totalAmountPaid: number;
    serviceCharges: any;
    serviceCharge: any;
    showCreate: string;
}

class ServiceChargeCtrl {
    static $inject: string[] = ["$scope", "ServiceChargeResource"]
    constructor(private $scope: IServiceChargeCtrl, private ServiceChargeService: IServiceChargeResource) {
        var id: number;
        this.$scope.showCreate = "";
        this.getAllServiceCharges();
        this.getServiceCharge(id);
        this.createServiceCharge();
        this.deleteServiceCharge(id);
    }

    getAllServiceCharges() {
        return this.ServiceChargeService.query().$promise.then((data) => {
            this.$scope.serviceCharges = data;
        });
    }

    getServiceCharge(id: number) {
        return this.ServiceChargeService.query(id).$promise.then((data) => {
                this.$scope.serviceCharge = data;
            },
            (error) => {
                console.log(error.data.message);
            });
    }

    createServiceCharge() {
        this.ServiceChargeService.save(this.$scope.serviceCharge).$promise.then((data) => {
                this.getAllServiceCharges();
            },
            (error) => {
                console.log(error.data.message);
            });
    }

    deleteServiceCharge(id: number) {
        this.ServiceChargeService.delete({ id: id }).$promise.then((data) => {
                this.getAllServiceCharges();
            },
            (error) => {
                console.log(error.data.message);
            });
    }

    showCreate() {
        this.$scope.showCreate = "show create form";
    }
}

angular.module("app").controller("ServiceChargeCtrl", ServiceChargeCtrl);