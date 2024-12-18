using System.Diagnostics.CodeAnalysis;

namespace HelloMaui.Resources.Styles;

static class AppStyles
{
	public static bool TryGetResource<T>(string resourceName, [NotNullWhen(true)] out T? resource)
	{
		resource = default;
		
		if (Application.Current?.Resources.ContainsKey(resourceName) is true)
		{
			resource = (T)Application.Current.Resources[resourceName];
			return true;
		}

		foreach (var mergeDict in Application.Current?.Resources.MergedDictionaries ?? Array.Empty<ResourceDictionary>())
		{
			if (mergeDict.Keys.Contains(resourceName))
			{
				resource = (T)mergeDict[resourceName];
				return true;
			}
		}

		return false;
	}
}