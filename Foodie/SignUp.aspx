<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Foodie.SignUp" %>

<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="head"></asp:Content>
<asp:Content ID="contentPlaceHolderSignUp" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <h1 class="box" style="text-align: center">FOODIE</h1>
    <table class="box" align="center">
        <tr>
            <td>FullName :</td>
            <td>
                <asp:TextBox runat="server" ID="Txtname"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfName" ControlToValidate="Txtname" ErrorMessage="Name required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validateName" runat="server" ControlToValidate="TxtName" ErrorMessage="Enter valid name" ValidationExpression="^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>PhoneNumber :</td>
            <td>
                <asp:TextBox runat="server" ID="TxtPhone"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfPhoneNumber" ControlToValidate="TxtPhone" ErrorMessage="Phone number required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validatePhone" runat="server" ControlToValidate="TxtPhone" ErrorMessage="Enter valid phone number" ValidationExpression="^[6789]\d{9}$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Email :</td>
            <td>
                <asp:TextBox runat="server" ID="TxtEmail"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfEmail" ControlToValidate="TxtEmail" ErrorMessage="Email required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validateEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Enter valid emailID" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Password :</td>
            <td>
                <asp:TextBox runat="server" ID="TxtPassword"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfPassword" ControlToValidate="TxtPassword" ErrorMessage="Password required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validatePassword" runat="server" ControlToValidate="TxtPassword" ErrorMessage="Enter valid password" ValidationExpression="^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Confirm Password :</td>
            <td>
                <asp:TextBox runat="server" ID="TxtConfirmPassword"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfConfirmPassword" ControlToValidate="TxtConfirmPassword" ErrorMessage="Confirm Password required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:CompareValidator ControlToValidate="TxtConfirmPassword" ControlToCompare="TxtPassword" ErrorMessage="Password doesn't match" ID="cmpPassword" runat="server"></asp:CompareValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validateConfirmPassword" runat="server" ControlToValidate="TxtConfirmPassword" ErrorMessage="Enter valid password" ValidationExpression="^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$"></asp:RegularExpressionValidator></td>
        </tr>

        <tr>
            <td>
                <asp:Button runat="server" ID="registerButton" Text="Register" OnClick="RegisterButton_Click" /></td>
            <td>
                <asp:LinkButton PostBackUrl="~/SigIn.aspx" runat="server" ID="sigInButton" Text="SignIn" /></td>
        </tr>
    </table>
</asp:Content>

