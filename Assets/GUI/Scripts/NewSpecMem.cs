using UnityEngine;
using System.Collections;

public class NewSpecMem : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;
	
	IEnumerator Start()
	{
		if(Var.NewSpecMems.Count == 0)
		{
			Text.text = "새로 가입한 특별 회원이 없습니다.";
		}
		else
		{
			Text.text = "특별 회원 <" + Var.NewSpecMems[0] + ">" + CheckSubjectFinalConsonant2(Var.NewSpecMems[0]) + " 가입했습니다!";
		}

		if(Var.NewSpecMems.Count > 1)
		{
			Text.text += "\n특별 회원 <" + Var.NewSpecMems[1] + ">" + CheckSubjectFinalConsonant2(Var.NewSpecMems[1]) + " 가입했습니다!";
		}

		Var.NewAchs.Clear ();
		Var.NewSpecMems.Clear ();

		yield return new WaitForSeconds(2.0f);

		Destroy (gameObject);
	}
	
	string CheckSubjectFinalConsonant2(string Word)
	{
		char[] WordDivision = Word.ToCharArray ();
		char FinalLetter = WordDivision [WordDivision.Length - 1];
		if((FinalLetter - '가') % 28 != 0)
		{
			return "이";
		}
		else
		{
			return "가";
		}
	}
}