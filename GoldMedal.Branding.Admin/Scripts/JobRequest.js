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
function ClearChild() {
    debugger;
    for (var i = 2; i < 12; i++) {
        $('#ddlSubJobType_ctl00_MainContent_ASPxPageControl1_gvDetails_ctl0' + i + '_ddlTypeofJob').val(0);
        $('#ddlSubSubJobType_ctl00_MainContent_ASPxPageControl1_gvDetails_ctl0' + i + '_ddlTypeofJob').val(0);
    }

}

function OnNameTypeChanged(cmbNameType) {
    //debugger
    $('#cmbSubContact_I').val('');
    $('#cmbSubAddress_I').val('');
    $('#cmbsubmail_I').val('');
    if (CmbName.InCallback())
        selectedData = cmbNameType.GetValue().toString();
    else

        CmbName.PerformCallback(cmbNameType.GetValue().toString());
}
function OnNameChanged(cmbName) {
    $('#cmbSubContact_I').val('');
    $('#cmbSubAddress_I').val('');
    $('#cmbsubmail_I').val('');
    if (cmbAddress.InCallback())
        selectedData = cmbName.GetValue().toString();
    else
        cmbAddress.PerformCallback(cmbName.GetValue().toString());
}
function OnAddressChanged(cmbAddress) {
    if (cmbcontactperson.InCallback()) {
        selectedData = cmbAddress.GetValue().toString();
    }
    else {
        cmbcontactperson.PerformCallback(cmbAddress.GetValue().toString());
    }
}
function OnSubNameChanged(cmbSubName) {
    if (cmbcontactperson.InCallback()) {
        selectedData = cmbSubName.GetValue().toString();
    }
    else {
        cmbcmbSubContact.PerformCallback(cmbSubName.GetValue().toString());
    }
}
function OnContactPersonChanged(cmbAddress) {
    if (cmbcontact.InCallback()) {
        selectedData = cmbAddress.GetValue().toString();
    }
    else {
        cmbcontact.PerformCallback(cmbAddress.GetValue().toString());
    }
}
function OnContactChanged(cmbAddress) {
    // debugger
    if (cmbemail.InCallback()) {
        selectedData = cmbAddress.GetValue().toString();
    }
    else {
        cmbemail.PerformCallback(cmbAddress.GetValue().toString());
    }
}
function OnGSTChangede(cmbName) {
    if (cmbgst.InCallback())
        selectedData = cmbName.GetValue().toString();
    else
        cmbgst.PerformCallback(cmbName.GetValue().toString());
}

//function OnGstNoChanged(cmbAddress) {
//    debugger
//    if (cmbgstno.InCallback()) {
//        selectedData = cmbAddress.GetValue().toString();
//    }
//    else {
//        cmbgstno.PerformCallback(cmbAddress.GetValue().toString());
//    }
//}
function loadsubjob(e) {
    debugger;
    var jobtypeval = $("#" + e).val();

    if (jobtypeval == 'Select') {
        jobtypeval = 0;

    }
    $("#" + e).parent().parent().next().find('input:text:nth-child(1)').val('');
    $("#" + e).parent().parent().next().next().find('input:text:nth-child(1)').val('');

    $.ajax({
        type: "POST",
        url: "JobRequest.aspx/GetSubJobType",
        data: '{jobtype: "' + e + '",jobtypeval: "' + jobtypeval + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //  debugger;

            var childid = $("#" + e).parent().parent().next('td').find("div").attr("id");

            $("#" + childid).html(data.d);

            $("#" + e).parent().parent().find('input:first-child').val(jobtypeval);

            $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().find('select option:eq(0)').prop('selected', true);
            $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('select option:eq(0)').prop('selected', true);

            $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().find('select').removeAttr('disabled').css('background-color','#fff');
            $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('select').removeAttr('disabled').css('background-color','#fff');


            LoadBoardType(e);

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function loadsubsubjob(e) {
    debugger;

    var subjobtypeval = $("#" + e).val();

    $("#" + e).parent().parent().next().find('input:text:nth-child(1)').val('');

    var valimg = $("#" + e).attr("valimage");
    var valapr = $("#" + e).attr("valaprove");
    $("#" + e).parent().parent().prev().find('input:text:nth-child(2)').val(valimg);
    $("#" + e).parent().parent().prev().find('input:text:nth-child(3)').val(valapr);
    if (valapr == "True") {
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('input:checkbox:nth-child(1)').prop("checked", true);
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('input:checkbox:nth-child(1)').prop("disabled", true);
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().find('.apto').prop("disabled", false)
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().next().find('.fmail').prop("disabled", false)
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('.ap').val("True")
    }
    else {
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('input:checkbox:nth-child(1)').prop("checked", false);
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('input:checkbox:nth-child(1)').prop("disabled", false);
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().find('.apto').prop("disabled", true)
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().next().find('.fmail').prop("disabled", true)
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('.ap').val("False")
    }
    var childHfid = $("#" + e).parent().parent().find("input:text").attr("id");
    $("#" + childHfid).val(subjobtypeval);
    $("#" + e).find('input:text[id="hfddlSubJob"]').text(subjobtypeval);

    $.ajax({
        type: "POST",
        url: "JobRequest.aspx/GetSubSubJobType",
        data: '{subjobtype: "' + e + '",subjobtypeval: "' + subjobtypeval + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //  debugger;
            var childid = $("#" + e).parent().parent().next('td').find("div").attr("id");
            $("#" + childid).html(data.d);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function fillsubsubjob(e) {
    debugger;
    var subjobtypeval = $("#" + e).val();

    var childHfid = $("#" + e).parent().parent().find("input:text").attr("id");

    $("#" + childHfid).val(subjobtypeval);
}
function loadsubsubjobedit(e) {
    debugger;
    var subjobtypeval = $("#" + e).val();

    var childHfid = $("#" + e).parent().parent().parent().find("input:text").attr("id");
    $("#" + childHfid).val(subjobtypeval);

    $("#" + e).find('input:text[id="hfddlSubJob"]').text(subjobtypeval);

    $.ajax({
        type: "POST",
        url: "JobRequest.aspx/GetSubSubJobType",
        data: '{subjobtype: "' + e + '",subjobtypeval: "' + subjobtypeval + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //debugger;
            var childid = $("#" + e).parent().parent().next('td').find("div").attr("id");

            $("#" + childid).html(data.d);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function fillsubsubjobedit(e) {
    // debugger;
    var subjobtypeval = $("#" + e).val();

    var childHfid = $("#" + e).parent().parent().parent().find("input:text").attr("id");

    $("#" + childHfid).val(subjobtypeval);
}
function OnNameChangede(cmbName) {
    if (cmbSubName.InCallback())
        selectedData = cmbName.GetValue().toString();
    else
        cmbSubName.PerformCallback(cmbName.GetValue().toString());
}
function OnSubNameChanged(cmbSubName) {
    if (cmbSubContact.InCallback())
        selectedData = cmbSubName.GetValue().toString();
    else
        cmbSubContact.PerformCallback(cmbSubName.GetValue().toString());
}
function OnSubNameChangede(cmbSubName) {
    if (cmbSubAddress.InCallback())
        selectedData = cmbSubName.GetValue().toString();
    else
        cmbSubAddress.PerformCallback(cmbSubName.GetValue().toString());
}
function OnSubNameChangedf(cmbSubName) {
    if (cmbsubmail.InCallback())
        selectedData = cmbSubName.GetValue().toString();
    else
        cmbsubmail.PerformCallback(cmbSubName.GetValue().toString());
}

function unitchange(e) {
    // debugger;

    var unit = $("#" + e).val();

    var childHfid = $("#" + e).parent().find(".lbunit").attr("id");

    $("#" + childHfid).val(unit);
}

function printlocchange(e) {
    // debugger;
    var loc = $("#" + e).val();

    var childHfid = $("#" + e).parent().find(".lbprintloc").attr("id");

    $("#" + childHfid).val(loc);
}

function fablocchange(e) {
    // debugger;
    var loc = $("#" + e).val();

    var childHfid = $("#" + e).parent().find(".lbfabloc").attr("id");

    $("#" + childHfid).val(loc);
}


function LoadBoardType(e) {

    debugger;
    var jobtypeval = $("#" + e).val();

    if (jobtypeval == 'Select') {
        jobtypeval = 0;
    }

    $("#" + e).parent().parent().next().next().next().next().next().find('input:text:nth-child(1)').val('');

    $.ajax({
        type: "POST",
        url: "JobRequest.aspx/GetBoardType",
        data: '{jobtype: "' + e + '",jobtypeval: "' + jobtypeval + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            var childid = $("#" + e).parent().parent().next().next().next().next().next('td').find("div").attr("id");

            $("#" + childid).html(data.d);

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function LoadBoardTypedis(e) {
   
    debugger;
    var jobtypeval = $("#" + e).val();

    if (jobtypeval == 'Select') {
        jobtypeval = 0;
    }

    $("#" + e).parent().parent().next().next().next().next().next().find('input:text:nth-child(1)').val('');
   
    $.ajax({
        type: "POST",
        url: "DisapprovedList.aspx/GetBoardType",
        data: '{jobtype: "' + e + '",jobtypeval: "' + jobtypeval + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
           
            var childid = $("#" + e).parent().parent().next().next().next().next().next('td').find("div").attr("id");

            $("#" + childid).html(data.d);

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}


function checkprintandfab(e,s) {
    debugger;
   
    var selectedBoardType = $(s).children("option:selected");

    var valprint = $(selectedBoardType).attr("isprintreq");
    var valfab = $(selectedBoardType).attr("isfabreq");


    $("#" + e).parent().parent().find('input:text').val($(s).val());

    $("#" + e).parent().parent().next().find('#hfIsPrintReq').val(valprint);
    $("#" + e).parent().parent().next().next().find('#hfIsFabReq').val(valfab);

    //alert($("#" + e).parent().parent().next().find('#hfIsPrintReq').val());
    //alert($("#" + e).parent().parent().next().next().find('#hfIsFabReq').val());

    $("#" + e).parent().parent().next().find('select option:eq(0)').prop('selected', true);
    $("#" + e).parent().parent().next().next().find('select option:eq(0)').prop('selected', true);

    if (valprint == "False") {
        $("#" + e).parent().parent().next().find('select').prop("disabled", true).css('background-color','#e8e8e8');
    }
    else {
        $("#" + e).parent().parent().next().find('select').removeAttr('disabled').css('background-color','#fff');
    }

    if (valfab == "False") {
        $("#" + e).parent().parent().next().next().find('select').prop("disabled", true).css('background-color','#e8e8e8');
    }
    else {
        $("#" + e).parent().parent().next().next().find('select').removeAttr('disabled').css('background-color','#fff');
    }

}


function checkprintandfabedit(e, s) {
    debugger;

    var selectedBoardType = $(s).children("option:selected");

    var valprint = $(selectedBoardType).attr("isprintreq");
    var valfab = $(selectedBoardType).attr("isfabreq");


    $("#" + e).parent().parent().parent().find('input:text').val($(selectedBoardType).val());

    $("#" + e).parent().parent().parent().next().find('#hfIsPrintReq').val(valprint);
    $("#" + e).parent().parent().parent().next().next().find('#hfIsFabReq').val(valfab);


    $("#" + e).parent().parent().parent().next().find('select option:eq(0)').prop('selected', true);
    $("#" + e).parent().parent().parent().next().next().find('select option:eq(0)').prop('selected', true);
    

    if (valprint == "False") {
        $("#" + e).parent().parent().parent().next().find('select').prop("disabled", true).css('background-color', '#e8e8e8');
    }
    else {
        $("#" + e).parent().parent().parent().next().find('select').removeAttr('disabled').css('background-color', '#fff');
    }

    if (valfab == "False") {
        $("#" + e).parent().parent().parent().next().next().find('select').prop("disabled", true).css('background-color', '#e8e8e8');
    }
    else {
        $("#" + e).parent().parent().parent().next().next().find('select').removeAttr('disabled').css('background-color', '#fff');
    }

}


function ClearGst() {
    
    debugger;
    var subname = $('#cmbSubName_VI').val();
    $('#ctl00_MainContent_ASPxPageControl1_hdfsubname').val(subname);
    $('#cmbgst_I').val('');

}

/*validation*/function OnNameValidation(s, e) {
    var name = e.value;

    if (name == "0")
        e.isValid = false;
}
function loadsubjobdis(e) {
    debugger;
    var jobtypeval = $("#" + e).val();



    if (jobtypeval == 'Select') {
        jobtypeval = 0;

    }
    $("#" + e).parent().parent().next().find('input:text:nth-child(1)').val('');
    $("#" + e).parent().parent().next().next().find('input:text:nth-child(1)').val('');


    $.ajax({
        type: "POST",
        url: "DisapprovedList.aspx/GetSubJobType",
        data: '{jobtype: "' + e + '",jobtypeval: "' + jobtypeval + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //debugger;
            var childid = $("#" + e).parent().parent().next('td').find("div").attr("id");

            $("#" + childid).html(data.d);

            $("#" + e).parent().parent().find('input:first-child').val(jobtypeval);

            LoadBoardTypedis(e);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function loadsubsubjobdis(e) {
    debugger
    var subjobtypeval = $("#" + e).val();
    $("#" + e).parent().parent().next().find('input:text:nth-child(1)').val('');

    var valimg = $("#" + e).attr("valimage");
    var valapr = $("#" + e).attr("valaprove");
    $("#" + e).parent().parent().prev().find('input:text:nth-child(2)').val(valimg);
    $("#" + e).parent().parent().prev().find('input:text:nth-child(3)').val(valapr);
    if (valapr == "True") {
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('input:checkbox:nth-child(1)').prop("checked", true);
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('input:checkbox:nth-child(1)').prop("disabled", true);
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().find('.apto').prop("disabled", false)
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().next().find('.fmail').prop("disabled", false)
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('.ap').val("True")
    }
    else {
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('input:checkbox:nth-child(1)').prop("checked", false);
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('input:checkbox:nth-child(1)').prop("disabled", false);
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().find('.apto').prop("disabled", true)
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().next().find('.fmail').prop("disabled", true)
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().find('.apto').val("0");
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().next().next().find('.fmail').val("");
        $("#" + e).parent().parent().next().next().next().next().next().next().next().next().next().next().next().find('.ap').val("False")
    }

    var childHfid = $("#" + e).parent().parent().find("input:text").attr("id");
    $("#" + childHfid).val(subjobtypeval);
    $("#" + e).find('input:text[id="hfddlSubJob"]').text(subjobtypeval);

    $.ajax({
        type: "POST",
        url: "DisapprovedList.aspx/GetSubSubJobType",
        data: '{subjobtype: "' + e + '",subjobtypeval: "' + subjobtypeval + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger;
            var childid = $("#" + e).parent().parent().next('td').find("div").attr("id");

            $("#" + childid).html(data.d);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function fillsubsubjobdis(e) {
    debugger;
    var subjobtypeval = $("#" + e).val();

    var childHfid = $("#" + e).parent().parent().find("input:text").attr("id");

    $("#" + childHfid).val(subjobtypeval);
}
function loadsubsubjobeditdis(e) {
    debugger;
    var subjobtypeval = $("#" + e).val();

    var childHfid = $("#" + e).parent().parent().parent().find("input:text").attr("id");
    $("#" + childHfid).val(subjobtypeval);

    $("#" + e).find('input:text[id="hfddlSubJob"]').text(subjobtypeval);

    $.ajax({
        type: "POST",
        url: "DisapprovedList.aspx/GetSubSubJobType",
        data: '{subjobtype: "' + e + '",subjobtypeval: "' + subjobtypeval + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger;
            var childid = $("#" + e).parent().parent().next('td').find("div").attr("id");

            $("#" + childid).html(data.d);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function fcnAddAddressonFocus(e) {
    debugger;
    var id = "#" + e;
    var a = $(id).parents('tr').find('.wi').val();
    var b = $(id).parents('tr').find('.hei').val();
    var g = $(id).parents('tr').find('.qty').val();
    var h = $("input[name='ctl00$MainContent$ASPxPageControl1$rduseaddress']:checked").val();
    if (a == "" || b == "" || g == "") {
        showDialog("Alert", "Are You Sure To Work On This Row Because The Width or Height or Quantity Is Blank For The Row.", 'warning');
    }
    else if (h == "0" && a != "" && b != "" && g != "") {
        addres = $('[id$=ctl00_MainContent_ASPxPageControl1_cmbAddress_I]').val();
        if (addres == "") {
            showDialog("Alert", "Address Is Missing For The Option ,Please Contact It Department For The Same else Use Other Option. ", 'warning');
        }
    }
    else if (h == "1" && a != "" && b != "" && g != "") {
        addres = $('[id$=cmbSubAddress_I]').val();
        if (addres == "") {
            showDialog("Alert", "Address Is Missing For The Option ,Please Contact It Department For The Same else Use Other Option. ", 'warning');
        }
    }
    else {
        addres = "";
    }
    $(id).parents('tr').find('.add').val(addres);
}
function fcnFillEmailid(e) {
    debugger;
    var id = "#" + e;
    var x = "";
    var a = $(id).parents('tr').find('.wi').val();
    var b = $(id).parents('tr').find('.hei').val();
    var g = $(id).parents('tr').find('.qty').val();
    var h = $(id).parents('tr').find(id).val()

    if (a == "" || b == "" || g == "") {
        showDialog("Alert", "Are You Sure To Work On This Row Because The Width or Height or Quantity Is Blank For The Row.", 'warning');
    }

    else if (a != "" && b != "" && g != "" && h == "0") {
        showDialog("Alert", "Please Select One Of The Option(Delear/Distributer,Sub Distributer,Sales Executive) For Email", 'warning');
    }
    else if (a != "" && b != "" && g != "" && h == "3") {
        showDialog("Alert", "Please Fill Email Manually Don't Leave The Mail Blank ", 'warning');
    }
    else if (a != "" && b != "" && g != "" && h == "1") {
        var j = $('[id$=ctl00_MainContent_ASPxPageControl1_cmbemail_I]').val()
        if (j == "") {
            showDialog("Alert", "Email Is Missing For The Option ,Please Contact It Department For The Same else Use Other Option. ", 'warning');
        }
        else {
            email = $('[id$=ctl00_MainContent_ASPxPageControl1_cmbemail_I]').val()
            x = $('[id$=ctl00_MainContent_ASPxPageControl1_cmbemail_I]').val().substr(0, email.indexOf(','));
            if ($('[id$=ctl00_MainContent_ASPxPageControl1_cmbemail_I]').val().substr(0, email.indexOf(',')) == "") {
                x = email;
            }
        }
    }
    else if (a != "" && b != "" && g != "" && h == "2") {
        var f = $('[id$=cmbsubmail_I]').val()
        if (f == "") {
            showDialog("Alert", "Email Is Missing For The Option ,Please Contact It Department For The Same else Use Other Option. ", 'warning');
        }
        else {
            email = $('[id$=cmbsubmail_I]').val()
            x = $('[id$=cmbsubmail_I]').val().substr(0, email.indexOf(','));
            if ($('[id$=cmbsubmail_I]').val().substr(0, email.indexOf(',')) == "") {
                x = email;
            }
        }
    }
    $(id).parents('tr').find('[id$=txtmail]').val(x);
}
function chkgridvalid(e) {
    debugger;
    var id = "#" + e;
    var cls = $(id).attr('class');
    var x = "";
    // var a = $(id).parents('tr').find('.wi').val();
    var b = $(id).parents('tr').prev().find('.wi').val();
    var d = $(id).parents('tr').prev().find('.hei').val();
    var e = $(id).parents('tr').prev().find('.jt').val();
    var f = $(id).parents('tr').prev().find('.hfddlSubJob').val();
    var g = $(id).parents('tr').prev().find('.hfddlSubSubJob').val();
    var h = $(id).parents('tr').prev().find('.dt').val();
    var i = $(id).parents('tr').prev().find('.qty').val();
    var j = $(id).parents('tr').prev().find('.add').val();
    var k = $(id).parents('tr').prev().find('.pt').val();
    var dd = $(id).parents('tr').prev().find('.ddlunit').val();
    //c == ''
    if (dd == '' || b == '' || d == '' || e == 'Select' || f == '' || g == '' || i == '' || h == 'Select' || i == '' || j == '' || k == 'Select') {
        showDialog("Alert", "In the privious row any one control(Width,Height,Job,Subjob,Material,Design Type,Product Type,Address) is blank", 'warning');
    }
}
function chkgridvalid2(e) {
    debugger;
    var id = "#" + e;
    var cls = $(id).attr('class');
    var x = "";
    var a = $(id).parents('tr').find('.wi').val();
    if (a == '') {
        showDialog("Alert", "Please Fill Width First", 'warning');
    }
}

function chkgridvalid3(e) {
    debugger;
    var id = "#" + e;
    var cls = $(id).attr('class');
    var x = "";
    var a = $(id).parents('tr').find('.ddlunit').val();
   
    if (a == '0') {
        showDialog("Alert", "Please select unit first", 'warning');
    }
}


function fcnchkcng(e) {
    debugger;
    var id = "#" + e;
    var x = "";
    var a = $(id).is(':checked');
    if (a == true) {
        $("#" + e).parent().parent().next().find('.apto').prop("disabled", false)
        $("#" + e).parent().parent().next().next().find('.fmail').prop("disabled", false)
        $("#" + e).parent().parent().find('.ap').val("True")
    }
    else {
        $("#" + e).parent().parent().next().find('.apto').prop("disabled", true)
        $("#" + e).parent().parent().next().next().find('.fmail').prop("disabled", true)
        $("#" + e).parent().parent().next().find('.apto').val("0");
        $("#" + e).parent().parent().next().next().find('.fmail').val("");
        $("#" + e).parent().parent().find('.ap').val("False")
    }
}

function fcnchkplacecng(e) {
    debugger;
    var id = "#" + e;
    var x = "";
    var a = $(id).is(':checked');
    if (a == true) {
        $("#" + e).parent().parent().find('.place').val("True")
    }
    else {
        $("#" + e).parent().parent().find('.place').val("False")
    }
}
function fcnFillEmailidfrdis(e) {
    debugger;
    var id = "#" + e;
    var x = "";
    var a = $(id).parents('tr').find('.wi').val();
    var b = $(id).parents('tr').find('.hei').val();
    var g = $(id).parents('tr').find('.qty').val();
    var h = $(id).parents('tr').find(id).val()

    if (a == "" || b == "" || g == "") {
        showDialog("Alert", "Are You Sure To Work On This Row Because The Width or Height or Quantity Is Blank For The Row.", 'warning');
    }

    else if (a != "" && b != "" && g != "" && h == "0") {
        showDialog("Alert", "Please Select One Of The Option(Delear/Distributer,Sub Distributer,Sales Executive) For Email", 'warning');
    }
    else if (a != "" && b != "" && g != "" && h == "3") {
        showDialog("Alert", "Please Fill Email Manually Don't Leave The Mail Blank ", 'warning');
    }
    else if (a != "" && b != "" && g != "" && h == "1") {
        var j = $('[id$=ctl00_MainContent_ASPxPageControl1_lblEmail]').text()
        if (j == "") {
            showDialog("Alert", "Email Is Missing For The Option ,Please Contact It Department For The Same else Use Other Option. ", 'warning');
        }
        else {
            email = $('[id$=ctl00_MainContent_ASPxPageControl1_lblEmail]').text()
            x = $('[id$=ctl00_MainContent_ASPxPageControl1_lblEmail]').text().substr(0, email.indexOf(','));
            if ($('[id$=ctl00_MainContent_ASPxPageControl1_lblEmail]').text().substr(0, email.indexOf(',')) == "") {
                x = email;
            }
        }
    }
    else if (a != "" && b != "" && g != "" && h == "2") {
        var f = $('[id$=ctl00_MainContent_ASPxPageControl1_lblsubemail]').text()
        if (f == "") {
            showDialog("Alert", "Email Is Missing For The Option ,Please Contact It Department For The Same else Use Other Option. ", 'warning');
        }
        else {
            email = $('[id$=ctl00_MainContent_ASPxPageControl1_lblsubemail]').text()
            x = $('[id$=ctl00_MainContent_ASPxPageControl1_lblsubemail]').text().substr(0, email.indexOf(','));
            if ($('[id$=ctl00_MainContent_ASPxPageControl1_lblsubemail]').text().substr(0, email.indexOf(',')) == "") {
                x = email;
            }
        }
    }
    $(id).parents('tr').find('[id$=txtmail]').val(x);
}