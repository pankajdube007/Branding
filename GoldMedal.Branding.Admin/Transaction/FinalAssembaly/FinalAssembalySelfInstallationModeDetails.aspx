<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="FinalAssembalySelfInstallationModeDetails.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.FinalAssembaly.FinalAssembalySelfInstallationModeDetails" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
                    <h2 style="text-align: center;">Final Assembaly Self Installation Mode Details</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
                    </dx:ASPxGridViewExporter>
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblchildid" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lbldesignsubmitsslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblprinterid" Visible="false" Text="0" runat="server"></asp:Label>
                     <asp:Label ID="lblPrintLocationID" Visible="false" Text="0" runat="server"></asp:Label>
                     <asp:Label ID="lblFabLocationID" Visible="false" Text="0" runat="server"></asp:Label>

                    <asp:Label ID="lbmultipleslno" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblqty" Visible="false" Text="0" runat="server"></asp:Label>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                             <asp:HiddenField ID="hfJobRequestNo" runat="server" Value="0" />
                             <asp:HiddenField ID="hfDesignSubmitID" runat="server" Value="0" />

                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="1" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                                 
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="Job Details">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl2" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">

                                                                            <ContentTemplate>
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                                    AutoGenerateColumns="False">
                                                                                    <Columns>

                                                                                        <%--<dx:GridViewCommandColumn ShowSelectCheckbox="true"   Width="100px" SelectAllCheckboxMode="AllPages" VisibleIndex="1"></dx:GridViewCommandColumn>--%>

                                                                                        
                                                                            <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" Caption="Send" ReadOnly="True" VisibleIndex="0" Width="100px">
                                                                                <Settings AllowDragDrop="True" />
                                                                                <DataItemTemplate>
                                                                                    <dx:ASPxCheckBox runat="server" ID="gvCheck" Theme="Moderno"></dx:ASPxCheckBox>
                                                                                </DataItemTemplate>
                                                                            </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No." VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                       <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="BranchName" Caption="Branch" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="3">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="name" Caption="Dealer Name" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="250px" FieldName="address" Caption="Address" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subname" Caption="Retailer" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Qty" Caption="Total Qty" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Qty" Caption="Sending Qty" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                          <%--<dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Qty" Caption="Sending Qty" VisibleIndex="13">
                                                                                           <DataItemTemplate>
                                                                                          <dx:ASPxTextBox ID="txtsendingqty" runat="server" Text='<%# Eval("Qty") %>' Width="100%">
                                                                                          </dx:ASPxTextBox>
                                                                                           </DataItemTemplate>
                                                                                           </dx:GridViewDataTextColumn>--%>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="FinalAssemblySubmittedDate" Caption="Final Assembly Submitted Date" VisibleIndex="11">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="ModeofdispatchUpdatedon" Caption="Dispatch Mode Update Date" VisibleIndex="12">
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

                                                             <div class="sec-btn" style="float:right;">
                                        <div class="row justify-content-end">

                                            <div class="col-md-12">
                                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                    <ContentTemplate>
                                                        <div style="float: left;">
                                                            <dx:ASPxButton ID="btnSend" AutoPostBack="true" runat="server" CssClass="btn btn-outline-cyan" OnClick="btnSend_Click" Text="Send" TabIndex="4">
                                                                <ClientSideEvents Click="function(s,e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                            </dx:ASPxButton>
                                                        </div>

                                                    </ContentTemplate>
                                                    <Triggers>
                                                         <asp:PostBackTrigger ControlID="btnSend" />
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
                                   

                                 

                                </TabPages>
                            </dx:ASPxPageControl>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

   
     <div>



          <asp:Button ID="btnShowPopup3" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeImage3" runat="server" TargetControlID="btnShowPopup3" PopupControlID="pnlpopup3"
            CancelControlID="btnShowPopup3" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopup3" runat="server" BackColor="White" Height="600px" Width="1050px" Style="display: none">
            <div class="row">
                <br />
                <br />
                <br />
                <div class="col-lg-12">
                    <div class="box" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel38" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                          

                                 <div class="row" style="padding-left:10px;padding-right:20px">
                                                          <div class="cls-sub-topic">
                                                               <i aria-hidden="true" class="fa fa-tasks"></i>
                                                               <h2>Transport Details</h2>
                                                          </div>
                                                     </div>


                                                    <div class="row" style="padding-left:10px;padding-right:20px">

                                                            <div class="col-md-3">
                                                                 <label>Transport Mode:<strong class="redmark">*</strong></label> 
                                                                 
                                                                         <dx:ASPxComboBox ID="cmbTransportMode" runat="server" ValueType="System.String" TextFormatString="{0}-{1}" 
                                                                             IsTextEditable="false" TabIndex="1" CssClass="form-control">
                                                                                <Items>
                                                                                    <dx:ListEditItem Text="Select" Value="0" Selected="True" />
                                                                                    <dx:ListEditItem Text="Transport" Value="Transport" />
                                                                                    <dx:ListEditItem Text="Local Mode" Value="Local Mode" />
                                                                                    <dx:ListEditItem Text="Courier" Value="Courier"/>
                                                                                    <dx:ListEditItem Text="Hand Delivery" Value="Hand Delivery"/>
                                                                                </Items>
                                                                             <%--   <ClientSideEvents SelectedIndexChanged="function(s,e){lp.Show();}" />--%>
                                                                         </dx:ASPxComboBox>
                                                                                
                                                            </div>

                                                             <div class="col-md-3">
                                                                 <label>Transpoter Name:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtTranspoterName" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="2"></asp:TextBox>                
                                                            </div>

                                                            <div class="col-md-3">
                                                                 <label>Invoice Number:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtInvoiceNumber" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="3"></asp:TextBox>                
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <label>Invoice Date:<strong class="redmark">*</strong></label>   
                                                                 <dx:ASPxDateEdit ID="txtInvoiceDate" EditFormat="Custom" EditFormatString="dd/MM/yyyy" runat="server" 
                                                                     CssClass="form-control" TabIndex="4"></dx:ASPxDateEdit>             
                                                            </div>

                                                             <div class="col-md-3">
                                                                 <label>LR Number:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtLRNumber" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="5"></asp:TextBox>                
                                                            </div>
                                                            <div class="col-md-3">
                                                                 <label>LR Date:<strong class="redmark">*</strong></label>   
                                                                 <dx:ASPxDateEdit ID="txtLRDate" runat="server" EditFormat="Custom" EditFormatString="dd/MM/yyyy" 
                                                                     CssClass="form-control" TabIndex="6"></dx:ASPxDateEdit>             
                                                            </div>
                                                        <div class="col-md-3">
                                                                 <label>No. Of Packages:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtpkges" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="5"></asp:TextBox>                
                                                            </div>
                                                         <div class="col-md-3">
                                                                 <label>No. Of Boards:<strong class="redmark">*</strong></label>   
                                                                 <asp:TextBox ID="txtnoofboards" ReadOnly="true" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="5"></asp:TextBox>                
                                                            </div>
                                                        <div class="col-md-3">
                                                                 <label>Remark:<strong class="redmark"></strong></label>   
                                                                 <asp:TextBox ID="txtremark" runat="server"  ClientIDMode="Static" CssClass="form-control"  TabIndex="5"></asp:TextBox>                
                                                            </div>
                                                           
                                                        </div>


                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left:10px;padding-right:20px;">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />

                                                                    <dx:ASPxButton ID="btnApprove" runat="server" ClientIDMode="Static" OnClick="btnApprove_Click" AutoPostBack="False"
                                                                        Text="Send" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                        OnCallback="ASPxCallback1_Callback">
                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                    </dx:ASPxCallback>

                                                                    <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn " TabIndex="8"
                                                                        OnClick="btnCancel_Click">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxLabel ID="lbmsg" runat="server" ForeColor="Red">
                                                                    </dx:ASPxLabel>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnApprove" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>



                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <!-- /.box -->
                </div>
            </div>
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-lg-12">
                 <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row" align="center">
                            <asp:Button ID="btnCloseMPE3" runat="server" Visible="false" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCloseMPE3" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>

    </div>
</asp:Content>

