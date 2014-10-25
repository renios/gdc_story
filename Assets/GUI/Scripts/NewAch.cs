using UnityEngine;
using System.Collections;

public class NewAch : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public TextMesh Text;

	public NewSpecMem NewSpecMemPf;

	IEnumerator Start()
	{
		Text.text = "업적 <" + Var.AchNameList [Var.NewAchs[0]] + ">" + CheckObjectFinalConsonant (Var.AchNameList [Var.NewAchs[0]]) + " 달성했습니다!";
		if(Var.NewAchs.Count != 1)
		{
			Text.text += "\n업적 <" + Var.AchNameList [Var.NewAchs[1]] + ">" + CheckObjectFinalConsonant (Var.AchNameList [Var.NewAchs[1]]) + " 달성했습니다!";
		}

		yield return new WaitForSeconds(2.0f);

		Instantiate (NewSpecMemPf);

		Destroy (gameObject);
	}

	string CheckObjectFinalConsonant(string Word)
	{
		char[] WordDivision = Word.ToCharArray ();
		char FinalLetter = WordDivision [WordDivision.Length - 1];
		if((FinalLetter - '가') % 28 != 0)
		{
			return "을";
		}
		else
		{
			return "를";
		}
	}
}