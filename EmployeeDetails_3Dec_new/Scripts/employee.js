$(document).ready(function () {
    $("form").find('div'); // find the all div under div.

    $('#remove').click(function () {)
        $('form').remove('h2');}
    $('')
})


//Load Data in Table when documents is ready
//$(document).ready(function () {
//    Add();
//}); 


    //$('#saveButton').click(function () {
    //    Add();
    //})
//function Add() {
//    let empNo = $('#TextBox1').val();
//    let name = $('#TextBox2').val();
//    let email = $('#TextBox3').val();
//    let address = $('#TextBox4').val();
//    if (empNo && name && email && address) {
//        $.ajax({
//            type: "POST",
//            url: "EmployeeDetails.aspx/addData",
//            async: false,
//            data: "{'empNo':'" + empNo + "','name':'" + name + "','email':'" + email + "','address':'" + address + "'}",
//            contentType: "application/json; charset=utf-8",
//            success: function (data) {
//                let obj = data.d;
//                if (obj === 'true') {
//                    $('#TextBox1').val('');
//                    $('#TextBox2').val('');
//                    $('#TextBox3').val('');
//                    $('#TextBox4').val('');
//                    alert("Data Saved Successfully");
//                }
//            },
//            error: function (result) {
//                alert("Error Occured, Please Try Again");
//            }
//        });
//    }
//    else {
//        alert("Please fill all the fields ! ! !");
//        return false;
//    }
//}

//function Add() {
//    let empNo = $('#TextBox1').val();
//    let name = $('#TextBox2').val();
//    let email = $('#TextBox3').val();
//    let address = $('#TextBox4').val();

//    if (empNo && name && email && address) {
//        $.ajax({
//            type: "POST",
//            url: "~/EmployeeDetails.aspx.cs/ functionname = addData",
//            async: false,
//            data: JSON.stringify({
//                empNo: empNo,
//                name: name,
//                email: email,
//                address: address
//            }),
//            contentType: "application/json; charset=utf-8",
//            success: function (data) {
//                let obj = data.d;
//                if (obj === true) {
//                    $('#TextBox1').val('');
//                    $('#TextBox2').val('');
//                    $('#TextBox3').val('');
//                    $('#TextBox4').val('');
//                    alert("Data Saved Successfully");
//                }
//            },
//            error: function (result) {
//                alert("Error Occurred, Please Try Again");
//            }
//        });
//    }
//    else {
//        alert("Please fill all the fields! !");
//        return false;
//    }
//}


////Load Data in Table when documents is ready
//$(document).ready(function () {
//    loadData();
//});

////Add Data Function
//function Add() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//    var empObj = {
//        EmployeeID: $('#EmployeeID').val(),
//        Name: $('#Name').val(),
//        Age: $('#Age').val(),
//        State: $('#State').val(),
//        Country: $('#Country').val()
//    };
//    $.ajax({
//        url: "/Home/Add",
//        data: JSON.stringify(empObj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myModal').modal('hide');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}
