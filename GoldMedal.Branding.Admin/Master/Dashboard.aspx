<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

     <style>
        .fake-legend {
            height: 15px;
            width: 100%;
            border-bottom: solid 1px #333;
            text-align: center;
            margin-top: 20px;
            margin-bottom: 30px;
        }

            .fake-legend span {
                background: #fff;
                position: relative;
                font-weight: bold;
                top: 0;
                padding: 0 15px;
                /*margin-left:30px;*/
                line-height: 30px;
                color: #6d6d6d;
            }

        .centergrid {
            margin: 0 auto;
        }
    </style>
     <script type="text/javascript" src="../Scripts/ListBoxFilter.js"></script>
     <script type="text/javascript" src="../Scripts/ListBoxFilterUpdated.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Dashboard</h2>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lbslno" Visible="false" Text="0" runat="server"></asp:Label>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>

                            <dx:ASPxCallback ID="ASPxCallback" runat="server" ClientInstanceName="ASPxCallback1"
                                OnCallback="ASPxCallback_Callback">
                                <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                            </dx:ASPxCallback>

                            <div class="row">

                               
                                <div class="col-md-3">
                                    <label>Branch:<strong class="redmark">*</strong></label>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <dx:ASPxListBox ID="lbBranch" runat="server" TextField="locnm" ClientInstanceName="lbBranch" 
                                                ValueField="SlNo" Width="400px" JS-Filter="True" CssClass="form-control js-filter-class" ValueType="System.String"
                                                TabIndex="1" SelectionMode="CheckColumn" Theme="Glass" Height="120px" Style="overflow: hidden; padding: 0 !important; margin: 0 !important;">
                                                <CaptionSettings Position="Top" />
                                                 <%--<ClientSideEvents SelectedIndexChanged="function(s,e){
                                                                    if(e.index == 0 && e.isSelected == true)
                                                                    {
                                                                    lbBranch.SelectAll();
                                                                    }

                                                                    if(e.index == 0 && e.isSelected == false)
                                                                    {
                                                                    lbBranch.UnselectAll();
                                                                    }
                                            }" />--%>
                                            </dx:ASPxListBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>


                                <div class="col-md-2">
                                    <label>From Date:<strong class="redmark">*</strong></label>
                                    <dx:ASPxDateEdit ID="txtFromDate" EditFormat="Custom" EditFormatString="dd/MM/yyyy" runat="server" CssClass="form-control" TabIndex="1"></dx:ASPxDateEdit>
                                </div>
                                <div class="col-md-2">
                                    <label>To Date:<strong class="redmark">*</strong></label>
                                    <dx:ASPxDateEdit ID="txtToDate" EditFormat="Custom" EditFormatString="dd/MM/yyyy" runat="server" CssClass="form-control" TabIndex="1"></dx:ASPxDateEdit>
                                </div>

                                <div class="col-md-2">
                                    <div style="height: 15px;"></div>
                                    <dx:ASPxButton ID="btnSearch" runat="server" ClientIDMode="Static" OnClick="btnSearch_Click" AutoPostBack="False"
                                        Text="Search" CssClass="btn btn-success btn-space" ClientInstanceName="btnSearch" TabIndex="6">
                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                    </dx:ASPxButton>
                                </div>
                            </div>

                            <br />
                            <br />

                            <div class="row justify-content-center">
                                <div class="col-md-12">
                                    <div class="box">
                                        <div class="box-body table-responsive">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>

                                                    <p class="fake-legend" style="margin-top: 0px;"><span>Branchwise Jobs</span></p>

                                                    <div class="row" style="margin-bottom: 30px;">
                                                        <div class="col-md-12">
                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid1_DataBinding" Width="50%" CssClass="centergrid" CustomFieldSort="ASPxPivotGrid1_CustomFieldSort">
                                                                <Fields>

                                                                    <dx:PivotGridField ID="fieldBranchID" FieldName="branchid" Area="RowArea" Visible="False"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldBranchName" FieldName="BranchName" Area="RowArea" Caption="Branch Name"
                                                                        AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldTotal" FieldName="TktCount" Area="ColumnArea"
                                                                        AreaIndex="0" Options-AllowSortBySummary="False">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldsTotal" FieldName="jobs" Area="DataArea"
                                                                        AreaIndex="0" CellStyle-HorizontalAlign="Center">
                                                                    </dx:PivotGridField>

                                                                </Fields>
                                                                <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                                                <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                                                <OptionsPager RowsPerPage="10000" />
                                                            </dx:ASPxPivotGrid>
                                                        </div>
                                                    </div>

                                                    <p class="fake-legend" style="margin-top: 0px;"><span>Branchwise Pending Approved Jobs</span></p>
                                                    <div class="row" style="margin-bottom: 30px;">
                                                        <div class="col-md-12">

                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid2" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid2_DataBinding" Width="50%" CssClass="centergrid">
                                                                <Fields>

                                                                    <dx:PivotGridField ID="fieldBranchID1" FieldName="BranchID" Area="RowArea" Visible="False"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldBranchName1" FieldName="BranchName" Area="RowArea" Caption="Branch Name"
                                                                        AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldTotal1" FieldName="TktCount" Area="ColumnArea"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldsTotal1" FieldName="jobs" Area="DataArea"
                                                                        AreaIndex="0" CellStyle-HorizontalAlign="Center">
                                                                    </dx:PivotGridField>

                                                                </Fields>
                                                                <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                                                <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                                                <OptionsPager RowsPerPage="10000" />
                                                            </dx:ASPxPivotGrid>

                                                        </div>
                                                    </div>
                                                                          <p class="fake-legend" style="margin-top: 0px;"><span>Branchwise Live Product Management Approval Pending Jobs</span></p>
                                                    <div class="row" style="margin-bottom: 30px;">
                                                        <div class="col-md-12">

                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid7" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid7_DataBinding" Width="50%" CssClass="centergrid">
                                                                <Fields>

                                                                    <dx:PivotGridField ID="fieldBranchID7" FieldName="BranchID" Area="RowArea" Visible="False"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldBranchName7" FieldName="BranchName" Area="RowArea" Caption="Branch Name"
                                                                        AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldTotal7" FieldName="TktCount" Area="ColumnArea"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldsTotal7" FieldName="jobs" Area="DataArea"
                                                                        AreaIndex="0" CellStyle-HorizontalAlign="Center">
                                                                    </dx:PivotGridField>

                                                                </Fields>
                                                                <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                                                <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                                                <OptionsPager RowsPerPage="10000" />
                                                            </dx:ASPxPivotGrid>

                                                        </div>
                                                    </div>
                                                    
                                                  
                                                    <div class="row" style="margin-bottom:30px;">
                                                        <div class="col-md-10 col-md-offset-1">

                                                            <div class="row" >
                                                                <div class="col-md-6" runat="server" visible="false">

                                                                    <p class="fake-legend" style="margin-top: 0px;"><span>Designerwise Pending Jobs</span></p>

                                                                    <dx:ASPxPivotGrid ID="ASPxPivotGrid3" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                        OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                        Theme="Glass" OnDataBinding="ASPxPivotGrid3_DataBinding" Width="50%" CssClass="centergrid">
                                                                        <Fields>

                                                                            <dx:PivotGridField ID="fDesignerID" FieldName="DesignerID" Area="RowArea" Visible="False"
                                                                                AreaIndex="0">
                                                                            </dx:PivotGridField>

                                                                            <dx:PivotGridField ID="fDesignerName" FieldName="DesignerName" Area="RowArea" Caption="Designer Name"
                                                                                AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                            </dx:PivotGridField>

                                                                            <dx:PivotGridField ID="fTktCount" FieldName="TktCount" Area="ColumnArea"
                                                                                AreaIndex="0">
                                                                            </dx:PivotGridField>

                                                                            <dx:PivotGridField ID="fjobs" FieldName="Jobs" Area="DataArea"
                                                                                AreaIndex="0" CellStyle-HorizontalAlign="Center">
                                                                            </dx:PivotGridField>

                                                                        </Fields>
                                                                        <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                                                        <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                                                        <OptionsPager RowsPerPage="10000" />
                                                                    </dx:ASPxPivotGrid>
                                                                </div>
                                                                <div class="col-md-12">

                                                                    <p class="fake-legend" style="margin-top: 0px;"><span>Designerwise Approved Pending Jobs</span></p>

                                                                    <dx:ASPxPivotGrid ID="ASPxPivotGrid4" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                        OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                        Theme="Glass" OnDataBinding="ASPxPivotGrid4_DataBinding" Width="50%" CssClass="centergrid">
                                                                        <Fields>

                                                                            <dx:PivotGridField ID="fDesignerID2" FieldName="DesignerID" Area="RowArea" Visible="False"
                                                                                AreaIndex="0">
                                                                            </dx:PivotGridField>

                                                                            <dx:PivotGridField ID="fDesignerName2" FieldName="DesignerName" Area="RowArea" Caption="Designer Name"
                                                                                AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                            </dx:PivotGridField>

                                                                            <dx:PivotGridField ID="fTktCount2" FieldName="TktCount" Area="ColumnArea"
                                                                                AreaIndex="0">
                                                                            </dx:PivotGridField>

                                                                            <dx:PivotGridField ID="fjobs2" FieldName="Jobs" Area="DataArea"
                                                                                AreaIndex="0" CellStyle-HorizontalAlign="Center">
                                                                            </dx:PivotGridField>

                                                                        </Fields>
                                                                        <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                                                        <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                                                        <OptionsPager RowsPerPage="10000" />
                                                                    </dx:ASPxPivotGrid>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>


                                                     <div runat="server" id="divBranchwiseJobsCount" visible="false">

                                                     <p class="fake-legend" style="margin-top: 0px;"><span>Branchwise Jobs Count</span></p>
                                                    <div class="row" style="margin-bottom: 30px;">
                                                        <div class="col-md-12">

                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid5" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid5_DataBinding" Width="50%" CssClass="centergrid">
                                                                <Fields>

                                                                    <dx:PivotGridField ID="fieldBranchID5" FieldName="BranchID" Area="RowArea" Visible="False"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldBranchName5" FieldName="BranchName" Area="RowArea" Caption="Branch Name"
                                                                        AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldTotal5" FieldName="JobCount" Area="ColumnArea"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldsTotal5" FieldName="jobs" Area="DataArea"
                                                                        AreaIndex="0" CellStyle-HorizontalAlign="Center">
                                                                    </dx:PivotGridField>

                                                                </Fields>
                                                                <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                                                <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                                                <OptionsPager RowsPerPage="10000" />
                                                            </dx:ASPxPivotGrid>

                                                        </div>
                                                    </div>

                                                         </div>

                                                    <p class="fake-legend" style="margin-top: 0px;"><span>Designer Jobs Count</span></p>
                                                    <div class="row" style="margin-bottom: 30px;">
                                                        <div class="col-md-12">

                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid6" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"  
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid6_DataBinding" Width="50%" CssClass="centergrid">
                                                                <Fields>
                                                                    
                                                                    
                                                                    <dx:PivotGridField ID="fieldBranchID6"  FieldName="DesignerID" Area="RowArea" Visible="False"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldBranchName6" FieldName="DesignerName"  Area="RowArea"
                                                                        AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                       
                                                                     </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldTotal6" FieldName="JobCount" Area="ColumnArea" 
                                                                        AreaIndex="2">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldsTotal6" FieldName="Jobs" Area="DataArea"
                                                                        AreaIndex="3" CellStyle-HorizontalAlign="Center">
                                                                    </dx:PivotGridField>

                                                                </Fields>
                                                                <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                                                <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                                                <OptionsPager RowsPerPage="10000" />
                                                            </dx:ASPxPivotGrid>

                                                        </div>
                                                    </div>
                                                     <p class="fake-legend" style="margin-top: 0px;"></p>


                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>



                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>