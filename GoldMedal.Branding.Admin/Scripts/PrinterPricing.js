$(document).ready(function () {

});

function Validation() {
    var ProductType = $("#txtName").val().trim();
    if (ProductType == "") {
        alert("Please enter design type");
        $("#txtName").focus();
        return false;
    }
    else {
        return true;
    }
}

function updatehf(e) {

    var id = "#" + e;

    var a = $(id).val();

    $(id).parent().find('input:hidden').val(a);
}



function chkgridvalid(e) {

    var id = "#" + e;

    var u = $(id).parents('tr').prev().find('.ddlunit').val();
    var r = $(id).parents('tr').prev().find('.gvrate').val();
    var d = $(id).parents('tr').prev().find('.gveffdate').val();

    //if (u != '0' && r == '' && d == '') {
    //    showDialog("Alert", "In the privious row rate and eff date not entered", 'warning');
    //}
    //else if (u != '0' && r != '' && d == '') {
    //    showDialog("Alert", "In the privious eff date not entered", 'warning');
    //    $(id).parent().find('select option:eq(0)').prop('selected', true);
    //}
}
function chkgridvalid2(e) {
   
    var id = "#" + e;
  
    var a = $(id).parents('tr').find('.ddlunit').val();

   
    if (a == '0') {
        showDialog("Alert", "Please select unit", 'warning');
    }
    else {
        $(id).parent().prev().find('input:hidden').val(a);
    }
}
function chkgridvalid3(e) {
   
    var id = "#" + e;
  
    var a = $(id).parents('tr').find('.gvrate').val();

    if (a == '') {
        showDialog("Alert", "Please enter rate", 'warning');
    }
}