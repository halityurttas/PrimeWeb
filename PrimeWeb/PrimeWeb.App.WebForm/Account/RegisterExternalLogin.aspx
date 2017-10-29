<%@ Page Title="Dış oturum açma hizmeti kaydet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="PrimeWeb.App.WebForm.Account.RegisterExternalLogin" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<h3><%: ProviderName %> hesabınızla kaydolun</h3>

    <asp:PlaceHolder runat="server">
        <div class="form-horizontal">
            <h4>İlişki Formu</h4>
            <hr />
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <p class="text-info">
                <strong><%: ProviderName %></strong> ile kimlik doğruladınız. Lütfen geçerli site için aşağıya bir e-posta girin
                ve Oturum aç düğmesine tıklayın.
            </p>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 control-label">E-posta</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="E-posta gereklidir" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="email" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Oturum aç" CssClass="btn btn-default" OnClick="LogIn_Click" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
