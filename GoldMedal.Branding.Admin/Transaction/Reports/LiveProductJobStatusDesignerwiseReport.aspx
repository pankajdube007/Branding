<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="LiveProductJobStatusDesignerwiseReport.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.Reports.LiveProductJobStatusDesignerwiseReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
                    <h2 style="text-align: center;">Live  Product  Approved / Disapproved  Job Report</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView2">
                    </dx:ASPxGridViewExporter>
                     <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="ASPxGridView3">
                    </dx:ASPxGridViewExporter>
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblchildid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblassignto" Visible="False" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblneedapr" Visible="False" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbluniquekey" Visible="False" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblsndemail" Visible="False" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lnkvisible" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbIsListShow" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:HiddenField ID="hfPopupEmail" Value="0" runat="server"></asp:HiddenField>

                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                       OnCallback="ASPxCallback1_Callback">
                      <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                      </dx:ASPxCallback>
                    <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                                                        Modal="true">
                                                                    </dx:ASPxLoadingPanel>
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="0" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                  
                                    <%--.Start of Tab-1--%>
                                     <dx:TabPage Text="Approved Jobs">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnXlsExport" />
                                                                        <asp:PostBackTrigger ControlID="btnXlsxExport" />
                                                                        <asp:PostBackTrigger ControlID="btnCsvExport" />
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel25" runat="server">

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
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView2"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView2_DataBinding"
                                                                                    OnHtmlRowCreated="ASPxGridView2_HtmlRowCreated" Settings-HorizontalScrollBarMode="Visible"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="NeedApproval" Caption="NeedApproval" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn  FixedStyle="Left" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                       <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="assignrequestno" Caption="Assign Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="approve2dt" Caption="Design head approval date" VisibleIndex="1">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                       

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

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Width" Caption="Width" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Height" Caption="Height" VisibleIndex="13">
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
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="qty" Caption="Qty" Width="50px" VisibleIndex="19">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="submitby" Caption="Design Submitted By" VisibleIndex="20">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="sendemail" Width="200px" Caption="Email Sent To" VisibleIndex="20">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="MgmApprovalDate" Caption="Live product approval date" VisibleIndex="20">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                      <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="liveproductjobacceptedby" Caption="Job Accepted By" VisibleIndex="21">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="liveproductjobaccepteddt" Caption="Job Accepted date" VisibleIndex="22">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                       <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Email Action" ReadOnly="True" VisibleIndex="23">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="LinkButton1" EnableViewState="false" OnClientClick="lp.Show()" CausesValidation="False" runat="server" CommandArgument='<%# Eval("designsubmitslno")+":"+ Eval("sendemail")+":"+ Eval("uniquekey") %>'
                                                                                                    Text='Resend' OnCommand="CmdEdit2_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Reopen" ReadOnly="True" VisibleIndex="24">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdReopen" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("designsubmitslno") %>'
                                                                                                    Text='Reopen' OnClientClick="javascript:return confirm('Do you really want to Reopen?');'yes,no'" OnCommand="CmdReopen_Command"></asp:LinkButton>
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
                                                        </div>
                                                    </div>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>

                                      <%--.Start of Tab-2--%>
                                     <dx:TabPage Text="Disapproved Jobs">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl4" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnXlsExport1" />
                                                                        <asp:PostBackTrigger ControlID="btnXlsxExport1" />
                                                                        <asp:PostBackTrigger ControlID="btnCsvExport1" />
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel34" runat="server">

                                                                            <ContentTemplate>
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
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView3"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView3_DataBinding"
                                                                                    OnHtmlRowCreated="ASPxGridView3_HtmlRowCreated" Settings-HorizontalScrollBarMode="Visible"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="NeedApproval" Caption="NeedApproval" Visible="false">
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn  FixedStyle="Left" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                       <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="assignrequestno" Caption="Assign Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="approve2dt" Caption="Design head approval date" VisibleIndex="1">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                       

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

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Width" Caption="Width" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Height" Caption="Height" VisibleIndex="13">
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
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="qty" Caption="Qty" Width="50px" VisibleIndex="19">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="submitby" Caption="Design Submitted By" VisibleIndex="20">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="MgmRemark" Width="200px" Caption="Management Remark" VisibleIndex="21">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="MgmApprovalDate" Caption="Live product disapproval date" VisibleIndex="22">
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
                                
                                </TabPages>
                            </dx:ASPxPageControl>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
  
</asp:Content>