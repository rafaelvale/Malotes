using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Malotes
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/style").Include(
               "~/Content/Style/rohr-responsive.css",
               "~/Content/Style/rohr.css"
               ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Content/Script/vendor/jquery-1.10.2.min.js",
                "~/Content/Script/vendor/bootstrap.min.js",
                "~/Content/Script/rohr-1.0.0.js",
                "~/Content/Script/vendor/jquery-scrolltofixed-min.js"
                ));
            //bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
            //                "~/Scripts/WebForms/WebForms.js",
            //                "~/Scripts/WebForms/WebUIValidation.js",
            //                "~/Scripts/WebForms/MenuStandards.js",
            //                "~/Scripts/WebForms/Focus.js",
            //                "~/Scripts/WebForms/GridView.js",
            //                "~/Scripts/WebForms/DetailsView.js",
            //                "~/Scripts/WebForms/TreeView.js",
            //                "~/Scripts/WebForms/WebParts.js"));

            //// Order is very important for these files to work, they have explicit dependencies
            //bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
            //        "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
            //        "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
            //        "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
            //        "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            //// Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //                "~/Scripts/modernizr-*"));
            //bundles.Add(new StyleBundle("~/bundles/style").Include(
            //    "~/Content/Style/rohr-responsive.css",
            //    "~/Content/Style/rohr.css"
            //    ));

            //bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            //    "~/Content/Script/vendor/jquery-1.10.2.min.js",
            //    "~/Content/Script/vendor/bootstrap.min.js",
            //    "~/Content/Script/rohr-1.0.0.js",
            //    "~/Content/Script/vendor/jquery-scrolltofixed-min.js"
            //    ));

            //ScriptManager.ScriptResourceMapping.AddDefinition(
            //    "respond",
            //    new ScriptResourceDefinition
            //    {
            //        Path = "~/Scripts/respond.min.js",
            //        DebugPath = "~/Scripts/respond.js",
            //    });
        }
    }
}