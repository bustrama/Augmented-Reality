<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs" Inherits="MyWebsite.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div align="center" style="padding: 5%">
        <a href="HomePage.aspx">
            <img alt="Augmented Reality" src="Images/error.png" width="40%" height="40%" />
        </a>
        <div align="center" style="font-family: 'Proxima Nova Bold','Avenir Next','Avenir','Helvetica Neue',Helvetica,Arial,sans-serif;
            font-size: 170%">
            <p>
                Aw, snap! Something went terribly wrong.</p>
            <p>
                We couldn't find the page you're looking for.</p>
        </div>
    </div>
</asp:Content>
