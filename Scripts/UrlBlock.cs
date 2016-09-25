using System;
using System.Linq;
using UnityEngine;

namespace LunraGames.PlugIt
{
	public struct UrlBlock
	{
		public string Raw { get; private set; }
		public UrlEntryBlock[] Entries { get; private set; }
		public string Formatted { get; private set; }

		public UrlBlock(string raw, params UrlEntryBlock[] entries)
		{
			Raw = raw;
			Entries = entries ?? new UrlEntryBlock[0];

			Formatted = Raw;

			foreach (var type in UrlPropertyBlock.All)
			{
				if (!Formatted.Contains(type.Tag)) continue;
				var replacement = Entries.FirstOrDefault(e => e.Key.Tag == type.Tag).Value ?? string.Empty;
				Formatted = Formatted.Replace(type.Tag, replacement);
			}
			Formatted = Uri.EscapeUriString(Formatted);
		}
	}
}