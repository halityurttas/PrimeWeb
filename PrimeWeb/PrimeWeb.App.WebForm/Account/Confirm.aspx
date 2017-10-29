<%@ Page Title="Hesap Doğrulama" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="PrimeWeb.App.WebForm.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Hesabınızı onayladığınız için teşekkür ederiz. Oturum açmak için <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">buraya</asp:HyperLink>  tıklayın             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                Bir hata oluştu.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
