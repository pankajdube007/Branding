<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Designerbranchwisejobscount.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.Designerbranchwisejobscount" %>

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

        <br />
    </div>

       <div runat="server" style="text-align:center" >
          
                                                    
                                                    <div class="row" style="margin-bottom: 30px;" runat="server" id="Grid5" visible="false">
                                                        <div class="col-md-6 col-md-offset-3">

                                  <div class="col-md-3">
                                    <label>Designer Name:</label>
                                    <asp:Label ID="lblDesignerName" runat="server" />
                                </div>
                                  <br />
                                   <br />

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


                                                    <div class="row" style="margin-bottom: 30px;" runat="server" id="Grid1" visible="false">
                                                        <div class="col-md-6 col-md-offset-3">

                                  <div class="col-md-3">
                                    <label>Branch Name:</label>
                                    <asp:Label ID="lblbranchname" runat="server" />
                                </div>
                                  <br />
                                   <br />

                                                             <p class="fake-legend" style="margin-top: 0px;"><span>Designerwise Jobs Count</span></p>
                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid1_DataBinding" Width="100%" CssClass="centergrid">
                                                                <Fields>

                                                                     <dx:PivotGridField ID="fieldBranchID1"  FieldName="DesignerID" Area="RowArea" Visible="False"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldBranchName1" FieldName="DesignerName"  Area="RowArea"
                                                                        AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                       
                                                                     </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldTotal1" FieldName="JobCount" Area="ColumnArea" 
                                                                        AreaIndex="2">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldsTotal1" FieldName="Jobs" Area="DataArea"
                                                                        AreaIndex="3" CellStyle-HorizontalAlign="Center">
                                                                    </dx:PivotGridField>

                                                                </Fields>
                                                                <OptionsView ShowColumnHeaders="False" ShowDataHeaders="False" ShowFilterHeaders="False" />
                                                                <%--   <OptionsData DataFieldUnboundExpressionMode="UseSummaryValues" />--%>
                                                                <OptionsPager RowsPerPage="10000" />
                                                            </dx:ASPxPivotGrid>

                                                        </div>
                                                    </div>


            <div class="row" style="margin-bottom: 30px;" runat="server" id="Grid2" visible="false">
                                                        <div class="col-md-6 col-md-offset-3">

                                  <div class="col-md-3">
                                    <label>Branch Name:</label>
                                    <asp:Label ID="lblbranchname1" runat="server" />
                                </div>
                                  <br />
                                   <br />

                                                             <p class="fake-legend" style="margin-top: 0px;"><span>Branchwise Pending Approved Jobs Count</span></p>
                                                            <dx:ASPxPivotGrid ID="ASPxPivotGrid2" runat="server" ClientIDMode="AutoID" OptionsView-ShowRowGrandTotalHeader="True"
                                                                OptionsView-ShowColumnGrandTotals="False" OptionsView-ShowRowGrandTotals="True"
                                                                Theme="Glass" OnDataBinding="ASPxPivotGrid2_DataBinding" Width="100%" CssClass="centergrid">
                                                                <Fields>

                                                                     <dx:PivotGridField ID="fieldBranchID2"  FieldName="DesignerID" Area="RowArea" Visible="False"
                                                                        AreaIndex="0">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldBranchName2" FieldName="DesignerName"  Area="RowArea"
                                                                        AreaIndex="1" Options-AllowSort="False" Options-AllowFilter="False">
                                                                       
                                                                     </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldTotal2" FieldName="JobCount" Area="ColumnArea" 
                                                                        AreaIndex="2">
                                                                    </dx:PivotGridField>

                                                                    <dx:PivotGridField ID="fieldsTotal2" FieldName="Jobs" Area="DataArea"
                                                                        AreaIndex="3" CellStyle-HorizontalAlign="Center">
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