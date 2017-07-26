<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterDefault.Master" AutoEventWireup="true" CodeBehind="EnviarDocumento.aspx.cs" Inherits="Malotes.EnviarDocumento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container">
        <div class="row">



            <div class="span12">
                <p class="muted" style="float: left">
                    Insira abaixo o documento que será enviado
                </p>
                <span class="reload">
                    <img src="Content/Image/Reload.png" onclick="reloadPage()" />
                </span>
                <div style="clear: left">
                    <asp:Label ID="lblMensagem" runat="server" EnableViewState="False"></asp:Label>
                </div>
                <div class="row">
                    <div class="span12" style="position:center">
                        <fieldset style="position:center" >
                            <legend>Novo Documento</legend>
                            <asp:TextBox style="width:450px;  margin:5px 20px 5px 200px;" runat="server" placeholder="Título do Documento" id="tituloDoc">
                              </asp:TextBox><br />
                             <asp:DropDownList cssclass="btn" style="width:180px; margin:5px 10px 5px 200px;" runat="server" AutoPostBack ="true" AppendDataBoundItems ="true"   id="ddlTipoDoc">
                              </asp:DropDownList>
                             <asp:DropDownList cssclass="btn" style="width:180px;  margin:5px 10px 5px 10px;" runat="server" AutoPostBack ="true" AppendDataBoundItems ="true"   id="ddlUrgencia">
                              </asp:DropDownList>
                              <asp:DropDownList cssclass="btn" style="width:180px;  margin:5px 20px 5px 10px;" runat="server" AutoPostBack ="true" AppendDataBoundItems ="true"   id="ddlFilialDestino">
                              </asp:DropDownList><br />
                              <asp:TextBox  style="width:450px;  margin:5px 10px 5px 200px;" runat="server" placeholder="Nome do Destinátario" id="NomeDestinatario">
                              </asp:TextBox>
                        </fieldset>
                    </div>
                </div>
                <br />
                <asp:Label ID="lblMensagemErro" runat="server" />
                <div class="form-actions">
                    <asp:Button ID="btnContinuar" runat="server" Text="Enviar Documento" CssClass="btn" OnClick="btnContinuar_Click"
                        UseSubmitBehavior="false" OnClientClick="ClientClickDisable(this);" />
                </div>
            </div>
        </div>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
                    EnableViewState="false">
                    <HeaderTemplate>
                        <table class="table table-condensed-small table-hover" id="tableDocumentos">
                            <thead>
                                <tr>
                                    <th style="width: 12px;">
                                        <input type="checkbox" id="checkBoxAll"></th>
                                    <th style="width: 1px;"></th>
                                    <th title="Protocolo do Malote" class="text-nowrap" style="width: 50px;">Nº Doc.</th>
                                    <th class="text-nowrap" title="C = Confidencial / D = Diversos" style="width: 30px;">Tipo</th>
                                    <th title="Status do malote" class="text-nowrap hidden-tablet" style="width: 32px;">Status</th>
                                    <th title="Data de Envio do Documento" class="text-nowrap hidden-tablet" style="width: 70px;">Dt. Envio</th>
                                    <th title="Colaborador responsável pela criação do documento"class="text-nowrap" style="width: 70px;">Enviado Por</th>
                                    <th title="Urgência do documento" class="text-nowrap" style="width: 50px;">Urgencia</th>
                                    <th title="Filial de origem" class="text-nowrap hidden-tablet" style="width: 55px;">Filial Origem</th>
                                    <th title="Filial de destino" class="text-nowrap hidden-tablet" style="width: 55px;">Filial Destino</th>
                                    <th title="Colaborador que irá receber o documento"class="text-nowrap" style="width: 70px;">Enviado Para</th>
                                    <th title="Data de recebimento do documento"class="text-nowrap" style="width: 70px;">Dt. Recebido</th>
                                </tr>
                            </thead>
                            <tbody id="fbody">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:CheckBox ID="ckDocumento" runat="server" />
                                <asp:HiddenField ID="hdIdDocumento" runat="server" />
                            </td>
                            <td class="text-nowrap">
                                <asp:Label runat="server" ID="lblNumeroDocumento" />
                            </td>
                            <td class="text-nowrap">
                                <%# DataBinder.Eval(Container.DataItem, "numeroDocumento", "{0:N0}") %>
                            </td>
                            <td class="text-nowrap" title='<%# Boolean.Parse(DataBinder.Eval(Container.DataItem, "eProposta").ToString()) ? "Proposta" : "Contrato" %>'>
                                <%# Boolean.Parse(DataBinder.Eval(Container.DataItem, "eProposta").ToString()) ? "P" : "C" %>
                            </td>
                            <td class="text-nowrap hidden-tablet">
                                <%# DataBinder.Eval(Container.DataItem, "revisaoCliente") %>
                            </td>
                            <td class="text-nowrap hidden-tablet">
                                <%# DataBinder.Eval(Container.DataItem, "versaoInterna") %>
                            </td>
                            <td class="text-nowrap">
                                <asp:Label runat="server" ID="lblNomeCliente" />
                            </td>
                            <td class="text-nowrap">
                                <asp:Label runat="server" ID="lblNomeObra" />
                            </td>
                            <td class="text-nowrap hidden-tablet">
                                <%# DataBinder.Eval(Container.DataItem, "filial") %>
                            </td>
                            <td class="text-nowrap text-right">
                                <%# DataBinder.Eval(Container.DataItem, "percentualDesconto", "{0:N2}") %>
                            </td>
                            <td class="text-nowrap text-right">
                                <%# DataBinder.Eval(Container.DataItem, "ValorNegocio", "{0:N2}") %>
                            </td>
                            <td class="text-nowrap hidden-tablet">
                                <%# DataBinder.Eval(Container.DataItem, "primeiroNome") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
    </div>

</asp:Content>
