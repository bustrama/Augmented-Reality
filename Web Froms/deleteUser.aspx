<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="deleteUser.aspx.cs" Inherits="MyWebsite.deleteUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="css/StylishTextBox.css" type="text/css" />
    <link rel="Stylesheet" href="css/StylishSubmit.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div dir="ltr" align="center" style="padding-top: 40px">

        <asp:TextBox ID="deletionPass" runat="server" TextMode="Password" class="inputs" placeholder="Enter Your Password" ></asp:TextBox>&nbsp&nbsp
            <input type="submit" id="delete" value="Delete User Forever!" class="styled-button-8" style="width: 200px" />
        <br />
        <br />

        <asp:Label ID="status" runat="server"></asp:Label>
    </div>

</asp:Content>
