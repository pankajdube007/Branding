<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="FinalAssembalyModeOfDispatch.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.FinalAssembaly.FinalAssembalyModeOfDispatch" %>


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
                    <h2 style="text-align: center;">Final Assembly Dispatch Mode Update</h2>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                       <asp:Label ID="lblHeadID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblChildID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblDesignSubmitID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblPrinterAssignID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblFabricatorAssignID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblFinalAssemblyID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblPrinterID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblFabricatorID" Visible="false" Text="0" runat="server"></asp:Label>
                           
                      <asp:Label ID="lblPrintLocationID" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblFabLocationID" Visible="false" Text="0" runat="server"></asp:Label>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
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
                                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                                                                    <br />

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
                                                                       
                                                                    </div>


                                                                    <br />
                                                                   

                                                                   <%-- <div class="row justify-content-center">
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Size Type:</label>
                                                                          
                                                                                <asp:RadioButtonList ID="rdsizetype" runat="server"  Enabled="false"  OnClick="lp.Show()" OnSelectedIndexChanged="rdsizetype_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0" Text="Board"></asp:ListItem>
                                                                                <asp:ListItem Value="1" Text="Place"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </div>

                                                                    </div>--%>


                                                                <%--    <div class="row">
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
                                                                                    <asp:TextBox ID="txtboardhight" onkeypress="return onlyNos(this);" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <label>
                                                                                Board Width:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:TextBox ID="txtboardwidth" onkeypress="return onlyNos(this);" runat="server" CssClass="form-control" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                       
                                                                    </div>
                                                                    <div class="row">
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
                                                                    <br />

                                                                 <%--   <div class="row">
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
                                                                                            <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="75px" HeaderText="Delete" ButtonType="Button" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>--%>
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
                                                                                    <asp:LinkButton ID="lbDesignImage" OnClientClick="lp.Show()" Visible="false"  runat="server" Text="View Image " OnClick="lnkFiles5_Click"></asp:LinkButton>
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
                                                                  
                                                                   
                                                                    </br>
                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                             <label>Item Details:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblMsg2" runat="server" />
                                                                                    <asp:GridView runat="server" ID="gvSchemeChild" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Sl. No." ItemStyle-Width="100">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                                    <asp:HiddenField ID="Itemid" Value='<%#Eval("Itemid") %>' runat="server" />
                                                                                                    <asp:HiddenField runat="server" ID="hfchildslno" Value=' <%#DataBinder.Eval(Container.DataItem,"childslno").ToString()==""? "0":DataBinder.Eval(Container.DataItem,"childslno") %>' />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="Item" ItemStyle-Width="140px" HeaderText="Item" />
                                                                                            <asp:BoundField DataField="Qty" ItemStyle-Width="140px" HeaderText="Qty" />
                                                                                            <%--<asp:CommandField ShowDeleteButton="True" ItemStyle-Width="75px" HeaderText="Delete" ButtonType="Button" />--%>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                         
                                                                    </div>
                                                                    <div class="row">
                                                            <div class="cls-sub-topic">
                                                                <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                <h2>Final Assembly Detail</h2>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                        <label>Image Uploaded By Final Assembly:</label>
                                                                        <div>
                                                                            <asp:LinkButton ID="lbFinalAssembly" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Image" OnClick="lnkFiles11_Click"></asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                            <div class="col-md-3">
                                                                            <label>
                                                                                Submitted By:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblsubmittedby" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                         <div class="col-md-3">
                                                                            <label>Mode:</label>
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>

                                                                                     <dx:ASPxComboBox ID="cmbMode" DropDownStyle="DropDownList" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                        EnableIncrementalFiltering="True" TabIndex="1"
                                                                                         TextFormatString="{0}-{1}"  ValueType="System.String" OnSelectedIndexChanged="cmbMode_SelectedIndexChanged"  AutoPostBack="true">
                                                                                        <Items>
                                                                                            <dx:ListEditItem Text="Select" Value="0" Selected="True" />
                                                                                            <dx:ListEditItem Text="Self Installation" Value="1"/>
                                                                                            <dx:ListEditItem Text="Vendor" Value="2" />
                                                                                            <dx:ListEditItem Text="Dispatch" Value="3" />
                                                                                        </Items>
                                                                                        
                                                                                    </dx:ASPxComboBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                            <div class="col-md-3">
                                                                <label>
                                                                    Dispatched By:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <dx:ASPxComboBox ID="cmbDispatchBy" ClientInstanceName="cmbDispatchBy" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                                                            ValueField="slno" TextFormatString="{0}-{1}"
                                                                            IsTextEditable="True" ValueType="System.String"
                                                                            IncrementalFilteringMode="Contains" AutoPostBack="True">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                        </dx:ASPxComboBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />
                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                         <div class="col-md-12">
                                                        <asp:Button ID="btnShowPopup50" runat="server" Style="display: none" />
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left: 20px">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />
                                                                    
                                                                    <dx:ASPxButton ID="btnApprove" runat="server" ClientIDMode="Static" OnClick="btnApprove_Click" AutoPostBack="False"
                                                                        Text="Save" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
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
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%" Settings-HorizontalScrollBarMode="Visible"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>
                                                                                        
                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="BranchName" Caption="Branch" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printername" Caption="Printer" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="fabricatorname" Caption="Fabricator" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                      <%--  <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="assignrequestno" Caption="Assign Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printerrequestno" Caption="Printer Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="fabricatorrequestno" Caption=" Fabricator Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>
                                                                                       <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="nametype" Caption="NameType" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Distributor" Caption="Dealer Name" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                      
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="distaddress" Caption="Address" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                       <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="distcontactperson" Caption="ContactPerson" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>


                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="180px" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                        <%--Retailer Details--%>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subjob" Caption="SubJobType" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subsubjob" Caption="Material" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designtype" Caption="DesignType" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="product" Caption="ProductType" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Qty" Caption="Job Qty" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="JobReceiveDate" Caption="Fabricator Receive Date" VisibleIndex="15">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <%-- <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="approvedt" Caption="Fabricator Approve Date" VisibleIndex="19">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="View" ReadOnly="True" VisibleIndex="16">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" EnableViewState="false" OnClientClick="lp.Show()" CausesValidation="False" runat="server" CommandArgument='<%# Eval("finalassembalyslno") %>'
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

    </div>
</asp:Content>
