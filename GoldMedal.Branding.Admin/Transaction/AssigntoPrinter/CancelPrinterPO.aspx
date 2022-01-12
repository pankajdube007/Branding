<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelPrinterPO.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.AssigntoPrinter.CancelPrinterPO" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <link href="../../Styles/Jobrequest.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
    <script type="text/javascript" src="../../Scripts/JobRequest.js"></script>
    <script type="text/javascript">
        function MDMMenuItemClick(s, e) {
           
                toEdit = $("[id$=ASPxGridView1]").attr("toEditParameter");
                toRedirect = $("[id$=ASPxGridView1]").attr("toRedirect");
                switch (e.item.name) {
                    case "NewRow":
                        doProcessClick = false;
                        e.usePostBack = false;
                        $('[id$=hkey]').val(0);
                        popup.SetHeaderText('Add New ' + pagename + '');
                        popup.SetContentUrl(toRedirect);
                        popup.Show();
                        e.handled = true;
                        break;
                    case "EditRow":
                        doProcessClick = false;
                        e.usePostBack = false;
                        if (e.objectType == "row") {
                            var index = e.elementIndex;
                            var key = s.GetRowKey(index);
                            s.GetRowValues(index, toEdit, OnGetSelectedRowValues);
                            popup.Show();
                        }
                        e.handled = true;

                        break;
                    case "DeleteRow":

                        doProcessClick = false;
                        e.usePostBack = false;
                        if (e.objectType == "row") {
                            var index = e.elementIndex;
                            var key = s.GetRowKey(index);
                            s.GetRowValues(index, toEdit, OnGetSelectedRowValues);
                            setAction("Delete");
                            popupDel.Show();

                        }
                        e.handled = true;
                        break;
                }

                alert('3');
            }
            function GetRowValueForUpdateBtn(s, e) {
                toEdit = $("[id$=ASPxGridView1]").attr("toEditParameter");
                doProcessClick = false;
                e.usePostBack = false;
                s.GetRowValues(s.GetFocusedRowIndex(), toEdit, OnGetSelectedRowValues);
            }
            function GetRowValueForUpdate(s, e) {
                toEdit = $("[id$=ASPxGridView1]").attr("toEditParameter");

                doProcessClick = false;
                s.GetRowValues(e.visibleIndex, toEdit, OnGetRowValues);

            }
      
    </script>
    <script type="text/javascript">
        var _selectNumber = 0;
        var _all = false;
        var _handle = true;

        function OnAllCheckedChanged(s, e) {
            
            if (s.GetChecked())
                ASPxGridView1.SelectRows();
            else
                ASPxGridView1.UnselectRows();
        }

        function OnGridSelectionChanged(s, e) {
           
            gvCheckAll.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);
            
            if (e.isChangedOnServer == false) {
                if (e.isAllRecordsOnPage && e.isSelected)
                {
                    
                    _selectNumber = s.GetVisibleRowsOnPage();
                }

                else if (e.isAllRecordsOnPage && !e.isSelected)
                {
                   
                    _selectNumber = 0;
                }

                else if (!e.isAllRecordsOnPage && e.isSelected)
                {
                   
                    _selectNumber++;
                }

                else if (!e.isAllRecordsOnPage && !e.isSelected)
                {
                   
                    _selectNumber--;
                }
                   

                if (_handle) {
                    //  cbPage.SetChecked(_selectNumber == s.GetVisibleRowsOnPage());
                    _handle = false;
                }
                _handle = true;
            }
            else {
                // cbPage.SetChecked(cbAll.GetChecked());
            }
        }

        function OnPageCheckedChanged(s, e) {
            _handle = false;
            if (s.GetChecked())
                ASPxGridView1.SelectAllRowsOnPage();
            else
                ASPxGridView1.UnselectAllRowsOnPage();
        }

        function OnGridEndCallback(s, e) {
            _selectNumber = s.cpSelectedRowsOnPage;
            
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Cancel Printer PO</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                   
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblfabpoheadslno" Visible="false" Text="0" runat="server"></asp:Label>

                    <asp:HiddenField ID="hdedit" runat="server" />
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                             <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                    </dx:ASPxGridViewExporter>
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="1" CssClass="tabsB" EnableTheming="True" Theme="Default">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>


                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="List Of Generated Po">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">

                                                                            <ContentTemplate>


                                                                                    <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    ClientInstanceName="ASPxGridView1" Settings-ShowFilterRow="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                                    align="left" KeyFieldName="POChildslno" CssClass="listin" Theme="Default" Width="100%" 
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding" Settings-HorizontalScrollBarMode="Visible" Settings-VerticalScrollBarMode="Auto" Settings-VerticalScrollableHeight="500"
                                                                                    AutoGenerateColumns="False">
                                                                                    <ClientSideEvents RowDblClick="GetRowValueForUpdate" SelectionChanged="GetRowValueForUpdateBtn" ContextMenuItemClick="MDMMenuItemClick" />
                                                                                    <Columns>
                                                                                        <%--<dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" Caption="Cancel" ReadOnly="True" VisibleIndex="0" Width="100px">
                                                                                <Settings AllowDragDrop="True" />
                                                                                <DataItemTemplate>
                                                                                <dx:ASPxCheckBox runat="server" ID="gvCheck" Theme="Moderno"></dx:ASPxCheckBox>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataTextColumn>--%>
                                                                                        <dx:GridViewCommandColumn Caption="Cancel" ShowSelectCheckbox="True" VisibleIndex="0" Width="50px">
                                                                                            <HeaderTemplate>
                                                                                                <dx:ASPxCheckBox ID="gvCheck" runat="server"  ShowCheckBoxSelectorColumn="True" Checked="false"  ClientInstanceName="gvCheckAll"  ToolTip="Select all Item" OnInit="gvCheckAll_Init" Theme="Moderno">
                                                                                                    <ClientSideEvents CheckedChanged="OnAllCheckedChanged" />
                                                                                                </dx:ASPxCheckBox>

                                                                                            </HeaderTemplate>
                                                                                        </dx:GridViewCommandColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Visible="false" FieldName="slno" Caption="SlNo" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="PoNumber" Caption="Po Number" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>



                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Podt" Caption="Po Date" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="JobrequestNo" Caption="Job Request Number" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="JobQty" Caption="Job Qty" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Itemname" Caption="Item Name" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Material" Caption="Material" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Height" Caption="Height" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="width" Caption="Width" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="TotalQty" Caption="Total Qty" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="name" Caption="Fabricator Name" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="partyadd" Caption="Fabricator Address" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="billingadd" Caption="Billing Address" Width="300px" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="dispatchadd" Caption="Dispatch Address" Width="300px" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="DelivryDate" Caption="Delivery Date" VisibleIndex="15">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="LastDelivryDate" Caption="Last Delivery Date" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Remark" VisibleIndex="17" Width="200px">
                                                                                            <DataItemTemplate>
                                                                                                <dx:ASPxTextBox ID="txtcancelremark" runat="server" Width="100%">
                                                                                                </dx:ASPxTextBox>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Visible="false" Caption="Cancel Po" ReadOnly="True" VisibleIndex="18">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdCancel" EnableViewState="false" CausesValidation="False" runat="server"
                                                                                                    CommandArgument='<%# Eval("AssignPrinterSlno")+":"+Eval("POChildslno")+":"+Eval("slno")+"" %>'
                                                                                                    Text='Cancel' OnClientClick="javascript:return confirm('Do you really want to Cancel this PO?');'yes,no'" OnCommand="CmdCancel_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Visible="false" FieldName="AssignPrinterSlno" Caption="AssignPrinterSlno" VisibleIndex="19">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Visible="false" FieldName="POChildslno" Caption="POChildslno" VisibleIndex="20">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                    </Columns>
                                                                                    <%-- <Settings ShowGroupPanel="true" VerticalScrollBarMode="Visible" VerticalScrollableHeight="400" />--%>

                                                                                     <Settings ShowFilterRow="True" />
                                                                                    <SettingsDataSecurity AllowDelete="False" />
                                                                                    <GroupSummary>
                                                                                        <dx:ASPxSummaryItem SummaryType="Count" />
                                                                                    </GroupSummary>
                                                                                    <TotalSummary>
                                                                                        <dx:ASPxSummaryItem FieldName="Size" SummaryType="Sum" />
                                                                                    </TotalSummary>
                                                                                    <SettingsBehavior EnableRowHotTrack="True" ProcessFocusedRowChangedOnServer="True" />
                                                                                    <SettingsPager Mode="ShowAllRecords">
                                                                                        <PageSizeItemSettings  Visible="true" Items="20, 50, 100, 500" />
                                                                                    </SettingsPager>
                                                                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />

                                                                                    <Styles>

                                                                                        <RowHotTrack BackColor="#E9E9E9">
                                                                                        </RowHotTrack>
                                                                                    </Styles>
                                                                                    <ClientSideEvents SelectionChanged="OnGridSelectionChanged" EndCallback="OnGridEndCallback" />
                                                                                   
                                                                                </dx:ASPxGridView>






                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>


                                                            <div class="sec-btn" style="float: right;">
                                                                <div class="row justify-content-end">

                                                                    <div class="col-md-12">
                                                                        <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                                            <ContentTemplate>
                                                                                <div style="float: left;">
                                                                                    <dx:ASPxButton ID="btnCancel" AutoPostBack="true" runat="server" CssClass="btn btn-outline-cyan" OnClick="btnCancel_Click" Text="Cancel" TabIndex="4">
                                                                                        <ClientSideEvents Click="function(s,e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                                    </dx:ASPxButton>
                                                                                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                                        OnCallback="ASPxCallback1_Callback">
                                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                                    </dx:ASPxCallback>
                                                                                </div>

                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btnCancel" />
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
                                </TabPages>
                            </dx:ASPxPageControl>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
