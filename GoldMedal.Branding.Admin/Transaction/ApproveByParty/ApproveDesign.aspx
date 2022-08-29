<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveDesign.aspx.cs" Inherits="GoldMedal.Branding.Admin.Transaction.ApproveByParty.ApproveDesign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Data.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html>
<link href="../../assets/css/dialog_box.css" rel="stylesheet" />
<script type="text/javascript" src="../../assets/js/dialog_box.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            width: 100%;
            border: 2px solid #808080;
        }

        .auto-style4 {
            height: 42px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="tsm" runat="server"></asp:ScriptManager>
        <div>
            <table class="auto-style1" style="margin-top:50px;margin-bottom:40px;">
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red" Text="Please Approve The  Job "></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="det" runat="server">
            <div style="margin-left: 32%">

                <table class="auto-style3" style="width:60%">
                    <tr style="width: 100%">
                        <td style="border: thin inset #808080; text-align: left">Request No</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="LblRequestNo" runat="server" Text="Label"></asp:Label></td>
                        <td style="border: thin inset #808080; text-align: left">Request Date</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lbslno" runat="server" style="display:none;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border: thin inset #808080; text-align: left">Dealer Name</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblAllName" runat="server" Text="Label"></asp:Label></td>
                        <td style="border: thin inset #808080; text-align: left">Contact Person</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblAllContactPerson" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td style="border: thin inset #808080; text-align: left">Retailer Name</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblRetailerName" runat="server" Text="Label"></asp:Label></td>
                        <td style="border: thin inset #808080; text-align: left">Contact Person</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblRetailerContactPerson" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border: thin inset #808080; text-align: left">Job Type</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="jobtype" runat="server" Text="Label"></asp:Label></td>
                        <td style="border: thin inset #808080; text-align: left">Sub Job Type</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="subjobtype" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border: thin inset #808080; text-align: left">Materials used by printer</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="subsubjobtype" runat="server" Text="Label"></asp:Label></td>
                         <td style="border: thin inset #808080; text-align: left">Fabrication Material</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="designtyp" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                          <td style="border: thin inset #808080; text-align: left">Priority</td>
                          <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblPriority" runat="server" Text=""></asp:Label></td>
                         <td style="border: thin inset #808080; text-align: left">Unit</td>
                          <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblUnit" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border: thin inset #808080; text-align: left">Height</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblheight" runat="server" Text="Label"></asp:Label></td>
                        <td style="border: thin inset #808080; text-align: left">Width</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblwidth" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblchildid" Style="display: none" runat="server" Text="Label"></asp:Label></td>
                       
                    </tr>
                    <tr>
                        <td style="border: thin inset #808080; text-align: left">Product Type</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="producttype" runat="server" Text="Label"></asp:Label></td>
                       <td style="border: thin inset #808080; text-align: left">Board Type</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblBoardType" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border: thin inset #808080; text-align: left">Printer Location</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblPrintLoc" runat="server" Text="Label"></asp:Label></td>
                       <td style="border: thin inset #808080; text-align: left">Fabricator Location</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:Label ID="lblFabLoc" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                         <td style="border: thin inset #808080; text-align: left">Sample Image</td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:LinkButton ID="lnkFiles2" runat="server" Text="View Image " OnClick="lnkFiles2_Click"></asp:LinkButton></td>
                        
                        <td style="border: thin inset #808080; text-align: left"><strong>Design</strong></td>
                        <td style="border: thin inset #808080; text-align: left">
                            <asp:TextBox ID="hfVisitingImage" Style="display: none" runat="server"></asp:TextBox>
                            <asp:LinkButton ID="LinkButton2" runat="server" Text="View Image " OnClick="lnkFiles3_Click" Font-Bold="True" ForeColor="Red"></asp:LinkButton>
                        </td>
                    </tr>

                    <%-- <tr>
                        <td style="border: thin inset #808080; text-align: center">&nbsp;</td>
                        <td style="border: thin inset #808080; text-align: left">
                            &nbsp;</td>
                    </tr>--%>

                    <tr>
                        <td style="border: thin inset #808080; text-align: center" class="auto-style4">
                            <asp:Label ID="lbtamt" runat="server" Text="Total Amount"></asp:Label></td>
                        <td style="border: thin inset #808080; text-align: left" class="auto-style4">
                            <asp:Label ID="lbltotamt" runat="server" Text="Label"></asp:Label></td>
                        <td style="border: thin inset #808080; text-align: left" class="auto-style4">Payment Requried</td>
                        <td style="border: thin inset #808080; text-align: left" class="auto-style4">

                            <asp:Label ID="ispayment" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border: thin inset #808080; text-align: center" class="auto-style4">Upload Files *</td>
                        <td colspan="3" style="border: thin inset #808080; text-align: left" class="auto-style4">
                            <asp:FileUpload ID="fuupload" runat="server" AllowMultiple="True" CssClass="form-control upload" TabIndex="6" />
                        </td>
                        <td style="border: thin inset #808080; text-align: center;display:none;" class="auto-style4">Image Link</td>
                        <td style="border: thin inset #808080; text-align: left;display:none;" class="auto-style4">
                           <asp:TextBox ID="txtlink"  Style="font-size: 12px;" Width="200px" runat="server" CssClass="form-control-grid flink"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="border: thin inset #808080; text-align: center" class="auto-style4">Remarks</td>
                        <td colspan="3" style="border: thin inset #808080; text-align: left;padding:5px;" class="auto-style4">
                           <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Rows="3" Columns="5" Style="font-size: 12px;padding:5px;" Width="95%" runat="server" CssClass="form-control-grid flink">
                           </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                           <td colspan="4" style="border: thin inset #808080; text-align: center" class="auto-style4">
                            <dx:ASPxButton ID="btnApprove" runat="server" Text="Approve" style="margin-right:15px;font-size:15px;" CssClass="btn " TabIndex="6"
                                OnClick="btnApprove_Click1">
                            </dx:ASPxButton>
                               <dx:ASPxButton ID="btnDisapprove" runat="server" style="font-size:15px;" Text="Disapprove" CssClass="btn" TabIndex="6"
                                OnClick="btnDisapprove_Click1">
                                   <ClientSideEvents Click="function(s, e) { return confirm('Do you really want to disapprove?');'yes,no' }" />
                                  <%-- <ClientSideEvents OnClientClick="javascript:return confirm('Do you really want to reopen?');'yes,no'"/>--%>
                            </dx:ASPxButton>
                        </td>

                    </tr>
                </table>
            </div>
            <div class="col-md-12" style="margin-left: 32%;margin-top:30px;">
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <asp:Label ID="lblable" runat="server" Text="List Of Items" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                <br />
              <asp:GridView runat="server" ID="gvSchemeChild" AutoGenerateColumns="false" EmptyDataText="No Records Found.">
                  <Columns>
                      <asp:TemplateField HeaderText="Sl. No." ItemStyle-Width="100">
                          <ItemTemplate>
                              <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                          </ItemTemplate>
                      </asp:TemplateField>

                      <asp:BoundField DataField="Item" ItemStyle-Width="140px" HeaderText="Item" />
                      <asp:BoundField DataField="MRP" ItemStyle-Width="140px" HeaderText="MRP" />
                      <asp:BoundField DataField="Discount" ItemStyle-Width="140px" HeaderText="Discount" />
                      <asp:BoundField DataField="Qty" ItemStyle-Width="140px" HeaderText="Qty" />
                      <asp:BoundField DataField="Amount" ItemStyle-Width="140px" HeaderText="Amount" />
                  </Columns>
              </asp:GridView>
            </div>
          <div>

           <asp:Button ID="Button1" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeImage" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
            CancelControlID="btnCloseMPE" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
            <div class="row">
                <br />
                <br />
                <br />
                <div class="col-lg-12">
                    <div class="box" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                                <asp:Repeater ID="rptImages" runat="server" OnItemCommand="rptImages_ItemCommand" OnItemDataBound="rptImages_ItemDataBound">
                                    <ItemTemplate>
                                            <div id="dvImage" style="width: 150px; height: 150px; overflow: hidden; text-align: center; float: left;">
                                        <div>
                                            <asp:HyperLink ID="hyLink" runat="server" Target="_blank"  Style="border: none; color: transparent;">
                                                <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                            </asp:HyperLink>
                                        </div>
                                        <div style="clear: both;" id="asd" runat="server">
                                            <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                            <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                             <asp:HiddenField ID="hfvisible" runat="server"  />
                                             
                                        </div>
                                         <div style="clear: both;">
                                            <asp:LinkButton ID="lnkDown"   EnableViewState="false" runat="server" 
                                                CommandArgument='<%# Eval("ImageName") %>' CommandName="Down" Text='Download' Style="text-decoration: underline;"></asp:LinkButton>
                                        </div>
                                    </div>
                                        <div style="clear: both" runat="server" visible="<%# (Container.ItemIndex+1) % 5 == 0 %>"></div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <h2 id="hdNoRecord" runat="server">No Image Found</h2>
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
                            <asp:Button ID="btnCloseMPE" runat="server" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCloseMPE" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
           
         
         
         <asp:Button ID="btnShowPopup1" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeImage1" runat="server" TargetControlID="btnShowPopup1" PopupControlID="pnlpopup1"
            CancelControlID="btnCloseMPE1" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopup1" runat="server" BackColor="White" Height="500px" Width="960px" Style="display: none">
            <div class="row">
                <br />
                <br />
                <br />
                <div class="col-lg-12">
                    <div class="box" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                                <asp:Repeater ID="rptImages1" runat="server" OnItemCommand="rptImages1_ItemCommand" OnItemDataBound="rptImages1_ItemDataBound">
                                    <ItemTemplate>
                                            <div id="dvImage" style="width: 150px; height: 150px; overflow: hidden; text-align: center; float: left;">
                                        <div>
                                            <asp:HyperLink ID="hyLink" runat="server" Target="_blank"  Style="border: none; color: transparent;">
                                                <asp:Image ID="imgDocs" runat="server" Width="100" Height="100" Style="border: solid" />
                                            </asp:HyperLink>
                                        </div>
                                        <div style="clear: both;" id="asd" runat="server">
                                            <asp:HiddenField ID="hfImgIName" runat="server" Value='<%# Eval("ImageName") %>' />
                                            <asp:HiddenField ID="rphfslno" runat="server" Value='<%# Eval("slno") %>' />
                                             <asp:HiddenField ID="hfvisible" runat="server"  />
                                         <asp:LinkButton ID="lnkDelete" EnableViewState="false" runat="server"
                                                CommandArgument='<%# Eval("ImageName") %>' OnClientClick="javascript:return confirm('Do you really want to delete?');'yes,no'"
                                                CommandName="cmdRemove" Text='Remove' Style="text-decoration: underline;"></asp:LinkButton>     
                                        </div>
                                         <div style="clear: both;">
                                            <asp:LinkButton ID="lnkDown"   EnableViewState="false" runat="server" 
                                                CommandArgument='<%# Eval("ImageName") %>' CommandName="Down" Text='Download' Style="text-decoration: underline;"></asp:LinkButton>
                                        </div>
                                    </div>
                                        <div style="clear: both" runat="server" visible="<%# (Container.ItemIndex+1) % 5 == 0 %>"></div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <h2 id="hdNoRecord1" runat="server">No Image Found</h2>
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
                            <asp:Button ID="btnCloseMPE1" runat="server" Width="100" Height="30" Text="Close"  CssClass="btn btn-info btn-space" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCloseMPE1" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
    </div>
        </div>
    </form>
</body>
</html>