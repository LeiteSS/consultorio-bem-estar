#pragma checksum "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e4378faa279cc100f7523a42b1828620a54cd36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consulta_Index), @"mvc.1.0.view", @"/Views/Consulta/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\_ViewImports.cshtml"
using medico.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\_ViewImports.cshtml"
using medico.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e4378faa279cc100f7523a42b1828620a54cd36", @"/Views/Consulta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32b718170826fa7824b286f509df8d4335c9cbd3", @"/Views/_ViewImports.cshtml")]
    public class Views_Consulta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<medico.web.Models.Consulta>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml"
  
    ViewData["Title"] = "Consultas";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Consultas</h1>\r\n\r\n\r\n");
#nullable restore
#line 10 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml"
 foreach (var consulta in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <h4 class=\"card-title\">Consulta</h4>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <p class=\"card-text\">");
#nullable restore
#line 18 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml"
                            Write(Html.DisplayFor(modelItem => consulta.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"card-footer\">\r\n            <p class=\"card-text\">");
#nullable restore
#line 21 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml"
                            Write(Html.DisplayFor(modelItem => consulta.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"card-text\">");
#nullable restore
#line 22 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml"
                            Write(Html.DisplayFor(modelItem => consulta.TransacaoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <button class=\"btn\">\r\n                ");
#nullable restore
#line 24 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml"
           Write(Html.ActionLink("Detalhar", "Detalhar", new { /*id = consulta.Id*/ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 25 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml"
           Write(Html.ActionLink("Iniciar", "Iniciar", new { /*id = consulta.Id*/ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n            </button>\r\n        </div>\r\n    </div>\r\n    <br />\r\n");
#nullable restore
#line 30 "C:\Users\bigch\workspace\Projeto-PIM\frontend\medico.web\Views\Consulta\Index.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<medico.web.Models.Consulta>> Html { get; private set; }
    }
}
#pragma warning restore 1591
