#pragma checksum "G:\Project\LearnCsharpWithXT\Theory\Bai50_RazorPages\Pages\FirstPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b198f36baa69bbaa52fdf429f810536316e7855"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_FirstPage), @"mvc.1.0.razor-page", @"/Pages/FirstPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/trang-dau-tien2/{abc:int?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b198f36baa69bbaa52fdf429f810536316e7855", @"/Pages/FirstPage.cshtml")]
    public class Pages_FirstPage : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Google.com", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<h1>Đây là trang wb đầu tiên</h1>\r\n<p>Hoc Lap trinh ASP.NET Core (<strong>");
#nullable restore
#line 6 "G:\Project\LearnCsharpWithXT\Theory\Bai50_RazorPages\Pages\FirstPage.cshtml"
                                  Write(System.DateTime.Now);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>)\r\n");
#nullable restore
#line 7 "G:\Project\LearnCsharpWithXT\Theory\Bai50_RazorPages\Pages\FirstPage.cshtml"
  
    var a = 2 ;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p> căn bật hai cua ");
#nullable restore
#line 9 "G:\Project\LearnCsharpWithXT\Theory\Bai50_RazorPages\Pages\FirstPage.cshtml"
                   Write(a);

#line default
#line hidden
#nullable disable
            WriteLiteral(" la ");
#nullable restore
#line 9 "G:\Project\LearnCsharpWithXT\Theory\Bai50_RazorPages\Pages\FirstPage.cshtml"
                         Write(Math.Sqrt(a));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> \r\n");
#nullable restore
#line 10 "G:\Project\LearnCsharpWithXT\Theory\Bai50_RazorPages\Pages\FirstPage.cshtml"
                                               
    var showMess  = this.Request.RouteValues["abc"];

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 12 "G:\Project\LearnCsharpWithXT\Theory\Bai50_RazorPages\Pages\FirstPage.cshtml"
  Write(showMess);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b198f36baa69bbaa52fdf429f810536316e78554509", async() => {
                WriteLiteral("click");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_FirstPage> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_FirstPage> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_FirstPage>)PageContext?.ViewData;
        public Pages_FirstPage Model => ViewData.Model;
    }
}
#pragma warning restore 1591