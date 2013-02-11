using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Optimization;
using Microsoft.Ajax.Utilities;

namespace SpeakerNet.Web.Optimization
{
    internal class JsMinifyWithRename : IBundleTransform
    {
        const string JsContentType = "text/javascript";

        static void GenerateErrorResponse(BundleResponse bundle, IEnumerable<object> errors)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("/* ");
            stringBuilder.Append("error on minifying").Append("\r\n");
            foreach (object obj in errors)
                stringBuilder.Append(obj.ToString()).Append("\r\n");
            stringBuilder.Append(" */\r\n");
            stringBuilder.Append(bundle.Content);
            bundle.Content = stringBuilder.ToString();
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (response == null)
                throw new ArgumentNullException("response");
            if (!context.EnableInstrumentation) {
                var minifier = new Minifier();
                string str = minifier.MinifyJavaScript(response.Content, new CodeSettings {
                    MinifyCode = true,
                    EvalTreatment = EvalTreatment.MakeImmediateSafe,
                    PreserveImportantComments = false,
                    LocalRenaming = LocalRenaming.KeepAll
                });
                if (minifier.ErrorList.Count > 0)
                    GenerateErrorResponse(response, minifier.ErrorList);
                else
                    response.Content = str;
            }
            response.ContentType = JsContentType;
        }
    }
}