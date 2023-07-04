using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "d8ddb6bffa5a9b264bf8f89038bf03c234083fd3", "/Views/Home/Privacy.cshtml")]
[RazorSourceChecksum("SHA1", "e9d8665dd09455b0012aeb8751e5996f289ea6d1", "/Views/_ViewImports.cshtml")]
public class Views_Home_Privacy : RazorPage<object>
{
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
		base.ViewData["Title"] = "Privacy Policy";
		WriteLiteral("<h1>");
		Write(base.ViewData["Title"]);
		WriteLiteral("</h1>\r\n\r\n<p>Use this page to detail your site's privacy policy.</p>\r\n");
	}
}
