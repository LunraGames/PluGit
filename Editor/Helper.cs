using UnityEditor;
using LunraGames.PlugIt;

namespace LunraGamesEditor.PlugIt
{
	public static class Helper
	{
		static PluginConfig GetConfig(string company, string plugin)
		{
			var guids = AssetDatabase.FindAssets("t:" + typeof(PluginConfig).Name);
			foreach (var guid in guids)
			{
				var instance = AssetDatabase.LoadAssetAtPath<PluginConfig>(AssetDatabase.GUIDToAssetPath(guid));
				if (instance.CompanyName == company && instance.PluginName == plugin) return instance;
			}
			return null;
		}

		public static void LaunchFeedback(string company, string plugin)
		{
			var config = GetConfig(company, plugin);

			if (config == null) EditorUtilityExtensions.DialogError("How embarrassing, it looks like the plugin you're trying to provide feedback for is missing or misconfigured!");
			else System.Diagnostics.Process.Start(new UrlBlock(config.FeedbackUrl, config.AutomatedEntries).Formatted);
		}
	}
}