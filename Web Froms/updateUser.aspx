<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="updateUser.aspx.cs" Inherits="MyWebsite.updateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StylishTextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishRadioButton.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishDropDown.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishSubmit.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div dir="ltr" align="center" style="padding-top: 5%">
        <asp:Label runat="server" ID="status" ForeColor="DarkSlateBlue"></asp:Label>
        <br />
        <br />

        <asp:TextBox runat="server" class="inputs" ID="firstName" Style="margin-bottom: 5px; width: 15%"></asp:TextBox><br />
        <asp:TextBox runat="server" class="inputs" ID="lastName" Style="margin-bottom: 5px; width: 15%"></asp:TextBox><br />
        <br />

        <input type="radio" id="male" value="male" class="css-checkbox" name="Gender" <%checkIfChecked("male"); %> /><label for="male" class="css-label">Male</label>
        &nbsp&nbsp&nbsp
        <input type="radio" id="female" value="female" class="css-checkbox" name="Gender" <%checkIfChecked("female"); %> /><label for="female" class="css-label">Female</label><br />
        <br />

        <asp:TextBox runat="server" ID="email" class="inputs" placeholder="eMail" Style="width: 15%"></asp:TextBox><br />
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

        <asp:TextBox runat="server" class="inputs" ID="password" placeholder="password" Style="margin-bottom: 5px; width: 15%" TextMode="Password" />
        <br />
        <asp:TextBox runat="server" class="inputs" ID="rePassword" placeholder="retype password" Style="margin-bottom: 5px; width: 15%" TextMode="Password" />
        <br />
        <input type="submit" value="Update" class="styled-button-8" />

    </div>
</asp:Content>
