#pragma checksum "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0604b1c18709e265642a012fe311be0787d616da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Privacy.cshtml", typeof(AspNetCore.Views_Home_Privacy))]
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
#line 1 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\_ViewImports.cshtml"
using DiasApp;

#line default
#line hidden
#line 2 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\_ViewImports.cshtml"
using DiasApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0604b1c18709e265642a012fe311be0787d616da", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8765f42badeacd9742001cf85e4aa3f36c145ad", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
            BeginContext(50, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(55, 17, false);
#line 4 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(72, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 5 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
 if (TempData["UserState"] != null && TempData["AuthInfo"] != null)
{

#line default
#line hidden
            BeginContext(151, 16, true);
            WriteLiteral("    <h3>You are ");
            EndContext();
            BeginContext(168, 21, false);
#line 7 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
           Write(TempData["UserState"]);

#line default
#line hidden
            EndContext();
            BeginContext(189, 2, true);
            WriteLiteral("! ");
            EndContext();
            BeginContext(192, 20, false);
#line 7 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
                                   Write(TempData["AuthInfo"]);

#line default
#line hidden
            EndContext();
            BeginContext(212, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 8 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
}
else
{
    if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
            BeginContext(278, 38, true);
            WriteLiteral("        <h3>You are authorized!</h3>\r\n");
            EndContext();
#line 14 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(340, 42, true);
            WriteLiteral("        <h3>You are not authorized!</h3>\r\n");
            EndContext();
#line 18 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
    }
}

#line default
#line hidden
            BeginContext(392, 25, true);
            WriteLiteral("<hr />\r\n<h3>Your status: ");
            EndContext();
            BeginContext(418, 12, false);
#line 21 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
            Write(ViewBag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(430, 29, true);
            WriteLiteral("!</h3>\r\n<h3>Last entry time: ");
            EndContext();
            BeginContext(460, 12, false);
#line 22 "C:\Users\Dias\source\repos\DiasApp\DiasApp\Views\Home\Privacy.cshtml"
                Write(ViewBag.Time);

#line default
#line hidden
            EndContext();
            BeginContext(472, 69, true);
            WriteLiteral("</h3>\r\n\r\n<p>Use this page to detail your site\'s privacy policy.</p>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
