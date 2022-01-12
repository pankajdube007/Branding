<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bootstrap.aspx.cs" Inherits="Bootstrap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/bootstrapValidator.min.css" rel="stylesheet" />
    <%--javascript--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="bootstrap/bootstrap.min.js"></script>
    <script src="bootstrap/bootstrapValidator.min.js"></script>
   <%-- <asp:ContentPlaceHolder id="head" runat="server">
    </asp:ContentPlaceHolder>--%>
    </head>


<body>
    <form id="form1" runat="server">
    <div class="form-horizontal" id="formValidator">
        <div class="form-group">
            <label class="col-lg-3 control-label">Username</label>
            <div class="col-lg-6">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Email address</label>
            <div class="col-lg-6">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-lg-3"></div>
            <div class="col-lg-6">
                <asp:LinkButton ID="btnSave" CssClass="lbtSubmit btn btn-primary" runat="server" OnClick="btnSave_Click">Submit</asp:LinkButton>
                <%--message return from sever side--%>
                <asp:Literal ID="ltrMs" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
<script>
       $(document).ready(function () {
           $('#formValidator').bootstrapValidator({
                submitButtons: '<%=btnSave.ClientID%>',
               message: 'This value is not valid',
               feedbackIcons: {
                   valid: 'glyphicon glyphicon-ok',
                   invalid: 'glyphicon glyphicon-remove',
                   validating: 'glyphicon glyphicon-refresh'
               },
               fields: {
                   <%= txtUserName.UniqueID %>: {
                       message: 'The username is not valid',
                       validators: {
                           notEmpty: {
                               message: 'The username is required and cannot be empty'
                           },
                           stringLength: {
                               min: 6,
                               max: 30,
                               message: 'The username must be more than 6 and less than 30 characters long'
                           },
                           regexp: {
                               regexp: /^[a-zA-Z0-9_]+$/,
                               message: 'The username can only consist of alphabetical, number and underscore'
                           }
                       }
                   },
                   <%= txtEmail.UniqueID %>: {
                       validators: {
                           notEmpty: {
                               message: 'The email is required and cannot be empty'
                           },
                           emailAddress: {
                               message: 'The input is not a valid email address'
                           }
                       }
                   }
               }
           });
 
         //validation manually
         $('#<%=btnSave.ClientID%>').click(function(){
           var validatorObj = $('#formValidator').data('bootstrapValidator');
           validatorObj.validate();
           return validatorObj.isValid();
         });
 
       });
   </script>


    </form>
</body>
</html>
