<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FabricatorJobDC.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.FabricatorDesignSubmit.FabricatorJobDC" %>

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
                    <h2 style="text-align: center;">Fabricator's Job DC</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblchildid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbldesignsubmitsslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblprinterid" Visible="false" Text="0" runat="server"></asp:Label>
                     <asp:Label ID="lblPrintLocationID" Visible="false" Text="0" runat="server"></asp:Label>
                     <asp:Label ID="lblFabLocationID" Visible="false" Text="0" runat="server"></asp:Label>

                    <asp:Label ID="lbmultipleslno" Visible="false" Text="0" runat="server"></asp:Label>
                   

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                             <asp:HiddenField ID="hfJobRequestNo" runat="server" Value="0" />
                             <asp:HiddenField ID="hfDesignSubmitID" runat="server" Value="0" />

                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="1" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="View" Visible="false">
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
                                                            <div class="col-md-3" style="display:none;">
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
                                                                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblCost" runat="server" />
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

                                                       <%-- <div class="row">
                                                          <div class="cls-sub-topic">
                                                               <i aria-hidden="true" class="fa fa-tasks"></i>
                                                               <h2>Printers Job Send Detail</h2>
                                                          </div>
                                                     </div>--%>
                                                     <br />

                                                   <%--   <div class="row">
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Printers Job Send To:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                                                    <ContentTemplate>

                                                                         <dx:ASPxComboBox ID="cmbSendToType" runat="server" ValueType="System.String" TextFormatString="{0}-{1}" 
                                                                             AutoPostBack="true" OnSelectedIndexChanged="cmbSendToType_SelectedIndexChanged" 
                                                                             IsTextEditable="false" TabIndex="1" CssClass="form-control">
                                                                                <Items>
                                                                                    <dx:ListEditItem Text="Select" Value="0" Selected="True" />
                                                                                     <dx:ListEditItem Text="Party" Value="1" />
                                                                                <%-- <dx:ListEditItem Text="Retailer" Value="5" />--%>
                                                                                    <%--<dx:ListEditItem Text="Branch" Value="2" />
                                                                                    <dx:ListEditItem Text="Fabricator" Value="3"/>
                                                                                    <dx:ListEditItem Text="Other" Value="4"/>
                                                                                </Items>
                                                                                <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />
                                                                         </dx:ASPxComboBox>

                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                             <div class="col-md-5" id="ddlsendto" runat="server" style="display:none;">
                                                                <label>
                                                                   Select Name<asp:Label ID="lblsendto" runat="server"></asp:Label><strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                                                    <ContentTemplate>
                                                                        <dx:ASPxComboBox ID="cmbSendTo" AutoPostBack="true"  OnSelectedIndexChanged="cmbSendTo_SelectedIndexChanged" ClientInstanceName="cmbSendTo" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                                                            ValueField="slno" TextFormatString="{0}-{1}"
                                                                            IsTextEditable="True" ValueType="System.String"
                                                                            IncrementalFilteringMode="Contains">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />
                                                                        </dx:ASPxComboBox>
                                                                        
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3" id="othername" runat="server" style="display:none;">
                                                                 <label>Other:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtSendToOther" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="1"></asp:TextBox>                
                                                            </div>

                                                          <div class="col-md-4" id="address" runat="server" style="display:none;">
                                                                 <label>Address:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2"  ClientIDMode="Static" CssClass="form-control"  TabIndex="1"></asp:TextBox>                
                                                            </div>
                                                            
                                                        </div>--%>

                                                        <div>

                                                          <%--  <div class="row" id="fabcost" runat="server" style="display:none;">
                                                                <div class="col-md-3">
                                                                    <label>
                                                                        Approx Total Cost of Fabricator :</label>
                                                                    <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblFabricatorCost" runat="server" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>

                                                                <asp:Label ID="lblPricingUnit" Visible="false" Text="0" runat="server"></asp:Label>
                                                                <asp:Label ID="lblPrice" Visible="false" Text="0" runat="server"></asp:Label>
                                                             
                                                                <div class="col-md-4" style="display:none">
                                                                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
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

                                                            </div>--%>

                                                        </div>

                                                      

                                                   <%--    <div class="row">
                                                          <div class="cls-sub-topic">
                                                               <i aria-hidden="true" class="fa fa-tasks"></i>
                                                               <h2>Transport Details</h2>
                                                          </div>
                                                     </div>--%>
                                                     <br />

                                                       <%-- <div class="row">

                                                            <div class="col-md-3">
                                                                 <label>Transport Mode:<strong class="redmark">*</strong></label> 
                                                                 
                                                                         <dx:ASPxComboBox ID="cmbTransportMode" runat="server" ValueType="System.String" TextFormatString="{0}-{1}" 
                                                                             IsTextEditable="false" TabIndex="1" CssClass="form-control">
                                                                                <Items>
                                                                                    <dx:ListEditItem Text="Select" Value="0" Selected="True" />
                                                                                    <dx:ListEditItem Text="Transport" Value="Transport" />
                                                                                    <dx:ListEditItem Text="Local Mode" Value="Local Mode" />
                                                                                    <dx:ListEditItem Text="Courier" Value="Courier"/>
                                                                                    <dx:ListEditItem Text="Hand Delivery" Value="Hand Delivery"/>
                                                                                </Items>
                                                                             <%--   <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />--%>
                                                                         <%--</dx:ASPxComboBox>
                                                                                
                                                            </div>

                                                             <div class="col-md-3">
                                                                 <label>Transpoter Name:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtTranspoterName" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="2"></asp:TextBox>                
                                                            </div>

                                                            <div class="col-md-3">
                                                                 <label>Invoice Number:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtInvoiceNumber" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="3"></asp:TextBox>                
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <label>Invoice Date:<strong class="redmark">*</strong></label>   
                                                                 <dx:ASPxDateEdit ID="txtInvoiceDate" EditFormat="Custom" EditFormatString="dd/MM/yyyy" runat="server" 
                                                                     CssClass="form-control" TabIndex="4"></dx:ASPxDateEdit>             
                                                            </div>

                                                             <div class="col-md-3">
                                                                 <label>LR Number:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtLRNumber" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="5"></asp:TextBox>                
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <label>LR Date:<strong class="redmark">*</strong></label>   
                                                                 <dx:ASPxDateEdit ID="txtLRDate" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" 
                                                                     CssClass="form-control" TabIndex="6"></dx:ASPxDateEdit>             
                                                            </div>
                                                           
                                                        </div>--%>

                                                    </div>
                                                    <div class="col-md-12">
                                                        <asp:Button ID="btnShowPopup5" runat="server" Style="display: none" />
                                                    </div>
                                                 <%--   <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left: 20px">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />

                                                                    <dx:ASPxButton ID="btnApprove" runat="server" ClientIDMode="Static" OnClick="btnapprove_Click" AutoPostBack="False"
                                                                        Text="Send" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
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
                                                    </asp:UpdatePanel>--%>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <%--.Start of Tab-2--%>
                                    <dx:TabPage Text="Approved Jobs">
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

                                                                                       <%-- <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="100px" SelectAllCheckboxMode="AllPages" VisibleIndex="1"></dx:GridViewCommandColumn>--%>


                                                                                 <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" Caption="Send" VisibleIndex="0" Width="100px">
                                                                                <Settings AllowDragDrop="True" />
                                                                                <DataItemTemplate>
                                                                                    <dx:ASPxCheckBox runat="server" ID="gvCheck" Theme="Moderno"></dx:ASPxCheckBox>
                                                                                </DataItemTemplate>
                                                                               </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="PONumber" Caption="PO Number" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="name" Caption="Dealer Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="address" Caption="Address" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Retailer" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subjobtype" Caption="SubJobType" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subsubjobtype" Caption="Material" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designtype" Caption="DesignType" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                    
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Qty" Caption="Qty" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Qty" Caption="Sending Qty" VisibleIndex="13">
                                                                                           <DataItemTemplate>
                                                                                          <dx:ASPxTextBox ID="txtsendingqty" runat="server" Text='<%# Eval("Qty") %>' Width="100%">
                                                                                          </dx:ASPxTextBox>
                                                                                           </DataItemTemplate>
                                                                                           </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="approvedt" Caption="Approve date" VisibleIndex="13">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>


                                                                                        <%--<dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="View" ReadOnly="True" VisibleIndex="14">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" EnableViewState="false" OnClientClick="lp.Show()" CausesValidation="False" runat="server" CommandArgument='<%# Eval("slno") %>'
                                                                                                    Text='View' OnCommand="CmdEdit_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>--%>
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

                                                             <div class="sec-btn" style="float:right;">
                                        <div class="row justify-content-end">

                                            <div class="col-md-12">
                                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                    <ContentTemplate>
                                                        <div style="float: left;">
                                                            <dx:ASPxButton ID="btnSend" AutoPostBack="true" runat="server" CssClass="btn btn-outline-cyan" OnClick="btnSend_Click" Text="Send" TabIndex="4">
                                                                <ClientSideEvents Click="function(s,e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                            </dx:ASPxButton>
                                                        </div>

                                                    </ContentTemplate>
                                                    <Triggers>
                                                         <asp:PostBackTrigger ControlID="btnSend" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <%--.Start of Tab-3--%>


                                      <%--.Start of Tab-2--%>
                                    <dx:TabPage Text="View Fabricator DC">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel40" runat="server">

                                                                            <ContentTemplate>
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView2"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView2_DataBinding"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>

                                                                                       <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="DcNumber" Caption="DC Number" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="InvoiceNumber" Caption="Invoice Number" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="InvoiceDate" Caption="Invoice Date" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="LRNumber" Caption="LR Number" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="LRDate" Caption="LR Date" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="TranspoterName" Caption="Transpoter Name" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                       

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="TransportMode" Caption="Transport Mode" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="View" ReadOnly="True" VisibleIndex="8">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:HyperLink ID="ViewProfile" EnableViewState="false" Text="View" runat="server"
                                                                                      NavigateUrl='<%# "~/PrintFabricatorDC.aspx?id="+ Eval("DcNumber") %>' Target="_blank">
                                                                                                   </asp:HyperLink>
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

                                                             <div class="sec-btn" style="float:right;">
                                        
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
                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank"  Style="border: none; color: transparent;">
                                                <asp:Image ID="Image1" runat="server" Width="100" Height="100" Style="border: solid" />
                                            </asp:HyperLink>
                                        </div>
                                        <div style="clear: both;" id="Div2" runat="server">
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ImageName") %>' />
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("slno") %>' />
                                             <asp:HiddenField ID="HiddenField3" runat="server"  />
                                         
                                        </div>
                                         <div style="clear: both;">
                                            <asp:LinkButton ID="LinkButton1"   EnableViewState="false" runat="server" 
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
                                            <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank"  Style="border: none; color: transparent;">
                                                <asp:Image ID="Image2" runat="server" Width="100" Height="100" Style="border: solid" />
                                            </asp:HyperLink>
                                        </div>
                                        <div style="clear: both;" id="Div3" runat="server">
                                            <asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("ImageName") %>' />
                                            <asp:HiddenField ID="HiddenField5" runat="server" Value='<%# Eval("slno") %>' />
                                             <asp:HiddenField ID="HiddenField6" runat="server"  />
                                         
                                        </div>
                                         <div style="clear: both;">
                                            <asp:LinkButton ID="LinkButton3"   EnableViewState="false" runat="server" 
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


          <asp:Button ID="btnShowPopup3" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeImage3" runat="server" TargetControlID="btnShowPopup3" PopupControlID="pnlpopup3"
            CancelControlID="btnShowPopup3" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopup3" runat="server" BackColor="White" Height="600px" Width="1050px" Style="display: none">
            <div class="row">
                <br />
                <br />
                <br />
                <div class="col-lg-12">
                    <div class="box" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel38" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                              <div style="display:none">
                                                                          <div class="row">
                                                          <div class="cls-sub-topic">
                                                               <i aria-hidden="true" class="fa fa-tasks"></i>
                                                               <h2>Printers Job Send Detail</h2>
                                                          </div>
                                                     </div>
                                
                                              <div class="row">
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Printers Job Send To:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                                                    <ContentTemplate>

                                                                         <dx:ASPxComboBox ID="cmbSendToType" runat="server" ValueType="System.String" TextFormatString="{0}-{1}" 
                                                                             AutoPostBack="true" OnSelectedIndexChanged="cmbSendToType_SelectedIndexChanged" 
                                                                             IsTextEditable="false" TabIndex="1" CssClass="form-control">
                                                                                <Items>
                                                                                    <dx:ListEditItem Text="Select" Value="0" Selected="True" />
                                                                                     <dx:ListEditItem Text="Party" Value="1" />
                                                                                <%-- <dx:ListEditItem Text="Retailer" Value="5" />--%>
                                                                                    <dx:ListEditItem Text="Branch" Value="2" />
                                                                                    <dx:ListEditItem Text="Fabricator" Value="3"/>
                                                                                    <dx:ListEditItem Text="Other" Value="4"/>
                                                                                </Items>
                                                                                <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />
                                                                         </dx:ASPxComboBox>

                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                             <div class="col-md-5" id="ddlsendto" runat="server" style="display:none;">
                                                                <label>
                                                                   Select Name<asp:Label ID="lblsendto" runat="server"></asp:Label><strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                                                    <ContentTemplate>
                                                                        <dx:ASPxComboBox ID="cmbSendTo" AutoPostBack="true"  OnSelectedIndexChanged="cmbSendTo_SelectedIndexChanged" ClientInstanceName="cmbSendTo" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                                                            ValueField="slno" TextFormatString="{0}-{1}"
                                                                            IsTextEditable="True" ValueType="System.String"
                                                                            IncrementalFilteringMode="Contains">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />
                                                                        </dx:ASPxComboBox>
                                                                        
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3" id="othername" runat="server" style="display:none;">
                                                                 <label>Other:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtSendToOther" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="1"></asp:TextBox>                
                                                            </div>

                                                          <div class="col-md-4" id="address" runat="server" style="display:none;">
                                                                 <label>Address:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2"  ClientIDMode="Static" CssClass="form-control"  TabIndex="1"></asp:TextBox>                
                                                            </div>
                                                            
                                                        </div>

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

                                                                <asp:Label ID="lblPricingUnit" Visible="false" Text="0" runat="server"></asp:Label>
                                                                <asp:Label ID="lblPrice" Visible="false" Text="0" runat="server"></asp:Label>
                                                             
                                                                <div class="col-md-4" style="display:none">
                                                                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="Label6" runat="server" />
                                                                        <asp:GridView runat="server" ID="gvfabdetail" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                            <Columns>

                                                                                <asp:TemplateField HeaderText="Sr No." ItemStyle-Width="100">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
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

                                 <div class="row" style="padding-left:10px;padding-right:20px">
                                                          <div class="cls-sub-topic">
                                                               <i aria-hidden="true" class="fa fa-tasks"></i>
                                                               <h2>Transport Details</h2>
                                                          </div>
                                                     </div>


                                                    <div class="row" style="padding-left:10px;padding-right:20px">

                                                            <div class="col-md-3">
                                                                 <label>Transport Mode:<strong class="redmark">*</strong></label> 
                                                                 
                                                                         <dx:ASPxComboBox ID="cmbTransportMode" runat="server" ValueType="System.String" TextFormatString="{0}-{1}" 
                                                                             IsTextEditable="false" TabIndex="1" CssClass="form-control">
                                                                                <Items>
                                                                                    <dx:ListEditItem Text="Select" Value="0" Selected="True" />
                                                                                    <dx:ListEditItem Text="Transport" Value="Transport" />
                                                                                    <dx:ListEditItem Text="Local Mode" Value="Local Mode" />
                                                                                    <dx:ListEditItem Text="Courier" Value="Courier"/>
                                                                                    <dx:ListEditItem Text="Hand Delivery" Value="Hand Delivery"/>
                                                                                </Items>
                                                                             <%--   <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />--%>
                                                                         </dx:ASPxComboBox>
                                                                                
                                                            </div>

                                                             <div class="col-md-3">
                                                                 <label>Transpoter Name:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtTranspoterName" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="2"></asp:TextBox>                
                                                            </div>

                                                            <div class="col-md-3">
                                                                 <label>Invoice Number:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtInvoiceNumber" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="3"></asp:TextBox>                
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <label>Invoice Date:<strong class="redmark">*</strong></label>   
                                                                 <dx:ASPxDateEdit ID="txtInvoiceDate" EditFormat="Custom" EditFormatString="dd/MM/yyyy" runat="server" 
                                                                     CssClass="form-control" TabIndex="4"></dx:ASPxDateEdit>             
                                                            </div>

                                                             <div class="col-md-3">
                                                                 <label>LR Number:<strong class="redmark"></strong></label>   
                                                                 <asp:TextBox ID="txtLRNumber" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="5"></asp:TextBox>                
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <label>LR Date:<strong class="redmark">*</strong></label>   
                                                                 <dx:ASPxDateEdit ID="txtLRDate" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" 
                                                                     CssClass="form-control" TabIndex="6"></dx:ASPxDateEdit>             
                                                            </div>
                                                           
                                                        
                                                             <div class="col-md-3">
                                                                 <label>No. Of Packages:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtpkges" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="5"></asp:TextBox>                
                                                            </div>
                                                        <div class="col-md-3">
                                                                 <label>Remark:<strong class="redmark"></strong></label>   
                                                                 <asp:TextBox ID="txtprintdcremark" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="5"></asp:TextBox>                
                                                            </div>
                                                           
                                                        </div>

                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left:10px;padding-right:20px;">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />

                                                                    <dx:ASPxButton ID="btnApprove" runat="server" ClientIDMode="Static" OnClick="btnapprove_Click" AutoPostBack="False"
                                                                        Text="Send" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
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
                            <asp:Button ID="btnCloseMPE3" Visible="false" runat="server" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCloseMPE3" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>

    </div>
</asp:Content>