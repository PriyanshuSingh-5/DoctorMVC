#pragma checksum "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "576e9c0dc26c43fbab41c8b4edb3c356e15f80b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_GetDocDetails), @"mvc.1.0.view", @"/Views/Doctor/GetDocDetails.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\_ViewImports.cshtml"
using DoctorListMVCApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\_ViewImports.cshtml"
using DoctorListMVCApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"576e9c0dc26c43fbab41c8b4edb3c356e15f80b2", @"/Views/Doctor/GetDocDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6eb80b6f1df4e69c8a1f84d5484bbaae66773e62", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_GetDocDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CommonLayer.Models.UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
  
    ViewData["Title"] = "GetDocDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetDocDetails</h1>\r\n\r\n<div>\r\n    <h4>UserModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.UserID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.UserID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.EmailID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.EmailID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ContactNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.ContactNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.RoleID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.RoleID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.IsAccepted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.IsAccepted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.CreatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedAt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 70 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetDocDetails.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "576e9c0dc26c43fbab41c8b4edb3c356e15f80b210237", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CommonLayer.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591