using UnityEditor;
using UnityEngine;
using System.IO;

namespace LunraGames.PluGit
{
	public static class MenuOptions
	{
		[MenuItem("Assets/Create/PluGit/Create Company")]
		static void CreateCompany()
		{
			var dir = SelectionExtensions.Directory();
			if (dir == null) 
			{
				EditorUtilityExtensions.DialogInvalid(Strings.SelectValidDirectory);
				return;
			}

			var config = ScriptableObject.CreateInstance<CompanyConfig>();
			AssetDatabase.CreateAsset(config, Path.Combine(dir, Strings.Files.Company));
		}

		[MenuItem("Assets/Create/PluGit/Create Plugin")]
		static void CreatePlugin()
		{
			var dir = SelectionExtensions.Directory();
			if (dir == null)
			{
				EditorUtilityExtensions.DialogInvalid(Strings.SelectValidDirectory);
				return;
			}

			var config = ScriptableObject.CreateInstance<PluginConfig>();
			AssetDatabase.CreateAsset(config, Path.Combine(dir, Strings.Files.Plugin));
		}
	}
}