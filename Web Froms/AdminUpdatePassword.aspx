<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdatePassword.aspx.cs" Inherits="MyWebsite.AdminUpdatePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StylishTextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishSubmit.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div dir="ltr" align="center" style="padding-top: 5%">

        <asp:Label runat="server" ID="status" ForeColor="DarkSlateBlue"></asp:Label>
        <br />
        <br />

        <asp:TextBox runat="server" class="inputs" ID="oldPassword" placeholder="old password" Style="margin-bottom: 5px; width: 15%" TextMode="Password" />
        <br />
        <asp:TextBox runat="server" class="inputs" ID="newPassword" placeholder="new password" Style="margin-bottom: 5px; width: 15%" TextMode="Password" />
        <br />
        <asp:TextBox runat="server" class="inputs" ID="reNewPass" placeholder="retype new password" Style="margin-bottom: 5px; width: 15%" TextMode="Password" />
        <br />
        <input type="submit" onclick="validateData()" value="Update" class="styled-button-8" />
    </div>
</asp:Content>
