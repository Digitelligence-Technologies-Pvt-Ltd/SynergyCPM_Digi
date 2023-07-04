using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCore;

[RazorSourceChecksum("SHA1", "7091c65830b0329e613be026ede8a57552863778", "/Views/_ViewStart.cshtml")]
[RazorSourceChecksum("SHA1", "e9d8665dd09455b0012aeb8751e5996f289ea6d1", "/Views/_ViewImports.cshtml")]
public class Views__ViewStart : RazorPage<object>
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
		base.Layout = "_Layout";
	}
}
