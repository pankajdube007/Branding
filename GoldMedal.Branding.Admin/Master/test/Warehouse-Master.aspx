<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Warehouse-Master.aspx.cs" Inherits="Warehouse_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1 {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 13px;
            font-weight: normal;
            color: #666;
            text-decoration: none;
            text-align: left;
            vertical-align: top;
            width: 1069px;
            padding-left: 20px;
            padding-right: 20px;
        }

        .style2 {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 10px;
            font-weight: normal;
            color: #666;
            text-decoration: none;
            text-align: left;
            width: 562px;
            padding-left: 20px;
        }

        .style3 {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 13px;
            font-weight: normal;
            color: #666;
            text-decoration: none;
            text-align: left;
            vertical-align: top;
            width: 562px;
            padding-left: 20px;
            padding-right: 20px;
        }
    </style>

    <script type="text/javascript">

        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
        }

        document.onkeypress = stopRKey;

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" ClientInstanceName="popuparea" PopupAction="MouseOver" CloseAction="CloseButton"
                PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="true" AllowResize="true" Width="1000" Height="700"
                ShowMaximizeButton="true" ShowCollapseButton="true" HeaderText="Branch" Modal="false"
                ContentUrl="Area-Master.aspx?request=popup">
            </dx:ASPxPopupControl>
            <dx:ASPxPopupControl ID="ASPxPopupControl7" runat="server" ClientInstanceName="popupuser" PopupAction="MouseOver" CloseAction="CloseButton"
                PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter" AllowDragging="true" AllowResize="true" HeaderText="Contact"
                ShowMaximizeButton="true" ShowCollapseButton="true" Width="1300" Height="800" Modal="false" ContentUrl="User-Master.aspx?request=popup">
            </dx:ASPxPopupControl>
            <asp:ScriptManager ID="scrpt1" runat="server">
            </asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Warehouse Master
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
                                ActiveTabIndex="0" CssClass="tabsB" EnableTheming="True" Theme="Default">
                                <TabPages>
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="Add">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                <div class="row ">
                                                    <%--FORM FIELDS  --%>
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>Branch Name:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <dx:ASPxComboBox ID="cboBranch" runat="server" CssClass="form-control" TextField="BranchName" ValueField="slno" Style="text-align: left"
                                                                            EnableIncrementalFiltering="True" TextFormatString="{0}-{1}" DropDownStyle="DropDown" IsTextEditable="True" AutoPostBack="true"
                                                                            ValueType="System.String" TabIndex="2" IncrementalFilteringMode="Contains" OnSelectedIndexChanged="cboBranch_SelectedIndexChanged">
                                                                        </dx:ASPxComboBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Warehouse Code:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtloccode" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Warehouse Name:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtlocname" OnTextChanged="txtlocname_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Print Name:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtprintname" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>Mobile:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="10" onkeyup="this.value = this.value.replace(/[^0-9]/g, '')" ID="txtmobile" runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Office Phone 1:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtpfficeph1" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Office Phone 2:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtpfficeph2" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Email:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtemail" runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>Address Line 1:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" TextMode="MultiLine" ID="txtadd1" runat="server" CssClass="form-control" TabIndex="9"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Address Line 2:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" TextMode="MultiLine" ID="txtadd2" runat="server" CssClass="form-control" TabIndex="9"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Address Line 3</label>
                                                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" TextMode="MultiLine" ID="txtadd3" runat="server" CssClass="form-control" TabIndex="9"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Pin Code:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" onkeyup="this.value = this.value.replace(/\D/g, '')" ID="txtpincode" runat="server" CssClass="form-control" TabIndex="12"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>Area Name:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtareaname" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>

                                                                        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel4" runat="server" ClientInstanceName="cbp" OnCallback="ASPxCallbackPanel1_Callback">
                                                                            <PanelCollection>
                                                                                <dx:PanelContent ID="PanelContent4" runat="server" SupportsDisabledAttribute="True">

                                                                                    <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" ClientInstanceName="lookup" CssClass="form-control" ForeColor="#666666" TabIndex="13"
                                                                                        DataSourceID="SqlDataSourcearea" KeyFieldName="areanm" AutoGenerateColumns="False" OnValueChanged="ASPxGridLookup1_ValueChanged"
                                                                                        TextFormatString="{0}" MultiTextSeparator=", " IncrementalFilteringMode="Contains">

                                                                                        <ClientSideEvents ValueChanged="function(s, e) {
								
								                                                        if (!!s.GetGridView().cpSelectedCountry)
									                                                        document.getElementById('txtcountryname').value = s.GetGridView().cpSelectedCountry;
                                                                                            document.getElementById('txtstatename').value = s.GetGridView().cpSelectedCountry1;
                                                                                            document.getElementById('txtcityname').value = s.GetGridView().cpSelectedCountry2;
                                                                                             document.getElementById('cbozone').value = s.GetGridView().cpSelectedzonenm2;
                                    
                                                                                             document.getElementById('txtregncode').focus();        }" />

                                                                                        <Columns>
                                                                                            <dx:GridViewCommandColumn VisibleIndex="0" ShowSelectCheckbox="True" ShowNewButtonInHeader="true">
                                                                                            </dx:GridViewCommandColumn>

                                                                                            <dx:GridViewDataTextColumn Caption="Area Name" FieldName="areanm" VisibleIndex="1">
                                                                                            </dx:GridViewDataTextColumn>

                                                                                        </Columns>
                                                                                        <GridViewProperties>

                                                                                            <Templates>

                                                                                                <StatusBar>
                                                                                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="false" Text="Add New" RenderMode="Link"
                                                                                                        ClientSideEvents-Click="function(s, e) {popuparea.Show();}" />
                                                                                                </StatusBar>
                                                                                            </Templates>
                                                                                            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                                                        </GridViewProperties>
                                                                                    </dx:ASPxGridLookup>


                                                                                </dx:PanelContent>
                                                                            </PanelCollection>
                                                                        </dx:ASPxCallbackPanel>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>City Name:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtcityname" ClientIDMode="Static" runat="server" CssClass="form-control" TabIndex="14"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>State Name:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ClientIDMode="Static" ID="txtstatename" runat="server" CssClass="form-control" TabIndex="15"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Zone:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ClientIDMode="Static" ID="cbozone" runat="server" CssClass="form-control" TabIndex="16"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>Country Name:<strong class="redmark">*</strong></label>
                                                                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ClientIDMode="Static" ID="txtcountryname" runat="server" CssClass="form-control" TabIndex="17"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                            <div class="col-md-3">
                                                                <label>Dc. No. Preffix:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtdcnopreffix" runat="server" CssClass="form-control" TabIndex="21"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Dc. No. Suffix:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtdcnosuffix" runat="server" CssClass="form-control" TabIndex="22"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Invoice. No. Preffix:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtinvoicenopreffix" runat="server" CssClass="form-control" TabIndex="23"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label>Invoice. No. Suffix:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="200" ID="txtinvoicenosuffix" runat="server" CssClass="form-control" TabIndex="24"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <label>Remarks:</label>
                                                                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox MaxLength="1000" ID="txtremarks" runat="server" TextMode="MultiLine" CssClass="form-control" TabIndex="26"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>

                                                        <table align="center">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="btnOverWrite" runat="server" class="btn" style="display:none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />
                                                                            <asp:Button ID="cmdsave" runat="server" class="btn" OnClick="CmdSubmit_Click" TabIndex="27" Text="Save" />
                                                                            <asp:Button ID="cmdclear" runat="server" class="btn" OnClick="CmdReset_Click" TabIndex="28" Text="Clear" />
                                                                            <br />
                                                                            <dx:ASPxLabel ID="lbmsg" runat="server" ForeColor="Red">
                                                                            </dx:ASPxLabel>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
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
                                                                                            <dx:ASPxButton ID="btnPdfExport" runat="server" Text="Export to PDF" UseSubmitBehavior="False" CssClass="listin" Theme="Default"
                                                                                                OnClick="btnPdfExport_Click" />
                                                                                        </td>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False" CssClass="listin" Theme="Default"
                                                                                                OnClick="btnXlsExport_Click" />
                                                                                        </td>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="Export to XLSX" UseSubmitBehavior="False" CssClass="listin" Theme="Default"
                                                                                                OnClick="btnXlsxExport_Click" />
                                                                                        </td>
                                                                                        <td style="padding-right: 4px">
                                                                                            <dx:ASPxButton ID="btnRtfExport" runat="server" Text="Export to RTF" UseSubmitBehavior="False" CssClass="listin" Theme="Default"
                                                                                                OnClick="btnRtfExport_Click" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxButton ID="btnCsvExport" runat="server" Text="Export to CSV" UseSubmitBehavior="False" CssClass="listin" Theme="Default"
                                                                                                OnClick="btnCsvExport_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <br />
                                                                                <br />
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true" SettingsBehavior-AllowGroup="true"
                                                                                    SettingsBehavior-AllowSort="true" ID="ASPxGridView1" DataSourceID="SqlDataSource1" KeyFieldName="SLNo" align="left"
                                                                                    CssClass="listin" Theme="Default" runat="server" EnablePagingCallbackAnimation="True" AutoGenerateColumns="False">
                                                                                    <Columns>
                                                                                        <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True"
                                                                                            VisibleIndex="10">
                                                                                        </dx:GridViewCommandColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Edit" ReadOnly="True" Width="50px"
                                                                                            VisibleIndex="11">
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" EnableViewState="false" runat="server"
                                                                                                    CommandArgument='<%# Eval("SLNo") %>'
                                                                                                    Text='Edit' OnCommand="CmdEdit_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Delete" Width="50px"
                                                                                            VisibleIndex="12">
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdDelete" EnableViewState="false" runat="server"
                                                                                                    CommandArgument='<%# Eval("SLNo") %>' OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                                                                    Text='Delete' OnCommand="CmdDelete_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="loccode" Caption="Warehouse Code" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="locnm" Caption="Warehouse Name" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printnm" Caption="Print Name" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="BranchNm" Caption="Branch Name" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="countrynm" Caption="Country Name" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="zonenm" Caption="Zone Name" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="statenm" Caption="State Name" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="citynm" Caption="City Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="areanm" Caption="Area Name" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="status" Caption="Status" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains"></Settings>
                                                                                        </dx:GridViewDataTextColumn>

                                                                                    </Columns>
                                                                                    <Settings ShowFilterRow="True" />
                                                                                    <Settings ShowFilterRow="True" />
                                                                                    <SettingsDataSecurity AllowDelete="False" />

                                                                                    <GroupSummary>
                                                                                        <dx:ASPxSummaryItem SummaryType="Count" />
                                                                                    </GroupSummary>

                                                                                    <TotalSummary>
                                                                                        <dx:ASPxSummaryItem FieldName="Size" SummaryType="Sum" />
                                                                                    </TotalSummary>

                                                                                    <SettingsBehavior EnableRowHotTrack="True"
                                                                                        ProcessFocusedRowChangedOnServer="True" />

                                                                                    <SettingsPager>
                                                                                        <PageSizeItemSettings Visible="true" Items="10, 20, 50, 100, 500" />
                                                                                    </SettingsPager>

                                                                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                                                    <Styles>
                                                                                        <RowHotTrack BackColor="#E9E9E9">
                                                                                        </RowHotTrack>
                                                                                    </Styles>
                                                                                </dx:ASPxGridView>

                                                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mycon %>"
                                                                                    SelectCommand="exec warehouseselect"></asp:SqlDataSource>

                                                                                <%--<asp:SqlDataSource ID="SqlDataSource9" runat="server"
                                                                                    ConnectionString="<%$ ConnectionStrings:mycon %>"
                                                                                    SelectCommand="exec userselect3"></asp:SqlDataSource>--%>

                                                                                <asp:SqlDataSource ID="SqlDataSourcearea" runat="server"
                                                                                    ConnectionString="<%$ ConnectionStrings:mycon %>"
                                                                                    SelectCommand="exec areaselect"></asp:SqlDataSource>
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

