<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="MyWebsite.loginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StylishTextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishSubmit.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div style="text-align:center; padding-top:100px" dir="ltr">
        <input type="text" class="inputs" placeholder="User Name" name="user" id="user" /> <br /><br />
        <input type="password" class="inputs" placeholder="Password" name="password" id="password" /> <br /><br />
        <input type="submit" class="styled-button-8"/>
    </div>
</asp:Content>
