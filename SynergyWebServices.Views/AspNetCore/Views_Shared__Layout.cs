using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf", "/Views/Shared/_Layout.cshtml")]
[RazorSourceChecksum("SHA1", "e9d8665dd09455b0012aeb8751e5996f289ea6d1", "/Views/_ViewImports.cshtml")]
public class Views_Shared__Layout : RazorPage<object>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("rel", new HtmlString("stylesheet"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("href", new HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("href", new HtmlString("~/css/site.css"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", new HtmlString("navbar-brand"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("asp-area", "", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("asp-controller", "Home", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("asp-action", "Index", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("class", new HtmlString("nav-link text-dark"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("asp-action", "Privacy", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("src", new HtmlString("~/lib/jquery/dist/jquery.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("src", new HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("src", "~/js/site.js", HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;

	private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

	private BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;

	private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;

	private ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;

	private TagHelperScopeManager __tagHelperScopeManager
	{
		get
		{
			if (__backed__tagHelperScopeManager == null)
			{
				__backed__tagHelperScopeManager = new TagHelperScopeManager(base.StartTagHelperWritingScope, base.EndTagHelperWritingScope);
			}
			return __backed__tagHelperScopeManager;
		}
	}

	[RazorInject]
	public IModelExpressionProvider ModelExpressionProvider { get; private set; }

	[RazorInject]
	public IUrlHelper Url { get; private set; }

	[RazorInject]
	public IViewComponentHelper Component { get; private set; }

	[RazorInject]
	public IJsonHelper Json { get; private set; }

	[RazorInject]
	public IHtmlHelper<dynamic> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf7780", async delegate
		{
			WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
			Write(base.ViewData["Title"]);
			WriteLiteral(" - SynergyWebServices</title>\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", TagMode.SelfClosing, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf8444", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", TagMode.SelfClosing, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf9622", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n");
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<HeadTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf11504", async delegate
		{
			WriteLiteral("\r\n    <header>\r\n        <nav class=\"navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3\">\r\n            <div class=\"container\">\r\n                ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf11960", async delegate
			{
				WriteLiteral("SynergyWebServices");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n                <button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\".navbar-collapse\" aria-controls=\"navbarSupportedContent\"\r\n                        aria-expanded=\"false\" aria-label=\"Toggle navigation\">\r\n                    <span class=\"navbar-toggler-icon\"></span>\r\n                </button>\r\n                <div class=\"navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse\">\r\n                    <ul class=\"navbar-nav flex-grow-1\">\r\n                        <li class=\"nav-item\">\r\n                            ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf14271", async delegate
			{
				WriteLiteral("Home");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n                        </li>\r\n                        <li class=\"nav-item\">\r\n                            ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf16110", async delegate
			{
				WriteLiteral("Privacy");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n                        </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </nav>\r\n    </header>\r\n    <div class=\"container\">\r\n        <main role=\"main\" class=\"pb-3\">\r\n            ");
			Write(RenderBody());
			WriteLiteral("\r\n        </main>\r\n    </div>\r\n\r\n    <footer class=\"border-top footer text-muted\">\r\n        <div class=\"container\">\r\n            &copy; 2020 - SynergyWebServices - ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf18494", async delegate
			{
				WriteLiteral("Privacy");
			});
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
			__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n        </div>\r\n    </footer>\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf20176", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf21276", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "f6c4ae6c7cd7247eaff8f117e570ad06d45e57cf22377", async delegate
			{
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<ScriptTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_11.Value;
			__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
			__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;
			__tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, HtmlAttributeValueStyle.DoubleQuotes);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n    ");
			Write(RenderSection("Scripts", required: false));
			WriteLiteral("\r\n");
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<BodyTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n</html>\r\n");
	}
}
