#pragma checksum "/home/codio/workspace/crimes/Views/GetArea.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a26a8c96b018f4fde5b3455a28c5baca25d36b37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(crimes.Pages.Views_GetArea), @"mvc.1.0.razor-page", @"/Views/GetArea.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Views/GetArea.cshtml", typeof(crimes.Pages.Views_GetArea), null)]
namespace crimes.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/codio/workspace/crimes/Views/_ViewImports.cshtml"
using crimes;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a26a8c96b018f4fde5b3455a28c5baca25d36b37", @"/Views/GetArea.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f842f8255da31aa43ed40deaf7f18adbc89934f4", @"/Views/_ViewImports.cshtml")]
    public class Views_GetArea : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
  
  ViewData["Title"] = "Area Information";

#line default
#line hidden
            BeginContext(73, 63, true);
            WriteLiteral("\n<h2>Top-10 Crimes in area</h2>  \n\n<br />\nYour search string: \"");
            EndContext();
            BeginContext(137, 11, false);
#line 10 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
                Write(Model.Input);

#line default
#line hidden
            EndContext();
            BeginContext(148, 22, true);
            WriteLiteral("\"\n<br />\nArea Name:   ");
            EndContext();
            BeginContext(171, 12, false);
#line 12 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
        Write(Model.arName);

#line default
#line hidden
            EndContext();
            BeginContext(183, 22, true);
            WriteLiteral(" \n<br />\nArea Number: ");
            EndContext();
            BeginContext(206, 11, false);
#line 14 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
        Write(Model.arNum);

#line default
#line hidden
            EndContext();
            BeginContext(217, 15, true);
            WriteLiteral("\n<br />\n<br />\n");
            EndContext();
#line 17 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
  
   if (@Model.EX != null)
	 {

#line default
#line hidden
            BeginContext(265, 16, true);
            WriteLiteral("\t\t <h3>**ERROR: ");
            EndContext();
            BeginContext(282, 16, false);
#line 20 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
                 Write(Model.EX.Message);

#line default
#line hidden
            EndContext();
            BeginContext(298, 46, true);
            WriteLiteral("</h3>\n\t\t <br />\n\t\t <hr />\n\t\t <br />\n\t\t <br />\n");
            EndContext();
#line 25 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
	 }

#line default
#line hidden
            BeginContext(350, 518, true);
            WriteLiteral(@"
<table class=""table"">  
    <thead>  
        <tr>  
            <th>  
                IUCR
            </th>  
            <th>  
                PrimaryDesc 
            </th>  
            <th>  
                SecondaryDesc
            </th>  
            <th>  
                numTimes
            </th>  
             <th>  
                percent area's Crime
            </th>  
             <th>  
                arrest Rate
            </th>  
        </tr>  
            
    </thead>  
    <tbody>  
");
            EndContext();
#line 53 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
          foreach (var item in Model.CrimeList)  
        {  

#line default
#line hidden
            BeginContext(930, 63, true);
            WriteLiteral("            <tr>   \n                <td>  \n                    ");
            EndContext();
            BeginContext(994, 9, false);
#line 57 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
               Write(item.IUCR);

#line default
#line hidden
            EndContext();
            BeginContext(1003, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1072, 16, false);
#line 60 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
               Write(item.PrimaryDesc);

#line default
#line hidden
            EndContext();
            BeginContext(1088, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1157, 18, false);
#line 63 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
               Write(item.SecondaryDesc);

#line default
#line hidden
            EndContext();
            BeginContext(1175, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1244, 13, false);
#line 66 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
               Write(item.numTimes);

#line default
#line hidden
            EndContext();
            BeginContext(1257, 68, true);
            WriteLiteral("\n                </td>  \n                <td>  \n                    ");
            EndContext();
            BeginContext(1326, 19, false);
#line 69 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
               Write(item.percentChicago);

#line default
#line hidden
            EndContext();
            BeginContext(1345, 66, true);
            WriteLiteral("\n                </td>\n                <td>  \n                    ");
            EndContext();
            BeginContext(1412, 15, false);
#line 72 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
               Write(item.arrestRate);

#line default
#line hidden
            EndContext();
            BeginContext(1427, 43, true);
            WriteLiteral("\n                </td>\n            </tr>  \n");
            EndContext();
#line 75 "/home/codio/workspace/crimes/Views/GetArea.cshtml"
						
        }  

#line default
#line hidden
            BeginContext(1489, 26, true);
            WriteLiteral("    </tbody>  \n</table> \n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GetAreaModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GetAreaModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GetAreaModel>)PageContext?.ViewData;
        public GetAreaModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
