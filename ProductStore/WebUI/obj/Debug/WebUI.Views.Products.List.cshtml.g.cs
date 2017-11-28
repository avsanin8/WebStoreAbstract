#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebUI.Views.Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using ServiceStack;
    using ServiceStack.Html;
    using ServiceStack.OrmLite;
    using ServiceStack.Razor;
    using ServiceStack.Text;
    using WebUI;
    
    #line 1 "I:\_GitHub\WebStoreAbstract\ProductStore\WebUI\\Views\Products\List.cshtml"
    using WebUI.Models;
    
    #line default
    #line hidden
    using WebUI.ServiceModel;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "4.5.14.0")]
    [ServiceStack.Razor.Compilation.CodeTransformers.VirtualPathAttribute("~/Views/Products/List.cshtml")]
    public partial class @__List : ServiceStack.Razor.ViewPage<ProductsListViewModel>
    {
        public @__List()
        {
        }
        public override void Execute()
        {
            
            #line 4 "I:\_GitHub\WebStoreAbstract\ProductStore\WebUI\\Views\Products\List.cshtml"
  
    ViewBag.Title = "List of Products";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "I:\_GitHub\WebStoreAbstract\ProductStore\WebUI\\Views\Products\List.cshtml"
 foreach (var p in Model.Products)
{
    
            
            #line default
            #line hidden
            
            #line 10 "I:\_GitHub\WebStoreAbstract\ProductStore\WebUI\\Views\Products\List.cshtml"
Write(Html.Partial("_ProductSummary", p));

            
            #line default
            #line hidden
            
            #line 10 "I:\_GitHub\WebStoreAbstract\ProductStore\WebUI\\Views\Products\List.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 10 "I:\_GitHub\WebStoreAbstract\ProductStore\WebUI\\Views\Products\List.cshtml"
                                                                                                        
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"btn-group pull-right\"");

WriteLiteral(">\r\n    <h4>\r\n");

WriteLiteral("        ");

            
            #line 15 "I:\_GitHub\WebStoreAbstract\ProductStore\WebUI\\Views\Products\List.cshtml"
   Write(Html.PageLinks(Model.PagingInfo, x => Url.Action("List", new { page = x, categ = Model.CurrentCategory })));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </h4>\r\n</div>");

        }
    }
}
#pragma warning restore 1591