using UnityEditor;
using UnityEngine;
using System.IO;
using LunraGames.PlugIt;

namespace LunraGamesEditor.PlugIt
{
	public static class MenuOptions
	{
#if PLUGIT_DEV
		[MenuItem("Assets/Create/PlugIt Plugin")]
#endif
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