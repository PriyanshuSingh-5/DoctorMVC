#pragma checksum "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3089d531315892fae9c77db617ba087429d68d34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_GetAllAppointment), @"mvc.1.0.view", @"/Views/Doctor/GetAllAppointment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3089d531315892fae9c77db617ba087429d68d34", @"/Views/Doctor/GetAllAppointment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6eb80b6f1df4e69c8a1f84d5484bbaae66773e62", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_GetAllAppointment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CommonLayer.Models.AppointmentModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml"
  
    ViewData["Title"] = "GetAllAppointment";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetAllAppointment</h1>\r\n\r\n");
#nullable restore
#line 55 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml"
 foreach (var item in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-4 mt-3\">\r\n\r\n        <div class=\"card\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1825, "\"", 1916, 1);
#nullable restore
#line 61 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml"
WriteAttributeValue("", 1832, Url.Action("UpdatetAppointmentByDocID", "Doctor", new { DoctorID = item.DoctorID }), 1832, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"card-header\">\r\n                    <h3>");
#nullable restore
#line 63 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml"
                   Write(item.Concerns);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    <p>");
#nullable restore
#line 66 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml"
                  Write(item.Appointmentdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>");
#nullable restore
#line 67 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml"
                  Write(item.StartTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>");
#nullable restore
#line 68 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml"
                  Write(item.EndTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 114 "C:\Users\Admin\source\repos\DoctorListMVCApp\DoctorListMVCApp\Views\Doctor\GetAllAppointment.cshtml"
               
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CommonLayer.Models.AppointmentModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
