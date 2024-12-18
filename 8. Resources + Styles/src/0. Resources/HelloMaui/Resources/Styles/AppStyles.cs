using System.Diagnostics.CodeAnalysis;

namespace HelloMaui.Resources.Styles;

static class AppStyles
{
	public static T GetResource<T>(string resourceName)
	{
		if (Application.Current?.Resources.TryGetValue(resourceName, out var resource) is true)
		{
			return (T)resource;
		}

		throw new KeyNotFoundException($"Resource {resourceName} Not Found");
	}
}