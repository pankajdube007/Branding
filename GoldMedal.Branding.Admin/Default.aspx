<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoldMedal.Branding.Admin.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v18.1" Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Goldmedal</title>
    <link id="Link" runat="server" rel="shortcut icon" href="images/fevicon.png" type="image/png" />
    <link href="Styles/loginpage.css" rel="stylesheet" type="text/css" />
    <link href="assets/libs/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
   <%-- <script src="../Script/jquery-1.9.1.js" type="text/javascript"></script>--%>
       <link type="text/css" href="Styles/GeoLocation.css" rel="stylesheet" />
     <script type="text/javascript" src="Scripts/GeoLocation.js?v=1"></script>
    <script type="text/javascript" >
       function preventBack(){window.history.forward();}
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script>

</head>
<body>
    <form id="form1" runat="server">

         <asp:HiddenField ID="hfPermission" runat="server" Value="" ClientIDMode="Static"></asp:HiddenField>
        <asp:HiddenField ID="hfLat" runat="server" Value="" ClientIDMode="Static"></asp:HiddenField>
        <asp:HiddenField ID="hfLon" runat="server" Value="" ClientIDMode="Static"></asp:HiddenField>
        <asp:HiddenField ID="hfLocation" runat="server" Value="" ClientIDMode="Static"></asp:HiddenField>
        <asp:HiddenField ID="hfBrowser" runat="server" Value="" ClientIDMode="Static"></asp:HiddenField>
        <asp:HiddenField ID="hfLcType" runat="server" Value="0" ClientIDMode="Static"></asp:HiddenField>
        <asp:HiddenField ID="hfLocResponse" runat="server" Value="" ClientIDMode="Static"></asp:HiddenField>
        <asp:HiddenField ID="hfLcFound" runat="server" Value="0" ClientIDMode="Static"></asp:HiddenField>
         <asp:HiddenField ID="hfUserID" runat="server" Value="0" ClientIDMode="Static"></asp:HiddenField>
         <asp:HiddenField ID="hfDesignationID" runat="server" Value="0" ClientIDMode="Static"></asp:HiddenField>
         <asp:HiddenField ID="hfCategory" runat="server" Value="" ClientIDMode="Static"></asp:HiddenField>

        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="60%" border="0" cellspacing="0" cellpadding="0" align="center" style="margin: ;">
                        <tr>
                            <td height="120" colspan="2">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="45%" height="503" align="center">
                                <table width="41%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="435">
                                            <img src="images/loginpageimage.jpg" width="500" height="600" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="55%" style="padding-left: 50px">
                                <table width="66%" height="436" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="65">
                                            <asp:Image ID="Image1" src="images/goldmedallogo_loginpage.png" Width="300" Height="63"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" class="tab"></td>
                                    </tr>
                                    <tr>
                                        <td height="40" class="tab">
                                            <h2>
                                                <span class="glyphicon glyphicon-lock"></span>Login</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="70">
                                            <label for="usrname">
                                                <span class="glyphicon glyphicon-user"></span>Username</label>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtusername" runat="server" class="input" placeholder="User Name"
                                                        Width="97%"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="70">
                                            <label for="psw">
                                                <span class="glyphicon glyphicon-eye-open"></span>Password</label>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtPassword" runat="server" class="input" placeholder="Password"
                                                        TextMode="Password" Width="97%"></asp:TextBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="70">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <button id="Button" onserverclick="Button1_Click" type="submit" runat="server"
                                                        class="btn btn-success btn-block">
                                                        <span class="glyphicon glyphicon-off"></span>Login</button>
                                                     <div onclick="ASPxPopupControlID.Show();" class="signup" style="text-align:right;color:red">FORGOT PASSWORD</div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            
                                             
                                            <br />
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lbmsg" ForeColor="Red" runat="server"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" class="text1">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10" colspan="2"></td>
                        </tr>
                    </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

          <div id="popbg" class="popbg" style="display:none;">
        </div>
        <div id="popcontent" class="popcontent" style="display:none;">
            <div class="closebtn">
                <img alt="close" src="Images/dialog_close.png" />
            </div>
            <div class="bltitle">
                <h5>Unable to get your location!</h5>
            </div>
            <div class="sectionend"></div>

            <div id="chrome" style="display: none;">
                <div class="lcgd">
                    <h5>Location Permission Guid for Google Chrome</h5>
                </div>

                <div class="steps">
                    Follow mentioned few steps to allow location access for this website in your browser :-
                </div>

                <div class="step">
                    <ol>
                        <li>At the top right, click on vertical three dots and then Settings.</li>
                        <li>Under <b>"Privacy and security"</b>, click <b>Site settings</b>.</li>
                        <li>Click <b>Location</b>.</li>
                        <li>Turn ON <b>Sites can ask for your location(recommended)</b> option and reload the page.</li>
                        <li>Or if already turned ON then find website name in <b>Not allowed to see your location</b> section.</li>
                        <li>If it is there then remove this website from that section.</li>
                        <li><b>Reload</b> the page.</li>
                    </ol>
                </div>
            </div>

            <div id="firefox" style="display: none;">
                <div class="lcgd">
                    <h5>Location Permission Guid for Mozilla Firefox</h5>
                </div>

                <div class="steps">
                    Follow mentioned few steps to allow location access for this website in your browser :-
                </div>

                <div class="step">
                    <ol>
                        <li>At the top right, Click the menu button with three lines then select Settings.</li>
                        <li>Use the Settings <b>Search box</b> to search for <b>"location"</b> (or select the <b>Privacy & Security</b> panel and scroll down to the <b>Permissions</b> section).</li>
                        <li>Under Permissions, click the <b>Settings</b> button to the right of Location.</li>
                        <li>The <b>Settings - Location Permissions</b> dialog box will open.</li>
                        <li>In the <b>Settings - Location Permissions</b> box that opens, <b>UnCheck</b> the box next to Block new requests asking to access your location. Then Click <b>Save Changes</b> and reload the page.</li>
                        <li>Or Search for our <b>website name</b> and change the <b>Status</b> to <b>Allow</b>.</li>
                        <li>Click <b>Save Changes</b>.</li>
                        <li><b>Reload</b> the page.</li>
                    </ol>
                </div>

            </div>

            <div id="edge" style="display: none;">
                <div class="lcgd">
                    <h5>Location Permission Guid for Microsoft Edge</h5>
                </div>

                <div class="steps">
                    Follow mentioned few steps to allow location access for this website in your browser :-
                </div>

                <div class="step">
                    <ol>
                        <li>At the top right, Click the menu button with three vertical dots then select Settings.</li>
                        <li>Use the Settings <b>Search box</b> to search for <b>"location"</b> (or select the <b>Cookies and site permissions</b> panel and scroll down to the <b>All Permissions</b> section).</li>
                        <li>Under Permissions, click on <b>Location</b>.</li>
                        <li>Turn ON <b>Ask before accessing (recommended)</b> option and reload the website.</li>
                        <li>Or if already turned ON then find website name in <b>Block</b> section.</li>
                        <li>If it is there then remove this website from that section.</li>
                        <li><b>Reload</b> the page.</li>
                    </ol>
                </div>
            </div>

            <div id="other" style="display: none;">
                <div class="steps">
                    Location is required to access this website. Please allow location access from the browser Address bar > Site settings and try again.
                </div>
            </div>

            <div class="sectionend"></div>
            <div class="closebtn2">
                Close
            </div>

        </div>
        <div >
          <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
        <dx:ASPxPopupControl ID="ASPxPopupControlID" runat="server" ClientInstanceName="ASPxPopupControlID"
            Height="240px" Modal="True" CloseAction="CloseButton" Width="400px" AllowDragging="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Send Password To Your Email Address"
            HeaderStyle-CssClass="PopupHeader CyanHeader">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                    <div class="popup-content-main">
                        <div class="row" style="padding-top: 10px;">
                                <div class="col-md-12">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control clsText" TabIndex="1">
                                        <asp:ListItem Value="0" Text="Select Category" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Internal User"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Printer"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Fabricator"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Dispatch Team"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="Vendor Team"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="Self Installation Team"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        <div class="row" style="padding-top: 20px;">
                            <div class="col-md-12">
                                <asp:HiddenField ID="hfCode" runat="server" />
                                <label>Enter Your Email ID</label>
                                <asp:TextBox runat="server" ID="txtEmailID" TabIndex="2" CssClass="form-control clsText"></asp:TextBox>
                            </div>
                        </div>
                         <br />
                        <div class="row">
                            <div class="col-md-12">
                                <dx:ASPxButton ID="SubmitButton" runat="server" Text="Send Password" Width="100%" OnClick="SubmitButton_Click" CssClass="form-control clsbtn" BackColor="#cc0000" ForeColor="White" />

                            </div>
                        </div>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
             </ContentTemplate>
                </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>