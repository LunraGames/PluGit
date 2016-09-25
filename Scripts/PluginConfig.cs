using UnityEngine;

namespace LunraGames.PlugIt
{
	public class PluginConfig : ScriptableObject
	{
		[HideInInspector]
		public bool Initialized;
		[HideInInspector]
		public string FeedbackUrl;
		[HideInInspector]
		public AutomatedFormats AutomatedFormat;

		public string CompanyName;
		public string PluginName;
		public string Version;
		public string Website;
		public string Email;
		[TextArea]
		public string Description;

		public UrlEntryBlock[] AutomatedEntries
		{
			get
			{
				return new UrlEntryBlock[]
				{
					new UrlEntryBlock(UrlPropertyBlock.CompanyName, CompanyName),
					new UrlEntryBlock(UrlPropertyBlock.PluginName, PluginName),
					new UrlEntryBlock(UrlPropertyBlock.Version, Version)
				};
			}
		}
	}
}