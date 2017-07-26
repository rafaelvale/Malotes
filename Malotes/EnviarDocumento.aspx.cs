using Malotes.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Malotes
{
    public partial class EnviarDocumento : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTipoDoc();
            GetTipoUrgencia();
            GetFilialDestinatario();
        }
        
        public void GetTipoDoc()
        {
            if (!Page.IsPostBack)
            {
                var tipodocumento = new TipoDocumentoBusiness().ObterTipos();

                ddlTipoDoc.DataSource = tipodocumento;
                ddlTipoDoc.Items.Clear();
               
                ddlTipoDoc.Items.Add("Tipo de Documento");
                ddlTipoDoc.DataValueField = "IdTipoDoc";
                ddlTipoDoc.DataTextField = "TipoDoc";
                ddlTipoDoc.DataBind();

            }
            
        }
        public void GetTipoUrgencia()
        {
            if (!Page.IsPostBack)
            {
                var tipoUrgencia = new TipoDocumentoBusiness().ObterTipoUrgencia();

                ddlUrgencia.DataSource = tipoUrgencia;
                ddlUrgencia.Items.Clear();

                ddlUrgencia.Items.Add("Urgência");
                ddlUrgencia.DataValueField = "Id";
                ddlUrgencia.DataTextField = "TipoUrgencia";
                ddlUrgencia.DataBind();

            }

        }
        public void GetFilialDestinatario()
        {
            if (!Page.IsPostBack)
            {
                var tipoFilialDest = new FilialBusiness().ObterFilialDest();

                ddlFilialDestino.DataSource = tipoFilialDest;
                ddlFilialDestino.Items.Clear();

                ddlFilialDestino.Items.Add("Filial de Destino");
                ddlFilialDestino.DataValueField = "FilialId";
                ddlFilialDestino.DataTextField = "DescricaoAbreviada1";
                ddlFilialDestino.DataBind();

            }

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
        protected void btnContinuar_Click(object sender, EventArgs e)
        {

        }

    }
}