<%@ Page Title="Parola Değiştirildi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="PrimeWeb.App.WebForm.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div>
        <p>Parolanız değiştirildi. Oturum açmak için <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">buraya</asp:HyperLink> tıklayın </p>
    </div>
</asp:Content>
