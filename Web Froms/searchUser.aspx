<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="searchUser.aspx.cs" Inherits="MyWebsite.searchUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StylishTable.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishSubmit.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishTextBox.css" rel="stylesheet" type="text/css" />
    <link href="css/StylishDropDown.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

        <div dir="ltr" align="center" style="padding:60px;"> Search By &nbsp
            <asp:DropDownList runat="server" ID="searchOption" class="DropDown" Width="100px">
                <asp:ListItem Text="User Name" Value="UUserName" class="DropDownItem"></asp:ListItem>
                <asp:ListItem Text="First Name" Value="UFirstName" class="DropDownItem"></asp:ListItem>
                <asp:ListItem Text="Security Level" Value="USecurity" class="DropDownItem"></asp:ListItem>
            </asp:DropDownList>
            <br /> <br />
            <asp:TextBox runat="server" ID="searchInput" class="inputs"></asp:TextBox>
            <input type="submit" class="styled-button-10"/> <br /><br />

            <%ListOfUsers(); %>
        </div>

</asp:Content>
