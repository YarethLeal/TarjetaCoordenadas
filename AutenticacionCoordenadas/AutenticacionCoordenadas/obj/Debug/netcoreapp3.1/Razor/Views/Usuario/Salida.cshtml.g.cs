#pragma checksum "C:\Users\Lenovo\Documents\GitHub\TarjetaCoordenadas\AutenticacionCoordenadas\AutenticacionCoordenadas\Views\Usuario\Salida.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ac01c6dd029466cacfcb8a78b28b6b9b0f87451"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Salida), @"mvc.1.0.view", @"/Views/Usuario/Salida.cshtml")]
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
#line 1 "C:\Users\Lenovo\Documents\GitHub\TarjetaCoordenadas\AutenticacionCoordenadas\AutenticacionCoordenadas\Views\_ViewImports.cshtml"
using AutenticacionCoordenadas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\Documents\GitHub\TarjetaCoordenadas\AutenticacionCoordenadas\AutenticacionCoordenadas\Views\_ViewImports.cshtml"
using AutenticacionCoordenadas.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ac01c6dd029466cacfcb8a78b28b6b9b0f87451", @"/Views/Usuario/Salida.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8d861901df49012d2ba3bcbc1aaef490c094626", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Salida : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\r\n    <a class=\"ui-btn ui-shadow ui-corner-all ui-btn-inline ui-mini\" style=\"float:right\">Bienvenido: Usuario</a>\r\n</div>\r\n<div class=\"d-flex justify-content-center btn-group-vertical\">\r\n\r\n    <p style=\"font-size:34px\">");
#nullable restore
#line 6 "C:\Users\Lenovo\Documents\GitHub\TarjetaCoordenadas\AutenticacionCoordenadas\AutenticacionCoordenadas\Views\Usuario\Salida.cshtml"
                         Write(ViewBag.Salida);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n</div>");
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
