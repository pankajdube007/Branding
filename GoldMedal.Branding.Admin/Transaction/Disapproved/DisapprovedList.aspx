<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DisapprovedList.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.Disapproved.DisapprovedList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../../Scripts/JobRequest.js?v=1.1"></script>

    <script>

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
       //    //document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
       //}

   </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">DisApprove Job Request</h2>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>
                     <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="ASPxGridView1">
                    </dx:ASPxGridViewExporter>
                   

                     <asp:Label ID="lbslnochildid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>


                             <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>

                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                        OnCallback="ASPxCallback1_Callback">
                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                    </dx:ASPxCallback>

                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="0" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="View">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                <div class="row ">
                                                    <%--FORM FIELDS  --%>
                                                    <div class="col-md-12">
                                                        <div id="head">
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
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
                                                                                    Request No<strong class="redmark">
                                                                                    </strong>
                                                                                </label>
                                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                                                    <ContentTemplate>
                                                                                        <div class="form-group">

                                                                                            <asp:Label ID="LblRequestNo" runat="server" />
                                                                                        </div>
                                                                                        <div class="form-group">
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <div runat="server" id="Div1" visible="true">
                                                                                <label>Date:<strong class="redmark"></strong></label>
                                                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                                    <ContentTemplate>

                                                                                        <asp:Label ID="lblDate" runat="server" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Type:<strong class="redmark"></strong></label>

                                                                            <asp:Label ID="lblNameType" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Name:<strong class="redmark"></strong></label>
                                                                            <asp:Label ID="lblName" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Address:<strong class="redmark"></strong></label>
                                                                            <asp:Label ID="lblAddress" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Contact Person:<strong class="redmark"></strong></label>
                                                                            <asp:Label ID="lblContactPerson" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Contact No.<strong class="redmark"></strong></label>
                                                                            <asp:Label ID="lblContact" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Email:<strong class="redmark"></strong></label>
                                                                            <asp:Label ID="lblEmail" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Retailer</h2>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Name:<strong class="redmark"></strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubName" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Contact No:<strong class="redmark"></strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubContact" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Address:<strong class="redmark"></strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubAddress" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                SubEmail:<strong class="redmark"></strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblsubemail" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Given By:<strong class="redmark"></strong></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblGivenBy" runat="server" />
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
                                                                        <div style="overflow-x: auto; width: 1840px; height:400px;">
       
                                                                            <asp:GridView runat="server" Width="100%" ID="gvDetails" HeaderStyle-Height="30px" EmptyDataText="" AllowPaging="true" 
                                                                                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                                                                        OnRowCommand="gvDetails_RowCommand" OnRowDataBound="gvDetails_RowDataBound" DataKeyNames="slno" CssClass="myGridView">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Task" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label Text="<%#Container.DataItemIndex+1 %>" ID="txtTaskID" CssClass="form-control-grid" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Unit">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox Style="display:none" ID="lblUnit" runat="server" Text='<%# Eval("UnitID") %>' />
                                                                                    <asp:DropDownList Width="140px" ID="ddlUnit" ToolTip="Unit" runat="server" onchange="unitchange(this.id);" CssClass="form-control-grid dt fntsize ddlunit"
                                                                                        DataTextField="name" DataValueField="slno">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Width">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtSizeInch" ToolTip="Width" onblur="return ValidateDecimal(this);" onfocusin="chkgridvalid(this.id);chkgridvalid3(this.id);" Width="40px" Text='<%# Eval("Width") %>' CssClass="form-control-grid wi fntsize" runat="server"></asp:TextBox>
                                                                                    <asp:HiddenField runat="server" ID="hfslnochild" Value=' <%#DataBinder.Eval(Container.DataItem,"slno").ToString()==""? "0":DataBinder.Eval(Container.DataItem,"slno") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Height">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtSizeHeight" ToolTip="Height" onblur="return ValidateDecimal(this);" onfocusin="chkgridvalid2(this.id)" Width="40px" Text='<%# Eval("Height") %>' CssClass="form-control-grid hei fntsize" runat="server"></asp:TextBox>
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
                                                                                            <asp:DropDownList Width="180px" ToolTip="Job Type" ID="ddlTypeofJob" runat="server" onchange="loadsubjobdis(this.id);"
                                                                                                CssClass="form-control-grid jt" DataTextField="name" DataValueField="SlNo">
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="SubJob Type">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox  style="display:none;" ID="hfddlSubJob" CssClass="form-control-grid hfddlSubJob" runat="server" Text='<%# Eval("SubJobTypeId") %>' />
                                                                                    <asp:UpdatePanel ID="UpdatePanel151" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <div id="ddlSubJob" runat="server"></div>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Materials used by printer">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox style="display:none;" ID="hfddlSubSubJob" CssClass="form-control-grid hfddlSubSubJob" runat="server" Text='<%# Eval("SubSubJobTypeId") %>' />
                                                                                    <asp:UpdatePanel ID="UpdatePanel152" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <div id="ddlSubSubJob" runat="server"></div>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Fabrication Material">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDesignType" runat="server" Text='<%# Eval("DesignTypeId") %>' Visible="false" />
                                                                                    <asp:DropDownList Width="140px" ToolTip="Fabrication Material" ID="ddlDesignType" runat="server" CssClass="form-control-grid dt"
                                                                                        DataTextField="name" DataValueField="SlNo">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Product Type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblProductType" runat="server" Text='<%# Eval("ProductTypeId") %>' Visible="false" />
                                                                                    <asp:DropDownList Width="140px" ID="ddlProductType" ToolTip="Product Type" runat="server" CssClass="form-control-grid pt" DataTextField="name" DataValueField="SlNo">
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
                                                                                   <asp:TextBox style="display:none;" ID="lblPrinterLocation" CssClass="lbprintloc" runat="server" Text='<%# Eval("PrintLocation") %>' />
                                                                                    <asp:DropDownList Width="140px" ID="ddlPrintLocation" ToolTip="Printer Location" runat="server" onchange="printlocchange(this.id);" CssClass="form-control-grid fntsize"
                                                                                        DataTextField="locnm" DataValueField="slno">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Fabricator Location">
                                                                                <ItemTemplate>
                                                                                     <asp:HiddenField ID="hfIsFabReq" ClientIDMode="Static" runat="server" />
                                                                                     <asp:TextBox style="display:none;" ID="lblFabricatorLocation" CssClass="lbfabloc" runat="server" Text='<%# Eval("FabricatorLocation") %>' />
                                                                                    <asp:DropDownList Width="140px" ID="ddlFabricatorLocation" ToolTip="Fabricator Location" runat="server" onchange="fablocchange(this.id);" CssClass="form-control-grid fntsize"
                                                                                        DataTextField="locnm" DataValueField="slno">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQty" Width="50px" ToolTip="Qty" runat="server" CssClass="form-control-grid qty" Text='<%# Eval("Qty") %>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Priority">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority") %>' Visible="false" />
                                                                                    <asp:DropDownList Width="100px" ToolTip="Priority" ID="ddlPriority" runat="server" CssClass="form-control-grid fntsize">
                                                                                        <asp:ListItem Value="1" Text="Normal"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="High"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Address">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox Width="160px" ID="txtInstallAddress" ToolTip="Address" Style="resize: none;" runat="server" CssClass="form-control-grid add" resize="none" TextMode="MultiLine" Text='<%# Eval("InstallAddress") %>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remark">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox Width="160px" ID="txtRemark"  ToolTip="Remark" runat="server" Style="resize: none;" CssClass="form-control-grid" TextMode="MultiLine" Text='<%# Eval("Remark") %>'></asp:TextBox>
                                                                                    <asp:HiddenField runat="server" ID="hfcancel" Value="0" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Party Approval?">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="lblchkisapprov" runat="server" CssClass="form-control ap" Text='<%# Eval("NeedApproval") %>' Style="display: none"></asp:TextBox>
                                                                                    <asp:UpdatePanel ID="UpdatePanel115" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:CheckBox ID="chkisapprov" ToolTip="Party Approval" onclick="fcnchkcng(this.id)" runat="server"></asp:CheckBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Party Approval To">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPartyApprovalTo" runat="server" Text='<%# Eval("approvalto") %>' Visible="false" />
                                                                                    <asp:DropDownList ID="DropDownList1" ToolTip="Approval To" onchange="fcnFillEmailidfrdis(this.id)" runat="server" Enabled="false" CssClass="form-control apto" Width="130px">
                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        <asp:ListItem Value="1">Delear/Distributer</asp:ListItem>
                                                                                        <asp:ListItem Value="2">Sub Distributer</asp:ListItem>
                                                                                        <asp:ListItem Value="3">Sales Executive</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Mail Id">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtmail" Width="160px" ToolTip="Mail Id" runat="server" Enabled="false" CssClass="form-control-grid fmail" Text='<%# Eval("approvalemail") %>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Images (PNG*JPEG*JPG)">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="hfImagenameDelete" runat="server" Text="" Visible="false" />
                                                                                    <asp:TextBox ID="hfImagename" Text='<%#Eval("Image")%>' runat="server" Visible="false" />
                                                                                    <div style="float: left; overflow: hidden">
                                                                                        <asp:FileUpload ID="fuPhoto" ToolTip="Images (PNG*JPEG*JPG)" AllowMultiple="true" CssClass="form-control-grid filecls" Width="220px" runat="server" TabIndex="6" EnableViewState="true" />
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
                                                                            <asp:TemplateField HeaderText="Disapprove Reason">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox Width="160px" ID="txtreason" ToolTip="Disapprove Reason" runat="server" Style="resize: none;" Enabled="false" CssClass="form-control-grid" TextMode="MultiLine" Text='<%# Eval("apdisapremarks") %>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Open?">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkopen" ToolTip="Open?" runat="server"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Cancel">
                                                                                <ItemTemplate>
                                                                                    <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:LinkButton ID="CmdDeleteChild" EnableViewState="true" runat="server" CommandArgument='<%#Eval("slno")%>' Text='Cancel'
                                                                                                OnClientClick="javascript:return confirm('Do you really want to cancel?');'yes,no'" OnCommand="CmdDeleteChild_Command"></asp:LinkButton>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle Height="30px" />
                                                                    </asp:GridView>
      
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-md-3">
                                                                    <asp:Button ID="btnShowPopup45" runat="server" Style="display: none" />
                                                                    <label>
                                                                        <%--   Visiting Card (<asp:Label ID="lblVisitingCard" runat="server" ForeColor="Maroon">PNG*JPEG*JPG</asp:Label>
                                                                    ):<strong class="redmark">*</strong></label>--%>
                                                                        <asp:TextBox ID="hfVisitingImageDelete" runat="server" Visible="False"></asp:TextBox>
                                                                        <asp:TextBox ID="hfVisitingImage" runat="server" Visible="False"></asp:TextBox>
                                                                        <asp:FileUpload ID="fuVisitingCard" runat="server" AllowMultiple="True" CssClass="form-control" TabIndex="6" Visible="False" />
                                                                        <div>
                                                                            <asp:LinkButton ID="lnkFiles2" runat="server" OnClick="lnkFiles2_Click"></asp:LinkButton>
                                                                        </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label>

                                                                        <asp:TextBox ID="hfReferSheetDelete" runat="server" Visible="False"></asp:TextBox>
                                                                        <asp:TextBox ID="hfReferSheet" runat="server" Visible="False"></asp:TextBox>
                                                                        <asp:FileUpload ID="fuReferSheet" runat="server" AllowMultiple="True" CssClass="form-control" TabIndex="6" Visible="False" />
                                                                        <div>
                                                                            <asp:LinkButton ID="lnkFiles3" runat="server" OnClick="lnkFiles3_Click"></asp:LinkButton>
                                                                        </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label>
                                                                        Submitted By:</label>
                                                                    <asp:Label ID="lblsubmitby" runat="server" />
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <label>
                                                                        Approved BY:</label>
                                                                    <asp:Label ID="lblapproveby" runat="server" />
                                                                </div>
                                                            </div>
                                                            <br />
                                                        </div>
                                                        </label>
                                                        </label>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left: 20px">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />
                                                                    <dx:ASPxButton ID="CmdSaveAsDraft" runat="server" ClientIDMode="Static" OnClick="CmdSaveAsDraft_Click" AutoPostBack="False"
                                                                        Text="Update" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                    </dx:ASPxButton>

                                                                    <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn " TabIndex="8"
                                                                        OnClick="btnCancel_Click1">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
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
                                                                                    AutoGenerateColumns="False" OnHtmlRowCreated="gvHead_HtmlRowCreated" Settings-HorizontalScrollBarMode="Visible">
                                                                                    <Columns>

                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request NO." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                      

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="disapprovedt" Caption="Disapprove Date" VisibleIndex="1">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="NameTypeId" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="AllName" Caption="Dealer Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="220px" FieldName="Address" Caption="Address" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ContactPerson" Caption="ContactPerson" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="Email" Caption="Email" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="220px" FieldName="subaddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>


                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="RequestDate" Caption="Request Date" VisibleIndex="12">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="GivenBy" Caption="Given By" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="headstatus" Caption="Status" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="apdisapremarks" Caption="Remark" VisibleIndex="15">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Edit" ReadOnly="True" VisibleIndex="21">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" OnClientClick="lp.Show()" EnableViewState="false" runat="server" CommandArgument='<%# Eval("slno") %>'
                                                                                                    Text="Edit" OnCommand="CmdEdit_Command">
                                                                                                </asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Cancel All" ReadOnly="True" VisibleIndex="22">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdDelete" EnableViewState="false" runat="server" CommandArgument='<%# Eval("slno") %>'
                                                                                                    OnClientClick="javascript:return confirm('Do you really want to cancel?');'yes,no'"
                                                                                                    Text="Cancel" OnCommand="CmdDelete_Command"></asp:LinkButton>
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

                                    <%--.Start of Tab-3--%>
                                    <dx:TabPage Text="Old List(>30 Days)">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btnXlsExport1" />
                                                                                <asp:PostBackTrigger ControlID="btnXlsxExport1" />
                                                                                <asp:PostBackTrigger ControlID="btnCsvExport1" />
                                                                            </Triggers>
                                                                            <ContentTemplate>
                                                                                <table class="BottomMargin">
                                                                                    <tr>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnXlsExport1" runat="server" Text="Export to XLS" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnXlsExport1_Click" />
                                                                                        </td>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnXlsxExport1" runat="server" Text="Export to XLSX" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnXlsxExport1_Click" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxButton ID="btnCsvExport1" runat="server" Text="Export to CSV" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnCsvExport1_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <br />
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding" Settings-HorizontalScrollBarMode="Visible"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>

                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Width="150px" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request NO." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="disapprovedt" Caption="Disapprove Date" VisibleIndex="1">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                       

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="NameTypeId" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="AllName" Caption="Dealer Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="220px" FieldName="Address" Caption="Address" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ContactPerson" Caption="ContactPerson" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="Email" Caption="Email" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="220px" FieldName="subaddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="RequestDate" Caption="Request Date" VisibleIndex="12">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                       
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="GivenBy" Caption="Given By" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="headstatus" Caption="Status" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="apdisapremarks" Caption="Remark" VisibleIndex="15">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
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
                                            <asp:HyperLink ID="hyLink" runat="server" Target="_blank"  Style="border: none; color: transparent;">
                                                <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                            </asp:HyperLink>
                                        </div>
                                        <div style="clear: both;" id="asd" runat="server">
                                            <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                            <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                             <asp:HiddenField ID="hfvisible" runat="server"  />
                              
                                        </div>
                                         <div style="clear: both;">
                                            <asp:LinkButton ID="lnkDown"   EnableViewState="false" runat="server" 
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
                            <asp:Button ID="btnCloseMPE" runat="server" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
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
                                            <asp:HyperLink ID="hyLink" runat="server" Target="_blank"  Style="border: none; color: transparent;">
                                                <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                            </asp:HyperLink>
                                        </div>
                                        <div style="clear: both;" id="asd" runat="server">
                                            <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                            <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                             <asp:HiddenField ID="hfvisible" runat="server"  />
                                
                                        </div>
                                         <div style="clear: both;">
                                            <asp:LinkButton ID="lnkDown"   EnableViewState="false" runat="server" 
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
                            <asp:Button ID="btnCloseMPE1" runat="server" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
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
                                            <asp:HyperLink ID="hyLink" runat="server" Target="_blank"  Style="border: none; color: transparent;">
                                                <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                            </asp:HyperLink>
                                        </div>
                                        <div style="clear: both;" id="asd" runat="server">
                                            <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                            <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                             <asp:HiddenField ID="hfvisible" runat="server"  />
                                
                                        </div>
                                         <div style="clear: both;">
                                            <asp:LinkButton ID="lnkDown"   EnableViewState="false" runat="server" 
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
                            <asp:Button ID="btnCloseMPE2" runat="server" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCloseMPE2" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>