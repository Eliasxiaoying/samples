using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _17_ModelBindSample.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _17_ModelBindSample.ModelBinders;

public class GeolocationModelBinder : IModelBinder
{
	public Task BindModelAsync(ModelBindingContext bindingContext)
	{
		if (bindingContext == null)
		{
			throw new ArgumentNullException(nameof(bindingContext));
		}

		var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
		if (valueResult == ValueProviderResult.None)
		{
			bindingContext.Result = ModelBindingResult.Failed();
			return Task.CompletedTask;
		}

		var modelValue = valueResult.FirstValue;
		if (!Regex.IsMatch(modelValue, @"\d+(.\d{1,4}),\d+(.\d{1,4})"))
		{
			bindingContext.Result = ModelBindingResult.Failed();
			return Task.CompletedTask;
		}

		var strValues = modelValue.Split(',');
		var values = Array.ConvertAll(strValues, Convert.ToDouble);
		var geo = new Geolocation(values[0], values[1]);
		bindingContext.Result = ModelBindingResult.Success(geo);
		return Task.CompletedTask;
	}
}