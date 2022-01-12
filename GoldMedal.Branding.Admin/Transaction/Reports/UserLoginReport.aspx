<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UserLoginReport.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.Reports.UserLoginReport" %>

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
                    <h2 style="text-align: center;">User Login Details Report</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">

                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                    </dx:ASPxGridViewExporter>
                   
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

                <div class="col-md-2">
                    <label>From Date*</label>
                    <dx:ASPxDateEdit ID="txtFromDate" runat="server" EditFormat="Custom" 
                        CssClass="form-control" EditFormatString="dd/MM/yy">
                    </dx:ASPxDateEdit>
                </div>
               
                <div class="col-md-1" style="padding-top: 22px;">

                    <dx:ASPxButton ID="CmdSubmit" runat="server" OnClick="CmdSubmit_Click" AutoPostBack="False" Text="Search" CssClass="btn btn-success" ClientInstanceName="ASPxButton2" TabIndex="5">

                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                    </dx:ASPxButton>
                    <dx:ASPxCallback ID="ASPxCallback2" runat="server" ClientInstanceName="ASPxCallback1" OnCallback="ASPxCallback1_Callback">
                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                    </dx:ASPxCallback>
                    <dx:ASPxLoadingPanel ID="ASPxLoadingPanel2" Theme="Material" runat="server" ClientInstanceName="lp" Modal="true" Text="Your data are loading shortly...">
                    </dx:ASPxLoadingPanel>


                </div>
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
                                                                              <dx:ASPxGridView Settings-ShowGroupPanel="true" Width="100%" SettingsBehavior-AllowDragDrop="true"
                                        SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1" runat="server"
                                        OnDataBinding="ASPxGridView1_DataBinding" EnablePagingCallbackAnimation="True" 
                                        Theme="Default" AutoGenerateColumns="False" Settings-HorizontalScrollBarMode="Visible">

                                        <Columns>

                                            <dx:GridViewDataTextColumn FieldName="slno" Visible="false">
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn FieldName="UserID" Visible="false">
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" Width="120px" FieldName="usercat" Caption="Category" VisibleIndex="1">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" Width="150px" FieldName="name" Caption="Name" VisibleIndex="3">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" Width="220px" FieldName="usernm" Caption="Login ID" VisibleIndex="4">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" Width="120px" FieldName="designm" Caption="Designation" VisibleIndex="5">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="stat" Width="80px" Caption="Status" VisibleIndex="6">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="branch" Width="150px" Caption="Branch" VisibleIndex="7">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="120px" FieldName="logindt" Caption="Login Date" VisibleIndex="8">
                                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                </PropertiesDateEdit>
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataDateColumn>

                                            <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="150px" FieldName="logtime" Caption="Login Time" VisibleIndex="9">
                                                <PropertiesDateEdit DisplayFormatString="hh:mm:ss tt">
                                                </PropertiesDateEdit>
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataDateColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="100px" FieldName="ipaddress" Caption="IP Address" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="Latitude" Caption="Latitude" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True"  Width="120px" FieldName="Longitude" Caption="Longitude" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="320px" FieldName="GeoLocation" Caption="Geo Location" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="OSFamily" Caption="OS Family" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="OSVersion" Caption="OS Version" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="BrowserFamily" Caption="Browser Family" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="BrowserVersion" Caption="Browser Version" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="DeviceFamily" Caption="Device Family" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="DeviceFormFactor" Caption="Device Form Factor" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="devBrand" Caption="Device Brand" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="devModel" Caption="Device Model" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="120px" FieldName="devbot" Caption="Is Bot" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="100px" FieldName="LocationType" Caption="Location From" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="1000px" Visible="false" FieldName="LocationResponse" Caption="Location Response" VisibleIndex="16">
                                                <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>

                                        </Columns>

                                        <Settings ShowFilterRow="True" />
                                   
                                        <SettingsPager PageSize="10">
                                            <PageSizeItemSettings Items="10, 20, 50, 100, 500" Visible="True">
                                            </PageSizeItemSettings>
                                        </SettingsPager>

                                        <Settings ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" ShowGroupPanel="True" />

                                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

                                    </dx:ASPxGridView>
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