<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signout.aspx.cs" Inherits="Malotes.Signout" %>

<!DOCTYPE html>

<html class="no-js">
<head id="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Malotes</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="msapplication-tooltip" content="Controle e Gerenciamento de Malotes entre Filiais" />
    <meta name="msapplication-starturl" content="/CockPit/" />
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
</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar">
        <div class="navbar-inner">
            <div class="container">
                <div class="span3">
                    <a class="brand">
                        Malotes</a>
                </div>
            </div>
        </div>
    </div>
    <div class="span12">
        <p class="lead">
            Você foi desconectado do Malotes
            <a href="Login.aspx" class="btn">Entrar</a>
        </p>
    </div>
        
    </form>
    
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../Content/Script/vendor/jquery-1.10.2.min.js"><\/script>');</script>
    <script src="../Content/Script/rohr-1.0.0.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                var updateTime = 4;
                window.setInterval(function () {
                    updateTime = eval(updateTime) - eval(1);
                    if (updateTime == 0) {
                        window.location = ("Login.aspx");
                    }
                }, 900);
            });
        });
    </script>
</body>
</html>
