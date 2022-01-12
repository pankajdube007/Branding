<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DesignTypeSubCategory.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.DesignTypeSubCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/validation.js"></script>
    <style type="text/css">
        label.error {
            color: red;
            display: inline-flex;
        }
    </style>
    <style type="text/css">
        .btn-space {
            margin-right: 10px;
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="scrpt1" runat="server">
            </asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Design Type Sub Category
                    </h2>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                        <ContentTemplate>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                            </dx:ASPxGridViewExporter>
                            <asp:Label ID="lbid" Visible="false" Text="0" runat="server"></asp:Label>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="0" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="Add">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">

                                                <%--FORM FIELDS  --%>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <asp:Label ID="lbslno" runat="server" Text="0" Visible="false"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">

                                                            <label>Design Type:<strong class="redmark">*</strong></label>

                                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <dx:ASPxComboBox ID="cmbDesignType" ClientInstanceName="cmbDesignType" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                        EnableIncrementalFiltering="True" TabIndex="1" TextField="Name"
                                                                        ValueField="slno" TextFormatString="{0}-{1}"
                                                                        IsTextEditable="True" ValueType="System.String"
                                                                        IncrementalFilteringMode="Contains">
                                                                    </dx:ASPxComboBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                        <div class="col-md-4">
                                                        </div>

                                                        <div class="col-md-4">
                                                            <label>Sub Category:<strong class="redmark">*</strong></label>

                                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox MaxLength="100" ID="txtName" ClientIDMode="Static" runat="server" TabIndex="2" CssClass="form-control"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">

                                                        <div class="col-md-6">

                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                            <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />
                                                                            <dx:ASPxButton ID="CmdSubmit" runat="server" OnClick="CmdSubmit_Click" AutoPostBack="true"
                                                                                Text="Save" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" ClientIDMode="Static" TabIndex="4">
                                                                            </dx:ASPxButton>

                                                                            <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                                OnCallback="ASPxCallback1_Callback">
                                                                                <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                            </dx:ASPxCallback>
                                                                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                                                                Modal="true">
                                                                            </dx:ASPxLoadingPanel>
                                                                            <dx:ASPxButton ID="CmdReset" runat="server" Text="Clear" TabIndex="5" CssClass="btn btn-space"
                                                                                OnClick="CmdReset_Click">
                                                                            </dx:ASPxButton>
                                                                            <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn " TabIndex="6"
                                                                                OnClick="btnCancel_Click1">
                                                                            </dx:ASPxButton>
                                                                        </div>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
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
                                                                                <asp:PostBackTrigger ControlID="btnPdfExport" />
                                                                                <asp:PostBackTrigger ControlID="btnXlsExport" />
                                                                                <asp:PostBackTrigger ControlID="btnRtfExport" />
                                                                                <asp:PostBackTrigger ControlID="btnXlsxExport" />
                                                                                <asp:PostBackTrigger ControlID="btnCsvExport" />
                                                                            </Triggers>
                                                                            <ContentTemplate>
                                                                                <table class="BottomMargin">
                                                                                    <tr>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnPdfExport" runat="server" Text="Export to PDF" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnPdfExport_Click" />
                                                                                        </td>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnXlsExport_Click" />
                                                                                        </td>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="Export to XLSX" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnXlsxExport_Click" />
                                                                                        </td>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnRtfExport" runat="server" Text="Export to RTF" UseSubmitBehavior="False"
                                                                                                CssClass="listin" Theme="Default" OnClick="btnRtfExport_Click" />
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
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="DesignTypeName" Caption="DesignType" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="DesignTypeSubCategoryName" Caption="SubCategory" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
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
</asp:Content>