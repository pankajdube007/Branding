<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="assigntoprinter.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.AssigntoPrinter.assigntoprinter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../../Scripts/JobRequest.js"></script>

    <script>

        function ValidateDecimal(ele) {
            //var regex = /^\d+(\.\d{1,2})?$/;
            var regex = /^[-+]?[0-9]+\.[0-9]+$/;
            if (ele.value.match(regex)) {
                alert("Valid");
                //return true;
            } else {
                alert("Invalid");
                //return false;
            }
        }

        function onlyNos(e) {
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

                if (charCode == 46) {
                    return true;
                }
                else {
                    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                        return false;
                    }
                }


                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Send For Print</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>
                   
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                                <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                                <asp:Label ID="lbldslno" Visible="false" Text="0" runat="server"></asp:Label>
                                <asp:Label ID="lblchildid" Visible="false" ClientIDMode="Static" Text="0" runat="server"></asp:Label>
                                <asp:Label ID="lbprilrequestno" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lblsizetype" Visible="false" Text="0" runat="server"></asp:Label>

                                <asp:Label ID="lblDSSlno" Visible="false" Text="0" runat="server"></asp:Label>
                                 <asp:Label ID="lblBranchID" Visible="false" Text="0" runat="server"></asp:Label>
                                 <asp:Label ID="lblBranch" Visible="false" Text="0" runat="server"></asp:Label>
                                 <asp:Label ID="lnkvisible" Visible="false" Text="0" runat="server"></asp:Label>
                                 <asp:Label ID="lbIsListShow" Visible="false" Text="0" runat="server"></asp:Label>
                                 <asp:Label ID="lblPrintLocationID" Visible="false" Text="0" runat="server"></asp:Label>
                                 <asp:Label ID="lblFabLocationID" Visible="false" Text="0" runat="server"></asp:Label>

                                <asp:HiddenField ID="hfPopupImageFlag" Value="0" runat="server" />
                                <asp:HiddenField ID="hfAllowSubmit" Value="0" runat="server" />
                                <asp:HiddenField ID="hfAllowSubmit2" Value="0" runat="server" />
                                <asp:HiddenField ID="hfIsFabSend" Value="0" runat="server" />
                                <asp:HiddenField ID="hfFabPricingAvailable" Value="0" runat="server" />


                             <asp:HiddenField ID="hfNameId" Value="0" runat="server" />
                             <asp:HiddenField ID="hfNameTypeId" Value="0" runat="server" />
                             <asp:HiddenField ID="hfSubNameId" Value="0" runat="server" />
                             <asp:HiddenField ID="hfUseAddressType" Value="0" runat="server" />

                            <asp:HiddenField ID="hfsendto" Value="0" runat="server" />





                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>
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
                                                                                    Request No
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
                                                                                <label>Date:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                                    <ContentTemplate>

                                                                                        <asp:Label ID="lblDate" runat="server" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Name Type:</label>

                                                                            <asp:Label ID="lblNameType" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Name:</label>
                                                                            <asp:Label ID="lblName" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <br>

                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Address:</label>
                                                                            <asp:Label ID="lblAddress" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Contact Person:</label>
                                                                            <asp:Label ID="lblContactPerson" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Contact No:</label>
                                                                            <asp:Label ID="lblContact" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Email:</label>
                                                                            <asp:Label ID="lblEmail" runat="server" />
                                                                        </div>
                                                                         
                                                                    </div>
                                                                     <br />
                                                                     <div class="row">
                                                                         <div class="col-md-3">
                                                                            <label>
                                                                                CIN Number:</label>
                                                                            <asp:Label ID="lblCinNo" runat="server" />
                                                                        </div>
                                                                     </div>
                                                                     <br />


                                                                    <div class="row">
                                                                     <div class="col-md-3">
                                                                            <label>
                                                                                Job Request Remark:</label>
                                                                            <asp:Label ID="lblJobRemark" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                     <br />
                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Retailer</h2>
                                                                        </div>
                                                                    </div>
                                                                    <br>

                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Name:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubName" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Firm Name:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblFirmName" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Address:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubAddress" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Contact No:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubContact" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Given By:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblGivenBy" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Job Details</h2>
                                                                        </div>
                                                                    </div>
                                                                    <br>

                                                                    <div class="row">

                                                                        <div class="col-md-3">
                                                                            <label>Unit:</label>
                                                                            <asp:Label ID="lblUnit" runat="server" />
                                                                            <asp:Label ID="lblUnitID" runat="server" Visible="false"/>
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Job Type:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="jobtype" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                SubJob Type:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="subjobtype" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Materials used by printer :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="subsubjobtype" runat="server" />
                                                                                    <asp:Label ID="subsubjobtypeID" runat="server" Visible="false"/>
                                                                                   
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                    </div>
                                                                    <br />
                                                                    <br />
                                                                    <div class="row">

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Fabrication Material:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="designtyp" runat="server" />
                                                                                    <asp:Label ID="designtypeID" runat="server" Visible="false"/>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Board Type:</label>
                                                                            <asp:Label ID="lblBoardType" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Printer Location:</label>
                                                                            <asp:Label ID="lblPrintLocation" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Fabricator Location:</label>
                                                                            <asp:Label ID="lblFabricatorLocation" runat="server" />
                                                                            <asp:Label ID="lblFabricatorLocationID" runat="server" Visible="false" Text="0"/>
                                                                        </div>
                                                                    </div>


                                                                    <br />
                                                                    <br />
                                                                    <div class="row">

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Priority:</label>
                                                                            <asp:Label ID="lblPriority" runat="server" />
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Qty.:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblqty" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Requested Image:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:LinkButton ID="lnkFiles2" OnClientClick="lp.Show()" runat="server" Text="View Image " OnClick="lnkFiles2_Click"></asp:LinkButton>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Requested Image Link:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:HyperLink ID="ImgLink" runat="server" Target="_blank"></asp:HyperLink>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>


                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Board Height:</label>

                                                                            <asp:TextBox ID="txtbheight" onkeypress="return onlyNos(this);" Enabled="false" OnTextChanged="txtbheightwidth_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Board Width:</label>
                                                                            <asp:TextBox ID="txtbwidth" onkeypress="return onlyNos(this);" Enabled="false" OnTextChanged="txtbheightwidth_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control" />
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Print Height:</label>
                                                                            <asp:TextBox ID="txtpheight" onkeypress="return onlyNos(this);" Enabled="false" OnTextChanged="txtHeightWidth_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Print Width:</label>
                                                                            <asp:TextBox ID="txtpwidth" onkeypress="return onlyNos(this);" Enabled="false" OnTextChanged="txtHeightWidth_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control" />
                                                                        </div>

                                                                    </div>

                                                                    <div class="row justify-content-center">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Size Type:</label>
                                                                            <%--<asp:RadioButtonList ID="rdsizetype" runat="server" OnClick="lp.Show()"  OnSelectedIndexChanged="rdsizetype_SelectedIndexChanged" AutoPostBack="True">--%>
                                                                                <asp:RadioButtonList ID="rdsizetype" runat="server"  Enabled="false" OnSelectedIndexChanged="rdsizetype_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0" Text="Board"></asp:ListItem>
                                                                                <asp:ListItem Value="1" Text="Place"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </div>

                                                                    </div>


                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Size Details</h2>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Board Height:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtboardhight" onkeypress="return onlyNos(this);" Enabled="false" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Board Width:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtboardwidth" onkeypress="return onlyNos(this);" Enabled="false" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Print Height:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtprintheight" onkeypress="return onlyNos(this);" Enabled="false" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Print Width:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtprintwidth" onkeypress="return onlyNos(this);" Enabled="false" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <asp:UpdatePanel ID="UpdatePanel200" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxButton ID="btnaddsize" runat="server" ClientIDMode="Static" AutoPostBack="False" Visible="false"
                                                                                        Text="Add Size Detail" CssClass="btn btn-success btn-space" ClientInstanceName="btnaddsize" TabIndex="6" OnClick="btnaddsize_Click">
                                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                                    </dx:ASPxButton>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <br />

                                                                    <div class="row">
                                                                        <div class="col-md-12">
                                                                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="Label1" runat="server" />
                                                                                    <asp:GridView runat="server" ID="gvSizeChild" AutoGenerateColumns="false" EmptyDataText="No Records Found."
                                                                                        OnRowDataBound="gvSizeChild_RowDataBound" OnRowDeleting="gvSizeChild_RowDeleting">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Sl. No." ItemStyle-Width="100">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                                    <asp:HiddenField runat="server" ID="hfsizeslno" Value=' <%#DataBinder.Eval(Container.DataItem,"SizeSlno").ToString()==""? "0":DataBinder.Eval(Container.DataItem,"SizeSlno") %>' />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="BoardHeight" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="BoardHeight" />
                                                                                            <asp:BoundField DataField="BoardWidth" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="BoardWidth" />
                                                                                            <asp:BoundField DataField="PrintHeight" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="PrintHeight" />
                                                                                            <asp:BoundField DataField="PrintWidth" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="PrintWidth" />
                                                                                            <%--<asp:CommandField ShowDeleteButton="True" ItemStyle-Width="75px" HeaderText="Delete" ButtonType="Button" />--%>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <br />

                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Design Task Details</h2>
                                                                        </div>
                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Submitted Product Type:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="product" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Total Amount:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lbltotalamount" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                         <div class="col-md-3">
                                                                            <label>
                                                                                Designer Name:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblDesignerName" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Submitted Design :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:LinkButton ID="LinkButton2" OnClientClick="lp.Show()" runat="server" Text="View Image " OnClick="lnkFiles3_Click"></asp:LinkButton>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        
                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Submitted Design Link:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:HyperLink ID="deslink" runat="server" Target="_blank"></asp:HyperLink>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        

                                                                    </div>

                                                                    <br />
                                                                     <br />
                                                                    <div class="row">
                                                                         <div class="col-md-3" id="liveproduct" runat="server" style="display:none;">
                                                                            <label>
                                                                                Submitted Live Product Design :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:LinkButton ID="lnkFiles4" OnClientClick="lp.Show()" runat="server" Text="View Image " OnClick="lnkFiles4_Click"></asp:LinkButton>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                        <div class="col-md-3" id="partyremark" runat="server" style="display:none;">
                                                                            <label>
                                                                                Party Remark :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblPartyRemarks" runat="server"></asp:Label>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                     </div>
                                                                    <br />
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-12">
                                                                            <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblMsg2" runat="server" />
                                                                                    <asp:GridView runat="server" ID="gvSchemeChild" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Sl. No." ItemStyle-Width="100">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:BoundField DataField="Item" ItemStyle-Width="140px" HeaderText="Item" />
                                                                                            <asp:BoundField DataField="MRP" ItemStyle-Width="140px" HeaderText="MRP" />
                                                                                            <asp:BoundField DataField="Discount" ItemStyle-Width="140px" HeaderText="Discount" />
                                                                                            <asp:BoundField DataField="Qty" ItemStyle-Width="140px" HeaderText="Qty" />
                                                                                            <asp:BoundField DataField="Amount" ItemStyle-Width="140px" HeaderText="Amount" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                         <div class="row">
                                                            <div class="cls-sub-topic">
                                                                <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                <h2>Approve Print Job</h2>
                                                            </div>
                                                        </div>
                                                        <br />

                                                        <div class="row">
                                                                        <div class="col-md-3" style="display:none;">
                                                                            <%--<label>
                                                                                Print File(<asp:Label ID="Label2" runat="server" ForeColor="Maroon"> Size < 30MB</asp:Label>
                                                                        ):</label>--%>
                                                                            <asp:TextBox ID="hfApprovedPrintImage" runat="server" Visible="false"></asp:TextBox>
                                                                            <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                                                                <ContentTemplate>
                                                                                <asp:TextBox ID="hfPrintFileDelete" runat="server" Visible="false"></asp:TextBox>
                                                                                <asp:TextBox ID="hfPrintFile" runat="server" Visible="false"></asp:TextBox>
                                                                                <asp:FileUpload ID="fuPrintFile" Width="240px" AllowMultiple="true" runat="server" CssClass="form-control" style="float:left;"/>
                                                                                 <div style="display:inline-block;margin-left:20px;padding-top:5px;">
                                                                                    <%-- <asp:LinkButton ID="lnkPrintFile"  runat="server" OnClick="lnkPrintFile_Click" Text="View Files" style="text-decoration:underline;"></asp:LinkButton>--%>
                                                                                 </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                                  <div class="col-md-3" style="display:inline-block;padding-top:5px;">
                                                                                      <label>
                                                                                Print File :</label>
                                                                                     <asp:LinkButton ID="lnkPrintFile"  runat="server" OnClick="lnkPrintFile_Click" Text="View Files" style="text-decoration:underline;"></asp:LinkButton>
                                                                                 </div>
                                                                        <div class="col-md-6">
                                                                            <label>
                                                                                Print Link:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtPrintLink" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="1"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                          <div class="col-md-3">
                                                                            <label>
                                                                                Approve Print Job Remark:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblapprovejobremark" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3" style="display:none;">
                                                                               

                                                                            <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                                            <ContentTemplate>
                                                                            <dx:ASPxButton ID="btnApprovePrintJob" runat="server" ClientIDMode="Static" OnClick="btnApprovePrintJob_Click" AutoPostBack="False"
                                                                                    Text="Approve Print Job " CssClass="btn btn-success btn-space" ClientInstanceName="btnApprovePrintJob" TabIndex="6">
                                                                                    <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                                </dx:ASPxButton>
                                                                               
                                                                                <dx:ASPxLabel ID="lblPrintFileError" runat="server" ForeColor="Red">
                                                                                </dx:ASPxLabel>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btnApprovePrintJob" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>

                                                                               
                                                                            </div>
                                                                    </div>


                                                        <div id="printerdetails" runat="server" style="display:none;">


                                                             <div class="row">
                                                            <div class="cls-sub-topic">
                                                                <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                <h2>Printer's Detail</h2>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Printer Location:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                                    <ContentTemplate>
                                                                        <dx:ASPxComboBox ID="cmbPrinterLocation" ClientInstanceName="cmbPrinterLocation" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="locnm"
                                                                            ValueField="slno" TextFormatString="{0}-{1}"
                                                                            IsTextEditable="True" ValueType="System.String"
                                                                            IncrementalFilteringMode="Contains" OnSelectedIndexChanged="cmbPrinterLocation_SelectedIndexChanged" AutoPostBack="True">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                        </dx:ASPxComboBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Printer:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <dx:ASPxComboBox ID="cmbPrinter" ClientInstanceName="cmbPrinter" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                                                            ValueField="slno" TextFormatString="{0}-{1}"
                                                                            IsTextEditable="True" ValueType="System.String"
                                                                            IncrementalFilteringMode="Contains" OnSelectedIndexChanged="cmbprinter_SelectedIndexChanged" AutoPostBack="True">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                        </dx:ASPxComboBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>
                                                                    Email Id:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblpriemail" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>
                                                                    Mobile :</label>
                                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblprimobile" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>
                                                                    Contact :</label>
                                                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblpricontect" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Approx Total Cost :</label>
                                                                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblCost" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />

                                                         <asp:Label ID="lblPricingUnit" Visible="false" Text="0" runat="server"></asp:Label>
                                                         <asp:Label ID="lblPrice" Visible="false" Text="0" runat="server"></asp:Label>

                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="Label3" runat="server" />
                                                                        <asp:GridView runat="server" ID="gvPrinter" Visible="false" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sr No." ItemStyle-Width="100">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfslno" Value='<%#Eval("slno") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfMaterialID" Value='<%#Eval("MaterialID") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfPrinterID" Value='<%#Eval("PrinterID") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfUnitID" Value='<%#Eval("UnitID") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Material" ItemStyle-Width="140px" HeaderText="Material" />
                                                                                <asp:BoundField DataField="Rate" ItemStyle-Width="140px" HeaderText="Rate" />
                                                                                <asp:BoundField DataField="Unit" ItemStyle-Width="140px" HeaderText="Unit" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="cls-sub-topic">
                                                                <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                <h2>Printers Job Send Detail</h2>
                                                            </div>
                                                        </div>
                                                        <br />

                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Printers Job Send To:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                                                    <ContentTemplate>

                                                                        <dx:ASPxComboBox ID="cmbSendToType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbSendToType_SelectedIndexChanged" IsTextEditable="false" TabIndex="1" CssClass="form-control">
                                                                            <Items>
                                                                                <dx:ListEditItem Text="Select" Value="0" Selected="True" />
                                                                                <dx:ListEditItem Text="Dealer" Value="1" />
                                                                                <dx:ListEditItem Text="Retailer" Value="5" />
                                                                                <dx:ListEditItem Text="Branch" Value="2" />
                                                                                <dx:ListEditItem Text="Fabricator" Value="3" />
                                                                                <dx:ListEditItem Text="Other" Value="4" />
                                                                            </Items>
                                                                            <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />
                                                                        </dx:ASPxComboBox>

                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-5" id="ddlsendto" runat="server" style="display: none;">
                                                                <label>
                                                                    <asp:Label ID="lblsendto" runat="server">Select:</asp:Label><strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                                                    <ContentTemplate>
                                                                        <dx:ASPxComboBox ID="cmbSendTo" OnSelectedIndexChanged="cmbSendTo_SelectedIndexChanged" AutoPostBack="true" ClientInstanceName="cmbSendTo" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                                                            ValueField="slno" TextFormatString="{0}-{1}"
                                                                            IsTextEditable="True" ValueType="System.String"
                                                                            IncrementalFilteringMode="Contains">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />
                                                                        </dx:ASPxComboBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3" id="othername" runat="server" style="display: none;">
                                                                <label>Other:<strong class="redmark">*</strong></label>
                                                                <asp:TextBox ID="txtSendToOther" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                                            </div>

                                                            <div class="col-md-4" id="address" runat="server" style="display: none;">
                                                                <label>Address:<strong class="redmark">*</strong></label>
                                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2" ClientIDMode="Static" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                                            </div>

                                                        </div>

                                                        <div>

                                                            <div class="row" id="fabcost" runat="server" style="display:none;">
                                                                <div class="col-md-3">
                                                                    <label>
                                                                        Approx Total Cost of Fabricator :</label>
                                                                    <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblFabricatorCost" runat="server" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>

                                                                <asp:Label ID="lblPricingUnitf" Visible="false" Text="0" runat="server"></asp:Label>
                                                                <asp:Label ID="lblPricef" Visible="false" Text="0" runat="server"></asp:Label>
                                                             
                                                                <div class="col-md-4" style="display:none">
                                                                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="Label6" runat="server" />
                                                                        <asp:GridView runat="server" ID="gvfabdetail" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                            <Columns>

                                                                                <asp:TemplateField HeaderText="Sr No." ItemStyle-Width="100">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfslno" Value='<%#Eval("slno") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfMaterialID" Value='<%#Eval("MaterialID") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfPrinterID" Value='<%#Eval("FabricatorID") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfUnitID" Value='<%#Eval("UnitID") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:BoundField DataField="Material" ItemStyle-Width="140px" HeaderText="Matertial" />
                                                                                <asp:BoundField DataField="Rate" ItemStyle-Width="140px" HeaderText="Rate" />
                                                                                <asp:BoundField DataField="unit" ItemStyle-Width="140px" HeaderText="Unit" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                            </div>

                                                        </div>


                                                        </div>

                                                       


                                                         <br />
                                                         <br />
                                                        <div class="row">
                                                             <div class="col-md-3">
                                                                            <label>
                                                                                Remark :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox MaxLength="100" ID="txtremark" Style="resize: none" TextMode="MultiLine" ClientIDMode="Static" runat="server" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                        </div>



                                                    </div>
                                                    <div class="col-md-12">
                                                        <asp:Button ID="btnShowPopup5" runat="server" Style="display: none" />
                                                    </div>



                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left: 20px">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />

                                                                    <dx:ASPxButton ID="btnApprove" runat="server" ClientIDMode="Static" OnClick="btnapprove_Click" AutoPostBack="False"
                                                                        Text="Assign " CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                        OnCallback="ASPxCallback1_Callback">
                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                    </dx:ASPxCallback>

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
                                                            <asp:PostBackTrigger ControlID="btnApprove" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <%--.Start of Tab-2--%>
                                    <dx:TabPage Text="List" Visible="false">
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

                                                                            <ContentTemplate>
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    AutoGenerateColumns="False" Settings-HorizontalScrollBarMode="Visible">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Width="150px" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                      
                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="approve2dt" Caption="Approve Date" VisibleIndex="1">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="nametype" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Distributor" Caption="Dealer Name" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="distaddress" Caption="Address" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="distcontactperson" Caption="ContactPerson" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subjob" Caption="SubJobType" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subsubjob" Caption="Material" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designtype" Caption="DesignType" VisibleIndex="15">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="product" Caption="ProductType" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="150px" FieldName="DesignerName" Caption="Designer Name" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>



                                                                                        <dx:GridViewDataTextColumn FieldName="LiveProductImg"  Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Live Product Image" Visible="false" ReadOnly="True" VisibleIndex="12">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                             <DataItemTemplate>

                                                                                                   <asp:LinkButton ID="lnkShowImg" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                        CommandArgument='<%# Eval("designsubmitslno") %>' Text='View File' 
                                                                                                        Style="text-decoration: underline;" OnCommand="lnkShowImg_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="View" ReadOnly="True" VisibleIndex="21">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                               <%-- <asp:LinkButton ID="CmdEdit" OnClientClick="lp.Show()" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("designsubmitslno") %>'
                                                                                                    Text='View' ></asp:LinkButton>--%>
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
                                     <dx:TabPage Text="Print Job Approved List">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel50" runat="server">

                                                                            <ContentTemplate>
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView2"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView2_DataBinding"
                                                                                    AutoGenerateColumns="False" Settings-HorizontalScrollBarMode="Visible">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Width="150px" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="JobApprovedt" Caption="Job Approve Date" VisibleIndex="2">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                       

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="nametype" Caption="Type" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Distributor" Caption="Dealer Name" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="distaddress" Caption="Address" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="distcontactperson" Caption="ContactPerson" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subjob" Caption="SubJobType" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subsubjob" Caption="Material" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designtype" Caption="DesignType" VisibleIndex="15">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="product" Caption="ProductType" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Width" Caption="Width" VisibleIndex="17">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Height" Caption="Height" VisibleIndex="18">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="150px" FieldName="DesignerName" Caption="Designer Name" VisibleIndex="19">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="designsubmitdate" Caption="Design Submit Date" VisibleIndex="20">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>
                                                                                      
                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="approve2dt" Caption="Design Approve Date" VisibleIndex="21">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="150px" FieldName="PrintLocation" Caption="Print Location" VisibleIndex="22">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="150px" FieldName="FabricatorLocation" Caption="Fabricator Location" VisibleIndex="23">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn FieldName="LiveProductImg"  Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Live Product Image" Visible="false" ReadOnly="True" VisibleIndex="24">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                             <DataItemTemplate>

                                                                                                   <asp:LinkButton ID="lnkShowImg2" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                        CommandArgument='<%# Eval("designsubmitslno") %>' Text='View File' 
                                                                                                        Style="text-decoration: underline;" OnCommand="lnkShowImg_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="View" ReadOnly="True" VisibleIndex="25">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" OnClientClick="lp.Show()" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("designsubmitslno") %>'
                                                                                                    Text='View' OnCommand="CmdEdit_Command"></asp:LinkButton>
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
                                </TabPages>
                            </dx:ASPxPageControl>
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
                        <asp:UpdatePanel ID="UpdatePanel45" runat="server" style="display: inline-block;">
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
                                         <asp:LinkButton ID="lnkDelete" EnableViewState="false" runat="server"
                                                CommandArgument='<%# Eval("ImageName") %>' OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                CommandName="cmdRemove" Text='Remove' Style="text-decoration: underline;display:none;"></asp:LinkButton>     
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


        <asp:Button ID="btnShowImgPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeAll" runat="server" TargetControlID="btnShowImgPopup" PopupControlID="pnlpopupAll"
            CancelControlID="btnClosempeAll" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupAll" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
            <div class="row">
                <br /><br />
                <div class="col-lg-12">
                    <div class="box" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel38" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                                <asp:Repeater ID="rptAllImages" runat="server" OnItemCommand="rptAllImages_ItemCommand" OnItemDataBound="rptAllImages_ItemDataBound">
                                    <ItemTemplate>
                                        <div id="dvImage" style="width: 150px; height: 150px; overflow: hidden; text-align: center; float: left;">
                                            <div>
                                                <asp:HyperLink ID="hyLink" runat="server" Target="_blank" Style="border: none; color: transparent;">
                                                    <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                                </asp:HyperLink>
                                            </div>
                                            <div style="clear: both;" id="asd" runat="server">
                                                <asp:HiddenField ID="hfPImgName" runat="server" Value='<%# Eval("ImageName") %>' />
                                                <asp:HiddenField ID="hfPslno" runat="server" Value='<%# Eval("slno") %>' />
                                                <asp:HiddenField ID="hfPVisible" runat="server" />
                                            </div>
                                            <div style="clear: both;">
                                                <asp:LinkButton ID="lnkDown" EnableViewState="false" runat="server"
                                                    CommandArgument='<%# Eval("ImageName") %>' CommandName="Down" Text='Download'
                                                    Style="text-decoration: underline;"></asp:LinkButton>
                                            </div>
                                        </div>
                                        <div style="clear: both" runat="server" visible="<%# (Container.ItemIndex+1) % 5 == 0 %>"></div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <h2 id="hdAllNoRecord" runat="server">No Image Found</h2>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <!-- /.box -->
                </div>
            </div>
            <br /><br />
            <div class="row">
                <div class="col-lg-12">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row" align="center">
                                <asp:Button ID="btnClosempeAll" runat="server" Width="100" Height="30" Text="Close" CssClass="btn btn-info btn-space" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnClosempeAll" />
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
                                <p id="printmsg" runat="server" style="color:orange;font-weight:bold;display:none;">Oops! Selected printer have not added pricing for the printing material-"<asp:Label ID="lblPopupsubsubjobtype" runat="server" /> ". Still you want to assign printer?</p>
                              
                                <asp:Button ID="btnYes" runat="server" Width="100" Height="30" Text="Yes" OnClick="btnYes_Click" OnClientClick="lp.Show(); ASPxCallback1.PerformCallback();" CssClass="btn btn-success" />
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


         <asp:Button ID="btnShowConfirmPopup2" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeConfirmPopup2" runat="server" TargetControlID="btnShowConfirmPopup2" PopupControlID="pnlConfirmPopup2"
            CancelControlID="btnCloseConfirmPopup2" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlConfirmPopup2" runat="server" BackColor="White" Height="300px" Width="560px" Style="display: none">
            <div class="row">
                <br /> <br /><br />
                <div class="col-lg-12">
                    <div class="box" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel48" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                                 <p id="fabmsg" runat="server" style="color:orange;font-weight:bold;display:none;">Oops! Selected fabricator have not added pricing for the fabrication material-"<asp:Label ID="lblPopupdesigntype" runat="server" /> ". Still you want to send to fabricator?</p>
                                <asp:Button ID="btnYes2" runat="server" Width="100" Height="30" Text="Yes" OnClick="btnYes2_Click" OnClientClick="lp.Show(); ASPxCallback1.PerformCallback();" CssClass="btn btn-success" />
                                <asp:Button ID="btnNo2" runat="server" Width="100" Height="30" Text="No" OnClick="btnNo2_Click" OnClientClick="lp.Show(); ASPxCallback1.PerformCallback();" CssClass="btn btn-danger" />
                            </ContentTemplate>
                            <Triggers>
                                 <asp:PostBackTrigger ControlID="btnYes2" />
                                 <asp:PostBackTrigger ControlID="btnNo2" />
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
                            <asp:Button ID="btnCloseConfirmPopup2" runat="server" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCloseConfirmPopup2" />
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
                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="PendingJobs" Caption="Pending Jobs" VisibleIndex="1">
                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>
                                   
                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="PendingDays" Caption="Pending Days" VisibleIndex="2">
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
</asp:Content>