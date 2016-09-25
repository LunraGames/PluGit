using System;

namespace LunraGames.PluGit
{
	public struct UrlEntryBlock
	{
		public UrlPropertyBlock Key;
		public string Value;

		public UrlEntryBlock(UrlPropertyBlock key, string value)
		{
			Key = key;
			Value = value;
		}
	}
}