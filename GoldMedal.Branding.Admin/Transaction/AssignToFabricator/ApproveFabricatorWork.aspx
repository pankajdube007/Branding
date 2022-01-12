<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ApproveFabricatorWork.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.AssignToFabricator.ApproveFabricatorWork" %>

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
                    <h2 style="text-align: center;">Approve Fabricator's Job</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHead">
                    </dx:ASPxGridViewExporter>

                     <asp:Label ID="lblHeadID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblChildID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblDesignSubmitID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblPrinterAssignID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblFabricatorAssignID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblFinalAssemblyID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblPrinterID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:Label ID="lblFabricatorID" Visible="false" Text="0" runat="server"></asp:Label>
                            <asp:HiddenField ID="hfPopupImageFlag" Value="0" runat="server" />
                      <asp:Label ID="lblPrintLocationID" Visible="false" Text="0" runat="server"></asp:Label>
                    <asp:Label ID="lblFabLocationID" Visible="false" Text="0" runat="server"></asp:Label>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp"
                                Modal="true">
                            </dx:ASPxLoadingPanel>
                            <dx:ASPxPageControl EnableHierarchyRecreation="False" ID="ASPxPageControl1" runat="server"
                                ActiveTabIndex="1" CssClass="tabsB" EnableTheming="True" Theme="Default" OnTabClick="ASPxPageControl1_TabClick">
                                <ClientSideEvents TabClick="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                <TabPages>
                                    <%--.Start of Tab-1--%>
                                    <dx:TabPage Text="View">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl1" runat="server">
                                                <div class="row ">
                                                    <%--FORM FIELDS  --%>
                                                    <div class="col-md-12">
                                                        <div id="head">
                                                             <div id="jobreqdetails">
                                                     <div class="row">
                                                    <div class="cls-sub-topic">
                                                        <i class="fa fa-tasks" aria-hidden="true"></i>
                                                        <h2>Job Request Head Details</h2>
                                                    </div>
                                                </div>
                                                      <br />
                                                   
                                                     <div class="row">
                                                     <div class="col-md-3">
                                                        <label>Job Request No:</label>
                                                        <div>
                                                             <asp:Label ID="LblRequestNo" Text="" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Branch Name:</label>
                                                        <div>
                                                             <asp:Label ID="lblBranch" Text="" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                            <label>Date:</label>
                                                            <div>
                                                                <asp:Label ID="lblDate" Text="" runat="server" />
                                                            </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Name Type:</label>
                                                        <div>
                                                             <asp:Label ID="lblNameType" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div class="row">
                                                    <div class="col-md-3">
                                                        <label>Given By:</label>
                                                        <div>
                                                            <asp:Label ID="lblGivenBy" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                       <label>Visiting Card</label>
                                                        <div>
                                                           <asp:LinkButton ID="lbVisitingCard" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View" OnClick="lnkFiles1_Click"></asp:LinkButton>
                                                       </div>
                                                   </div>
                                                    <div class="col-md-3">
                                                       <label>Refer Sheet</label>
                                                        <div>
                                                           <asp:LinkButton ID="lbRefersheet" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View" OnClick="lnkFiles2_Click"></asp:LinkButton>
                                                       </div>
                                                   </div>
                                                    <div class="col-md-3">
                                                        <label>Submitted By:</label>
                                                        <div>
                                                            <asp:Label ID="lblSubmittedBy" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div class="row">
                                                     <div class="col-md-3">
                                                        <label>Approved By:</label>
                                                        <div>
                                                            <asp:Label ID="lblApprovedBy" runat="server" />
                                                        </div>
                                                    </div> 
                                                     <div class="col-md-3">
                                                        <label>Job Status:</label>
                                                        <div>
                                                            <asp:Label ID="lblJobStatus" runat="server" style="background-color:lightgreen;padding:2px;" />
                                                        </div>
                                                    </div>  
                                                </div>
                                                </div>
                                                <br />
                                               
                                                <div id="dealerdetails">

                                                     <div class="row">
                                                    <div class="cls-sub-topic">
                                                        <i class="fa fa-tasks" aria-hidden="true"></i>
                                                        <h2>Dealer Details</h2>
                                                    </div>
                                                </div>
                                                     <br>
                                                     <div class="row">
                                                     <div class="col-md-3">
                                                        <label>Name:</label>
                                                        <div>
                                                           <asp:Label ID="lblName" runat="server" />
                                                        </div>
                                                       
                                                    </div>
                                                     <div class="col-md-3">
                                                        <label> Contact Person:</label>
                                                        <div>
                                                           <asp:Label ID="lblContactPerson" runat="server" />
                                                        </div>
                                                       
                                                    </div>
                                                     <div class="col-md-3">
                                                        <label>Address:</label>
                                                        <div>
                                                              <asp:Label ID="lblAddress" runat="server" />
                                                        </div>
                                                    </div>
                                                     <div class="col-md-3">
                                                        <label> Contact No:</label>
                                                        <div>
                                                          <asp:Label ID="lblContactNo" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div class="row">
                                                     <div class="col-md-3">
                                                        <label>Email:</label>
                                                        <div>
                                                           <asp:Label ID="lblEmail" runat="server" />
                                                        </div>
                                                    </div>
                                                     <div class="col-md-3">
                                                        <label>CIN Number:</label>
                                                        <div>
                                                            <asp:Label ID="lblCinNo" runat="server" />
                                                        </div>
                                                    </div>
                                                     <div class="col-md-3">
                                                        <label>GST:</label>
                                                        <div>
                                                            <asp:Label ID="lblGST" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                                <br />
                                              
                                                <div id="retailerdetails" runat="server" style="display:none;">
                                                     <div class="row">
                                                    <div class="cls-sub-topic">
                                                        <i aria-hidden="true" class="fa fa-tasks"></i>
                                                        <h2>Retailer Details</h2>
                                                    </div>
                                                </div>
                                                     <br>
                                                     <div class="row">
                                                        <div class="col-md-3">
                                                            <label>Firm Name:</label>
                                                            <div>
                                                                <asp:Label ID="lblFirmName" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Name:</label>
                                                            <div>
                                                                <asp:Label ID="lblSubName" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Address:</label>
                                                            <div>
                                                               <asp:Label ID="lblSubAddress" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Contact No:</label>
                                                            <div>
                                                                <asp:Label ID="lblSubContact" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                     <br />
                                                     <div class="row">
                                                     <div class="col-md-3">
                                                        <label>Email ID:</label>
                                                        <div>
                                                            <asp:Label ID="lblSubEmail" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                                <br />
                                               
                                                <div id="jobdetails">
                                                     <div class="row">
                                                    <div class="cls-sub-topic">
                                                        <i aria-hidden="true" class="fa fa-tasks"></i>
                                                        <h2>Job Request Child Details</h2>
                                                    </div>
                                                </div>
                                                     <br>
                                                     <div class="row">
                                                    <div class="col-md-3">
                                                        <label>Dimension:</label>
                                                        <div>
                                                            <asp:Label ID="lblDimension" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Quantity:</label>
                                                        <div>
                                                            <asp:Label ID="lblQty" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Job type:</label>
                                                        <div>
                                                            <asp:Label ID="lblJobtype" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Sub Job type:</label>
                                                        <div>
                                                            <asp:Label ID="lblSubJobtype" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div class="row">
                                                           <div class="col-md-3">
                                                            <label>Materials used by printer:</label>
                                                            <div>
                                                                <asp:Label ID="lblSubSubJobtype" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Fabrication Material:</label>
                                                            <div>
                                                                <asp:Label ID="lblDesignType" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Product Type:</label>
                                                            <div>
                                                                <asp:Label ID="lblProductType" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Board Type:</label>
                                                            <div>
                                                                <asp:Label ID="lblBoardType" runat="server" />
                                                            </div>
                                                        </div>
                                                     </div>
                                                     <br />
                                                     <div class="row">
                                                           <div class="col-md-3">
                                                            <label>Printer Location:</label>
                                                            <div>
                                                                <asp:Label ID="lblPrinterLocation" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Fabricator Location:</label>
                                                            <div>
                                                                <asp:Label ID="lblFabricatorLocation" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Priority:</label>
                                                            <div>
                                                                <asp:Label ID="lblPriority" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Install Address:</label>
                                                            <div>
                                                                <asp:Label ID="lblInstallAddress" runat="server" />
                                                            </div>
                                                        </div>
                                                     </div>
                                                     <br />
                                                     <div class="row">
                                                           <div class="col-md-3">
                                                            <label>Is Party Approval:</label>
                                                            <div>
                                                                <asp:Label ID="lblIsPartyApproval" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div id="partyapprovedetails" runat="server" style="display:none;"> 
                                                             <div class="col-md-3">
                                                                <label>Party Approval To:</label>
                                                                <div>
                                                                    <asp:Label ID="lblPartyApprovalTo" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label>Approval Email ID:</label>
                                                                <div>
                                                                    <asp:Label ID="lblApprovalEmailID" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                   
                                                        <div class="col-md-3">
                                                            <label>Is Place Size:</label>
                                                            <div>
                                                                <asp:Label ID="lblIsPlaceSize" runat="server" />
                                                            </div>
                                                        </div>

                                                   
                                                     </div>
                                                     <br />
                                                     <div class="row">
                                                         <div class="col-md-3">
                                                            <label>Requested Image:</label>
                                                            <div>
                                                                <asp:LinkButton ID="lbJobImage" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Image" OnClick="lnkFiles3_Click"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                          <div class="col-md-3">
                                                            <label>Requested Link:</label>
                                                            <div>
                                                                <asp:HyperLink ID="JobImgLink" style="word-break:break-all;" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>CDR File:</label>
                                                            <div>
                                                                <asp:LinkButton ID="lbCDRFile" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View File" OnClick="lnkFiles4_Click"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Other Job Requested Image:</label>
                                                            <div>
                                                                <asp:LinkButton ID="lbOtherJobImage" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Images" OnClick="lnkFiles12_Click"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                   
                                                         </div>
                                                     <br />
                                                     <div class="row">
                                                         <div class="col-md-3">
                                                            <label>Job Remark:</label>
                                                            <div>
                                                                <asp:Label ID="lblJobRemark" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Approve Remark:</label>
                                                            <div>
                                                                <asp:Label ID="lblApproveRemark" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <label>Assign Remark:</label>
                                                            <div>
                                                                <asp:Label ID="lblAssignRemark" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                               
                                                <div id="designdetails" runat="server" style="display:none;">
                                                     <div class="row">
                                                    <div class="cls-sub-topic">
                                                        <i aria-hidden="true" class="fa fa-tasks"></i>
                                                        <h2>Design Task Details</h2>
                                                    </div>
                                                </div>
                                                     <br /> 
                                                     <div class="row">

                                                    <div class="col-md-3">
                                                        <label>Designer Name:</label>
                                                        <div>
                                                            <asp:Label ID="lblDesignerName" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Submitted Product Type:</label>
                                                        <div>
                                                            <asp:Label ID="lblNewProductType" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Total Amount:</label>
                                                        <div>
                                                            <asp:Label ID="lbltotalamount" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div class="row">
                                                     <div class="col-md-3">
                                                        <label>Submitted Design:</label>
                                                        <div>
                                                            <asp:LinkButton ID="lbDesignImage" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Image" OnClick="lnkFiles5_Click"></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Submitted Design Link:</label>
                                                        <div>
                                                            <asp:HyperLink ID="Designlink" style="word-break:break-all;" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label>Print File:</label>
                                                        <div>
                                                            <asp:LinkButton ID="lbPrintImage" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Image" OnClick="lnkFiles6_Click"></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label>Print File Link:</label>
                                                        <div>
                                                            <asp:HyperLink ID="PrintLink" style="word-break:break-all;" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div class="row">
                                                     <div class="col-md-6">
                                                        <label>Size Details:</label>
                                                        <asp:GridView runat="server" ID="gvSizeChild" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                            <Columns>
                                                                <asp:BoundField DataField="BoardHeight" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="BoardHeight" />
                                                                <asp:BoundField DataField="BoardWidth" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="BoardWidth" />
                                                                <asp:BoundField DataField="PrintHeight" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="PrintHeight" />
                                                                <asp:BoundField DataField="PrintWidth" ItemStyle-Width="140px" DataFormatString="{0:n}" HeaderText="PrintWidth" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                     <div class="col-md-6">
                                                        <label>Item Details:</label>
                                                        <asp:GridView runat="server" ID="gvSchemeChild" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="SrNo." ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:BoundField DataField="Item" ItemStyle-Width="250px" HeaderText="Item" HeaderStyle-HorizontalAlign="Center"/>
                                                                        <asp:BoundField DataField="MRP" ItemStyle-Width="100px" HeaderText="MRP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                                                                        <asp:BoundField DataField="Discount" ItemStyle-Width="100px" HeaderText="Discount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                                                                        <asp:BoundField DataField="Qty" ItemStyle-Width="50px" HeaderText="Qty" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                                                                        <asp:BoundField DataField="Amount" ItemStyle-Width="140px" HeaderText="Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                                                                    </Columns>
                                                                </asp:GridView>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div class="row">
                                                    <div class="col-md-3">
                                                         <label>Designer Remark:</label>
                                                         <div>
                                                              <asp:Label ID="lblDesignRemark" runat="server" />
                                                         </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                         <label>Designer Approve Remark:</label>
                                                         <div>
                                                              <asp:Label ID="lblDesignApproveRemark" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div id="liveproductdetails" runat="server" style="display:none;">
                                                          <div class="row">
                                                    <div class="cls-sub-topic">
                                                        <i class="fa fa-tasks" aria-hidden="true"></i>
                                                        <h2>Live Product Approval Details</h2>
                                                    </div>
                                                </div>
                                                          <br>
                                                          <div class="row">
                                                     <div class="col-md-3">
                                                             <label>Approval Given By:</label>
                                                             <div>
                                                                  <asp:Label ID="lblApprovalGivenBy" runat="server" />
                                                             </div>
                                                        </div>
                                                     <div class="col-md-3">
                                                             <label>Management Remark:</label>
                                                             <div>
                                                                  <asp:Label ID="lblManagementRemark" runat="server" />
                                                             </div>
                                                        </div>
                                                     <div class="col-md-3">
                                                            <label>Live Product Image:</label>
                                                            <div>
                                                                <asp:LinkButton ID="lbLiveProductImg" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Image" OnClick="lnkFiles7_Click"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                 </div>
                                                          <br />
                                                     </div>
                                                     
                                                     <div id="partyapprovaldetails" runat="server" style="display:none;">
                                                          <div class="row">
                                                     <div class="col-md-3">
                                                             <label>Party Email ID:</label>
                                                             <div>
                                                                  <asp:Label ID="lblPartyEmail" runat="server" />
                                                             </div>
                                                        </div>
                                                     <div class="col-md-3">
                                                             <label>Is Mail Sent:</label>
                                                             <div>
                                                                  <asp:Label ID="lblIsMailSent" runat="server" />
                                                             </div>
                                                        </div>
                                                      <div class="col-md-3">
                                                             <label>Is Approved By Party:</label>
                                                             <div>
                                                                  <asp:Label ID="lblIsApprovedByParty" runat="server" />
                                                             </div>
                                                        </div>
                                                     <div class="col-md-3">
                                                            <label>Image uploaded by Party:</label>
                                                            <div>
                                                                <asp:LinkButton ID="lbPartyImage" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Image" OnClick="lnkFiles8_Click"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                 </div>
                                                          <br />
                                                          <div class="row">
                                                      <div class="col-md-3">
                                                             <label>Is Final Party Approved:</label>
                                                             <div>
                                                                  <asp:Label ID="lblIsFinalPartyApproved" runat="server" />
                                                             </div>
                                                        </div>

                                                       <div class="col-md-3">
                                                             <label>Party Remark:</label>
                                                             <div>
                                                                  <asp:Label ID="lblPartyRemark" runat="server" />
                                                             </div>
                                                        </div>
                                                 </div>
                                                         <br />
                                                     </div>
                                               </div>
                                               <br />
                                              
                                                <div id="jobsenddetails" runat="server" style="display:none;">
                                                     <div class="row">
                                                    <div class="cls-sub-topic">
                                                        <i aria-hidden="true" class="fa fa-tasks"></i>
                                                        <h2>Job Send Details</h2>
                                                    </div>
                                                </div>
                                                     <br />
                                                     <div class="row">
                                                      <div class="col-md-3">
                                                                <label>Printers Job Send To:</label>
                                                                <div>
                                                                     <asp:Label ID="lblJobSendTo" runat="server" />
                                                                </div>
                                                               
                                                            </div>
                                                      <div class="col-md-3" id="ddlsendto" runat="server" style="display:none;">
                                                                <label>Job Send To Name:</label>
                                                                 <div>
                                                                     <asp:Label ID="lblSendToName" runat="server" />
                                                                 </div>
                                                                
                                                            </div>
                                                      <div class="col-md-3" id="othername" runat="server" style="display:none;">
                                                                 <label>Other:</label>   
                                                                 <div>
                                                                     <asp:Label ID="lblSendToOtherName" runat="server" />
                                                                 </div>
                                                                 
                                                            </div>
                                                      <div class="col-md-4" id="address" runat="server" style="display:none;">
                                                                 <label>Address:</label>  
                                                               <div>
                                                                   <asp:Label ID="lblSendToAddress" runat="server" />
                                                                 </div>
                                                                 
                                                            </div>
                                                            
                                                 </div>
                                                </div>
                                                <br /> 
                                              
                                              <div id="printerdetails" runat="server" style="display:none;">
                                                   <div class="row">
                                                    <div class="cls-sub-topic">
                                                        <i aria-hidden="true" class="fa fa-tasks"></i>
                                                        <h2>Printer Details</h2>
                                                    </div>
                                                </div>
                                                   <br />
                                                   <div class="row">
                                                      <div class="col-md-3">
                                                        <label>Printer Name:</label>
                                                        <div>
                                                             <asp:Label ID="lblprinter" runat="server" />
                                                        </div>
                                                    </div>

                                                     <div class="col-md-3">
                                                        <label>Mobile No:</label>
                                                        <div>
                                                             <asp:Label ID="lblprimobile" runat="server" />
                                                        </div>
                                                    </div>

                                                     <div class="col-md-3">
                                                        <label>Contact No:</label>
                                                        <div>
                                                              <asp:Label ID="lblpricontect" runat="server" />
                                                        </div>
                                                    </div>

                                                      <div class="col-md-3">
                                                        <label>Email ID:</label>
                                                        <div>
                                                            <asp:Label ID="lblpriemail" runat="server" />
                                                        </div>
                                                    </div>
                                                   </div>
                                                   <br />
                                                   <div class="row">

                                                    <div class="col-md-3" style="display:none;">
                                                            <label>Image Uploaded By Printer:</label>
                                                            <div>
                                                                <asp:LinkButton ID="lbPrinterImage" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Image" OnClick="lnkFiles13_Click"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                          <div class="col-md-3" style="display:none;">
                                                            <label>Image Link By Printer:</label>
                                                            <div>
                                                                 <asp:HyperLink ID="PrinterLink" style="word-break:break-all;" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                                                            </div>
                                                        </div>

                                                    <div class="col-md-6" style="display:none;">
                                                       <label>Printer Material:</label>
                                                                <asp:GridView runat="server" ID="gvPrinter" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Material" ItemStyle-Width="140px" HeaderText="Material" />
                                                                        <asp:BoundField DataField="Rate" ItemStyle-Width="140px" HeaderText="Rate" />
                                                                        <asp:BoundField DataField="Unit" ItemStyle-Width="140px" HeaderText="Unit" />
                                                                    </Columns>
                                                                </asp:GridView>
                                               
                                                    </div>
                                                </div>
                                              </div>
                                              <br />
                                             
                                              <div id="transportdetails" runat="server" style="display:none;">
                                                   <div class="row">
                                                     <div class="cls-sub-topic">
                                                          <i aria-hidden="true" class="fa fa-tasks"></i>
                                                          <h2>Transport Details</h2>
                                                     </div>
                                                </div>
                                                   <br />
                                                   <div class="row">
                                                       <div class="col-md-3">
                                                            <label>Transpoter Mode:</label>   
                                                            <div>
                                                                 <asp:Label ID="lblTransportMode" runat="server" />     
                                                            </div>
                                                       </div>
                                                       <div class="col-md-3">
                                                            <label>Transpoter Name:</label>   
                                                            <div>
                                                                 <asp:Label ID="lblTranspoterName" runat="server" />     
                                                            </div>         
                                                       </div>
                                                       <div class="col-md-3">
                                                            <label>Invoice Number:</label>   
                                                            <div>
                                                                 <asp:Label ID="lblInvoiceNumber" runat="server" />     
                                                            </div>    
                                                            </div>
                                                       <div class="col-md-3">
                                                            <label>Invoice Date:</label>   
                                                            <div>
                                                                 <asp:Label ID="lblInvoiceDate" runat="server" />     
                                                            </div>
                                                       </div>   
                                                  </div>
                                                   <br />
                                                   <div class="row">
                                                       <div class="col-md-3">
                                                            <label>LR Number:</label> 
                                                            <div>
                                                                 <asp:Label ID="lblLRNumber" runat="server" /> 
                                                            </div>             
                                                       </div>
                                                       <div class="col-md-3">
                                                            <label>LR Date:</label>  
                                                            <div>
                                                                 <asp:Label ID="lblLRDate" runat="server" />    
                                                            </div>   
                                                       </div>
                                                  </div>
                                              </div>
                                              <br />
                                             
                                              <div id="fabricatordetails" runat="server" style="display:none;">
                                                   <div class="row">
                                                            <div class="cls-sub-topic">
                                                                <i aria-hidden="true" class="fa fa-tasks"></i>
                                                                <h2>Fabricator Details</h2>
                                                            </div>
                                                        </div>
                                                   <br />
                                                   <div class="row">

                                                    <div class="col-md-3">
                                                        <label>Fabricator Name:</label>
                                                        <div>
                                                               <asp:Label ID="lblfabname" runat="server" />
                                                        </div>
                                                    </div>

                                                     <div class="col-md-3">
                                                        <label>Mobile No:</label>
                                                        <div>
                                                               <asp:Label ID="lblfabmobile" runat="server" />
                                                                       
                                                        </div>
                                                    </div>

                                                     <div class="col-md-3">
                                                        <label>Contact No:</label>
                                                        <div>
                                                              <asp:Label ID="lblfabcontact" runat="server" />
                                                        </div>
                                                    </div>

                                                      <div class="col-md-3">
                                                        <label>Email ID:</label>
                                                        <div>
                                                            <asp:Label ID="lblfabemail" runat="server" />
                                                        </div>
                                                    </div>

                                                        </div>
                                                   <br />
                                                   <div class="row">


                                                        <div class="col-md-3">
                                                            <label>Image Uploaded By Fabricator:</label>
                                                            <div>
                                                                <asp:LinkButton ID="lbFabricatorImage" OnClientClick="lp.Show()" runat="server" Visible="false" Text="View Image" OnClick="lnkFiles10_Click"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                          <div class="col-md-3">
                                                            <label>Image Link By Fabricator:</label>
                                                            <div>
                                                                 <asp:HyperLink ID="Fablink" style="word-break:break-all;" runat="server" Visible="false" Target="_blank"></asp:HyperLink>
                                                            </div>
                                                        </div>

                                                            <div class="col-md-6">
                                                                       <label>Fabricator Material:</label>
                                                                        <asp:GridView runat="server" ID="gvfab" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Material" ItemStyle-Width="140px" HeaderText="Matertial" />
                                                                                <asp:BoundField DataField="Rate" ItemStyle-Width="140px" HeaderText="Rate" />
                                                                                <asp:BoundField DataField="unit" ItemStyle-Width="140px" HeaderText="unit" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    
                                                            </div>
                                                        </div>
                                              </div>
                                              <br />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <asp:Button ID="btnShowPopup50" runat="server" Style="display: none" />
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row" style="padding-left: 20px">
                                                                <div class="col-md-6 cls-buttons">
                                                                    <asp:Button ID="btnOverWrite" runat="server" class="btn" Style="display: none" OnClick="btnOverWrite_Click" TabIndex="27" Text="OverWrite" />

                                                                    <dx:ASPxButton ID="btnApprove" runat="server" ClientIDMode="Static" OnClick="btnapprove_Click" AutoPostBack="False"
                                                                        Text="Approve" CssClass="btn btn-success btn-space" ClientInstanceName="ASPxButton2" TabIndex="6">
                                                                        <ClientSideEvents Click="function(s, e) { lp.Show(); ASPxCallback1.PerformCallback(); }" />
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="ASPxCallback1"
                                                                        OnCallback="ASPxCallback1_Callback">
                                                                        <ClientSideEvents CallbackComplete="function(s, e) { lp.Hide(); }" />
                                                                    </dx:ASPxCallback>

                                                                    <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn " TabIndex="8"
                                                                        OnClick="btnCancel_Click1">
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
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <%--.Start of Tab-2--%>
                                    <dx:TabPage Text="List">
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
                                                                                    AutoGenerateColumns="False" Settings-HorizontalScrollBarMode="Visible">
                                                                                    <Columns>

                                                                                          <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printername" Caption="Printer" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="fabricatorname" Caption="Fabricator" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                      

                                                                                    <%--    <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="assignrequestno" Caption="Assign Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printerrequestno" Caption="Printer Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                       <%-- <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="fabricatorrequestno" Caption=" Fabricator Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="nametype" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Distributor" Caption="Dealer Name" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="distaddress" Caption="Address" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="distcontactperson" Caption="ContactPerson" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="180px" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subjob" Caption="SubJobType" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subsubjob" Caption="Material" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designtype" Caption="DesignType" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="product" Caption="ProductType" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="180px" FieldName="FabricatorSubmitDate" Caption="Fabricator Submit Date" VisibleIndex="16">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Caption="View" ReadOnly="True" VisibleIndex="21">
                                                                                            <Settings AllowDragDrop="True" />
                                                                                            <DataItemTemplate>
                                                                                                <asp:LinkButton ID="CmdEdit" EnableViewState="false" CausesValidation="False" OnClientClick="lp.Show()" runat="server" CommandArgument='<%# Eval("assignfabricatorslno") %>'
                                                                                                    Text='View' OnCommand="CmdEdit_Command"></asp:LinkButton>
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
                                                        </div>
                                                    </div>
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <%--.Start of Tab-3--%>
                                    <dx:TabPage Text="Approved List">
                                        <ContentCollection>
                                            <dx:ContentControl ID="ContentControl3" runat="server">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-body table-responsive">
                                                                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel35" runat="server">

                                                                            <ContentTemplate>
                                                                                <dx:ASPxGridView Settings-ShowGroupPanel="true" SettingsBehavior-AllowDragDrop="true"
                                                                                    SettingsBehavior-AllowGroup="true" SettingsBehavior-AllowSort="true" ID="ASPxGridView2"
                                                                                    align="left" KeyFieldName="slno" CssClass="listin" Theme="Default" Width="100%"
                                                                                    runat="server" EnablePagingCallbackAnimation="True" OnDataBinding="ASPxGridView2_DataBinding"
                                                                                    AutoGenerateColumns="False" Settings-HorizontalScrollBarMode="Visible">
                                                                                    <Columns>
                                                                                        
                                                                                        <dx:GridViewDataTextColumn FixedStyle="Left" Settings-AllowDragDrop="True" FieldName="reqno" Caption="Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printername" Caption="Printer" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="fabricatorname" Caption="Fabricator" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                      <%--  <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="assignrequestno" Caption="Assign Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="printerrequestno" Caption="Printer Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="fabricatorrequestno" Caption=" Fabricator Request No" VisibleIndex="1">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="nametype" Caption="Type" VisibleIndex="2">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="Distributor" Caption="Name" VisibleIndex="4">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="distaddress" Caption="Address" VisibleIndex="5">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="distcontactperson" Caption="ContactPerson" VisibleIndex="6">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>


                                                                                        <%--Retailer Details--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subname" Caption="Retailer Firm Name" VisibleIndex="7">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="220px" FieldName="SubAddress" Caption="Retailer Address" VisibleIndex="8">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" Width="150px" FieldName="subpname" Caption="Retailer Person Name" VisibleIndex="9">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--<dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subemail" Caption="Retailer Email" VisibleIndex="10">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="SubContact" Caption="Retailer Contact" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                        <%--Retailer Details--%>


                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="jobtype" Caption="JobType" VisibleIndex="11">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subjob" Caption="SubJobType" VisibleIndex="12">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="subsubjob" Caption="Material" VisibleIndex="13">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="designtype" Caption="DesignType" VisibleIndex="14">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="product" Caption="ProductType" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataTextColumn>

                                                                                         <dx:GridViewDataDateColumn Settings-AllowDragDrop="True" Width="160px" FieldName="approvedt" Caption="Approve Date" VisibleIndex="16">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
                                                                                        </dx:GridViewDataDateColumn>

                                                                                        <dx:GridViewDataTextColumn Settings-AllowDragDrop="True" FieldName="approveby" Caption="Approve By" VisibleIndex="16">
                                                                                            <Settings ShowFilterRowMenu="True" ShowFilterRowMenuLikeItem="True" ShowInFilterControl="True" AutoFilterCondition="Contains" />
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

    <asp:Button ID="btnResumeShowUp" runat="server" Style="display: none" />
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header bg-aqua">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">OK</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div>

        <asp:Button ID="btnShowImgPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeAll" runat="server" TargetControlID="btnShowImgPopup" PopupControlID="pnlpopupAll"
            CancelControlID="btnClosempeAll" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupAll" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
            <div class="row">
                <br />
                <br />
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
            <br />
            <br />
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