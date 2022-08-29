<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="JobRequest.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.JobRequest.JobRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../../Scripts/JobRequest.js?v=1.1"></script>
    <style type="text/css">
            .FixedHeader {
            position: absolute;
            font-weight: bold;
        }   
    </style>

    <script>
        $(document).ready(function () {
            $('input[id=ctl00_MainContent_ASPxPageControl1_fuReferSheet]').change(function () {
                var val = $(this).val().toLowerCase();
                var regex = new RegExp("(.*?)\.(xlsx|xls|pptx|ppt)$");
                if (!(regex.test(val))) {
                    $(this).val('');
                    alert('Please select correct file format');
                }
            });
        });
        $(document).ready(function () {
            $('input[id=ctl00_MainContent_ASPxPageControl1_fuVisitingCard]').change(function () {

                var val = $(this).val().toLowerCase();
                var regex = new RegExp("(.*?)\.(png|jpeg|jpg)$");
                if (!(regex.test(val))) {
                    $(this).val('');
                    alert('Please select correct file format');
                }
            });
        });
        $(document).ready(function () {
            $('.filecls').change(function () {

                var val = $(this).val().toLowerCase();
                var regex = new RegExp("(.*?)\.(png|jpeg|jpg)$");
                if (!(regex.test(val))) {
                    $(this).val('');
                    alert('Please select correct file format');
                }
            });
        });
        $(document).ready(function () {
            $('.filecdr').change(function () {

                var val = $(this).val().toLowerCase();
                var regex = new RegExp("(.*?)\.(cdr)$");
                if (!(regex.test(val))) {
                    $(this).val('');
                    alert('Please select correct file format');
                }
            });
        });
        $(document).ready(function () {

            $('.flink').change(function () {

                var val = $(this).val().toLowerCase();
                var regex = new RegExp(/(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/g);
                if (!(regex.test(val))) {

                    $(this).val('');
                    alert('Please enter correct link format');
                }
            });
        });

        $(document).ready(function () {
            $(".wi").bind("keyup paste", function () {
                setTimeout(jQuery.proxy(function () {

                    this.val(this.val().replace(/[^0-9,.]/g, ''));
                }, $(this)), 0);
            });
        });
        $(document).ready(function () {
            $(".hei").bind("keyup paste", function () {
                setTimeout(jQuery.proxy(function () {

                    this.val(this.val().replace(/[^0-9,.]/g, ''));
                }, $(this)), 0);
            });
        });
        $(document).ready(function () {
            $(".qty").bind("keyup paste", function () {
                setTimeout(jQuery.proxy(function () {

                    this.val(this.val().replace(/[^0-9,.]/g, ''));
                }, $(this)), 0);
            });
        });
        $(document).ready(function () {
            $("#ctl00_MainContent_ASPxPageControl1_cmbcontact_I").bind("keyup paste", function () {
                setTimeout(jQuery.proxy(function () {
                    this.val(this.val().replace(/[^0-9]/g, ''));
                }, $(this)), 0);
            });
        });

        $(document).ready(function () {

            if ($('.jstatus').val() != 1) {
                display_ct();
            }
        });

        function display_c() {
            var refresh = 1000; // Refresh rate in milli seconds
            mytime = setTimeout('display_ct()', refresh)
        }

        function display_ct() {
            var x = new Date();
            var mm = x.getMonth() + 1;
            var x1 = x.getDate() + "/" + mm +  "/" + x.getFullYear();
            x1 = x1 + " " + x.getHours() + ":" + x.getMinutes() + ":" + x.getSeconds();
            //var _splite = x1.split("-");
            $('.rqdate').val(x1);
            display_c();
        }

        function ValidateDecimal(ele) {
            //var regex = /^\d+(\.\d{1,2})?$/;
            var regex = /(?:\d*\.\d{1,2}|\d+)$/;
            if (regex.test(ele.value)) {
              //  alert("Valid");
            } else {
               // alert("Invalid");
            }
        }
       
        function onlyNos(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else {
                    return true;
                }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }

        //function isFormSubmitted(form) // Submit button clicked
        //{
        //    form.submitButton.disabled = true;
        //    return true;
        //}

        function hidebuttons() {
            //alert();
            //lp.Show();
            $('.btndraft').css("display", "none");
            $('.btnsave').css("display", "none");
            $('#loaderbg').css("display", "block");
        }

        function showbuttons() {
            $('.btndraft').css("display", "inline-table");
            $('.btnsave').css("display", "inline-table");
            $('#loaderbg').css("display", "none");
        }

        //function DisableButtons() {
        //    var inputs = document.getElementsByTagName("INPUT");
        //    alert(inputs);
        //    for (var i in inputs) {
        //        if (inputs[i].type == "button" || inputs[i].type == "submit") {
        //            inputs[i].disabled = true;
        //        }
        //    }
        //}
        //window.onbeforeunload = DisableButtons;


    </script>

    <script>


        function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRow');
                var DivMC = document.getElementById('DivMainContent');
               
                //*** Set divheaderRow Properties ****
                DivHR.style.height = headerHeight + 'px';
                DivHR.style.width = (parseInt(width) - 16) + 'px';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '10';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + 'px';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -headerHeight + 'px';
                DivMC.style.zIndex = '1';

                DivHR.appendChild(tbl.cloneNode(true));
            }
        }


        //function OnScrollDiv(Scrollablediv) {
        //    document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
        //}


         <%--$(document).ready(function () {
           var gridHeader = $('#<%=GridView1.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
             $(gridHeader).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
             $('#<%=GridView1.ClientID%> tr th').each(function (i) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHead").append(gridHeader);
                    $('#GHead').css('position', 'absolute');
             $('#GHead').css('top', $('#<%=GridView1.ClientID%>').offset().top);

         });--%>

       <%-- function loadgridhead() {

            console.log($(".myGridView").width());

            var gridHeader = $('#<%=gvDetails.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
            $(gridHeader).find("tr:gt(0)").remove();
           
          
          
            $('#<%=gvDetails.ClientID%> tr th').each(function (i) {
                // Here Set Width of each th from gridview to new table(clone table) th 
                $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
            });
            $('.newhead').css('width', $(".myGridView").width() + 'px');
            //console.log($(gridHeader).html());
            //console.log(headtr);
            //alert(headtr);
        }--%>

    </script>

    <style type="text/css">

        .gridhead{
            display:none;
        }

        .newhead tr th{
            border: solid 1px #999999;
        }

        .newhead tr{
            background-color: #ccc;
        }

        .newhead th{
            text-align:center;
        }

        .fntsize {
            font-size: 12px;
        }
        
        .divgrid
        {
            height: 500px;
            width: 1900px;
        }
        .divgrid table
        {
            width: 1900px;
        }
        .divgrid table th
        {
            background-color: dimgray;
            color: #fff;
        }

        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Job Request</h2>
                </div>
            </div>
            <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" ClientInstanceName="popup3"
                Height="100px" Modal="True" CloseAction="CloseButton" Width="1000px" AllowDragging="True"
                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Add Retailer"
                HeaderStyle-CssClass="PopupHeader CyanHeader">

                <ContentCollection>
                    <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">

                        <div class="popup-content-main">

                            <div class="row popup-content-body">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" OnUnload="UpdatePanel3_Unload">
                                        <ContentTemplate>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 10%; padding-bottom: 9px">Category
                                                    </td>
                                                    <td style="width: 40%">
                                                        <dx:ASPxComboBox ID="cmbcat" ClientInstanceName="cmbcat" Width="350px" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="partycatnm"
                                                            ValueField="slno" TextFormatString="{0}-{1}"
                                                            IsTextEditable="True" ValueType="System.String"
                                                            IncrementalFilteringMode="Contains">
                                                        </dx:ASPxComboBox>

                                                    </td>
                                                    <td style="width: 10%; padding-bottom: 9px">Company Name
                                                    </td>
                                                    <td style="width: 40%">
                                                        <asp:TextBox ID="txtcomname" ClientIDMode="Static" runat="server" TabIndex="2" CssClass="form-control"></asp:TextBox>

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="width: 10%; padding-bottom: 9px">Name
                                                    </td>
                                                    <td style="width: 40%">
                                                        <asp:TextBox ID="txtname" ClientIDMode="Static" Width="90%" runat="server" TabIndex="2" CssClass="form-control"></asp:TextBox>

                                                    </td>
                                                    <td style="width: 10%; padding-bottom: 9px">Mobile
                                                    </td>
                                                    <td style="width: 40%">
                                                        <asp:TextBox ID="txtmob" ClientIDMode="Static" TextMode="Number" Width="90%" runat="server" TabIndex="2" CssClass="form-control"></asp:TextBox>

                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td style="width: 10%; padding-bottom: 9px">Address
                                                    </td>
                                                    <td style="width: 40%">
                                                        <asp:TextBox ID="txtaddress" TextMode="MultiLine" ClientIDMode="Static" runat="server" TabIndex="2" CssClass="form-control"></asp:TextBox>

                                                    </td>

                                                    <td style="width: 10%; padding-bottom: 9px">Area
                                                    </td>
                                                    <td style="width: 40%">
                                                        <dx:ASPxComboBox ID="cmbarea" ClientInstanceName="cmbarea" Width="350px" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="Name"
                                                            ValueField="slno" TextFormatString="{0}-{1}"
                                                            IsTextEditable="True" ValueType="System.String"
                                                            IncrementalFilteringMode="Contains">
                                                        </dx:ASPxComboBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <dx:ASPxButton ID="btnaddorg" runat="server" ClientIDMode="Static" OnClick="btnaddorg_Click"
                                                            Text="Save" CssClass="btn btn-success btn-space" ClientInstanceName="btnaddorg">
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lber" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>

                                            </table>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>

                    <asp:Label ID="lbslnochildid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblStatus" CssClass="jstatus" Visible="false" Text="" runat="server"></asp:Label>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="0" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="Add">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                <div class="row ">
                                                    <%--FORM FIELDS  --%>
                                                    <div class="col-md-12">
                                                        <div id="head">

                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
                                                                    <div class="row">
                                                                     <div class="col-md-3">
                                                                            <label>Branch:<strong class="redmark">*</strong></label>
                                                                            <dx:ASPxComboBox runat="server" ID="cmbbranch" ClientInstanceName="cmbbranch"  DropDownStyle="DropDownList" AutoPostBack="true" OnSelectedIndexChanged="cmbbranch_SelectedIndexChanged"
                                                                                TextField="locnm" ValueField="slno" IncrementalFilteringMode="StartsWith" EnableSynchronization="False" CssClass="form-control">
                                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { lp.Show(); }" />
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                         <div class="col-md-3">
                                                                <label>Is Wall Size:</label>

                                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:CheckBox ID="chkwallsize" runat="server"></asp:CheckBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                                         <div class="col-md-3">
                                                                <label>Map Wall Size Job:</label>

                                                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:CheckBox ID="chkmapjob" runat="server" OnCheckedChanged="chkmapjob_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                                         <div class="col-md-3">
                                                                            <label>Wall Size Jobs Request Nos:<strong class="redmark"></strong></label>

                                                                            <dx:ASPxComboBox runat="server" ID="cmbWallSizeJobs" DropDownStyle="DropDownList" IncrementalFilteringMode="StartsWith"
                                                                                TextField="reqno" EnableSynchronization="False" CssClass="form-control">
                                                                              
                                                                            </dx:ASPxComboBox>
                                                                        </div>


                                                                         </div>
                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i class="fa fa-tasks" aria-hidden="true"></i>
                                                                            <h2>Dealer</h2>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <div runat="server" id="dvRequest">
                                                                                <label>
                                                                                    Request No<strong class="redmark">*
                                                                                    </strong>
                                                                                </label>
                                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                                                    <ContentTemplate>
                                                                                        <div class="form-group">
                                                                                            <asp:TextBox ID="txtRequestNo" Text="It will be system generated" MaxLength="14" ClientIDMode="Static" onkeypress="return noNumbers(event)" ReadOnly runat="server" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="form-group">
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <div runat="server" id="Div1" visible="true">
                                                                                <label>Date:<strong class="redmark">*</strong></label>
                                                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:TextBox ID="txtDate" MaxLength="14" ClientIDMode="Static" onkeypress="return noNumbers(event)" ReadOnly runat="server" TabIndex="1" CssClass="form-control rqdate"></asp:TextBox>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Type:<strong class="redmark">*</strong></label>

                                                                            <dx:ASPxComboBox runat="server" ID="cmbNameType" DropDownStyle="DropDownList" IncrementalFilteringMode="StartsWith"
                                                                                TextField="name" EnableSynchronization="False" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbNameType_SelectedIndexChanged">
                                                                                <%--    <ValidationSettings SetFocusOnError="True" ErrorText="Name is required.">
                                                                                    <RequiredField IsRequired="True" ErrorText="" />
                                                                                </ValidationSettings>--%>
                                                                                <InvalidStyle BackColor="LightPink" />
                                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { lp.Show(); }" />
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                        <div class="col-md-3" id="namedata2" runat="server">
                                                                            <label>Name:<strong class="redmark">*</strong></label>
                                                                            <dx:ASPxComboBox runat="server" ID="CmbName" ClientInstanceName="CmbName" DropDownStyle="DropDownList"
                                                                                TextField="name" ValueField="slno" IncrementalFilteringMode="StartsWith" EnableSynchronization="False" CssClass="form-control"
                                                                                 OnSelectedIndexChanged="CmbName_SelectedIndexChanged" AutoPostBack="true">
                                                                                <%-- <ValidationSettings SetFocusOnError="True" ErrorText="Name  is required.">
                                                                                    <RequiredField IsRequired="True" ErrorText="" />
                                                                                </ValidationSettings>--%>
                                                                                <InvalidStyle BackColor="LightPink" />
                                                                              <ClientSideEvents SelectedIndexChanged="function(s, e) {lp.Show(); }" />
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" id="namedata" runat="server">
                                                                        <div class="col-md-3">
                                                                            <label>Address:<strong class="redmark">*</strong></label>
                                                                            <dx:ASPxComboBox runat="server" ID="cmbAddress" ClientInstanceName="cmbAddress"  DropDownStyle="DropDownList"
                                                                                TextField="address" ValueField="addressid" IncrementalFilteringMode="StartsWith" EnableSynchronization="False" CssClass="form-control disadd">

                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Contact Person:<strong class="redmark">*</strong></label>
                                                                            <dx:ASPxComboBox runat="server" ID="cmbcontactperson" ClientInstanceName="cmbcontactperson"  DropDownStyle="DropDownList"
                                                                                TextField="contactperson" ValueField="contactperson" IncrementalFilteringMode="StartsWith" EnableSynchronization="False" CssClass="form-control">
                                                                               
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Contact No<strong class="redmark">*</strong></label>
                                                                            <dx:ASPxComboBox runat="server" MaskType="Numeric" MaxLength="10" ID="cmbcontact" ClientInstanceName="cmbcontact" DropDownStyle="DropDownList" 
                                                                                TextField="mobile" ValueField="mobile" IncrementalFilteringMode="StartsWith" EnableSynchronization="False" CssClass="form-control num">
                                                                               
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                       
                                                                        <div class="col-md-3">
                                                                            <label>Email:<strong class="redmark"></strong></label>
                                                                            <dx:ASPxComboBox runat="server" ID="cmbemail" ClientInstanceName="cmbemail" DropDownStyle="DropDownList" 
                                                                                TextField="email" ValueField="email" IncrementalFilteringMode="StartsWith" EnableSynchronization="False" CssClass="form-control">

                                                                                <InvalidStyle BackColor="LightPink" />
                                                                                
                                                                            </dx:ASPxComboBox>
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>CIN Number:</label>
                                                                            <dx:ASPxComboBox runat="server" ID="cmbcinnum" ClientInstanceName="cmbCinNo" DropDownStyle="DropDownList" 
                                                                                TextField="cinnum" ValueField="cinnum" IncrementalFilteringMode="StartsWith" EnableSynchronization="False" CssClass="form-control">

                                                                                <InvalidStyle BackColor="LightPink" />
                                                                                
                                                                            </dx:ASPxComboBox>
                                                                        </div>

                                                                         
                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i class="fa fa-tasks" aria-hidden="true"></i>
                                                                            <h2>Retailer</h2>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-1">
                                                                <label>Get All Retailers:</label>

                                                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:CheckBox ID="chkStatecheck" runat="server" OnCheckedChanged="chkStatecheck_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                                        <div class="col-md-3">
                                                                            <label>Name:<strong class="redmark"></strong></label>
                                                                            <dx:ASPxComboBox ID="cmbSubName" DropDownStyle="DropDownList" ClientInstanceName="cmbSubName" OnCallback="cmbName_Callback" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                EnableIncrementalFiltering="True" TabIndex="1" TextField="name" 
                                                                                ValueField="slno" TextFormatString="{0}-{1}"
                                                                                IsTextEditable="True" ValueType="System.String"
                                                                                IncrementalFilteringMode="Contains" OnSelectedIndexChanged="cmbSubName_SelectedIndexChanged" AutoPostBack="true">
                                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {lp.Show(); ClearGst();OnSubNameChanged(s); OnSubNameChangede(s);OnSubNameChangedf(s); ASPxCallback1.PerformCallback();  }" />
                                                                           
                                                                                
                                                                            </dx:ASPxComboBox>
                                                                            <asp:TextBox ID="hdfsubname" runat="server" Style="display:none;"></asp:TextBox>
                                                                        </div>
                                                                       
                                                                        <div class="col-md-2" style="padding-top: 20px; font-size: large;display:none;">
                                                                            <asp:LinkButton ID="CmdWorking" EnableViewState="false" runat="server"
                                                                                ToolTip="Working"
                                                                                OnClientClick="lp.Show();popup3.Show();ASPxCallback1.PerformCallback();"
                                                                                Text='Add Retailer'>
                                                                            </asp:LinkButton>
                                                                        </div>



                                                                        <div class="col-md-2">
                                                                            <label>Contact No:<strong class="redmark"></strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxComboBox ID="cmbSubContact" MaxLength="10" ClientInstanceName="cmbSubContact" OnCallback="cmbSubName_Callback" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                        EnableIncrementalFiltering="True" DropDownStyle="DropDownList" TabIndex="1" TextField="areanm" IncrementalFilteringMode="StartsWith" EnableSynchronization="False"
                                                                                        ValueField="slno"
                                                                                        ValueType="System.String">
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Address:<strong class="redmark"></strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxComboBox ID="cmbSubAddress" ClientInstanceName="cmbSubAddress" DropDownStyle="DropDownList" OnCallback="cmbSubName_Callback" ClientIDMode="Static" runat="server" CssClass="form-control subdisadd"
                                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="address"
                                                                                        ValueField="addressid" TextFormatString="{0}-{1}"
                                                                                        ValueType="System.String"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <label>Email:<strong class="redmark"></strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxComboBox ID="cmbsubmail" ClientInstanceName="cmbsubmail" DropDownStyle="DropDownList" OnCallback="cmbSubName_Callback" ClientIDMode="Static" runat="server" CssClass="form-control subdisadd"
                                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="regemail"
                                                                                        ValueField="regemail" TextFormatString="{0}-{1}"
                                                                                        ValueType="System.String"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>Use Address:<strong class="redmark"></strong></label>
                                                                            <asp:RadioButtonList ID="rduseaddress" CssClass="form-control rd" runat="server" 
                                                                                RepeatDirection="Horizontal" onchange="lp.Show();" OnSelectedIndexChanged="rduseaddress_SelectedIndexChanged" AutoPostBack="true">
                                                                                <asp:ListItem Value="0" Selected="True">Dealer/Distributor/Branch</asp:ListItem>
                                                                                <asp:ListItem Value="1">Retailer</asp:ListItem>
                                                                                <asp:ListItem Value="2">None</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <label>Given By:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>

                                                                                     <dx:ASPxComboBox ID="cmbGivenBy" DropDownStyle="DropDownList" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                        EnableIncrementalFiltering="True" TabIndex="1"  AutoPostBack="true"  OnSelectedIndexChanged="ddlGivenBy_SelectedIndexChanged"
                                                                                         TextFormatString="{0}-{1}" IsTextEditable="True" ValueType="System.String"  IncrementalFilteringMode="Contains">
                                                                                        <Items>
                                                                                            <dx:ListEditItem Text="Select" Selected="True" />
                                                                                            <dx:ListEditItem Text="Sales Executive" Value="1" />
                                                                                            <dx:ListEditItem Text="Others" Value="2" />
                                                                                        </Items>
                                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {lp.Show(); }" />
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                         <div class="col-md-2" id="salesex" runat="server" style="display:none">
                                                                            <label>Sales Executive:<strong class="redmark">*</strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxComboBox ID="cmbSalesExecutive" DropDownStyle="DropDownList" ClientInstanceName="cmbSalesExecutive" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="salesexnm" 
                                                                                        ValueField="slno" TextFormatString="{0}-{1}"
                                                                                        IsTextEditable="True" ValueType="System.String"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                        <div class="col-md-2" id="othergivenby" runat="server" style="display:none">
                                                                            <label>Other<strong class="redmark">*</strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                                <ContentTemplate>
                                                                                   <asp:TextBox ID="txtGivenByOther" ClientIDMode="Static" onkeypress="return noNumbers(event)" runat="server" TabIndex="4" CssClass="form-control"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>



                                                                         <div class="col-md-2">
                                                                            <label>GST:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxComboBox ID="cmbgst"  ClientInstanceName="cmbgst" OnCallback="cmbName_Callback" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                        EnableIncrementalFiltering="True" DropDownStyle="DropDown" TabIndex="1" TextField="gst" IncrementalFilteringMode="StartsWith" EnableSynchronization="False"
                                                                                        ValueField="slno"
                                                                                        ValueType="System.String">
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                    </div>


                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                        <div id="child">
                                                            <div class="row">
                                                                <div class="cls-sub-topic">
                                                                    <i class="fa fa-tasks" aria-hidden="true"></i>
                                                                    <h2>Particular</h2>
                                                                </div>
                                                            </div>
                                                            <asp:HiddenField runat="server" ID="hfchildslno" Value='0' />
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div id="">
                                                                        <div style="overflow-x: auto; width:1840px; height:400px;" id="">

                                                                            <asp:GridView runat="server" Width="100%" ID="gvDetails" HeaderStyle-Height="30px" EmptyDataText="" AllowPaging="true" 
                                                                                AutoGenerateColumns="false" HeaderStyle-CssClass="" ShowHeaderWhenEmpty="true"
                                                                                OnRowCommand="gvDetails_RowCommand" OnRowDataBound="gvDetails_RowDataBound" DataKeyNames="slno" CssClass="myGridView" 
                                                                                PageSize="15">
                                                                                <Columns>
                                                                                        <asp:TemplateField HeaderText="Task" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label Text="<%#Container.DataItemIndex+1 %>" ID="txtTaskID" CssClass="form-control-grid" runat="server" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                         <asp:TemplateField HeaderText="Unit">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox Style="display:none" ID="lblUnit" CssClass="lbunit" runat="server" Text='<%# Eval("UnitID") %>' />
                                                                                                <asp:DropDownList Width="140px" ID="ddlUnit" runat="server" ToolTip="Unit" onchange="unitchange(this.id);" CssClass="form-control-grid dt fntsize ddlunit"
                                                                                                    DataTextField="name" DataValueField="slno">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Width">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtSizeInch" ToolTip="Width" onblur="return ValidateDecimal(this);" onfocusin="chkgridvalid(this.id);chkgridvalid3(this.id);" Width="60px" Text='<%# Eval("Width") %>' CssClass="form-control-grid wi fntsize" runat="server"></asp:TextBox>
                                                                                                <asp:HiddenField runat="server" ID="hfslnochild" Value=' <%#DataBinder.Eval(Container.DataItem,"slno").ToString()==""? "0":DataBinder.Eval(Container.DataItem,"slno") %>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Height">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtSizeHeight" ToolTip="Height" onblur="return ValidateDecimal(this);" onfocusin="chkgridvalid2(this.id)" Width="60px" Text='<%# Eval("Height") %>' CssClass="form-control-grid hei fntsize" runat="server"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Job Type">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox Style="display: none" ID="lblCJobTypeId" runat="server" Text='<%# Eval("JobTypeId") %>' />
                                                                                                <asp:TextBox Style="display: none" CssClass="form-control-grid abc" ID="lblimgreq" runat="server" Text='False' />
                                                                                                <asp:TextBox Style="display: none" CssClass="form-control-grid xyz" ID="lblaprreq" runat="server" Text='False' />
                                                                                                <%--<asp:Label ID="lblCJobTypeId" runat="server" Text='<%# Eval("JobTypeId") %>' Visible="false" />--%>
                                                                                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:DropDownList Width="180px" ToolTip="Job Type" ID="ddlTypeofJob" runat="server" onchange="lp.Show(); ASPxCallback1.PerformCallback();loadsubjob(this.id);"
                                                                                                            CssClass="form-control-grid jt fntsize" DataTextField="name" DataValueField="SlNo">
                                                                                                        </asp:DropDownList>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub Job Type">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox style="display:none;" ID="hfddlSubJob" CssClass="form-control-grid hfddlSubJob" runat="server" Text='<%# Eval("SubJobTypeId") %>' />
                                                                                                <asp:UpdatePanel ID="UpdatePanel151" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <div id="ddlSubJob" runat="server" class="fntsize"></div>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Materials used by printer">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox style="display:none;"  ID="hfddlSubSubJob" CssClass="form-control-grid hfddlSubSubJob" runat="server" Text='<%# Eval("SubSubJobTypeId") %>' />
                                                                                                <asp:UpdatePanel ID="UpdatePanel152" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <div id="ddlSubSubJob" class="fntsize" runat="server"></div>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Fabrication Material">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblDesignType" runat="server" Text='<%# Eval("DesignTypeId") %>' Visible="false" />
                                                                                                <asp:DropDownList Width="140px" ToolTip="Fabrication Material" ID="ddlDesignType" runat="server" CssClass="form-control-grid dt fntsize"
                                                                                                    DataTextField="name" DataValueField="SlNo">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Product Type">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProductType" runat="server" Text='<%# Eval("ProductTypeId") %>' Visible="false" />
                                                                                                <asp:DropDownList Width="140px" ToolTip="Product Type" ID="ddlProductType" runat="server" CssClass="form-control-grid pt fntsize" DataTextField="name" DataValueField="SlNo">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                         <asp:TemplateField HeaderText="Board Type">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox style="display:none;" ID="hfddlBoardType" CssClass="form-control-grid hfddlBoardType" runat="server" Text='<%# Eval("BoardTypeID") %>' />
                                                                                                <asp:UpdatePanel ID="UpdatePanel154" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <div id="ddlBoardType" runat="server" class="fntsize"></div>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Printer Location">
                                                                                            <ItemTemplate>
                                                                                                <asp:HiddenField ID="hfIsPrintReq" ClientIDMode="Static" runat="server" />
                                                                                             <%--   <asp:Label ID="lblPrinterLocation" runat="server" CssClass="lbprintloc" Text='<%# Eval("PrintLocation") %>' Visible="false" />--%>
                                                                                   
                                                                                                 <asp:TextBox style="display:none;" ID="lblPrinterLocation" CssClass="lbprintloc" runat="server" Text='<%# Eval("PrintLocation") %>' />
                                                                                                <asp:DropDownList Width="140px" ToolTip="Printer Location" ID="ddlPrintLocation" runat="server" onchange="printlocchange(this.id);" CssClass="form-control-grid fntsize"
                                                                                                    DataTextField="locnm" DataValueField="slno">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Fabricator Location">
                                                                                            <ItemTemplate>
                                                                                                 <asp:HiddenField ID="hfIsFabReq"  ClientIDMode="Static" runat="server" />
                                                                                                <%--<asp:Label ID="lblFabricatorLocation" runat="server" CssClass="lbfabloc" Text='<%# Eval("FabricatorLocation") %>' Visible="false" />--%>

                                                                                                <asp:TextBox style="display:none;" ID="lblFabricatorLocation" CssClass="lbfabloc" runat="server" Text='<%# Eval("FabricatorLocation") %>' />

                                                                                                <asp:DropDownList Width="140px" ToolTip="Fabricator Location" ID="ddlFabricatorLocation" runat="server"  onchange="fablocchange(this.id);" CssClass="form-control-grid fntsize"
                                                                                                    DataTextField="locnm" DataValueField="slno">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Qty">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtQty" ToolTip="Qty" Width="50px" runat="server" CssClass="form-control-grid qty fntsize" Text='<%# Eval("Qty") %>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Priority">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority") %>' Visible="false" />
                                                                                                <asp:DropDownList ToolTip="Priority" Width="100px" ID="ddlPriority" runat="server" CssClass="form-control-grid fntsize">
                                                                                                    <asp:ListItem Value="1" Text="Normal"></asp:ListItem>
                                                                                                    <asp:ListItem Value="2" Text="High"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>


                                                                                        <asp:TemplateField HeaderText="Address">
                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox Width="160px" ToolTip="Address" onfocus="fcnAddAddressonFocus(this.id)" ID="txtInstallAddress" Style="resize: none; font-size: 12px;" runat="server" CssClass="form-control-grid add fntsize" resize="none" TextMode="MultiLine" Text='<%# Eval("InstallAddress") %>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remark">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox Width="130px" ToolTip="Remark" ID="txtRemark" runat="server" Style="resize: none; font-size: 12px;" CssClass="form-control-grid fntsize" TextMode="MultiLine" Text='<%# Eval("Remark") %>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Party</br>Approval" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="lblchkisapprov" runat="server" CssClass="form-control ap" Text='<%# Eval("NeedApproval") %>' Style="display: none"></asp:TextBox>
                                                                                                <asp:CheckBox ID="chkisapprov" ToolTip="Party Approval" CssClass="form-control-grid apro" onclick="fcnchkcng(this.id)" runat="server"></asp:CheckBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Party Approval To">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPartyApprovalTo" runat="server" Text='<%# Eval("approvalto") %>' Visible="false" />
                                                                                                <div style="padding-top: 15px">
                                                                                                    <asp:DropDownList ID="DropDownList1" ToolTip="Approval To" Enabled="false" onchange="fcnFillEmailid(this.id)" runat="server" CssClass="form-control apto" Width="130px">
                                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                                        <asp:ListItem Value="1">Delear/Distributer</asp:ListItem>
                                                                                                        <asp:ListItem Value="2">Retailer</asp:ListItem>
                                                                                                        <asp:ListItem Value="3">Sales Executive</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                </div>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Mail Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtmail" ToolTip="Mail Id" Enabled="false" Style="font-size: 12px;" Width="160px" runat="server" CssClass="form-control-grid fmail" Text='<%# Eval("approvalemail") %>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Images(PNG*JPEG*JPG) Size < 20MB">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="hfImagenameDelete" runat="server" Text="" Visible="false" />
                                                                                                <asp:TextBox ID="hfImagename" Text='<%#Eval("Image")%>' runat="server" Visible="false" />
                                                                                                <div style="float: left; overflow: hidden; padding-top: 20px">
                                                                                                    <asp:FileUpload ID="fuPhoto" ToolTip="Images(PNG*JPEG*JPG) Size < 20MB" AllowMultiple="true" CssClass="form-control-grid filecls" Width="200px" runat="server" TabIndex="6" EnableViewState="true" />
                                                                                                </div>
                                                                                                <div>
                                                                                                    <asp:Label ID="lbllink" runat="server" Text="OR Enter Link" />
                                                                                                </div>
                                                                                                <div>
                                                                                                    <asp:TextBox ID="txtlink" ToolTip="Image Link" Style="font-size: 12px;" Width="200px" runat="server" CssClass="form-control-grid flink" Text='<%# Eval("ImageLink") %>'></asp:TextBox>
                                                                                                </div>
                                                                                                <div style="float: left; padding: 10px;">
                                                                                                    <asp:LinkButton ID="CmdlnkImage3" EnableViewState="true" runat="server" CommandArgument='<%#Eval("slno")%>'
                                                                                                        OnCommand="CmdlnkImage3_Command"></asp:LinkButton>
                                                                                                </div>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="File(.CDR) Size < 4MB" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="hfFilenameDelete" runat="server" Text="" Visible="false" />
                                                                                                <asp:TextBox ID="hfFilename" runat="server" Visible="false" />
                                                                                                <div style="float: left; overflow: hidden; padding-top: 20px">
                                                                                                    <asp:FileUpload ID="fuFile" ToolTip="File(.CDR) Size < 4MB" AllowMultiple="true" CssClass="form-control-grid filecdr" Width="200px" runat="server" TabIndex="6" EnableViewState="true" />
                                                                                                </div>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="PlaceSize</br>?">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="lblchkisplace" runat="server" CssClass="form-control place" Text='<%# Eval("isplacesize") %>' Style="display: none;"></asp:TextBox>
                                                                                                <asp:CheckBox ID="chkisplace" ToolTip="Is PlaceSize" onclick="fcnchkplacecng(this.id)" CssClass="form-control-grid isplace" runat="server"></asp:CheckBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="60px" ItemStyle-Width="60px">
                                                                                            <ItemTemplate>
                                                                                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:LinkButton ID="CmdDeleteChild" EnableViewState="true" runat="server" CommandArgument='<%#Eval("slno")%>' Text='Delete'
                                                                                                            OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'" OnCommand="CmdDeleteChild_Command"></asp:LinkButton>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                <HeaderStyle  Height="30px" />
                                                                            </asp:GridView>
      
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="btnShowPopup50" runat="server" Style="display: none" />
                                                                    <label>
                                                                        Upload Visiting Card(<asp:Label ID="lblVisitingCard" runat="server" ForeColor="Maroon">PNG*JPEG*JPG  Size < 25MB</asp:Label>
                                                                        ):</label>
                                                                    <asp:TextBox ID="hfVisitingImageDelete" runat="server" Visible="False"></asp:TextBox>
                                                                    <asp:TextBox ID="hfVisitingImage" runat="server" Visible="False"></asp:TextBox>
                                                                    <asp:FileUpload ID="fuVisitingCard" runat="server" AllowMultiple="True" CssClass="form-control" TabIndex="6" />
                                                                    <div>
                                                                        <asp:LinkButton ID="lnkFiles2" OnClientClick="lp.Show()" runat="server" OnClick="lnkFiles2_Click"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label>
                                                                        Upload Refer Sheet(<asp:Label ID="lblReferSheet" runat="server" ForeColor="Maroon">XLS*XLSX*PPT*PPTX Size < 25MB</asp:Label>
                                                                        ):</label>
                                                                    <asp:TextBox ID="hfReferSheetDelete" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:TextBox ID="hfReferSheet" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:FileUpload ID="fuReferSheet" runat="server" AllowMultiple="True" CssClass="form-control" TabIndex="6" />
                                                                    <div>
                                                                        <asp:LinkButton ID="lnkFiles3" OnClientClick="lp.Show()" runat="server" OnClick="lnkFiles3_Click"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label>
                                                                        Submitted By:</label>
                                                                    <dx:ASPxComboBox ID="cmbSubmitby" ClientInstanceName="cmbSubmitby" DropDownStyle="DropDown" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="salesexnm"
                                                                        ValueField="salesexnm" TextFormatString="{0}-{1}"
                                                                        ValueType="System.String"
                                                                        IncrementalFilteringMode="Contains">
                                                                    </dx:ASPxComboBox>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label>
                                                                        Approved BY:</label>
                                                                    <asp:TextBox ID="txtapproveby" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />
                                                             <div class="row">
                                                                 <div class="col-md-3">
                                                                    <label>
                                                                        Upload Shop Photo(<asp:Label ID="lblShopPhoto" runat="server" ForeColor="Maroon">PNG*JPEG*JPG Size < 25MB</asp:Label>
                                                                        ):</label>
                                                                    <asp:TextBox ID="hfShopPhotoDelete" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:TextBox ID="hfShopPhoto" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:FileUpload ID="fuShopPhoto" runat="server" AllowMultiple="True" CssClass="form-control" TabIndex="6" />
                                                                    <div>
                                                                        <asp:LinkButton ID="lnkFiles4" OnClientClick="lp.Show()" runat="server" OnClick="lnkFiles4_Click"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                 <div class="col-md-3">
                                                                    <label>
                                                                        Upload Regional Lang.(<asp:Label ID="lblRegionalLang" runat="server" ForeColor="Maroon">CDR* < 25MB</asp:Label>
                                                                        ):</label>
                                                                    <asp:TextBox ID="hfRegionalLangDelete" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:TextBox ID="hfRegionalLang" runat="server" Visible="false"></asp:TextBox>
                                                                    <asp:FileUpload ID="fuRegionalLang" runat="server" AllowMultiple="True" CssClass="form-control" TabIndex="6" />
                                                                    <div>
                                                                        <asp:LinkButton ID="lnkFiles5" OnClientClick="lp.Show()" runat="server" OnClick="lnkFiles5_Click"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                 </div>
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left: 20px">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Label ID="lblnote" runat="server" ForeColor="Maroon" Text="NOTE:- *You Cannot Edit Record After Submit Click"></asp:Label>
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />
                                                                    <dx:ASPxButton ID="CmdSaveAsDraft" runat="server" ClientIDMode="Static" OnClick="CmdSaveAsDraft_Click" AutoPostBack="False"
                                                                        Text="SaveAsDraft" CssClass="btn btn-success btn-space btndraft" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                        <ClientSideEvents Click="function(s, e) { hidebuttons(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnSubmit" runat="server" ClientIDMode="Static" OnClick="btnSubmit_Click" AutoPostBack="False" 
                                                                        Text="Submit" CssClass="btn btn-success btn-space btnsave" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                        <ClientSideEvents Click="function(s, e) { hidebuttons(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                        OnCallback="ASPxCallback1_Callback">
                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                    </dx:ASPxCallback>
                                                                    <dx:ASPxButton ID="CmdReset" runat="server" Text="Clear" TabIndex="7" CssClass="btn btn-space"
                                                                        OnClick="CmdReset_Click">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn " TabIndex="8"
                                                                        OnClick="btnCancel_Click1">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxLabel ID="lbmsg" runat="server" ForeColor="Red">
                                                                    </dx:ASPxLabel>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnSubmit" />
                                                            <asp:PostBackTrigger ControlID="CmdSaveAsDraft" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <%--.Start of Tab-2--%>
                                    <dx:TabPage Text="List">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl2" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                                            <Triggers>

                                                                                <asp:PostBackTrigger ControlID="btnXlsExport" />

                                                                                <asp:PostBackTrigger ControlID="btnXlsxExport" />
                                                                                <asp:PostBackTrigger ControlID="btnCsvExport" />
                                                                            </Triggers>
                                                                            <ContentTemplate>
                                                                                <table class="BottomMargin">
                                                                                    <tr>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnXlsExport_Click" />
                                                                                        </td>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="Export to XLSX" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnXlsxExport_Click" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxButton ID="btnCsvExport" runat="server" Text="Export to CSV" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnCsvExport_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <br />
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="gvHead"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="gvHead_DataBinding"
                                                                                    AutoGenerateColumns="False" OnHtmlRowCreated="gvHead_HtmlRowCreated">
                                                                                    <Columns>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="NameTypeId" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="AllName" Caption="Dealer Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Address" Caption="Address" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ContactPerson" Caption="ContactPerson" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Email" Caption="Email" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ContactNumber" Caption="Contact Number" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Retailer Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subcompname" Caption="Retailer Firm Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                       <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Sub Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="RequestDate" Caption="Request Date" VisibleIndex="10">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="GivenBy" Caption="Given By" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="headstatus" Caption="Status" VisibleIndex="19">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="RetApprovalStatus" Caption="Retailer Approval Status" VisibleIndex="20">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="RetActiveStatus" Caption="Retailer Active Status" VisibleIndex="21">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Edit" ReadOnly="True" VisibleIndex="22">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" OnClientClick="lp.Show()" EnableViewState="false" runat="server" CommandArgument='<%# Eval("slno") %>'
                                                                                                    Text='<%# GetLinkButtonText(Eval("headstatus")) %>' OnCommand="CmdEdit_Command">
                                                                                                </asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Delete" ReadOnly="True" VisibleIndex="23">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdDelete" EnableViewState="false" runat="server" CommandArgument='<%# Eval("slno") %>'
                                                                                                    OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                                                                    Text='<%# Eval("headstatus").ToString()=="Draft"?"Delete":"" %>' OnCommand="CmdDelete_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                    </Columns>
                                                                                    <Settings ShowFilterRow="True" />
                                                                                    <SettingsDataSecurity AllowDelete="False" />
                                                                                    <GroupSummary>
                                                                                        <dx:ASPxSummaryItem SummaryType="Count" />
                                                                                    </GroupSummary>
                                                                                    <TotalSummary>
                                                                                        <dx:ASPxSummaryItem FieldName="Size" SummaryType="Sum" />
                                                                                    </TotalSummary>
                                                                                    <SettingsBehavior EnableRowHotTrack="True" ProcessFocusedRowChangedOnServer="True" />
                                                                                    <SettingsPager>
                                                                                        <PageSizeItemSettings Visible="true" Items=" 20, 50, 100, 500" />
                                                                                    </SettingsPager>
                                                                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                                                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                                                                    <Styles>
                                                                                        <RowHotTrack BackColor="#E9E9E9">
                                                                                        </RowHotTrack>
                                                                                    </Styles>
                                                                                </dx:ASPxGridView>
                                                                                <%--   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mycon %>"
                                                                                    SelectCommand="proc_JobRequest_getAllHead" SelectCommandType="StoredProcedure">
                                                                                    <SelectParameters>
                                                                                        <asp:QueryStringParameter DefaultValue="0" Type="Int32" Name="refid" QueryStringField="id" />
                                                                                    </SelectParameters>
                                                                                </asp:SqlDataSource>--%>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                </TabPages>
                            </dx:ASPxPageControl>
                            <asp:HiddenField runat="server" ID="repType" Value="" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <div>
        <asp:Button ID="btnResumeShowUp" runat="server" Style="display: none" />
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header bg-aqua">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">OK</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div>
            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="mpeImage" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
                CancelControlID="btnCloseMPE" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
                <div class="row">
                    <br />
                    <br />
                    <br />
                    <div class="col-lg-12">
                        <div class="box" style="text-align: center;">
                            <asp:UpdatePanel ID="UpdatePanel26" runat="server" style="display: inline-block;">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptImages" runat="server" OnItemCommand="rptImages_ItemCommand" OnItemDataBound="rptImages_ItemDataBound">
                                        <ItemTemplate>
                                            <div id="dvImage" style="width: 150px; height: 150px; overflow: hidden; text-align: center; float: left;">
                                                <div>
                                                    <asp:HyperLink ID="hyLink" runat="server" Target="_blank" Style="border: none; color: transparent;">
                                                        <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                                    </asp:HyperLink>
                                                </div>
                                                <div style="clear: both;" id="asd" runat="server">
                                                    <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                                    <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                                    <asp:HiddenField ID="hfvisible" runat="server" />
                                                    <asp:LinkButton ID="lnkDelete" EnableViewState="false" runat="server"
                                                        CommandArgument='<%# Eval("ImageName") %>' OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                        CommandName="cmdRemove" Text='Remove' Style="text-decoration: underline;"></asp:LinkButton>
                                                </div>
                                                <div style="clear: both;">
                                                    <asp:LinkButton ID="lnkDown" EnableViewState="false" runat="server"
                                                        CommandArgument='<%# Eval("ImageName") %>' CommandName="Down" Text='Download' Style="text-decoration: underline;"></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div style="clear: both" runat="server" visible="<%# (Container.ItemIndex+1) % 5 == 0 %>"></div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <h2 id="hdNoRecord" runat="server">No Image Found</h2>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- /.box -->
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row" align="center">
                                    <asp:Button ID="btnCloseMPE" runat="server" Width="100" Height="30" Text="Close" CssClass="btn btn-info btn-space" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCloseMPE" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>
            <asp:Button ID="btnShowPopup1" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="mpeImage1" runat="server" TargetControlID="btnShowPopup1" PopupControlID="pnlpopup1"
                CancelControlID="btnCloseMPE1" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlpopup1" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
                <div class="row">
                    <br />
                    <br />
                    <br />
                    <div class="col-lg-12">
                        <div class="box" style="text-align: center;">
                            <asp:UpdatePanel ID="UpdatePanel33" runat="server" style="display: inline-block;">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptImages1" runat="server" OnItemCommand="rptImages1_ItemCommand" OnItemDataBound="rptImages1_ItemDataBound">
                                        <ItemTemplate>
                                            <div id="dvImage" style="width: 150px; height: 150px; overflow: hidden; text-align: center; float: left;">
                                                <div>
                                                    <asp:HyperLink ID="hyLink" runat="server" Target="_blank" Style="border: none; color: transparent;">
                                                        <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                                    </asp:HyperLink>
                                                </div>
                                                <div style="clear: both;" id="asd" runat="server">
                                                    <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                                    <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                                    <asp:HiddenField ID="hfvisible" runat="server" />
                                                    <asp:LinkButton ID="lnkDelete" EnableViewState="false" runat="server"
                                                        CommandArgument='<%# Eval("ImageName") %>' OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                        CommandName="cmdRemove" Text='Remove' Style="text-decoration: underline;"></asp:LinkButton>
                                                </div>
                                                <div style="clear: both;">
                                                    <asp:LinkButton ID="lnkDown" EnableViewState="false" runat="server"
                                                        CommandArgument='<%# Eval("ImageName") %>' CommandName="Down" Text='Download' Style="text-decoration: underline;"></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div style="clear: both" runat="server" visible="<%# (Container.ItemIndex+1) % 5 == 0 %>"></div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <h2 id="hdNoRecord1" runat="server">No Image Found</h2>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- /.box -->
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row" align="center">
                                    <asp:Button ID="btnCloseMPE1" runat="server" Width="100" Height="30" Text="Close" CssClass="btn btn-info btn-space" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCloseMPE1" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>




            <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="mpeImage2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2"
                CancelControlID="btnCloseMPE2" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
                <div class="row">
                    <br />
                    <br />
                    <br />
                    <div class="col-lg-12">
                        <div class="box" style="text-align: center;">
                            <asp:UpdatePanel ID="UpdatePanel34" runat="server" style="display: inline-block;">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptImages2" runat="server" OnItemCommand="rptImages2_ItemCommand" OnItemDataBound="rptImages2_ItemDataBound">
                                        <ItemTemplate>
                                            <div id="dvImage" style="width: 150px; height: 150px; overflow: hidden; text-align: center; float: left;">
                                                <div>
                                                    <asp:HyperLink ID="hyLink" runat="server" Target="_blank" Style="border: none; color: transparent;">
                                                        <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                                    </asp:HyperLink>
                                                </div>
                                                <div style="clear: both;" id="asd" runat="server">
                                                    <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                                    <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                                    <asp:HiddenField ID="hfvisible" runat="server" />
                                                    <asp:LinkButton ID="lnkDelete" EnableViewState="false" runat="server"
                                                        CommandArgument='<%# Eval("ImageName") %>' OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                        CommandName="cmdRemove" Text='Remove' Style="text-decoration: underline;"></asp:LinkButton>
                                                </div>
                                                <div style="clear: both;">
                                                    <asp:LinkButton ID="lnkDown" EnableViewState="false" runat="server"
                                                        CommandArgument='<%# Eval("ImageName") %>' CommandName="Down" Text='Download' Style="text-decoration: underline;"></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div style="clear: both" runat="server" visible="<%# (Container.ItemIndex+1) % 5 == 0 %>"></div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <h2 id="hdNoRecord2" runat="server">No Image Found</h2>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- /.box -->
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row" align="center">
                                    <asp:Button ID="btnCloseMPE2" runat="server" Width="100" Height="30" Text="Close" CssClass="btn btn-info btn-space" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCloseMPE2" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>






             <asp:Button ID="btnShowPopup3" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="mpeImage3" runat="server" TargetControlID="btnShowPopup3" PopupControlID="pnlpopup3"
                CancelControlID="btnCloseMPE3" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlpopup3" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
                <div class="row">
                    <br />
                    <br />
                    <br />
                    <div class="col-lg-12">
                        <div class="box" style="text-align: center;">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server" style="display: inline-block;">
                                <ContentTemplate>
                                    <asp:Repeater ID="rptImages3" runat="server" OnItemCommand="rptImages3_ItemCommand" OnItemDataBound="rptImages3_ItemDataBound">
                                        <ItemTemplate>
                                            <div id="dvImage" style="width: 150px; height: 150px; overflow: hidden; text-align: center; float: left;">
                                                <div>
                                                    <asp:HyperLink ID="hyLink" runat="server" Target="_blank" Style="border: none; color: transparent;">
                                                        <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                                    </asp:HyperLink>
                                                </div>
                                                <div style="clear: both;" id="asd" runat="server">
                                                    <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                                    <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                                    <asp:HiddenField ID="hfvisible" runat="server" />
                                                    <asp:LinkButton ID="lnkDelete" EnableViewState="false" runat="server"
                                                        CommandArgument='<%# Eval("ImageName") %>' OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                        CommandName="cmdRemove" Text='Remove' Style="text-decoration: underline;"></asp:LinkButton>
                                                </div>
                                                <div style="clear: both;">
                                                    <asp:LinkButton ID="lnkDown" EnableViewState="false" runat="server"
                                                        CommandArgument='<%# Eval("ImageName") %>' CommandName="Down" Text='Download' Style="text-decoration: underline;"></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div style="clear: both" runat="server" visible="<%# (Container.ItemIndex+1) % 5 == 0 %>"></div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <h2 id="hdNoRecord3" runat="server">No Image Found</h2>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- /.box -->
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row" align="center">
                                    <asp:Button ID="btnCloseMPE3" runat="server" Width="100" Height="30" Text="Close" CssClass="btn btn-info btn-space" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCloseMPE3" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </asp:Panel>




 <asp:Button ID="btnShowConfirmPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeConfirmPopup" runat="server" TargetControlID="btnShowConfirmPopup" PopupControlID="pnlConfirmPopup"
            CancelControlID="btnCloseConfirmPopup" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlConfirmPopup" runat="server" BackColor="White" Height="300px" Width="560px" Style="display: none">
            <div class="row">
                <br /> <br /><br />
                <div class="col-lg-12">
                    <div class="box" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel47" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                                <p id="printmsg" runat="server" style="color:orange;font-weight:bold;">Dhanbarse Status Of the Retailer  - <asp:Label ID="lblApprovalStatus" runat="server" />  / <asp:Label ID="lblCurrentStatus" runat="server" /> .<br /><br />Do you still you want to continue ?</p>
                              
                                <asp:Button ID="btnYes" runat="server" Width="100" Height="30" Text="Yes" OnClick="btnYes_Click" 
                                    OnClientClick="lp.Show(); ASPxCallback1.PerformCallback();" CssClass="btn btn-success" />
                                <asp:Button ID="btnNo" runat="server" Width="100" Height="30" Text="No" OnClick="btnNo_Click" OnClientClick="lp.Show(); ASPxCallback1.PerformCallback();" CssClass="btn btn-danger" />
                            </ContentTemplate>
                            <Triggers>
                                 <asp:PostBackTrigger ControlID="btnYes" />
                                 <asp:PostBackTrigger ControlID="btnNo" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <!-- /.box -->
                </div>
            </div>
            <br /> <br />
            <div class="row">
                <div class="col-lg-12">
                 <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row" align="center">
                            <asp:Button ID="btnCloseConfirmPopup" runat="server" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCloseConfirmPopup" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>



  <asp:Button ID="btnShowConfirmPopup3" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeImagee" runat="server" TargetControlID="btnShowConfirmPopup3" PopupControlID="pnlpopupDocse"
        CancelControlID="btnCloseMPEe" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlpopupDocse" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none; border: solid 1px #cdcdcd !important;">
        <div class="row">
            <br />
            <div class="col-lg-12">
                <div class="box" style="text-align: center;">
                    <asp:UpdatePanel ID="UpdatePanel53" runat="server" style="display: inline-block;">
                        <ContentTemplate>
                            <dx:ASPxGridView Settings-ShowGroupPanel="true"
                                SettingsBehavior-AllowGroup="true" ID="gvdetail"
                                align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                runat="server" EnablePagingCallbackAnimation="True"
                                AutoGenerateColumns="False">
                                <Columns>
                                   <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Days" Caption="Days" VisibleIndex="1">
                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request Number" VisibleIndex="2">
                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="JobType" Caption="Job Type" VisibleIndex="3">
                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Width" Caption="Width" VisibleIndex="4">
                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Height" Caption="Height" VisibleIndex="5">
                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row" align="center">
                            <asp:Button ID="btnCloseMPEe" runat="server" Width="100" Height="30" Text="Close" CssClass="btn btn-info btn-space" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCloseMPEe" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>


        </div>
    </div>
</asp:Content>