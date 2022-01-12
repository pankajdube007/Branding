<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="SubJobTypeImageReport.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.Reports.SubJobTypeImageReport" %>



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
                    <h2 style="text-align: center;">Sub Job Type Image Report</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">

                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                    </dx:ASPxGridViewExporter>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="ASPxGridView2">
                    </dx:ASPxGridViewExporter>
                     <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                        OnCallback="ASPxCallback1_Callback">
                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                    </dx:ASPxCallback>
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblfinalassemblyslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblchildid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbldesignsubmitsslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblprinterid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblfabricatorid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblassignfabricatorslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblassignprinterslno" Visible="false" Text="0" runat="server"></asp:Label>
                    
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
                                    <dx:TabPage Text="Active Image List">
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
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%" SettingsPager-PageSize="10"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    
                                                                                    AutoGenerateColumns="False"
                                                                                   EnableCallBacks="false"  >
                                                                                    <Columns>

                                                                                       

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="slno" Caption="slno" Visible="false" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="name" Caption="Job Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Job Type Photo" ReadOnly="True" VisibleIndex="3">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                             <DataItemTemplate>

                                                                                                   <asp:LinkButton ID="lnkSubJobTypePhoto" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                        CommandArgument='<%# Eval("slno") %>' Text='View File' 
                                                                                                        Style="text-decoration: underline;" OnCommand="lnkSubJobTypePhoto_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ImageValidFromDate" Caption="Image Valid From Date" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Visible="false" FieldName="ImageValidToDate" Caption="Image Valid To Date" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Status" Caption="Status" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                    </Columns>
                                                                                    <Settings ShowGroupPanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" />
                                                                                   <%--<SettingsPager Mode="EndlessPaging" PageSize="10" />--%>
                                                                                    <Settings ShowFilterRow="True"  />
                                                                                    <SettingsDataSecurity AllowDelete="False" />
                                                                                    <GroupSummary>
                                                                                        <dx:ASPxSummaryItem SummaryType="Count" />
                                                                                    </GroupSummary>
                                                                                    <TotalSummary>
                                                                                        <dx:ASPxSummaryItem FieldName="Size" SummaryType="Sum" />
                                                                                    </TotalSummary>
                                                                                    <SettingsBehavior EnableRowHotTrack="True" ProcessFocusedRowChangedOnServer="True" />
                                                                                    <SettingsPager>
                                                                                        <PageSizeItemSettings Visible="true" Items="20, 50, 100, 500" />
                                                                                    </SettingsPager>
                                                                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                                                   <%-- <Settings ShowFilterRow="True" ShowGroupPanel="True" />--%>
                                                                                    <Styles>
                                                                                        <RowHotTrack BackColor="#E9E9E9">
                                                                                        </RowHotTrack>
                                                                                    </Styles>
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

                                     <%--.Start of Tab-2--%>
                                    <dx:TabPage Text="Inactive Image List">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnXlsExport1" />
                                                                        <asp:PostBackTrigger ControlID="btnXlsxExport1" />
                                                                        <asp:PostBackTrigger ControlID="btnCsvExport1" />
                                                                    </Triggers>
                                                                    <ContentTemplate>

                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">

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
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView2"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%" SettingsPager-PageSize="10"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView2_DataBinding" 
                                                                                    AutoGenerateColumns="False"
                                                                                     EnableCallBacks="false">
                                                                                    <Columns>

                                                                                       
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="slno" Caption="slno" Visible="false" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="name" Caption="Job Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Job Type Photo" ReadOnly="True" VisibleIndex="3">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                             <DataItemTemplate>

                                                                                                   <asp:LinkButton ID="lnkSubJobTypePhotoInactive" EnableViewState="false" runat="server" OnClientClick="lp.Show()"
                                                                                                        CommandArgument='<%# Eval("slno") %>' Text='View File' 
                                                                                                        Style="text-decoration: underline;" OnCommand="lnkSubJobTypePhotoInactive_Command"></asp:LinkButton>

                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ImageValidFromDate" Caption="Image Valid From Date" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Visible="false" FieldName="ImageValidToDate" Caption="Image Valid To Date" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Status" Caption="Status" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                    </Columns>
                                                                                    <Settings ShowGroupPanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" />
                                                                                   <%--<SettingsPager Mode="EndlessPaging" PageSize="10" />--%>
                                                                                    <Settings ShowFilterRow="True"  />
                                                                                    <SettingsDataSecurity AllowDelete="False" />
                                                                                    <GroupSummary>
                                                                                        <dx:ASPxSummaryItem SummaryType="Count" />
                                                                                    </GroupSummary>
                                                                                    <TotalSummary>
                                                                                        <dx:ASPxSummaryItem FieldName="Size" SummaryType="Sum" />
                                                                                    </TotalSummary>
                                                                                    <SettingsBehavior EnableRowHotTrack="True" ProcessFocusedRowChangedOnServer="True" />
                                                                                    <SettingsPager>
                                                                                        <PageSizeItemSettings Visible="true" Items="20, 50, 100, 500" />
                                                                                    </SettingsPager>
                                                                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                                                   <%-- <Settings ShowFilterRow="True" ShowGroupPanel="True" />--%>
                                                                                    <Styles>
                                                                                        <RowHotTrack BackColor="#E9E9E9">
                                                                                        </RowHotTrack>
                                                                                    </Styles>
                                                                                </dx:ASPxGridView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        <asp:Label ID="lblfilename1" Visible="false" runat="server"></asp:Label>
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
    <div>
          <asp:Button ID="btnShowImgPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeAll" runat="server" TargetControlID="btnShowImgPopup" PopupControlID="pnlpopupAll"
            CancelControlID="btnClosempeAll" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupAll" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
            <div class="row">
                <br /><br />
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
            <br /><br />
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