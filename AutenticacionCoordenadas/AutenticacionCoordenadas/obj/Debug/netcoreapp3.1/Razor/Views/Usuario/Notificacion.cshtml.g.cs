#pragma checksum "C:\Users\hp\Documents\Github\TarjetaCoordenadas\AutenticacionCoordenadas\AutenticacionCoordenadas\Views\Usuario\Notificacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebe5faa4af8d19d8af37d0671994125ec4da40c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Notificacion), @"mvc.1.0.view", @"/Views/Usuario/Notificacion.cshtml")]
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
#line 1 "C:\Users\hp\Documents\Github\TarjetaCoordenadas\AutenticacionCoordenadas\AutenticacionCoordenadas\Views\_ViewImports.cshtml"
using AutenticacionCoordenadas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\Documents\Github\TarjetaCoordenadas\AutenticacionCoordenadas\AutenticacionCoordenadas\Views\_ViewImports.cshtml"
using AutenticacionCoordenadas.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebe5faa4af8d19d8af37d0671994125ec4da40c0", @"/Views/Usuario/Notificacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8d861901df49012d2ba3bcbc1aaef490c094626", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Notificacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div>
    <a class=""ui-btn ui-shadow ui-corner-all ui-btn-inline ui-mini"" style=""float:right"">Bienvenido: Usuario</a>
</div>

<div class=""container p-3 my-3 text-black-50"" style=""background-color: #ffffff;"">
    <h1>Notificaciones:</h1>

    <div class=""table-responsive"">
        <table class=""table"" id=""table"">
            <tr>
                <th>Mensaje</th>
                <th>Fecha</th>
            </tr>

            <tr>
                <td>Su tarjeta ha sido asignada</td>
                <td>21-12-21</td>
            </tr>

            <tr>
                <td>Su tarjeta ha sido desbloqueada</td>
                <td>30-12-21</td>
            </tr>

        </table>
    </div>
</div>

<div class=""container"">
    <div class=""row"">
        <div class=""col-xl-3"">
            <div class=""modal fade"" id=""modalN"">
                <div class=""modal-dialog modal-lg"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
          ");
            WriteLiteral(@"                  <button type=""button"" class=""close"" data-dismiss=""modal"">
                                x
                            </button>
                        </div>
                        <div class=""modal-body"">
                             <div class=""text-center"">
                              <input type=""submit"" value=""Borrar notificación"" class=""btn btn-primary"" style=""background-color: #005cb9; width: 200px;"" />
                             </div>
                        </div>
                        <div class=""modal-footer"">

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>


<script>

    var table = document.getElementById('table');

    for (var i = 1; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            //rIndex = this.rowIndex;
            // alert(this.cells[0].innerHTML);
           // alert(""Borrar"");
            $(""#modalN"").mod");
            WriteLiteral("al(\'show\');\r\n        };\r\n    }\r\n\r\n\r\n</script>");
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
