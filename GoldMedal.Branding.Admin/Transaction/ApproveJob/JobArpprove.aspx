<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="JobArpprove.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.ApproveJob.JobArpprove" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../../Scripts/JobRequest.js"></script>

    <script type="text/javascript">
        function myFunction() {

            var txt;
            var count = document.getElementById('ctl00_MainContent_lblacount').innerText;
            if (count > 0) {
                var r = confirm(" There Are " + count + " jobs are approved is this request ! Do you want to cancel all jobs");
                if (r == true) {

                    $('[id$=can]').click();
                }
                else {

                }
            }
            else {

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
                    <h2 style="text-align: center;">Job Request Approval</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="ASPxGridView1">
                    </dx:ASPxGridViewExporter>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>

                            <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lbslnochild" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblBranchID" Visible="False" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblacount" Style="display: none" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblImageSlno" Style="display: none" Text="0" runat="server"></asp:Label>
                            <asp:HiddenField ID="hfPopupImageFlag" Value="0" runat="server" />
                            <asp:HiddenField ID="popupcount" Value="0" runat="server" />

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
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <div id="dvRequest" runat="server">
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
                                                                            <div id="Div1" runat="server" visible="true">
                                                                                <label>
                                                                                    Date:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblDate" runat="server" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Type:</label>
                                                                            <%--<dx:ASPxComboBox runat="server" ID="cmbNameType" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith"
                                                                                TextField="name" EnableSynchronization="False" CssClass="form-control">--%>
                                                                            <asp:Label ID="lblNameType" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Name:</label>
                                                                            <asp:Label ID="lblName" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <br />
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
                                                                                Contact No.</label>
                                                                            <asp:Label ID="lblContact" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Email:</label>
                                                                            <asp:Label ID="lblEmail" runat="server" />
                                                                        </div>
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
                                                                                Visiting Card (<asp:Label ID="lblVisitingCard" runat="server" ForeColor="Maroon">PNG*JPEG*JPG</asp:Label>):
                                                                            </label>
                                                                            <asp:TextBox ID="hfVisitingImageDelete" runat="server" Visible="false" />
                                                                            <asp:TextBox ID="hfVisitingImage" runat="server" Visible="false" />
                                                                            <div>
                                                                                <asp:LinkButton ID="lnkFiles2" OnClientClick="lp.Show()" runat="server" OnClick="lnkFiles2_Click"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Refer Sheet (<asp:Label ID="lblReferSheet" runat="server" ForeColor="Maroon">XLS*XLSX</asp:Label>
                                                                                ):</label>
                                                                            <asp:TextBox ID="hfReferSheetDelete" runat="server" Visible="false" />
                                                                            <asp:TextBox ID="hfReferSheet" runat="server" Visible="false" />
                                                                            <div>
                                                                                <asp:LinkButton ID="lnkFiles3" OnClientClick="lp.Show()" runat="server" OnClick="lnkFiles3_Click"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label style="margin-top: 20px;">
                                                                                Given By:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblGivenBy" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label style="margin-top: 20px;">
                                                                                Submitted By:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubmittedBy" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label style="margin-top: 20px;">
                                                                                Approved By:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblApprovedBy" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label style="margin-top: 20px;">
                                                                                Shop Photo:
                                                                            </label>
                                                                            <asp:TextBox ID="hfShopPhotoDelete" runat="server" Visible="false" />
                                                                            <asp:TextBox ID="hfShopPhoto" runat="server" Visible="false" />
                                                                            <div>
                                                                                <asp:LinkButton ID="lnkFilesShop" OnClientClick="lp.Show()" runat="server" OnClick="lnkFilesShop_Click"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label style="margin-top: 20px;">CDR File:</label>
                                                                            <asp:LinkButton ID="lbCDRFile" OnClientClick="lp.Show()" runat="server" Text="View File" OnClick="lbCDRFile_Click"></asp:LinkButton>
                                                                        </div>
                                                                    </div>


                                                                    <br />


                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Retailer</h2>
                                                                        </div>
                                                                    </div>
                                                                    <br />
                                                                    <div class="row">

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Firm Name:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubFirmName" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>


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
                                                                                Contact No:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubContact" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Address:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblSubAddress" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>


                                                                    </div>
                                                                    <br />

                                                                    <div id="dhbretdet" runat="server" style="display: none;">
                                                                        <div class="row">
                                                                            <div class="cls-sub-topic">
                                                                                <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                                <h2>Dhanbarse Retailer Details</h2>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label>
                                                                                    Dhanbarse Registration Date:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblRegisterDate" runat="server" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Approval Status:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblApprovalStatus" runat="server" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <br />
                                                                                <label>Approval Date:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblApprovalDate" runat="server" Text="51" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Total Points Earn:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblTotalPoints" runat="server" Text="5151" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <br />
                                                                                <label>Last 6 Months Avarage Points Earn:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblAvaragePoint" runat="server" Text="51" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>

                                                                            <div class="col-md-3">
                                                                                <label>Total Scan:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblTotalScan" runat="server" Text="554141" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <br />
                                                                                <label>Last 6 Months Avarage Scan:</label>
                                                                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Label ID="lblAvarageScan" runat="server" Text="51" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>

                                                                        </div>
                                                                        <br />
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
                                                                    <asp:GridView runat="server" Width="100%" ID="gvDetails" HeaderStyle-Height="30px" EmptyDataText=""
                                                                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" PageSize="20" AllowPaging="false"
                                                                        OnRowDataBound="gvDetails_RowDataBound" DataKeyNames="slno" CssClass="myGridView">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Task" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label Text="<%#Container.DataItemIndex+1 %>" ID="txtTaskID" CssClass="form-control-grid" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Unit">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("unit") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Width">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblwidth" runat="server" Text='<%# Eval("width") %>' />
                                                                                    <asp:HiddenField runat="server" ID="hfslnochild" Value=' <%#DataBinder.Eval(Container.DataItem,"slno").ToString()==""? "0":DataBinder.Eval(Container.DataItem,"slno") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Height">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblheight" runat="server" Text='<%# Eval("height") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Job type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbljobtype" runat="server" Text='<%# Eval("jobtype") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="SubJob Type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSubJob" runat="server" Text='<%# Eval("SubJobType") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Materials used by printer">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSubSubJob" runat="server" Text='<%# Eval("SubSubJobType") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Fabrication Material">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDesignType" runat="server" Text='<%# Eval("DesignType") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Product Type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblProductType" runat="server" Text='<%# Eval("Product") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Board Type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblBoardType" runat="server" Text='<%# Eval("BoardType") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Printer Location">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hfIsPrintReq" ClientIDMode="Static" runat="server" />
                                                                                    <asp:TextBox Style="display: none;" ID="lblPrinterLocation" CssClass="lbprintloc" runat="server" Text='<%# Eval("PrintLocation") %>' />
                                                                                    <asp:DropDownList Width="140px" ID="ddlPrintLocation" ToolTip="Printer Location" runat="server" onchange="printlocchange(this.id);" CssClass="form-control-grid fntsize"
                                                                                        DataTextField="locnm" DataValueField="slno">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Fabricator Location">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hfIsFabReq" ClientIDMode="Static" runat="server" />
                                                                                    <asp:TextBox Style="display: none;" ID="lblFabricatorLocation" CssClass="lbfabloc" runat="server" Text='<%# Eval("FabricatorLocation") %>' />
                                                                                    <asp:DropDownList Width="140px" ID="ddlFabricatorLocation" ToolTip="Fabricator Location" runat="server" onchange="fablocchange(this.id);" CssClass="form-control-grid fntsize"
                                                                                        DataTextField="locnm" DataValueField="slno">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Qty">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblqty" runat="server" Text='<%# Eval("qty") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Priority">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Address">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblInstallAddress" runat="server" Text='<%# Eval("InstallAddress") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Job Request Remark">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("remark") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Images">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="hfImagenameDelete" runat="server" Text="" Visible="false" />
                                                                                    <asp:TextBox ID="hfImagename" Text='<%#Eval("Image")%>' runat="server" Visible="false" />
                                                                                    <div style="float: left; padding: 10px;">
                                                                                        <asp:LinkButton ID="CmdlnkImage3" OnClientClick="lp.Show()" EnableViewState="true" runat="server" CommandArgument='<%#Eval("slno")%>'
                                                                                            OnCommand="CmdlnkImage3_Command"></asp:LinkButton>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Image Link">
                                                                                <ItemTemplate>

                                                                                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ImageLink") %>' Text='<%# Eval("ImageLink") %>' Target="_blank"></asp:HyperLink>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Select">
                                                                                <ItemTemplate>
                                                                                    <asp:RadioButtonList ID="rdisapprave" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdisapprave_SelectedIndexChanged" AutoPostBack="true">
                                                                                        <asp:ListItem Value="1" Text="Approve"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="DisApprove"></asp:ListItem>
                                                                                        <asp:ListItem Value="3" Text="None" Selected="True"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Images(PNG*JPEG*JPG) Size < 20MB">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="hfnewImagenameDelete" runat="server" Text="" Visible="false" />
                                                                                    <asp:TextBox ID="hfnewImagename" Text='<%#Eval("Image")%>' runat="server" Visible="false" />
                                                                                    <div style="float: left; overflow: hidden; padding-top: 20px">
                                                                                        <asp:FileUpload ID="fuPhoto" ToolTip="Images(PNG*JPEG*JPG) Size < 20MB" AllowMultiple="true" CssClass="form-control-grid filecls" Width="200px" runat="server" TabIndex="6" EnableViewState="true" />
                                                                                    </div>
                                                                                    <%--<div>
                                                                                                    <asp:TextBox ID="txtlink" ToolTip="Image Link" Style="font-size: 12px;" Width="200px" runat="server" CssClass="form-control-grid flink" Text='<%# Eval("ImageLink") %>'></asp:TextBox>
                                                                                                </div>--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remark">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtRemark" Style="resize: none" ClientIDMode="Static" TextMode="MultiLine" resize="null" runat="server" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle Height="30px" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <asp:Button ID="btnShowPopup3" runat="server" Style="display: none" />

                                                        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
                                                            <div class="modal-dialog">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <%--<div class="modal-content hightwight">--%>
                                                                        <div class="modal-content">
                                                                            <div class="modal-header bg-aqua">
                                                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                                                <h4 class="modal-title">
                                                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h4>
                                                                            </div>
                                                                            <%--<div class="modal-body hightwight">--%>
                                                                            <div class="modal-body">
                                                                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                                                            </div>
                                                                            <%-- <div class="modal-footer hightwight">--%>
                                                                            <div class="modal-footer">
                                                                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">OK</button>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left: 20px">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />

                                                                    <dx:ASPxButton ID="btnSubmit" runat="server" ClientIDMode="Static" OnClick="btnSubmit_Click" AutoPostBack="False"
                                                                        Text="Approve/Disapprove" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="btnCancelall" runat="server" ClientIDMode="Static" AutoPostBack="False" Visible="false"
                                                                        Text="Cancel All" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                        <ClientSideEvents Click="function(s, e) { myFunction(); lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <asp:Button ID="can" runat="server" class="btn" Style="display: none" OnClick="can_Click" TabIndex="27" Text="OverWrite" />

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
                                                                    <asp:Label ID="lblfilename" Visible="false" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnSubmit" />
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

                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Width="130px" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="NameTypeId" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="180px" FieldName="AllName" Caption="Dealer Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="Address" Caption="Dealer Address" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subaddress" Caption="Retailer Address" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subpname" Caption="Retailer Name" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Caption="Retailer Email" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="RetApprovalStatus" Caption="Retailer Approval Status" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="RetActiveStatus" Caption="Retailer Active Status" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ContactPerson" Caption="ContactPerson" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="Email" Caption="Email" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ContactNumber" Caption="Contact Number" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="JobType" Caption="Job Type" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>



                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubJobType" Caption="Sub Job Type" VisibleIndex="15">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Remark" Width="160px" Caption="Remarks" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="RequestDate" Caption="Request Date" VisibleIndex="17">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="ModifiedDate" Caption="Modified Date" VisibleIndex="18">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>



                                                                                        <%--<dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Sub Name" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                        <dx:GridViewDataTextColumn FieldName="VisitingCardImg" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Visiting Card Image" ReadOnly="True" VisibleIndex="19">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>

                                                                                                <asp:LinkButton ID="lnkShowImg" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                    CommandArgument='<%# Eval("slno") %>' Text='View File'
                                                                                                    Style="text-decoration: underline;" OnCommand="lnkShowImg_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="GivenBy" Caption="Given By" VisibleIndex="20">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="submittedby" Caption="Submitted By" VisibleIndex="21">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="approvedby" Caption="Approved By" VisibleIndex="22">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="headstatus" Caption="Status" VisibleIndex="23">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="JobCount" Caption="Job Count" VisibleIndex="24">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Edit" ReadOnly="True" VisibleIndex="25">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" EnableViewState="false" OnClientClick="lp.Show()" CausesValidation="False" runat="server" CommandArgument='<%# Eval("slno") %>'
                                                                                                    Text='Edit' OnCommand="CmdEdit_Command"></asp:LinkButton>
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
                                    <dx:TabPage Text="Approved List">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btnXlsExport1" />
                                                                                <asp:PostBackTrigger ControlID="btnXlsxExport1" />
                                                                                <asp:PostBackTrigger ControlID="btnCsvExport1" />
                                                                            </Triggers>
                                                                            <ContentTemplate>

                                                                                <div class="row">

                                                                                    <div class="col-md-3">
                                                                                        <label>From Date:<strong class="redmark">*</strong></label>
                                                                                        <dx:ASPxDateEdit ID="txtFromDate" EditFormat="Date" runat="server" CssClass="form-control" TabIndex="1"></dx:ASPxDateEdit>
                                                                                    </div>
                                                                                    <div class="col-md-3">
                                                                                        <label>To Date:<strong class="redmark">*</strong></label>
                                                                                        <dx:ASPxDateEdit ID="txtToDate" EditFormat="Date" runat="server" CssClass="form-control" TabIndex="1"></dx:ASPxDateEdit>
                                                                                    </div>

                                                                                    <div class="col-md-3">
                                                                                        <div style="height: 15px;"></div>
                                                                                        <dx:ASPxButton ID="btnSearch" runat="server" ClientIDMode="Static" OnClick="btnSearch_Click" AutoPostBack="False"
                                                                                            Text="Search" CssClass="btn btn-success btn-space" ClientInstanceName="btnSearch" TabIndex="6">
                                                                                            <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                                        </dx:ASPxButton>
                                                                                    </div>
                                                                                </div>
                                                                                <br />
                                                                                <br />


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
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    AutoGenerateColumns="False" OnHtmlRowCreated="ASPxGridView1_HtmlRowCreated" Settings-HorizontalScrollBarMode="Visible">
                                                                                    <Columns>

                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Width="130px" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="NameTypeId" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="180px" FieldName="AllName" Caption="Dealer Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="Address" Caption="Dealer Address" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="subaddress" Caption="Retailer Address" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subpname" Caption="Retailer Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="180px" FieldName="subemail" Caption="Retailer Email" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>



                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ContactPerson" Caption="ContactPerson" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="180px" FieldName="Email" Caption="Email" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ContactNumber" Caption="Contact Number" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="JobType" Caption="Job Type" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Remark" Width="160px" Caption="Remarks" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="RequestDate" Caption="Request Date" VisibleIndex="15">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>



                                                                                        <%--<dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Sub Name" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                        <dx:GridViewDataTextColumn FieldName="VisitingCardImg" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Visiting Card Image" ReadOnly="True" VisibleIndex="16">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>

                                                                                                <asp:LinkButton ID="lnkShowImg" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                    CommandArgument='<%# Eval("slno") %>' Text='View File'
                                                                                                    Style="text-decoration: underline;" OnCommand="lnkShowImg1_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="GivenBy" Caption="Given By" VisibleIndex="17">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="childstatus1" Caption="Status" VisibleIndex="18">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="180px" FieldName="apdisdt" Caption="Approve/Disapprove Date" VisibleIndex="19">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>



                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="180px" FieldName="apdisapby" Caption="Approve/Disapprove By" VisibleIndex="20">
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

        <asp:Button ID="btnShowImgPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeAll" runat="server" TargetControlID="btnShowImgPopup" PopupControlID="pnlpopupAll"
            CancelControlID="btnClosempeAll" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupAll" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
            <div class="row">
                <br />
                <br />
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
            <br />
            <br />
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
                <br />
                <br />
                <br />
                <div class="col-lg-12">
                    <div class="box" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel47" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                                <p id="printmsg" runat="server" style="color: orange; font-weight: bold;">
                                    Dhanbarse Status Of the Retailer -
                                    <asp:Label ID="lblApprovalStatuspopup" runat="server" />
                                    /
                                    <asp:Label ID="lblCurrentStatuspopup" runat="server" />
                                    .<br />
                                    <br />
                                    Do you still you want to continue ?
                                </p>

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
            <br />
            <br />
            <div class="row">
                <div class="col-lg-12">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row" align="center">
                                <asp:Button ID="btnCloseConfirmPopup" runat="server" Width="100" Height="30" Text="Close" CssClass="btn btn-info btn-space" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCloseConfirmPopup" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
    </div>


</asp:Content>
