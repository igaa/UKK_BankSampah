#pragma checksum "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a645c0775cec96810ef299ebaa0098a761e7bc06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nasabah_Index), @"mvc.1.0.view", @"/Views/Nasabah/Index.cshtml")]
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
#line 1 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\_ViewImports.cshtml"
using KKN_UKK;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\_ViewImports.cshtml"
using KKN_UKK.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a645c0775cec96810ef299ebaa0098a761e7bc06", @"/Views/Nasabah/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5581b230c5aa0dfee7c15c182a91183a61ebfd63", @"/Views/_ViewImports.cshtml")]
    public class Views_Nasabah_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KKN_UKK.Models.Transaksi.T_TransaksiTimbangan>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\" style=\"width: auto;\">\r\n    <div class=\"card-header\">\r\n        <h4> Saldo: ");
#nullable restore
#line 10 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
               Write(ViewBag.Saldo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <br />\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <table class=\"table table-responsive table-striped\" id=\"Datatables\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 18 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 21 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.NamaNasabah));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 24 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Items));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 27 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 30 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.HargaSatuan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 33 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Qty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 36 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Unit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 39 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.TotalHarga));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 42 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 48 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 52 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 55 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NamaNasabah));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Items));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 64 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.HargaSatuan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 67 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Qty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Unit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TotalHarga));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 77 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n\r\n                </tr>\r\n");
#nullable restore
#line 82 "C:\Git\UKK_BankSampah\KKN_UKK\KKN_UKK\Views\Nasabah\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Script", async() => {
                WriteLiteral("\r\n    <script>\r\n    $(document).ready(function () {\r\n\r\n        $(\'#Datatables\').DataTable();\r\n    });\r\n    </script>\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KKN_UKK.Models.Transaksi.T_TransaksiTimbangan>> Html { get; private set; }
    }
}
#pragma warning restore 1591
