using UnityEngine;

namespace LunraGames.PluGit
{
	public class CompanyConfig : ScriptableObject
	{
		[SerializeField]
		string CompanyName;
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