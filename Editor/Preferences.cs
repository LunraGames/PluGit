using UnityEngine;
using System.Collections;
using UnityEditor;

namespace LunraGames.PlugIt
{
	public static class Preferences
	{
		[PreferenceItem("PlugIt")]
		static void OnGUI()
		{
			Settings.IsAnyConfigEditingAllowed = EditorGUILayout.Toggle(
				new GUIContent("Allow Editing of Any Configurations", "If enabled, you can edit other companies configuration files. Only use this option if you know what you're doing!"), 
				Settings.IsAnyConfigEditingAllowed
			);
		}
	}
}
