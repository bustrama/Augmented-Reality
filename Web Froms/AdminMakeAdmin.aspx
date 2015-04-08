<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminMakeAdmin.aspx.cs" Inherits="MyWebsite.AdminMakeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StylishTextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishSubmit.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div dir="ltr" align="center" style="padding-top: 40px">
        <asp:TextBox ID="adminMe" runat="server" class="inputs" TextMode="Password" placeholder="Enter Your Password"></asp:TextBox>
        &nbsp&nbsp
        <input type="submit" id="delete" value="Admin Me!" class="styled-button-8" style="width: 200px" />
        <br />
        <br />
        <asp:Label ID="status" runat="server"></asp:Label>
    </div>
</asp:Content>
