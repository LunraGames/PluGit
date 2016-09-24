using UnityEngine;
using System.Collections;

namespace LunraGames.PluGit
{
	public class PluginConfig : ScriptableObject
	{
		[SerializeField]
		CompanyConfig Company;
		[SerializeField]
		string Website;
		[SerializeField]
		string Email;
		[SerializeField]
		string FeedbackUrl;
		[SerializeField]
		string Description;
	}
}