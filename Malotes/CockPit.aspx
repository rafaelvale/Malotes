<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterDefault.Master" AutoEventWireup="true" CodeBehind="CockPit.aspx.cs" Inherits="Malotes.CockPit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
 <div class="container-fluid" style="display: none;">
     <table>

<tr>
<td >
          <a href="EnviarDocumento.aspx" >
              <div  id="btnEnviar"  runat="server" style="height:150px; width: 250px;  background-color: rgb(192,192,192); text-align: center; margin:100px 25px 25px 25px; padding: 30px 30px 30px 30px;">
                  <img src="Content/Image/send.png" style="height:25px; width:25px;">
                    <h3 class="titleButton">Enviar</h3>
                  <p style="font-size: 13px;">Enviar malote</p>
              </div>
          </a>
    </td>
    <td >
          <a href="EncaminharDocumento.aspx">
              <div id="btnFac" runat="server" style="height:150px; width: 250px;  background-color:rgb(192,192,192); text-align: center; margin:100px 25px 25px 25px; padding: 30px 30px 30px 30px;" >
                  <img src="Content/Image/facilities.png" style="height:25px; width:25px;">
                  <h3 class="titleButton">Encaminhar</h3>
                  <p style="font-size: 13px;">Administrar e encaminhar malotes</p>
              </div>
          </a>
        </td>
        <td >
          <a href="ReceberDocumento.aspx">
              <div id="btnRec" runat="server" style="height:150px; width: 250px;  background-color:rgb(192,192,192); text-align: center; margin:100px 25px 25px 25px; padding: 30px 30px 30px 30px;">
                  <img src="Content/Image/receive.png" style="height:25px; width:25px;">
                  <h3 class="titleButton">Receber</h3>
                  <p style="font-size: 13px;">Receber e dar baixa no malote</p>
              </div>
          </a>
          </td>
          </tr>
      </table>
 </div>



</asp:Content>
