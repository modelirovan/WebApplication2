var phoneVue = new Vue({
    el: '#phonebook-vue',
    data: {
        employees: [],
        editPopUpEmployeeName: "",
        editPopUpEmployeeDepartment: "",
        editPopUpEmployeePosition: "",
        editPopUpEmployeeId: 0,
        newPopUpEmployeeName: "",
        newPopUpEmployeeDepartment: "",
        newPopUpEmployeePosition: "",
        newPopUpEmployeeId: 0,
        departments: [],
        positions: [],
        selectedDepartment: null,
        selectedPosition: null,
        editPopUpSelectedDepartment: null,
        editPopUpSelectedPosition: null

    },

    filters: {},
    created: function () {

        this.getEmployees();
        this.loadDepartmentsAndPositions();
    },

    mounted: function () {

    },

    watch: {
        editPopUpEmployeeName: function () {
            var vue = this;
            vue.editPopUpEmployeeName = vue.$refs.employeeName.value;
            vue.editPopUpEmployeeDepartment = vue.$refs.employeeDepartment.value;
            vue.editPopUpEmployeePosition = vue.$refs.employeePosition.value;
            vue.editPopUpEmployeeId = vue.$refs.newEmployeeId.value;
        },
        editPopUpEmployeeDepartment: function () {
            var vue = this;

        },
        editPopUpEmployeePosition: function () {
            var vue = this;


        },
        editPopUpEmployeeId: function () {
            var vue = this;

        }

    },

    methods: {
        showNewEmployeeModal: function () {

            var vue = this;
            this.loadDepartmentsAndPositions();

            $("#add-new-employee-modal").modal('show');
        },

        addNewEmployee: function () {
            var vue = this;
            var res = vue.selectedDepartment.departmentName;

            var employeeFIO = vue.$refs.newEmployeeNameRef.value;
            var employeePosition = vue.selectedPosition.positionName; //vue.$refs.newEmployeePositionRef.value;
            var employeeDepartment = vue.selectedDepartment.departmentName; //vue.$refs.newEmployeeDepartmentRef.value;

            var data =
            {
                'employeeName': employeeFIO,
                'employeePosition': employeePosition,
                'employeeDepartment': employeeDepartment
            };

            $.ajax({
                type: "post",
                url: addNewEmployeeUrl,
                dataType: "json",
                data: data,
                success: function (response) {

                    var res = response;
                    //vue.$refs.newEmployeeNameRef.value = "";
                    //vue.$refs.newEmployeePositionRef.value = "";
                    //vue.$refs.newEmployeeDepartmentRef.value = "";
                    vue.newPopUpEmployeeName = "";
                    vue.newPopUpEmployeeDepartment = "";
                    vue.newPopUpEmployeePosition = "";

                },
                error: function (response) {

                }
            });
        },

        getEmployees: function () {
            var vue = this;

            $.ajax({
                type: "post",
                url: getEmployeesUrl,
                dataType: "json",
                success: function (response) {
                    // hermesLoader.stop();
                    if (response !== null && response !== undefined && response.length > 0) {

                        vue.employees = response;
                        //vue.success = true;
                        //vue.error = false;
                        //vue.data = response;
                        //vue.orderList = response.orders;
                        //vue.originalOrderList = response.orders;
                        //vue.deliveryMenList = response.deliveryMen;
                        //vue.isAnyRussianPostParcel = response.isAnyParcelRussianPost;
                    } else {
                        //vue.success = false;
                        //vue.error = true;
                        //vue.message = "Нет отправлений";
                    }
                },
                //error: function (response) {
                //    // hermesLoader.stop();
                //    vue.success = false;
                //    vue.error = true;
                //    vue.message = "Произошла ошибка";
                //}
            });
        },

        showVsdModal: function () {

            $("#vsd-modal").modal('show');
        },

        editEmployee: function (employeeId, employeeFIO, employeePosition, employeeDepartment) {

            $("#vsd-modal").modal('show');
            var vue = this;

            vue.$refs.employeeName.value = employeeFIO;
            //vue.$refs.employeePosition.value = employeePosition;
            //vue.$refs.employeeDepartment.value = employeeDepartment;
            vue.editPopUpSelectedPosition = employeePosition;
            vue.editPopUpSelectedDepartment = employeeDepartment;
            vue.$refs.newEmployeeId.value = employeeId;


        },
        SaveChanges: function () {
            var vue = this;
            var newEmployeeName = vue.$refs.employeeName.value;//vue.editPopUpEmployeeName;
            var newEmployeePosition = vue.editPopUpSelectedPosition.positionName;//vue.$refs.employeePosition.value; //vue.editPopUpEmployeePosition;
            var newEmployeeDepartment = vue.editPopUpSelectedDepartment.departmentName;//vue.editPopUpEmployeeDepartment;


            var newEmployeeId = vue.$refs.newEmployeeId.value;
            var data =
            {
                'employeeId': newEmployeeId,
                'employeeName': newEmployeeName,
                'employeePosition': newEmployeePosition,
                'employeeDepartment': newEmployeeDepartment
            };

            $.ajax({
                type: "post",
                url: saveEmployeeChangesUrl,
                dataType: "json",
                data: data,
                success: function (response) {

                    var res = response;

                },
                error: function (response) {

                }
            });
        },
        loadDepartmentsAndPositions: function () {
            var vue = this;

            $.ajax({
                type: "post",
                url: loadDepartmentsUrl,
                dataType: "json",
                success: function (response) {

                    vue.departments = response;
                },
                error: function (response) {

                }
            });

            $.ajax({
                type: "post",
                url: loadPositionsUrl,
                dataType: "json",
                success: function (response) {

                    vue.positions = response;
                },
                error: function (response) {

                }
            });
        }
    }
});