﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrinterQuotation.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.PrinterQuotation.PrinterQuotation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/JobRequest.js"></script>
    <script type="text/javascript" src="../../Scripts/ListBoxFilter.js"></script>
     <script type="text/javascript" src="../../Scripts/ListBoxFilterUpdated.js"></script>
    <style type="text/css">
        label.error {
            color: red;
            display: inline-flex;
        }
    </style>

    <style type="text/css">
        .btn-space {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content" id="contactForm">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Printer Quotation
                    </h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                        <ContentTemplate>
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
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
                                                    <%--FORM FIELDS  --%>
                                                    <div class="col-md-12" style="height: 400px">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <label>Printer:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                              <asp:Label ID="lnkvisible" Visible="false" Text="0" runat="server"></asp:Label>
                                                                            <asp:Label ID="lbslno" runat="server" Text="0" Visible="false"></asp:Label>
                                                                            <asp:HiddenField runat="server" Visible="true" ID="hf"></asp:HiddenField>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <dx:ASPxComboBox ID="cmbPrinter" ClientInstanceName="cmbPrinter" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                EnableIncrementalFiltering="True" TabIndex="1" TextField="Name"
                                                                                ValueField="slno" TextFormatString="{0}-{1}"
                                                                                IsTextEditable="True" ValueType="System.String"
                                                                                IncrementalFilteringMode="Contains">
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <label style="margin-bottom:18px;">Quotation:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="hfReferSheetDelete" runat="server" Visible="false"></asp:TextBox>
                                                                                <asp:TextBox ID="hfReferSheet" runat="server" Visible="false"></asp:TextBox>
                                                                                <asp:FileUpload ID="fuPhoto" Width="240px" AllowMultiple="true" runat="server" CssClass="form-control" />
                                                                                 <div>
                                                                        <asp:LinkButton ID="lnkFiles3"  runat="server" OnClick="lnkFiles3_Click"></asp:LinkButton>
                                                                    </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <label>Eff. Date:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                            <dx:ASPxDateEdit ID="txtdate" runat="server" CssClass="form-control" Theme="DevEx" EditFormat="Custom" EditFormatString="dd/MM/yyyy" TabIndex="4">
                                                                                <ClientSideEvents KeyDown="function(s, e) {if (e.htmlEvent.KeyCode == ASPxKey.Enter) s.HideDropDown(); }" GotFocus="function(s, e) {s.ShowDropDown();}" />
                                                                            </dx:ASPxDateEdit>
                                                                            <%--<asp:TextBox MaxLength="100" ID="txtdate" ClientIDMode="Static" runat="server" TabIndex="1" CssClass="form-control"></asp:TextBox>--%>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                             <%--<div class="col-md-6">
                                                              <label>
                                                                    Branch:
                                                                </label>
                                                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="">
                                                                            <asp:Label ID="lblbranch" runat="server" Text="0" Visible="false"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <dx:ASPxComboBox ID="cmbBranch" ClientInstanceName="cmbcmbBranch" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                                                EnableIncrementalFiltering="True" TabIndex="1" TextField="locnm"
                                                                                ValueField="slno" TextFormatString="{0}-{1}"
                                                                                IsTextEditable="True" ValueType="System.String"
                                                                                IncrementalFilteringMode="Contains">
                                                                              
                                                                               
                                                                            </dx:ASPxComboBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>--%>
                                                             <div class="col-md-3">

                                                                <label>
                                                                    Branch:<strong class="redmark">*
                                                                    </strong>
                                                                </label>
                                                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblbranch" runat="server" Text="0" Visible="false"></asp:Label>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <dx:ASPxListBox ID="lbBranch" runat="server" TextField="locnm" ClientInstanceName="lbBranch" 
                                                                                ValueField="slno" Width="500px" JS-Filter="True" CssClass="form-control js-filter-class" ValueType="System.String"
                                                                                TabIndex="1" SelectionMode="CheckColumn" Theme="Glass" Height="120px" Style="overflow: hidden; padding: 0 !important; margin: 0 !important;">
                                                                                <CaptionSettings Position="Top" />
                                                                                
                                                                            </dx:ASPxListBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <div class="row">
                                                                    <div class="col-md-6">

                                                                        <dx:ASPxButton ID="CmdSubmit" runat="server" OnClick="CmdSubmit_Click" AutoPostBack="False"
                                                                            Text="Save" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" ClientIDMode="Static" TabIndex="4">
                                                                            <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                            OnCallback="ASPxCallback1_Callback">
                                                                            <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                        </dx:ASPxCallback>
                                                                        <dx:ASPxButton ID="CmdReset" runat="server" Text="Clear" TabIndex="5" CssClass="btn btn-space"
                                                                            OnClick="CmdReset_Click">
                                                                            <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                        </dx:ASPxButton>
                                                                          <asp:Label ID="lblfilename" Visible="false" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="CmdSubmit" />
                                                            </Triggers>
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
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printername" Caption="Printer" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="EffDate" Caption="EffDate" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="PrinterQuotationNumber" Caption="Quotation Number" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                       <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" Caption="View File" ReadOnly="True"
                                                                                            VisibleIndex="6">
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="LinkButViewFile" RenderMode="Link" EnableViewState="false" runat="server"
                                                                                                    CommandArgument='<%# Eval("SlNo") %>'
                                                                                                    Text='View File' OnCommand="LinkButViewFile_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Edit" ReadOnly="True"
                                                                                            VisibleIndex="6">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" OnClientClick="lp.Show()" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("slno") %>'
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
                                            <asp:LinkButton ID="lnkDelete" EnableViewState="false" runat="server"
                                                CommandArgument='<%# Eval("ImageName") %>' OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                CommandName="cmdRemove" Text='Remove' Style="text-decoration: underline;"></asp:LinkButton>
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
    </div>
</asp:Content>