#pragma checksum "G:\Project\LearnCsharpWithXT\Theory\Bai033_WebASP_USING_DI\Views\Home\ProductInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cb60cdf4d6e1fc07888ff7ac5381919d805b81e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductInfo), @"mvc.1.0.view", @"/Views/Home/ProductInfo.cshtml")]
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
#line 1 "G:\Project\LearnCsharpWithXT\Theory\Bai033_WebASP_USING_DI\Views\_ViewImports.cshtml"
using Bai033_WebASP_USING_DI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Project\LearnCsharpWithXT\Theory\Bai033_WebASP_USING_DI\Views\_ViewImports.cshtml"
using Bai033_WebASP_USING_DI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cb60cdf4d6e1fc07888ff7ac5381919d805b81e", @"/Views/Home/ProductInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a6482545e59e4f969b8d3df0c090bf2288e2db3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>thông tin sản phẩm</h1>\r\n");
#nullable restore
#line 3 "G:\Project\LearnCsharpWithXT\Theory\Bai033_WebASP_USING_DI\Views\Home\ProductInfo.cshtml"
 if(Model == null){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\">không tìm thấy sản phẩm</div>\r\n");
#nullable restore
#line 5 "G:\Project\LearnCsharpWithXT\Theory\Bai033_WebASP_USING_DI\Views\Home\ProductInfo.cshtml"
}else{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n            <p><strong>");
#nullable restore
#line 8 "G:\Project\LearnCsharpWithXT\Theory\Bai033_WebASP_USING_DI\Views\Home\ProductInfo.cshtml"
                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n            <p>Sản Phẩm có giá: ");
#nullable restore
#line 9 "G:\Project\LearnCsharpWithXT\Theory\Bai033_WebASP_USING_DI\Views\Home\ProductInfo.cshtml"
                           Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 12 "G:\Project\LearnCsharpWithXT\Theory\Bai033_WebASP_USING_DI\Views\Home\ProductInfo.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
