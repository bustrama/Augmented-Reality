<%@ Page Title="Register" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyWebsite.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StylishTextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishRadioButton.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishSubmit.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishDropDown.css" rel="stylesheet" type="text/css" />

    <script src="js/ValidateData.js"></script>
    <script type="text/javascript">
        function isValid() {
            var valid = true;

            valid = checkUserName(document.getElementById("<%=userName.ClientID%>").value) && valid;
            valid = checkFirstName(document.getElementById("<%=firstName.ClientID%>").value) && valid;
            valid = checkLastName(document.getElementById("<%=lastName.ClientID%>").value) && valid;
            valid = checkPassword(document.getElementById("<%=password.ClientID%>").value, document.getElementById("<%=rePassword.ClientID%>").value) && valid;
            valid = checkEmail(document.getElementById("<%=email.ClientID%>").value) && valid;

            return valid;
        };
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div dir="ltr" align="center" style="margin-top: 5%">
        <asp:Label runat="server" ID="status" ForeColor="DarkSlateBlue"></asp:Label>
        <br />
        <br />

        <asp:TextBox runat="server" ID="userName" class="inputs" placeholder="User Name" Style="margin-bottom: 5px; width: 20%" MaxLength="15"></asp:TextBox><br />
        <asp:TextBox runat="server" class="inputs" placeholder="Password" ID="password" Style="margin-bottom: 5px; width: 20%" TextMode="Password" MaxLength="12"></asp:TextBox><br />
        <asp:TextBox runat="server" class="inputs" placeholder="Retype Password" ID="rePassword" Style="margin-bottom: 5px; width: 20%" TextMode="Password" MaxLength="12"></asp:TextBox><br />

        <asp:TextBox runat="server" class="inputs" placeholder="First Name" ID="firstName" Style="margin-bottom: 5px; width: 20%" MaxLength="20"></asp:TextBox><br />
        <asp:TextBox runat="server" class="inputs" placeholder="Last Name" ID="lastName" Style="margin-bottom: 5px; width: 20%" MaxLength="20"></asp:TextBox><br />
        <br />

        <input type="radio" id="male" value="male" class="css-checkbox" name="Gender" /><label for="male" class="css-label">Male</label>
        &nbsp&nbsp&nbsp
        <input type="radio" id="female" value="female" class="css-checkbox" name="Gender" /><label for="female" class="css-label">Female</label><br />
        <br />

        <asp:TextBox runat="server" ID="email" class="inputs" placeholder="eMail" Style="width: 20%" MaxLength="30"></asp:TextBox><br />
        <br />

        <asp:DropDownList ID="birthdayDay" runat="server" class="DropDown">
        </asp:DropDownList>&nbsp&nbsp
            <asp:DropDownList ID="birthdayMonth" runat="server" class="DropDown">
            </asp:DropDownList>&nbsp&nbsp
            <asp:DropDownList ID="birthdayYear" runat="server" class="DropDown">
            </asp:DropDownList>&nbsp&nbsp
            <br />
        <br />
        <br />
        <input type="submit" class="styled-button-8" name="submit" />
    </div>
</asp:Content>

