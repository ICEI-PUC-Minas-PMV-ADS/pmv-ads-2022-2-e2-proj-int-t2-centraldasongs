#pragma checksum "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff6101c6f5b4f5320c6f37256bd4c8bf2681d736"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserVoluntarioModel_Details), @"mvc.1.0.view", @"/Views/UserVoluntarioModel/Details.cshtml")]
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
#line 1 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/_ViewImports.cshtml"
using CentralDasOngs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/_ViewImports.cshtml"
using CentralDasOngs.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff6101c6f5b4f5320c6f37256bd4c8bf2681d736", @"/Views/UserVoluntarioModel/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9241e69825c6d7107a62c8a970ea136cbedf5681", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_UserVoluntarioModel_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CentralDasOngs.Models.UserVoluntarioModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Details</h1>\n\n<div>\n    <h4>UserVoluntarioModel</h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 14 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 17 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 20 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateBirthDay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 23 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.DateBirthDay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 26 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 29 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 32 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 35 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 38 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Contact));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 41 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.Contact));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n    </dl>\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 46 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdressModel.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 49 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.AdressModel.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 52 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdressModel.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 55 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.AdressModel.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 58 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdressModel.District));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 61 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.AdressModel.District));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 64 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdressModel.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 67 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.AdressModel.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 70 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdressModel.HouseNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 73 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.AdressModel.HouseNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 76 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AdressModel.Complement));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 79 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
       Write(Html.DisplayFor(model => model.AdressModel.Complement));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n    </dl>\n\n</div>\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff6101c6f5b4f5320c6f37256bd4c8bf2681d73613326", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
                           WriteLiteral(Model.Cpf);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff6101c6f5b4f5320c6f37256bd4c8bf2681d73615506", async() => {
                WriteLiteral("Deletar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "/Users/outrogato/Documents/pmv-ads-2022-2-e2-proj-int-t2-centraldasongs/src/CentralDasOngs/CentralDasOngs/Views/UserVoluntarioModel/Details.cshtml"
                             WriteLiteral(Model.Cpf);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff6101c6f5b4f5320c6f37256bd4c8bf2681d73617689", async() => {
                WriteLiteral("Voltar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CentralDasOngs.Models.UserVoluntarioModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
