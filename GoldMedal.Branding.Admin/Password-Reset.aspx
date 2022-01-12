<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Password-Reset.aspx.cs" Inherits="GoldMedal.Branding.Admin.Password_Reset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }

        .btn-space {
            margin-right: 10px;
        }

        .View {
            font-size: 15px;
            margin-bottom: 20px;
            color: #3A7FBA;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="scrpt1" runat="server"></asp:ScriptManager>

    <div>

        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeImage" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
            CancelControlID="btnCloseMPE" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="350px" Width="500px" Style="display: none">

            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-12 modal-header text-center bg-aqua">
                        <label style="color: white">Reset Password</label>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div class="col-lg-12">
                    <div class="row" style="text-align: center;">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server" style="display: inline-block;">
                            <ContentTemplate>
                                <div class="col-md-12">
                                    <label>Password must contain Minimum 6 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character eg. Itm@123456</label>
                                    <label>New Password:<strong class="redmark">*</strong></label>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox MaxLength="200" ID="txtpassword" runat="server" TabIndex="1" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                                            </br>

                                     <asp:RegularExpressionValidator ID="Regex4" runat="server" ControlToValidate="txtpassword"
                                         ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}"
                                         ErrorMessage="Password must contain: Minimum 6 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ForeColor="Red" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Password Required" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-12">

                                    <label>Confirm Password:<strong class="redmark">*</strong></label>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox MaxLength="200" ID="txtconfirmpassword" runat="server" TabIndex="2" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>

                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ErrorMessage="Both Password are not equal" ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword" SetFocusOnError="true" Type="String"></asp:CompareValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="col-md-12 text-center">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Label runat="server" ID="lbmsg" Text="" ForeColor="Red"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-6" style="margin-top: -10px">

                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btn" runat="server" Text="Submit" CssClass="btn btn-info btn-space" OnClick="btn_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-6" style="margin-top: -10px">
                            <asp:Button ID="btnCloseMPE" runat="server" Text="Close" CssClass="btn btn-danger btn-space" />
                        </div>
                    </div>

                    <div class="row" style="margin-left: 280px">
                    </div>

                    <!-- /.box -->
                </div>
            </div>

            <br />
            <br />
            <br />
        </asp:Panel>
    </div>
</asp:Content>