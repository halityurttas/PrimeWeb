<%@ Page Title="Hesabı Yönet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="PrimeWeb.App.WebForm.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Hesap ayarlarınızı değiştirin</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Parola:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Değiştir]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Oluştur]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>Dış Oturum Açmalar:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Yönet]" runat="server" />

                    </dd>
                    <%--
                        Telefon Numaraları, iki öğeli kimlik doğrulama sisteminde ikinci öğe olarak kullanılabilir.
                        Bu ASP.NET uygulamasını SMS kullanarak iki öğeli kimlik doğrulamasını destekleyecek şekilde
                        ayarlama konusunda ayrıntılı bilgi için <a href="https://go.microsoft.com/fwlink/?LinkId=403804">bu makaleye</a> bakın.
                        İki öğeli kimlik doğrulamayı ayarladıktan sonra aşağıdaki blokları açıklama durumundan çıkarın
                    --%>
                    <%--
                    <dt>Telefon Numarası:</dt>
                    <% if (HasPhoneNumber)
                       { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Ekle]" />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Değiştir]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Kaldır]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                    <dt>İki Öğeli Kimlik Doğrulama:</dt>
                    <dd>
                        <p>
                            Yapılandırılmış iki öğeli kimlik doğrulama sağlayıcısı yok. Bu ASP.NET uygulamasını iki öğeli kimlik doğrulamayı destekleyecek şekilde ayarlama
                            konusunda ayrıntılı bilgi için <a href="https://go.microsoft.com/fwlink/?LinkId=403804">bu makaleye</a>bakın.
                        </p>
                        <% if (TwoFactorEnabled)
                          { %> 
                        <%--
                        Etkin
                        <asp:LinkButton Text="[Devre Dışı Bırak]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                          else
                          { %> 
                        <%--
                        Devre Dışı
                        <asp:LinkButton Text="[Etkinleştir]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    </dd>
                </dl>
            </div>
        </div>
    </div>

</asp:Content>
