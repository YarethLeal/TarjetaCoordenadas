#pragma checksum "C:\Users\hp\Documents\Github\TarjetaCoordenadas\AutenticacionCoordenadas\AutenticacionCoordenadas\Views\Administrador\BuscarOficina.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aaf4e84bd72a334cb11b68886f50a3b61273998b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrador_BuscarOficina), @"mvc.1.0.view", @"/Views/Administrador/BuscarOficina.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaf4e84bd72a334cb11b68886f50a3b61273998b", @"/Views/Administrador/BuscarOficina.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8d861901df49012d2ba3bcbc1aaef490c094626", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrador_BuscarOficina : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administrador", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ActualizaOficina", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\r\n    <a class=\"ui-btn ui-shadow ui-corner-all ui-btn-inline ui-mini\" style=\"float:right\">Bienvenido: Usuario</a>\r\n</div>\r\n<div class=\"d-flex justify-content-center\">\r\n\r\n    <div>\r\n        <p style=\"font-size:19px\">Buscar Oficina</p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaf4e84bd72a334cb11b68886f50a3b61273998b4638", async() => {
                WriteLiteral(@"

            <div class=""form-group w-100"">
                <label class=""control-label"">Nombre de oficina:</label>
                <input class=""form-control"" required/>
            </div>


            <div class=""text-center"">
                <input type=""submit"" value=""Buscar"" class=""btn btn-primary"" style=""background-color: #005cb9;"" />
                <input type=""submit"" value=""Cancelar"" class=""btn btn-primary"" style=""background-color: #005cb9;"" />

            </div>
");
                WriteLiteral("        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


    </div>
</div>

<div class=""container p-3 my-3 text-black-50"" style=""background-color: #ffffff;"">
    <h1>Oficinas:</h1>

    <div class=""table-responsive"">
        <table class=""table"" id=""table"">
            <tr>
                <th>Código</th>
                <th>Nombre</th>
                <th>Usuario</th>
                <th>Institución</th>
            </tr>

            <tr>
                <td>OF01</td>
                <td>Oficina1</td>
                <td>Usuario1</td>
                <td>OIJ</td>
            </tr>

            <tr>
                <td>OF02</td>
                <td>Oficina2</td>
                <td>Usuario2</td>
                <td>OIJ</td>
            </tr>

        </table>
    </div>
</div>

<div class=""container"">
    <div class=""row"">
        <div class=""col-xl-3"">
            <div class=""modal fade"" id=""modalC"">
                <div class=""modal-dialog modal-lg"">
                    <div class=""modal-content"">
                    ");
            WriteLiteral(@"    <div class=""modal-header"">
                            <button type=""button"" class=""close"" data-dismiss=""modal"">
                                x
                            </button>
                        </div>
                        <div class=""modal-body"">
                            <div class=""text-center"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaf4e84bd72a334cb11b68886f50a3b61273998b7878", async() => {
                WriteLiteral("\r\n                                    <input type=\"submit\" value=\"Actualizar Oficina\" class=\"btn btn-primary\" style=\"background-color: #005cb9; width: 200px;\" />\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                <br />
                                <input type=""submit"" value=""Borrar Oficina"" class=""btn btn-primary"" style=""background-color: #005cb9; width: 200px;"" />

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
           // rIndex = this.rowIndex;
           // alert(this.cells[0].innerHTML);
           //alert(""Borrar"");
            $(""#modalC"").modal('show');
        };
    }


</script>");
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
