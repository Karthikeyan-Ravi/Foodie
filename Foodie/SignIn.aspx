<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Foodie.SignIn" %>

<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="head"></asp:Content>
<asp:Content ID="contentPlaceHolderSignIn" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <table class="box">
        <tr>
            <td>Email :</td>
            <td>
                <asp:TextBox runat="server" ID="TextEmail"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password :</td>
            <td>
                <asp:TextBox runat="server" ID="TextPassword"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="submitButton" Text="SigIn" Style="width: 43px" OnClick="SubmitButton_Click" /></td>
        </tr>
    </table>
</asp:Content>


