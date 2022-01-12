<%@ Page Title="Help Desk" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Helpdesk.aspx.cs" Inherits="GoldMedal.Branding.Admin.Master.Helpdesk" %>

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

    <div class="wrapper row-offcanvas row-offcanvas-left">
        <div class="content">
            <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center;">Help Desk</h2>
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

                            <br />
                            <br />

                            <div class="row justify-content-center">
                                <div class="col-md-12">
                                    <div class="box">
                                        <div class="box-body table-responsive">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>

                                                    <p class="fake-legend" style="margin-top: 0px;"><span>Branding Users</span></p>

                                                    <div class="row" style="margin-bottom: 30px;">
                                                        <div class="col-md-12">
                                                            <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView1"
                                                                align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView1_DataBinding"
                                                                AutoGenerateColumns="False">
                                                                <Columns>

                                                                    <dx:GridViewDataTextColumn Width="180px" Settings-AllowDragDrop="True" FieldName="ContactPerson" Caption="Contact Person" VisibleIndex="1">
                                                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>

                                                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Branch" Caption="BranchName" VisibleIndex="1">
                                                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>

                                                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="WorkDescriptipn" Caption="Work Descriptipn" VisibleIndex="1">
                                                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="MobileNo" Caption="Mobile No." VisibleIndex="1">
                                                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="LandlineNo" Caption="Landline No." VisibleIndex="1">
                                                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Email" Caption="Email ID" VisibleIndex="1">
                                                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>

                                                                   <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Department" Caption="Department Name" VisibleIndex="1">
                                                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>

                                                                    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Designation" Caption="Designation Name" VisibleIndex="1">
                                                                        <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                    </dx:GridViewDataTextColumn>--%>

                                                                </Columns>
                                                                <Settings ShowFilterRow="True" />

                                                                <GroupSummary>
                                                                    <dx:ASPxSummaryItem SummaryType="Count" />
                                                                </GroupSummary>

                                                                <SettingsBehavior EnableRowHotTrack="True" ProcessFocusedRowChangedOnServer="True" />
                                                                <SettingsPager>
                                                                    <PageSizeItemSettings Visible="true" Items="10, 20, 50, 100" />
                                                                </SettingsPager>
                                                                <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                                                <Styles>
                                                                    <RowHotTrack BackColor="#E9E9E9">
                                                                    </RowHotTrack>
                                                                </Styles>
                                                            </dx:ASPxGridView>
                                                        </div>
                                                    </div>

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