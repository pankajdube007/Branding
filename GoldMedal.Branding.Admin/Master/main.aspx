<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.main" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="col-md-12" width="100%">
        <br />
        <br />
        <br />

        <br />

       
        <br />
            <br />
            <br />
            <br />
            <br />
        <p style="color: darkred; font-family: Verdana; font-size: 25pt">Kindly note that branding will be done only for those Retailers who are approved and their current status is active in dhanbarse.</p>
        <br />
             <br />
            <br />
            <p style="color: darkred; font-family: Verdana; font-size: 25pt">Branding pending for more than 15 days due to unapproved retailer in dhanbarse will be  automatically disapproved.</p>
    </div>

       <div runat="server" id="divBranchwiseJobsCount" visible="false" >

                                                    
                                                    <div class="row" style="margin-bottom: 30px;">
                                                        <div class="col-md-6 col-md-offset-3">
                                                             <p class="fake-legend" style="margin-top: 0px;"><span>Branchwise Jobs Count</span></p>
                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid5" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid5_DataBinding" Width="100%" CssClass="centergrid">
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


     <div runat="server" id="divdispatchdashboard" visible="false" >

                                                    
                                                    <div class="row" style="margin-bottom: 30px;">
                                                        <div class="col-md-6 col-md-offset-3">
                                                             <p class="fake-legend" style="margin-top: 0px;"><span>Branchwise Dispatch Jobs Count</span></p>
                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid1_DataBinding" Width="100%" CssClass="centergrid">
                                                                <Fields>

                                                                    <dx:PivotGridField ID="fieldBranchID" FieldName="BranchID" Area="RowArea" Visible="False"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldBranchName" FieldName="BranchName" Area="RowArea" Caption="Branch Name"
                                                                        AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldTotal" FieldName="JobCount" Area="ColumnArea"
                                                                        AreaIndex="0">
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

                                                         </div>
</asp:Content>