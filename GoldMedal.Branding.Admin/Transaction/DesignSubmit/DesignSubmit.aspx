<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DesignSubmit.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.DesignSubmit.DesignSubmit" %>

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
            var regex = /(?:\d*\.\d{1,2}|\d+)$/;
            if (regex.test(ele.value)) {
                alert("Valid");
            } else {
                alert("Invalid");
                ele.value = '';
                return false;
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
                if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                    return false;
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
                    <h2 style="text-align: center;">Design Form For Task </h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>
                    <asp:Label ID="lnkvisible" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblchildid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbldslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblrefid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblismailsnd" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblisplace" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblsizetype" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbIsListShow" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblHeadSlno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblstatue" Visible="false" Text="0" runat="server"></asp:Label>



                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <asp:Label ID="lblImageSlno" Style="display: none" Text="0" runat="server"></asp:Label>
                            <asp:HiddenField ID="hfPopupImageFlag" Value="0" runat="server" />

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
                                                                            <label>Request No:</label>
                                                                            <asp:Label ID="LblRequestNo" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Date:</label>
                                                                            <asp:Label ID="lblDate" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Name Type:</label>
                                                                            <asp:Label ID="lblNameType" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Name:</label>
                                                                            <asp:Label ID="lblName" runat="server" />
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
                                                                                Contact No.:</label>
                                                                            <asp:Label ID="lblContact" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Email:</label>
                                                                            <asp:Label ID="lblEmail" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <br />
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Visiting Card (<asp:Label ID="lblVisitingCard" runat="server" ForeColor="Maroon">PNG*JPEG*JPG</asp:Label>):
                                                                            </label>


                                                                            <div>
                                                                                <asp:LinkButton ID="lbVisitingCardImg" OnClientClick="lp.Show()" runat="server" Text="View Image" OnClick="lbVisitingCardImg_Click"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Refer Sheet (<asp:Label ID="lblReferSheet" runat="server" ForeColor="Maroon">XLS*XLSX</asp:Label>
                                                                                ):</label>


                                                                            <div>
                                                                                <asp:LinkButton ID="lbReferSheetImg" OnClientClick="lp.Show()" runat="server" Text="View Image" OnClick="lbReferSheetImg_Click"></asp:LinkButton>
                                                                            </div>
                                                                        </div>


                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Job Request Remark:</label>
                                                                            <asp:Label ID="lblJobRemark" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Job Approval Remark:</label>
                                                                            <asp:Label ID="lblAprrovalRemark" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Assign Job Remark:</label>
                                                                            <asp:Label ID="lblAssignRemark" runat="server" />
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>Regional Language CDR File:</label>
                                                                            <asp:LinkButton ID="lnkRegionalCDRFile" OnClientClick="lp.Show()" runat="server" OnClick="lnkRegionalCDRFile_Click" Text="View CDR File" />
                                                                        </div>

                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Retailer</h2>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Name:</label>
                                                                            <asp:Label ID="lblSubName" runat="server" />
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Firm Name:</label>
                                                                            <asp:Label ID="lblFirmName" runat="server" />
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Address:</label>
                                                                            <asp:Label ID="lblSubAddress" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Contact No:</label>
                                                                            <asp:Label ID="lblSubContact" runat="server" />
                                                                        </div>

                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Given By:</label>
                                                                            <asp:Label ID="lblGivenBy" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Job Details</h2>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-1">
                                                                            <label>
                                                                                Unit:</label>
                                                                            <asp:Label ID="lblUnit" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <label>
                                                                                Board Height:</label>
                                                                            <asp:TextBox ID="txtbheight" onkeypress="return onlyNos(event,this);" runat="server" Enabled="false" CssClass="form-control" />
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <label>
                                                                                Board Width:</label>
                                                                            <asp:TextBox ID="txtbwidth" onkeypress="return onlyNos(event,this);" runat="server" Enabled="false" CssClass="form-control" />
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="row">
                                                                                <div class="cls-sub-topic">
                                                                                    <h2 id="sizelbl" runat="server">Modify Sizes</h2>
                                                                                </div>
                                                                                <div class="col-md-6">
                                                                                    <label>
                                                                                        New Board Height:</label>
                                                                                    <asp:TextBox ID="txtNewHeight" onkeypress="return onlyNos(event,this);" runat="server" CssClass="form-control" />
                                                                                </div>
                                                                                <div class="col-md-6">
                                                                                    <label>
                                                                                        New Board Width:</label>
                                                                                    <asp:TextBox ID="txtNewWidth" onkeypress="return onlyNos(event,this);" runat="server" CssClass="form-control" />
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <%--<div class="col-md-3" style="display:none;">
                                                                            <label>
                                                                                Print Height:</label>

                                                                            <asp:TextBox ID="txtpheight" onkeypress = "return onlyNos(event,this);"  runat="server"  CssClass="form-control" />
                                                                        </div>
                                                                        <div class="col-md-3" style="display:none;">
                                                                            <label>
                                                                                Print Width:</label>
                                                                            <asp:TextBox ID="txtpwidth" onkeypress = "return onlyNos(event,this);"  runat="server"  CssClass="form-control" />
                                                                        </div>--%>
                                                                    </div>
                                                                    <br />

                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Place Size:</label>
                                                                            <asp:Label ID="lblPlaceSize" runat="server" />

                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Qty:</label>
                                                                            <asp:Label ID="lblqty" runat="server" />
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Priority:</label>
                                                                            <asp:Label ID="lblPriority" runat="server" />
                                                                        </div>

                                                                    </div>
                                                                    <br />

                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Job Type:</label>
                                                                            <asp:Label ID="jobtype" runat="server" />
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                SubJob Type:</label>
                                                                            <asp:Label ID="subjobtype" runat="server" />
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Materials used by printer:</label>
                                                                            <asp:Label ID="subsubjobtype" runat="server" />
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Fabrication Material:</label>
                                                                            <asp:Label ID="designtyp" runat="server" />
                                                                        </div>

                                                                        <%--<div class="col-md-3" style="display:none;">
                                                                            <label>
                                                                                Size Type:</label>
                                                                            <asp:RadioButtonList ID="rdsizetype" runat="server" OnClick="lp.Show()" AutoPostBack="True" OnSelectedIndexChanged="rdsizetype_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0" Text="Board"></asp:ListItem>
                                                                                <asp:ListItem Value="1" Text="Place"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </div>--%>
                                                                    </div>
                                                                    <br />

                                                                    <div class="row">



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
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>CDR File:</label>

                                                                            <asp:LinkButton ID="lbCDRFile" OnClientClick="lp.Show()" runat="server" Text="View File" OnClick="lbCDRFile_Click"></asp:LinkButton>

                                                                        </div>

                                                                    </div>
                                                                    <br />
                                                                    <div class="row">

                                                                        <div class="col-md-3">
                                                                            <label>Image:</label>
                                                                            <asp:LinkButton ID="lnkFiles2" OnClientClick="lp.Show()" runat="server" Text="View Image" OnClick="lnkFiles2_Click"></asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>Image Link:</label>
                                                                            <asp:HyperLink ID="ImgLink" runat="server" Target="_blank"></asp:HyperLink>
                                                                        </div>

                                                                        <div class="col-md-3">
                                                                            <label>Other Jobs Images:</label>
                                                                            <asp:LinkButton ID="lnkAllFiles" OnClientClick="lp.Show()" runat="server" Text="View Image" OnClick="lnkAllFiles_Click"></asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Shop Photo:
                                                                            </label>

                                                                            <asp:LinkButton ID="lnkFilesShop" OnClientClick="lp.Show()" Text="View Image" runat="server" OnClick="lnkFilesShop_Click"></asp:LinkButton>

                                                                        </div>
                                                                        <div class="col-md-3" style="display: none;">
                                                                            <label>Other Jobs Image Links:</label>
                                                                            <div id="otherlinks" runat="server">
                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                    <br />

                                                                    <div class="row">
                                                                    </div>
                                                                    <%--<div class="row" style="display:none;">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Size Details</h2>
                                                                        </div>
                                                                    </div>--%>
                                                                    <%--<div class="row" style="display:none;">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Board Height:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtboardhight" onkeypress = "return onlyNos(event,this);" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Board Width:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtboardwidth" onkeypress = "return onlyNos(event,this);" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Print Height:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtprintheight" onkeypress = "return onlyNos(event,this);" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Print Width:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtprintwidth" onkeypress = "return onlyNos(event,this);" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>--%>
                                                                    <%--<div class="row" style="display:none;">
                                                                        <div class="col-md-3">
                                                                            <asp:UpdatePanel ID="UpdatePanel200" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxButton ID="btnaddsize" runat="server" ClientIDMode="Static" AutoPostBack="False"
                                                                                        Text="Add Size Detail" CssClass="btn btn-success btn-space" ClientInstanceName="btnaddsize" TabIndex="6" OnClick="btnaddsize_Click">
                                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                                    </dx:ASPxButton>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>--%>
                                                                    <div class="row">
                                                                        <div class="col-md-12">
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                                                                            <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="75px" HeaderText="Delete" ButtonType="Button" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Design Task Details</h2>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Product Type:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxComboBox ID="cmbProductType" ClientInstanceName="cmbProductType" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="Name"
                                                                                        ValueField="slno" TextFormatString="{0}-{1}"
                                                                                        IsTextEditable="True" ValueType="System.String"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                    </div>

                                                                    <div class="row">

                                                                        <div class="col-md-2">
                                                                            <label>
                                                                                Item Division:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxComboBox ID="cmbItemDivision" ClientInstanceName="cmbItemDivision" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="divisionnm" AutoPostBack="true" OnSelectedIndexChanged="cmbItemDivision_SelectedIndexChanged"
                                                                                        ValueField="slno" TextFormatString="{0}-{1}"
                                                                                        IsTextEditable="True" ValueType="System.String"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>



                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Item:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxComboBox ID="CmbItem" ClientInstanceName="CmbItem" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="Name"
                                                                                        ValueField="slno" TextFormatString="{0}-{1}" OnSelectedIndexChanged="CmbItem_SelectedIndexChanged" AutoPostBack="true"
                                                                                        IsTextEditable="True" ValueType="System.String"
                                                                                        IncrementalFilteringMode="Contains">
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <label>
                                                                                MRP.:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtmrp" runat="server" Text="0" Enabled="false" ClientIDMode="Static" onkeypress="return onlyNos(event,this);" CssClass="form-control" MaxLength="100" TabIndex="1" AutoPostBack="True" OnTextChanged="cal_changed"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <label>
                                                                                Qty.:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtqty" runat="server" onkeypress="return onlyNos(event,this);" Text="0" ClientIDMode="Static" CssClass="form-control" MaxLength="100" TabIndex="1" AutoPostBack="True" OnTextChanged="cal_changed"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">

                                                                        <div class="col-md-2">
                                                                            <label>
                                                                                Discount:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtDiscount" runat="server" Enabled="False" Text="0" ClientIDMode="Static" CssClass="form-control" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>


                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Amount:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtamt" runat="server" Enabled="false" Text="0" ClientIDMode="Static" CssClass="form-control" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label></label>
                                                                            <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                                                <ContentTemplate>
                                                                                    <dx:ASPxButton ID="btnadditem" runat="server" ClientIDMode="Static" OnClick="btnadditem_Click" AutoPostBack="False"
                                                                                        Text="Add Item" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                                    </dx:ASPxButton>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>

                                                                    </br>
                                                                    </br>
                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                            <label>Item Details:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblMsg2" runat="server" />
                                                                                    <asp:GridView runat="server" ID="gvSchemeChild" AutoGenerateColumns="false" EmptyDataText="No Records Found."
                                                                                        OnRowDataBound="gvSchemeChild_RowDataBound" OnRowDeleting="gvSchemeChild_RowDeleting">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Sl. No." ItemStyle-Width="100">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                                    <asp:HiddenField ID="Itemid" Value='<%#Eval("Itemid") %>' runat="server" />
                                                                                                    <asp:HiddenField runat="server" ID="hfchildslno" Value=' <%#DataBinder.Eval(Container.DataItem,"childslno").ToString()==""? "0":DataBinder.Eval(Container.DataItem,"childslno") %>' />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="Item" ItemStyle-Width="140px" HeaderText="Item" />
                                                                                            <asp:BoundField DataField="MRP" ItemStyle-Width="140px" HeaderText="MRP" />
                                                                                            <asp:BoundField DataField="Discount" ItemStyle-Width="140px" HeaderText="Discount" />
                                                                                            <asp:BoundField DataField="Qty" ItemStyle-Width="140px" HeaderText="Qty" />
                                                                                            <asp:BoundField DataField="Amount" ItemStyle-Width="140px" HeaderText="Amount" />
                                                                                            <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="75px" HeaderText="Delete" ButtonType="Button" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Total Amoumt. :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txttotalamt" runat="server" Enabled="false" Text="0" ClientIDMode="Static" CssClass="form-control" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="cls-sub-topic">
                                                                            <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                            <h2>Submit Design Image</h2>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Upload Image(<asp:Label ID="Label2" runat="server" ForeColor="Maroon"> Size < 25MB</asp:Label>
                                                                                ):</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="hfReferSheetDelete" runat="server" Visible="false"></asp:TextBox>
                                                                                    <asp:TextBox ID="hfReferSheet" runat="server" Visible="false"></asp:TextBox>
                                                                                    <asp:FileUpload ID="fuPhoto" Width="240px" AllowMultiple="true" runat="server" CssClass="form-control" Style="float: left;" />
                                                                                    <div style="display: inline-block; margin-left: 20px; padding-top: 5px;">
                                                                                        <asp:LinkButton ID="lnkFiles3" runat="server" OnClick="lnkFiles3_Click" Text="View Files" Style="text-decoration: underline;"></asp:LinkButton>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Image Link:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtLink" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Remark :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox MaxLength="500" Style="resize: none" TextMode="MultiLine" ID="txtremark" ClientIDMode="Static" runat="server" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3" id="partyremark" runat="server">
                                                                            <label>
                                                                                Party Disapproval Remark :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblPartyRemarks" runat="server"></asp:Label>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>

                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <asp:Button ID="btnShowPopup3" runat="server" Style="display: none" />
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left: 20px">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />
                                                                    <dx:ASPxButton ID="btnSubmit" runat="server" ClientIDMode="Static" OnClick="btnSubmit_Click" AutoPostBack="False"
                                                                        Text="Submit" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
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
                                                                    <asp:Label ID="lblfilename" Visible="false" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnSubmit" />
                                                            <asp:PostBackTrigger ControlID="btnadditem" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <%--.Start of Tab-2--%>
                                    <dx:TabPage Text="List Of Assigned Design Type">
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

                                                                                <br />
                                                                                <br />
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true" Settings-HorizontalScrollBarMode="Visible"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    AutoGenerateColumns="False" OnHtmlRowCreated="ASPxGridView1_HtmlRowCreated">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Width="130px" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Reqno" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="assignrequestno" Caption="Assign Reqno" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>
                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="Assigndate" Caption="Assign Date" VisibleIndex="2">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="JobReopendate" Caption="Job Reopen Date" VisibleIndex="3">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="nametype" Caption="NameType" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="name" Caption="Dealer Name" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="Address" Caption="Address" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Visible="false" FieldName="ContactPerson" Caption="ContactPerson" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="subaddress" Caption="Retailer Address" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Visible="false" Caption="Retailer Person Name" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="180px" FieldName="subemail" Visible="false" Caption="Retailer Email" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Visible="false" Caption="Retailer Contact" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>




                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Width" Caption="Width" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Height" Caption="Hight" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="15">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subjobtype" Caption="SubJobType" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="200px" FieldName="jobrequestremark" Caption="Job Request Remark" VisibleIndex="17">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subsubjobtype" Caption="Material" VisibleIndex="18">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designtype" Caption="DesignType" VisibleIndex="19">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="producttype" Caption="ProductType" VisibleIndex="20">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Qty" Caption="Qty" VisibleIndex="21">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="JobPriority" Caption="Job Priority" VisibleIndex="22">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn FieldName="VisitingCardImg" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Visible="false" Caption="Visiting Card Image" ReadOnly="True" VisibleIndex="23">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>

                                                                                                <asp:LinkButton ID="lnkShowImg" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                    CommandArgument='<%# Eval("jrhslno") %>' Text='View File'
                                                                                                    Style="text-decoration: underline;" OnCommand="lnkShowImg2_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>



                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="AssignTo" Caption="Assign To" VisibleIndex="24">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="PartyRemark" Caption="Party Disapproval Remark" VisibleIndex="25">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="deadline" Caption="DeadLine" VisibleIndex="26">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="View" ReadOnly="True" VisibleIndex="27">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" OnClientClick="lp.Show()" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("assignslno") %>'
                                                                                                    Text='View' OnCommand="CmdEdit_Command">
                                                                                                </asp:LinkButton>
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
                                    <dx:TabPage Text="List Of Submited Design Type">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel30" runat="server">

                                                                            <ContentTemplate>
                                                                                <br />
                                                                                <br />
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="gvdesignsubmit"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%" Settings-HorizontalScrollBarMode="Visible"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="gvdesignsubmit_DataBinding"
                                                                                    AutoGenerateColumns="False" OnHtmlRowCreated="gvdesignsubmit_HtmlRowCreated">
                                                                                    <Columns>

                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" Width="130px" FieldName="reqno" Caption="Reqno" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <%--  <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="assignrequestno" Caption="Assign Reqno" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="100px" FieldName="nametype" Caption="NameType" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="Distributor" Caption="Dealer Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="distaddress" Caption="Address" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="distcontactperson" Visible="false" Caption="ContactPerson" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Visible="false" Caption="Retailer Person Name" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Visible="false" Caption="Retailer Email" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Visible="false" Caption="Retailer Contact" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="jobrequestdate" Caption="Request Date" VisibleIndex="11">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Width" Caption="Width" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Height" Caption="Hight" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subjob" Caption="SubJobType" VisibleIndex="15">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subsubjob" Caption="Material" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designtype" Caption="DesignType" VisibleIndex="17">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="product" Caption="ProductType" VisibleIndex="18">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="qty" Caption="Qty" VisibleIndex="19">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn FieldName="jobimage" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn FieldName="jobimagelink" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Reference Image" ReadOnly="True" VisibleIndex="20">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>

                                                                                                <asp:LinkButton ID="lnkShowImg3" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                    CommandArgument='<%# Eval("childslno") %>' Text='View File'
                                                                                                    Style="text-decoration: underline;" OnCommand="lnkShowImg3_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn FieldName="sumbmitimg" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn FieldName="ImageLink" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Submitted Image" ReadOnly="True" VisibleIndex="21">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>

                                                                                                <asp:LinkButton ID="lnkShowImg" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                    CommandArgument='<%# Eval("designsubmitslno") %>' Text='View File'
                                                                                                    Style="text-decoration: underline;" OnCommand="lnkShowImg_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Submitted Image Link" ReadOnly="True" VisibleIndex="22">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:HyperLink ID="submitLink" runat="server" Text="View File" Target="_blank" Style="text-decoration: underline;">
                                                                                                </asp:HyperLink>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="designsubmitdate" Caption="Design Submit Date" VisibleIndex="23">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="designapprovedate" Caption="Design Approve Date" VisibleIndex="24">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="reopendt" Caption="Job Reopen Date" VisibleIndex="25">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designsubmitstatus" Caption="Status" VisibleIndex="26">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="DisapprovedRemarks" Caption="Disapproved Remarks" VisibleIndex="27">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="PartyDisapprovedRemarks" Caption="Party Disapproved Remarks" VisibleIndex="28">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Edit" ReadOnly="True" VisibleIndex="29">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdDSEdit" OnClientClick="lp.Show()" EnableViewState="false" runat="server" CommandArgument='<%# Eval("designsubmitslno") %>'
                                                                                                    Text='<%# Eval("statuss")%>' OnCommand="CmdDSEdit_Command">
                                                                                                </asp:LinkButton>
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
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" style="display: inline-block;">
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


        <asp:Button ID="btnShowImgPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeAll" runat="server" TargetControlID="btnShowImgPopup" PopupControlID="pnlpopupAll"
            CancelControlID="btnClosempeAll" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupAll" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none" ScrollBars="Both">
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

    </div>
</asp:Content>
