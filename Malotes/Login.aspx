<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Malotes.Login" %>

<!DOCTYPE html>

<head runat="server">
    <title>MALOTES</title>
         <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="msapplication-tooltip" content="Controle e Gerenciamento de Malotes entre Filiais" />
    <meta name="msapplication-starturl" content="Login.aspx" />
    <meta name="msapplication-navbutton-color" content="#ffe100" />
    <meta name="msapplication-window" content="width=1230;height=700" />
    <meta name="description" content="Controle e Gerenciamento de Malotes entre Filiais" />
    
    <link rel="apple-touch-icon" sizes="57x57" href="/Content/Image/Favicon/apple-icon-57x57.png">
    <link rel="apple-touch-icon" sizes="60x60" href="/Content/Image/Favicon/apple-icon-60x60.png">
    <link rel="apple-touch-icon" sizes="72x72" href="/Content/Image/Favicon/apple-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="76x76" href="/Content/Image/Favicon/apple-icon-76x76.png">
    <link rel="apple-touch-icon" sizes="114x114" href="/Content/Image/Favicon/apple-icon-114x114.png">
    <link rel="apple-touch-icon" sizes="120x120" href="/Content/Image/Favicon/apple-icon-120x120.png">
    <link rel="apple-touch-icon" sizes="144x144" href="/Content/Image/Favicon/apple-icon-144x144.png">
    <link rel="apple-touch-icon" sizes="152x152" href="/Content/Image/Favicon/apple-icon-152x152.png">
    <link rel="apple-touch-icon" sizes="180x180" href="/Content/Image/Favicon/apple-icon-180x180.png">
    <link rel="icon" type="image/png" sizes="192x192"  href="/Content/Image/Favicon/android-icon-192x192.png">
    <link rel="icon" type="image/png" sizes="32x32" href="/Content/Image/Favicon/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="96x96" href="/Content/Image/Favicon/favicon-96x96.png">
    <link rel="icon" type="image/png" sizes="16x16" href="/Content/Image/Favicon/favicon-16x16.png">
    

    <webopt:BundleReference runat="server" Path="~/bundles/style" />
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/scripts") %>
    </asp:PlaceHolder>
</head>
<body>
        <form id="form1" runat="server">
    <div class="navbar">
        <div class="navbar-inner">
            <div class="container">
                <div class="span3">
                    <a href="#" class="brand" id="LogoMalotes">
                        <span style="display: inline-block;">&nbsp;Malotes</span> </a>
                </div>
            </div>
        </div>
    </div>
    <div class="container" style="font-size: 14px; margin: 0 auto;">
        <asp:Label runat="server" ID="lblNavegador" Visible="False" CssClass="alert alert-error"></asp:Label>
        <br />
            <br />
        <div class="span5">
            <ul class="infoEPC">
                <li>
                    <img src="Content/Image/pc.png" width="32" height="32" />&nbsp;Programação de envios e recebimentos</li>
                <li>
                    <img src="Content/Image/mail_send.png" width="32" height="32" />&nbsp;Avisos por e-mail</li>
  
                <li>
                    <img src="Content/Image/seta_troca.png" width="32" height="32" />&nbsp;Acompanhamento simplificado do início ao fim</li>
            </ul>
            <br />
           <span style="font-weight: bold; padding-top: 15px;">Total confiança!</span><br />
            Você envia o malote, eu aviso a central e o destinatário<br />
            <span style="font-weight: bold; padding-top: 15px;">Acompanhamento de entrega</span><br />
            <span>Assim que o malote for entregue e finalizado pela central, eu aviso você ;)</span><br />
        
            <br />
            <br />
        </div>
        <div class="span5">
            <div class="well">
                <h3 style="display: inline-block; color: #565656">
                    :) Login</h3>
                <img alt="Rohr" height="60" src="Content/Image/Logo03.png" style="float: right;" width="60" />
                <div class="control-group">
                    <label for="txtUsuario">
                        Acesse a sua conta</label>
                    <asp:TextBox ID="txtUsuario" CssClass="input-xlarge" MaxLength="20" autocomplete="true"
                        runat="server" autofocus></asp:TextBox>
                </div>
                <div class="control-group">
                    <label for="txtSenha">
                        Senha</label>
                    <asp:TextBox ID="txtSenha" TextMode="Password" CssClass="input-xlarge" MaxLength="20"
                        autocomplete="off" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblMensagem" runat="server" Text="" ForeColor="#dd4b39"></asp:Label>
                </div>
                <div class="control-group">
                    <asp:Button ID="btnAcessar" runat="server" CssClass="btn" Text="Login" OnClick="btnAcessar_Click"  />
                </div>
                <a href="Ajuda.aspx">Não consegue acessar sua conta?</a>
            </div>
            <div style="text-align:center;" class="text-error">
                <asp:Label runat="server" ID="lblServidor" Visible="false"></asp:Label>
            </div>
        </div>
        <footer>
            <div class="span12">
                <hr />
                Rohr S/A Estruturas Tubulares&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; <a href="http://portal:portal@portalrohr/Processos%20Administrativos/DSI/PADSI%20002%20%20Politica%20de%20Uso%20de%20Recursos%20de%20TI-%20Rev%2000.pdf"
                    target="_blank">Política de Uso de Recursos de TI</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;Departamento
                de Sistemas - Divisão Corporativa
            </div>
        </footer>
    </div>
    </form>

</bod>
</html>


