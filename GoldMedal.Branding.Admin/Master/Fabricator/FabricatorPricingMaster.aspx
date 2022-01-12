<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FabricatorPricingMaster.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.Fabricator.FabricatorPricingMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../../Scripts/PrinterPricing.js"></script>

    <style type="text/css">
        label.error {
            color: red;
            display: inline-flex;
        }

        .btn-space {
            margin-right: 10px;
        }
    </style>

    <script type="text/javascript">

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

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="scrpt1" runat="server">
            </asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Fabricator Pricing Master</h2>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                        <ContentTemplate>

                            <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                OnCallback="ASPxCallback1_Callback">
                                <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                            </dx:ASPxCallback>
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp" Modal="true">
                            </dx:ASPxLoadingPanel>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                            </dx:ASPxGridViewExporter>

                            <asp:HiddenField ID="hfEFabricatorID" ClientIDMode="Static" Value="0" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hfEMaterialID" ClientIDMode="Static" Value="0" runat="server"></asp:HiddenField>
                               <asp:HiddenField ID="hfEBranchID" ClientIDMode="Static" Value="0" runat="server"></asp:HiddenField>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="0" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="Add">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                <div class="row ">

                                                    <div class="form-group">
                                                        <asp:Label ID="lbslno" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:Label ID="lbFabricatorID" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:Label ID="lbFQslno" runat="server" Text="0" Visible="false"></asp:Label>
                                                          <asp:Label ID="lbBranchID" runat="server" Text="0" Visible="false"></asp:Label>
                                                    </div>

                                                    <%--FORM FIELDS  --%>
                                                    <div class="col-md-12">
                                                        <div class="row">

                                                            <div class="col-md-3">

                                                                <label>Fabricator:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                    <ContentTemplate>

                                                                        <div class="form-group">
                                                                            <dx:ASPxComboBox ID="cmbFabricator" ClientInstanceName="cmbFabricator" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                                                                ValueField="slno" TextFormatString="{0}-{1}"
                                                                                IsTextEditable="True" ValueType="System.String"
                                                                                IncrementalFilteringMode="Contains" OnSelectedIndexChanged="cmbFabricator_SelectedIndexChanged" AutoPostBack="True">
                                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                             <div class="col-md-3">

                                                                <label>Branch:</label>
                                                                <div class="form-group">
                                                                    <dx:ASPxComboBox ID="cmbBranch" ClientInstanceName="cmbBranch" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="locnm"
                                                                        ValueField="slno" TextFormatString="{0}-{1}"
                                                                        IsTextEditable="True" ValueType="System.String"
                                                                        IncrementalFilteringMode="Contains" OnSelectedIndexChanged="cmbBranch_SelectedIndexChanged" AutoPostBack="True">
                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxComboBox>
                                                                </div>

                                                            </div>

                                                            <div class="col-md-3">

                                                                <label>Fabricator Quotation:</label>
                                                                <div class="form-group">
                                                                    <dx:ASPxComboBox ID="cmbFabricatorQT" ClientInstanceName="cmbFabricatorQT" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="FabricatorQuotationNumber"
                                                                        ValueField="slno" TextFormatString="{0}-{1}"
                                                                        IsTextEditable="True" ValueType="System.String"
                                                                        IncrementalFilteringMode="Contains" OnSelectedIndexChanged="cmbFabricatorQT_SelectedIndexChanged" AutoPostBack="True">
                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxComboBox>
                                                                </div>

                                                            </div>

                                                            <div class="col-md-3">
                                                                <label style="margin-bottom: 10px;">Quotation File:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="hfReferSheet" runat="server" Visible="false"></asp:TextBox>

                                                                            <div>
                                                                                <asp:LinkButton ID="lnkFiles3" runat="server" OnClick="lnkFiles3_Click">View File</asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                            <div class="col-md-12">
                                                                <label style="margin-bottom: 10px;"><strong class="redmark">*Note - </strong>If material price is not added, Job can not be sent for fabrication.</label>
                                                            </div>

                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lblMsg2" runat="server" />
                                                                        <asp:GridView Width="70%" runat="server" ID="gvPricing" HeaderStyle-Height="30px" AutoGenerateColumns="false" EmptyDataText="No Records Found."
                                                                            OnRowDataBound="gvPricing_RowDataBound" CssClass="myGridView" AllowPaging="true" ShowHeaderWhenEmpty="true" OnPageIndexChanging="gvPricing_PageIndexChanging"
                                                                            PagerStyle-BackColor="#ffffff" PagerStyle-HorizontalAlign="center" PagerStyle-Height="30">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sr No." ItemStyle-Width="100">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfMaterialID" Value='<%#Eval("MaterialID") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfFabricatorID" Value='<%#Eval("FabricatorID") %>' runat="server" />
                                                                                         <asp:HiddenField ID="hfBranchID" Value='<%#Eval("BranchID") %>' runat="server" />
                                                                                        <asp:HiddenField ID="hfslno" Value='<%#Eval("slno") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:BoundField DataField="Material" ItemStyle-Width="300px" HeaderText="Material" ItemStyle-HorizontalAlign="Left" />

                                                                                <asp:TemplateField HeaderText="Unit" ItemStyle-Width="150px">
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hfUnit" Value='<%#Eval("UnitID") %>' runat="server" />

                                                                                        <asp:DropDownList Width="140px" ID="ddlUnit" runat="server" CssClass="form-control-grid dt fntsize ddlunit"
                                                                                            DataTextField="name" DataValueField="slno" TabIndex="1" onfocusin="chkgridvalid(this.id);" onchange="updatehf(this.id);">
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Per Unit Rate" ItemStyle-Width="100px">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox Width="100px" ID="txtRate" runat="server" TabIndex="1" onkeypress="return onlyNos(this);" onfocusin="chkgridvalid2(this.id);" Style="resize: none; font-size: 12px;" CssClass="form-control-grid fntsize gvrate" Text='<%# Eval("Rate") %>'></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Effective From Date" ItemStyle-Width="200px">
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hfEffDate" Value='<%#Eval("EffectiveFromDate") %>' runat="server" />
                                                                                        <dx:ASPxDateEdit ID="txtEffectiveFromDate" EditFormat="Date" runat="server" CssClass="form-control-grid gveffdate" onfocusin="chkgridvalid3(this.id);" TabIndex="1"></dx:ASPxDateEdit>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                        </asp:GridView>

                                                                    </ContentTemplate>

                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>


                                                    </div>

                                                    <div style="">
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div style="margin-top: 30px; margin-left: 15px;">
                                                                            <dx:ASPxButton ID="CmdSubmit" runat="server" ClientIDMode="Static" OnClick="CmdSubmit_Click" AutoPostBack="False"
                                                                                Text="Save" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                                <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                            </dx:ASPxButton>

                                                                            <dx:ASPxButton ID="CmdReset" runat="server" Text="Clear" TabIndex="7" CssClass="btn btn-space"
                                                                                OnClick="CmdReset_Click">
                                                                                <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                            </dx:ASPxButton>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>


                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>

                                    <dx:TabPage Text="List">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl2" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
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
                                                                                <br />
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    AutoGenerateColumns="False" OnHtmlRowCreated="ASPxGridView1_HtmlRowCreated">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Fabricator" Caption="Fabricator" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                          <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Branchname" Caption="Branch Name" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Material" Caption="Material" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Unit" Caption="Unit" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" CellStyle-HorizontalAlign="Left" FieldName="Rate" Caption="Rate" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="EffectiveFromDate" Caption="Effective From Date" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="EffectiveToDate" Caption="Effective To Date" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn FieldName="EffectiveToDate"  Visible="false">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Edit" ReadOnly="True"
                                                                                            VisibleIndex="5">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" OnClientClick="lp.Show()" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("slno") %>'
                                                                                                    Text='Edit' OnCommand="CmdEdit_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Delete" ReadOnly="True"
                                                                                            VisibleIndex="6">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdDelete" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("slno") %>'
                                                                                                    OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                                                                    Text='Delete' OnCommand="CmdDelete_Command"></asp:LinkButton>
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
                                                                                        <PageSizeItemSettings Visible="true" Items="10, 20, 50, 100, 500" />
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
                        <asp:UpdatePanel ID="UpdatePanel21" runat="server" style="display: inline-block;">
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
                                            <asp:LinkButton ID="lnkDown"  EnableViewState="false" runat="server" 
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
                 
                </div>

            </div>
            <br />
            <br />
            <br />
         
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
        </asp:Panel>

        <asp:Button ID="btnShowEditPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeEdit" runat="server" TargetControlID="btnShowEditPopup" PopupControlID="EditPopup"
            CancelControlID="btnCloseEdit" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="EditPopup" runat="server" BackColor="White" Height="350px" Width="1000px" Style="display: none">
            <div class="row">
                <br />
                <br />
                <br />
                <div class="col-lg-12">
                    <div class="box" style="padding:15px;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                                <div class="row" style="margin-bottom:20px;">
                                    <div class="col-md-4">
                                        <label>Fabricator:</label>
                                        <asp:Label ID="lblFabricator" CssClass="" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <label>Material:</label>
                                        <asp:Label ID="lblMaterial" CssClass="" runat="server"></asp:Label>
                                    </div>
                                </div>
                                  <div class="row" style="margin-bottom:10px;">
                                    <div class="col-md-4">
                                        <label>Branch:</label>
                                        <asp:Label ID="lblBranchName" CssClass="" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4">
                                        <label>Unit:<strong class="redmark">*</strong></label>
                                        <dx:ASPxComboBox ID="cmbUnit" ClientInstanceName="cmbUnit" Width="390px" ClientIDMode="Static"
                                            runat="server" CssClass="form-control"
                                            EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                            ValueField="slno" TextFormatString="{0}-{1}"
                                            IsTextEditable="True" ValueType="System.String"
                                            IncrementalFilteringMode="Contains">
                                        </dx:ASPxComboBox>
                                    </div>

                                    <div class="col-md-4">
                                        <label>Rate:<strong class="redmark">*</strong></label>
                                        <asp:TextBox ID="txtRate" runat="server" TabIndex="1"
                                            onkeypress="return onlyNos(this);" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Effective From Date:<strong class="redmark">*</strong></label>
                                        <dx:ASPxDateEdit ID="txtEffectiveFromDate" EditFormat="Date" runat="server"
                                            CssClass="form-control" TabIndex="1">
                                        </dx:ASPxDateEdit>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </div>

            </div>
            <br />
            
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row" align="center">
                        <asp:Button ID="btnUpdatePrice" runat="server" OnClick="btnUpdatePrice_Click" Width="100" Height="30" Text="Update" CssClass="btn btn-success" />
                        <asp:Button ID="btnCloseEdit" runat="server" Width="100" Height="30" Text="Close" CssClass="btn btn-info btn-space" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnCloseEdit" />
                    <asp:PostBackTrigger ControlID="btnUpdatePrice" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>


    </div>

</asp:Content>