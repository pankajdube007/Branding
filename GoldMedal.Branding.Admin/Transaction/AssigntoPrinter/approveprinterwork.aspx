<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="approveprinterwork.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.AssigntoPrinter.approveprinterwork" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../../Scripts/JobRequest.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Approve Printer's Job</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="ASPxGridView2">
                    </dx:ASPxGridViewExporter>

                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblchildid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbldesignsubmitsslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblprinterid" Visible="false" Text="0" runat="server"></asp:Label>

                     <asp:Label ID="lblPrintLocationID" Visible="false" Text="0" runat="server"></asp:Label>
                     <asp:Label ID="lblFabLocationID" Visible="false" Text="0" runat="server"></asp:Label>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="1" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
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
                                                                            <label>
                                                                                Unit:</label>
                                                                            <asp:Label ID="lblUnit" runat="server" />
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
                                                                         <asp:HyperLink ID="ImgLink"  runat="server" Target="_blank"></asp:HyperLink>
                                                                                      </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                       
                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                         <div class="col-md-6">
                                                                            <asp:GridView runat="server" ID="gvSizeChild" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="BoardHeight" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="BoardHeight" />
                                                                                    <asp:BoundField DataField="BoardWidth" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="BoardWidth" />
                                                                                    <asp:BoundField DataField="PrintHeight" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="PrintHeight" />
                                                                                    <asp:BoundField DataField="PrintWidth" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="PrintWidth" />
                                                                                </Columns>
                                                                            </asp:GridView>
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
                                                                                Submitted Design :</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:LinkButton ID="LinkButton2" OnClientClick="lp.Show()" runat="server" Text="View Image " OnClick="lnkFiles3_Click"></asp:LinkButton>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                         <div class="col-md-3">
                                                                            <label>
                                                                               Submitted Design Link:</label>
                                                                           <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                                                <ContentTemplate>
                                                                         <asp:HyperLink ID="deslink"  runat="server" Target="_blank"></asp:HyperLink>
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
                                                                <h2>Printer Detail</h2>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Printer:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblprinter" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Email Id:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblpriemail" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Mobile :</label>
                                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblprimobile" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Contact :</label>
                                                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblpricontect" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-3" style="display:none;">
                                                                <label>
                                                                    Image Uploaded By Printer :</label>
                                                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="LinkButton4" OnClientClick="lp.Show()" runat="server" Text="View Image " OnClick="lnkFiles4_Click"></asp:LinkButton>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                             <div class="col-md-3" style="display:none;">
                                                                            <label>
                                                                               Image Link Uploaded By Printer :</label>
                                                                           <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                                                <ContentTemplate>
                                                                         <asp:HyperLink ID="prilink"  runat="server" Target="_blank"></asp:HyperLink>
                                                                                      </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                             <div class="col-md-3">
                                                                <label>
                                                                    Approx Total Cost :</label>
                                                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblCost" runat="server" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="Label3" runat="server" />
                                                                        <asp:GridView runat="server" ID="gvPrinter" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Material" ItemStyle-Width="140px" HeaderText="Material" />
                                                                                <asp:BoundField DataField="Rate" ItemStyle-Width="140px" HeaderText="Rate" />
                                                                                <asp:BoundField DataField="Unit" ItemStyle-Width="140px" HeaderText="Unit" />
                                                                            </Columns>
                                                                        </asp:GridView>
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
                                                                        Text="Approve" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
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

                                                                            <ContentTemplate>
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <%--<dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printerrequestno" Caption="Printer Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printername" Caption="Printer" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                      
                                                                                     
                                                                                      
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

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
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

                                                                                          <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="PrinterReceivedDate" Caption="Printer Receive Date" VisibleIndex="21">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="View" ReadOnly="True" VisibleIndex="21">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" EnableViewState="false" OnClientClick="lp.Show()" CausesValidation="False" runat="server" CommandArgument='<%# Eval("slno") %>'
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
                                    <%--.Start of Tab-3--%>
                                     <dx:TabPage Text="Approved List">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel33" runat="server">

                                                                            <ContentTemplate>
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView2"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView2_DataBinding"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printername" Caption="Printer" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                      
                                                                                       <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printerrequestno" Caption="Printer Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="nametype" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Distributor" Caption="Name" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                      
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="distaddress" Caption="Address" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="distcontactperson" Caption="ContactPerson" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Retailer" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
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

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="approveby" Caption="Approved By" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="approvedt" Caption="Approve Date" VisibleIndex="21">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

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
                        <asp:UpdatePanel ID="UpdatePanel20" runat="server" style="display: inline-block;">
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
                        <asp:UpdatePanel ID="UpdatePanel26" runat="server" style="display: inline-block;">
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
                        <asp:UpdatePanel ID="UpdatePanel27" runat="server" style="display: inline-block;">
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