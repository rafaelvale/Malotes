using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Malotes
{
    public class BasePage :Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["usuario"] == null)
                Response.Redirect("Redirecionar.aspx");
        }
    }
}