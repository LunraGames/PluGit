using System;

namespace LunraGames.PlugIt
{
	[Serializable]
	public struct UrlPropertyBlock
	{
		public static UrlPropertyBlock AutomatedFeedback { get { return new UrlPropertyBlock("Automated Feedback", "automated"); } }
		public static UrlPropertyBlock CompanyName { get { return new UrlPropertyBlock("Company Name", "company"); } }
		public static UrlPropertyBlock PluginName { get { return new UrlPropertyBlock("Plugin Name", "plugin"); } }
		public static UrlPropertyBlock Version { get { return new UrlPropertyBlock("Version", "version"); } }

		public static UrlPropertyBlock[] All { get { return new UrlPropertyBlock[] { CompanyName, PluginName, Version }; } }

		public string Name;
		public string Tag;
		public string Description;

		UrlPropertyBlock(string name, string tagContent, string description = "")
		{
			Name = name;
			Tag = "<"+tagContent+">";
			Description = description;
		}
	}
}