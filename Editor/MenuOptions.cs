using UnityEditor;
using UnityEngine;
using System.IO;

namespace LunraGames.PlugIt
{
	public static class MenuOptions
	{
		[MenuItem("Assets/Create/PlugIt Plugin")]
		static void CreatePlugin()
		{
			var dir = SelectionExtensions.Directory();
			if (dir == null) 
			{
				EditorUtilityExtensions.DialogInvalid(Strings.Dialogs.Messages.SelectValidDirectory);
				return;
			}

			var config = ScriptableObject.CreateInstance<PluginConfig>();
			AssetDatabase.CreateAsset(config, Path.Combine(dir, Strings.Files.Plugin));
		}
	}
}