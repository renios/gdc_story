using UnityEngine;
using System.Collections;

public class GameType : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public Project Parent;

	public TextMesh Text;

	public GameTypeSelect SelectPopupPf;
	GameTypeSelect SelectPopup;

	void Update () 
	{
		if(Parent.Type == Project.Types.None)
		{
			Text.text = "선택";
		}
		else if(Parent.Type == Project.Types.Violence)
		{
			Text.text = "폭력성";
		}
		else if(Parent.Type == Project.Types.Emotion)
		{
			Text.text = "감성";
		}
		else if(Parent.Type == Project.Types.Strategy)
		{
			Text.text = "전략";
		}
		else if(Parent.Type == Project.Types.Control)
		{
			Text.text = "컨트롤";
		}
		else if(Parent.Type == Project.Types.Liberty)
		{
			Text.text = "자유도";
		}
		else if(Parent.Type == Project.Types.Puzzle)
		{
			Text.text = "퍼즐";
		}
		else if(Parent.Type == Project.Types.Simplity)
		{
			Text.text = "단순성";
		}
		else if(Parent.Type == Project.Types.Story)
		{
			Text.text = "스토리";
		}
	}

	void OnMouseDown()
	{
		SelectPopup = Instantiate (SelectPopupPf) as GameTypeSelect;
		SelectPopup.ParentPj = Parent;
	}
}