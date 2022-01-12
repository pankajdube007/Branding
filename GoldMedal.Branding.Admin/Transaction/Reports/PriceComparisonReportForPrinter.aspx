<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="PriceComparisonReportForPrinter.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.Reports.PriceComparisonReportForPrinter" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../../Scripts/JobRequest.js"></script>

    <style>

        .hdlbl{
            display:none;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Price Comparison Report (Printer)</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">

                   <%-- <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                    </dx:ASPxGridViewExporter>--%>

                    <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server"
                ASPxPivotGridID="ASPxGridView1">
            </dx:ASPxPivotGridExporter>
                   
                     <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                        OnCallback="ASPxCallback1_Callback">
                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                    </dx:ASPxCallback>
                   
                    
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                           
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>

                            <div class="row">

             
               
               
            </div>

                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="0" CssClass="tabsB" EnableTheming="True" Theme="Default">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="List">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl2" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnXlsExport" />
                                                                        <asp:PostBackTrigger ControlID="btnXlsxExport" />
                                                                        <asp:PostBackTrigger ControlID="btnCsvExport" />
                                                                    </Triggers>
                                                                    <ContentTemplate>

                                                                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">

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
                             <dx:ASPxPivotGrid ID="ASPxGridView1" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="False" OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="False" OptionsView-ShowRowTotals="False" Theme="Glass" OnDataBinding="ASPxGridView1_DataBinding">
                                <Fields>

                                  
                                    <dx:PivotGridField ID="fieldBranchName" FieldName="Branch" Options-AllowSort="False" Area="RowArea" Caption="Branch Name"
                                        AreaIndex="1">
                                    </dx:PivotGridField>

                                     <dx:PivotGridField ID="fieldVendorName" FieldName="Vendor" Options-AllowSort="False" Area="RowArea" Caption="Vendor Name"
                                        AreaIndex="2">
                                    </dx:PivotGridField>

                                    <dx:PivotGridField ID="fieldstatecode1" FieldName="Material" Area="ColumnArea"
                                        AreaIndex="0">
                                    </dx:PivotGridField>

                                    <dx:PivotGridField ID="fieldstatecode2" FieldName="Rate" Area="DataArea"
                                        AreaIndex="0">
                                    </dx:PivotGridField>

                                   


                                </Fields>
                                <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                <OptionsPager RowsPerPage="10000" />
                            </dx:ASPxPivotGrid>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        <asp:Label ID="lblfilename" Visible="false" runat="server"></asp:Label>
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
   
</asp:Content>