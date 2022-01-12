<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrinterFabricatorMapping.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.Printer.PrinterFabricatorMapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
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

  

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="scrpt1" runat="server">
            </asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Printer Fabricator Mapping</h2>
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
                                                        <asp:Label ID="lbPrinterID" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:Label ID="lbBranchID" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:Label ID="lbPQslno" runat="server" Text="0" Visible="false"></asp:Label>
                                                    </div>

                                                    <%--FORM FIELDS  --%>
                                                    <div class="col-md-12"  style="height: 200px">
                                                        <div class="row">

                                                            <div class="col-md-3">

                                                                <label>Printer:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                    <ContentTemplate>

                                                                        <div class="form-group">
                                                                            <dx:ASPxComboBox ID="cmbPrinter" ClientInstanceName="cmbPrinter" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                                                                ValueField="slno" TextFormatString="{0}-{1}"
                                                                                IsTextEditable="True" ValueType="System.String"
                                                                                IncrementalFilteringMode="Contains">
                                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { }" />
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                            <div class="col-md-3">

                                                                <label>Fabricator:<strong class="redmark">*</strong></label>
                                                                <div class="form-group">
                                                                    <dx:ASPxComboBox ID="cmbFabricator" ClientInstanceName="cmbFabricator" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                EnableIncrementalFiltering="True" TabIndex="1" TextField="name"
                                                                                ValueField="slno" TextFormatString="{0}-{1}"
                                                                                IsTextEditable="True" ValueType="System.String"
                                                                                IncrementalFilteringMode="Contains">
                                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {  }" />
                                                                            </dx:ASPxComboBox>
                                                                </div>

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
                                                                                    AutoGenerateColumns="False" >
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="slno" Caption="slno" VisibleIndex="1" Visible="false">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Printername" Caption="Printer Name" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Fabricatorname" Caption="Fabricator Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="CreateDate" Caption="Create Date" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
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

    </asp:Content>