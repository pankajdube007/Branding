<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddUpdateDispatchTeam.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.DispatchTeam.AddUpdateDispatchTeam" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../assets/css/dialog_box.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
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
     <style type="text/css">
        input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
    -webkit-appearance: none;
    margin: 0;
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

        function IsMobileNumber() {

            var number = document.getElementById('txtmobno').value


            if (/^\d{10}$/.test(number)) {
                // value is ok, use it
            } else {
                alert("Invalid number; must be ten digits")
                document.getElementById('txtmobno').value = "";
                number.focus()
                return false
            }
        }


        function validateEmail() {

            var emailField = document.getElementById('txtemail').value
            var reg = /^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$/;

            if (reg.test(emailField) == false) {
                alert('Invalid Email Address');
                document.getElementById('txtemail').value = "";
                return false;
            }

            return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="scrpt1" runat="server">
            </asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Dispatch Team</h2>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                        <ContentTemplate>
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel2" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                            </dx:ASPxGridViewExporter>
                            <asp:Label ID="lbslno" runat="server" Text="0" Visible="false"></asp:Label>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="1" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
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
                                                                                ValueField="SlNo" Width="500px" JS-Filter="True" CssClass="form-control js-filter-class" ValueType="System.String"
                                                                                TabIndex="1" SelectionMode="CheckColumn" Theme="Glass" Height="120px" Style="overflow: hidden; padding: 0 !important; margin: 0 !important;">
                                                                                <CaptionSettings Position="Top" />
                                                                              
                                                                            </dx:ASPxListBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            
                                                          

                                                            </div>
                                                        
                                                        <div class="row">
                                                               
                                                          <div class="col-md-4">
                                                                <label>Name:<strong class="redmark">*</strong></label>

                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtname" ClientIDMode="Static" MaxLength="50" onkeypress="return noNumbers(event)" runat="server" TabIndex="4" CssClass="form-control"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                            <div class="col-md-3">
                                                                <label>Mobile:<strong class="redmark">*</strong></label>

                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtmobno" ClientIDMode="Static" MaxLength="10" TextMode="Number"  onblur="return IsMobileNumber()" runat="server" TabIndex="4" CssClass="form-control"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                             <div class="col-md-3">
                                                                <label>Email:<strong class="redmark">*</strong></label>

                                                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtemail" ClientIDMode="Static" onblur="return validateEmail()" runat="server" TabIndex="5" CssClass="form-control"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                           
                                                        </div>

                                                     

                                                        <div class="row">
                                                           
                                                            
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <label>Username:<strong class="redmark">*</strong></label>

                                                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                    <ContentTemplate>
                                                                        <div style="display:flex;">
                                                                            <div style="padding-top:7px;padding-right:5px;">
                                                                                disp_
                                                                            </div>
                                                                            <div style="width:100%;">
                                                                                <asp:TextBox ID="txtUserName" ClientIDMode="Static" onkeypress="return noNumbers(event)" runat="server" TabIndex="6" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <label>Password:<strong class="redmark">*</strong></label>

                                                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtPassword" ClientIDMode="Static" runat="server" TabIndex="7" CssClass="form-control"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <label>Active Status:</label>

                                                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group">
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:CheckBox ID="chkstatus" runat="server"></asp:CheckBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                        </div>
                                                        

                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />
                                                                    <dx:ASPxButton ID="CmdSubmit" runat="server" ClientIDMode="Static" OnClick="CmdSubmit_Click" AutoPostBack="False"
                                                                        Text="Save" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                        OnCallback="ASPxCallback1_Callback">
                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                    </dx:ASPxCallback>
                                                                    <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                                                        Modal="true">
                                                                    </dx:ASPxLoadingPanel>
                                                                    <dx:ASPxButton ID="CmdReset" runat="server" Text="Clear" TabIndex="7" CssClass="btn btn-space"
                                                                        OnClick="CmdReset_Click">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
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
                                                                                    align="left" KeyFieldName="Slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Name" Caption="Name" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Email" Caption="Email" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="MobileNo" Caption="MobileNo" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                      
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Branch" Caption="Branch" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="ActiveStatus" Caption="Status" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True"
                                                                                                AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                      
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Edit" ReadOnly="True"
                                                                                            VisibleIndex="5">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" OnClientClick="lp.Show()" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("Slno") %>'
                                                                                                    Text='Edit' OnCommand="CmdEdit_Command"></asp:LinkButton>
                                                                                            </DataItemTemplate>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="Delete" ReadOnly="True"
                                                                                            VisibleIndex="6" Visible="false">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdDelete" EnableViewState="false" CausesValidation="False" runat="server" CommandArgument='<%# Eval("Slno") %>'
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