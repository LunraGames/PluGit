using System.IO;
using UnityEditor;
using UnityEngine;

namespace LunraGames.PluGit
{
	[CustomEditor(typeof(PluginConfig), true)]
	public class PluginConfigEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			var config = (PluginConfig)target;

			if (config.Initialized) DrawInitialized(config);
			else DrawUninitialized(config);
		}

		void DrawUninitialized(PluginConfig config)
		{
			if (GUILayout.Button("Initialize Plugin"))
			{
				var projectCompanyNotConfigured = StringExtensions.IsNullOrWhiteSpace(PlayerSettings.companyName);

				if (projectCompanyNotConfigured) Initialize(config);
				else
				{
					EditorUtilityExtensions.YesNoCancelDialog(
						"Initial Plugin Configuration",
						"Would you like to use the details from player settings to initialize this configuration?",
						() => Initialize(config, PlayerSettings.companyName),
						() => Initialize(config)
					);
				}
			}
		}

		void DrawInitialized(PluginConfig config)
		{
			var editingAllowed = Settings.IsAnyConfigEditingAllowed || PlayerSettings.companyName == config.CompanyName;

			if (!editingAllowed) EditorGUILayout.HelpBox("This configuration's company does not match your project's company, barring you from modifying it. To edit this configuration, change your PluGit preferences.", MessageType.Info);

			GUI.enabled = editingAllowed;
			DrawDefaultInspector();

			EditorGUILayout.LabelField("Feedback Url");

			config.AutomatedFormat = (AutomatedFormats)EditorGUILayoutExtensions.HelpfulEnumPopup("Select a format for automatic feedback...", config.AutomatedFormat);
			if (config.AutomatedFormat != AutomatedFormats.Custom) return;

			foreach (var block in UrlPropertyBlock.All)
			{
				var isUsed = config.FeedbackUrl.Contains(block.Tag);
				GUI.color = isUsed ? Color.green : Color.yellow;
				EditorGUILayout.LabelField(new GUIContent(block.Name, block.Description), new GUIContent(block.Tag, block.Description));
				GUI.color = Color.white;
			}

			config.FeedbackUrl = EditorGUILayout.TextArea(config.FeedbackUrl);

			GUILayout.BeginHorizontal();
			{
				GUILayout.FlexibleSpace();
				if (GUILayout.Button("Test Feedback", GUILayout.Width(128f)))
				{
					System.Diagnostics.Process.Start(new UrlBlock(config.FeedbackUrl, config.AutomatedEntries).Formatted);
				}
			}
			GUILayout.EndHorizontal();
		}

		#region Initializiation
		void Initialize(PluginConfig config, string companyName = "")
		{
			config.Initialized = true;
			config.CompanyName = companyName;
			EditorUtility.SetDirty(config);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}
		#endregion
	}
}