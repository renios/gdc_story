using UnityEngine;
using System.Collections;

public class QuestionText : MonoBehaviour 
{
	public Question Parent;
	
	public TextMesh Text;
	
	void Start()
	{
		if(Parent.QuestionType == Question.QuestionTypes.ClbIntro)
		{
			Text.text = "동아리 소개제에\n참가하시겠습니까?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.RoomUpg)
		{
			Text.text = "정말로 동아리방을\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.WbUpg)
		{
			Text.text = "정말로 화이트보드를\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.CpuUpg)
		{
			Text.text = "정말로 컴퓨터를\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.SbUpg)
		{
			Text.text = "정말로 스케치북을\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.CpsUpg)
		{
			Text.text = "정말로 작곡도구를\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.BgUpg)
		{
			Text.text = "정말로 보드게임을\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.TvUpg)
		{
			Text.text = "정말로 TV를\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.GmUpg)
		{
			Text.text = "정말로 게임기를\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.BkUpg)
		{
			Text.text = "정말로 책장을\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.CkUpg)
		{
			Text.text = "정말로 조리도구를\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.PiaUpg)
		{
			Text.text = "정말로 피아노를\n업그레이드할까요?";
		}
		else if(Parent.QuestionType == Question.QuestionTypes.PassTuto)
		{
			Text.text = "오프닝과 튜토리얼을\n보시겠습니까?";
		}
	}
}