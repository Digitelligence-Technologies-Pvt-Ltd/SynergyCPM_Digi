using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SynergyWebServices.Service;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter, IFilterMetadata
{
	public void OnResourceExecuting(ResourceExecutingContext context)
	{
		IList<IValueProviderFactory> factories = context.ValueProviderFactories;
		factories.RemoveType<FormValueProviderFactory>();
		factories.RemoveType<JQueryFormValueProviderFactory>();
	}

	public void OnResourceExecuted(ResourceExecutedContext context)
	{
	}
}
