<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="usersPage.aspx.cs" Inherits="MyWebsite.usersPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StylishTable.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div align="center" dir="ltr">
        <form id="users" method="post" style="background:#202020" action="_">
            <h1 style="font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif; font-size:40px; font-style:italic">List Of Users</h1>
            <%ListOfUsers(); %>
        </form>
    </div>
</asp:Content>
