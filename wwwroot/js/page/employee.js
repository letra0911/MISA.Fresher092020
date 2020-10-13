$(document).ready(function () {
        employeeJS = new EmployeeJS("Mạnh");
})

/**
 * class quản lý các function cho trang Customer
 * Author: NVMANH (25/09/2020 )
 * */
class EmployeeJS extends BaseJS {
    constructor(name) {
            super();
    }
}
var data = [];
for (var i = 0; i < 100; i++) {
    var employee = {
        EmployeeCode: "Kh000"+ i+1,
        FullName: "Nguyễn Văn Mạnh",
        Gender: "Nam",
        DateOfBirth: new Date('1999-01-11'),
        Mobile: "097732433",
        PositionName: "Giám đốc",
        DepartmentName: "Phòng đào tạo",
        Email: "manhnv229@gmail.com",
        Salary: 14000000,
        WorkStatus: "Đang làm việc"
    };
    data.push(employee);
};
