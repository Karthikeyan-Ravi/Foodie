<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Foodie.SignUp" %>

<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="head"></asp:Content>
<asp:Content ID="contentPlaceHolderSignUp" runat="server" ContentPlaceHolderID="ContentPlaceHolder">

    <table class="box" align="center">
        <tr>
            <td>FullName :</td>
            <td>
                <asp:TextBox runat="server" ID="txtname"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfName" ControlToValidate="txtname" ErrorMessage="Name required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validateName" runat="server" ControlToValidate="txtName" ErrorMessage="Enter valid name" ValidationExpression="^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>PhoneNumber :</td>
            <td>
                <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfPhoneNumber" ControlToValidate="txtPhone" ErrorMessage="Phone number required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validatePhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Enter valid phone number" ValidationExpression="^[6789]\d{9}$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Email :</td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfEmail" ControlToValidate="txtEmail" ErrorMessage="Email required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validateEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter valid emailID" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Password :</td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfPassword" ControlToValidate="txtPassword" ErrorMessage="Password required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validatePassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter valid password" ValidationExpression="^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Confirm Password :</td>
            <td>
                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rvfConfirmPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password required"></asp:RequiredFieldValidator></td>
            <td>
                <asp:CompareValidator ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Password doesn't match" ID="cmpPassword" runat="server"></asp:CompareValidator></td>
            <td>
                <asp:RegularExpressionValidator ID="validateConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Enter valid password" ValidationExpression="^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$"></asp:RegularExpressionValidator></td>
        </tr>

        <tr>
            <td>
                <asp:Button runat="server" ID="registerButton" Text="Register" OnClick="RegisterButton_Click" /></td>
            <td>
                <asp:Button runat="server" ID="signInButton" Text="SignIn" OnClick="SignInButton_Click" /></td>
        </tr>
    </table>
</asp:Content>

