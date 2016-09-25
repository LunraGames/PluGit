using UnityEditor;
using UnityEngine;
using System.IO;

namespace LunraGames.PluGit
{
	public static class MenuOptions
	{
		[MenuItem("Assets/Create/PluGit Plugin")]
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