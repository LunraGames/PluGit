using UnityEngine;
using UnityEditor;

namespace LunraGames.PluGit
{
	public static class Settings
	{
		class Keys
		{
			const string Prefix = "LG_PluGit_";
			public const string AnyConfigEditingAllowed = Prefix + "AnyConfigEditingAllowed";
		}

		public static bool IsAnyConfigEditingAllowed 
		{ 
			get { return EditorPrefs.GetBool(Keys.AnyConfigEditingAllowed); }
			set { EditorPrefs.SetBool(Keys.AnyConfigEditingAllowed, value); }
		}
	}
}