using UnityEngine;
using System.Collections;

public class GameTypeCollider : MonoBehaviour 
{
	public GameTypeSelect Parent;

	public enum GameTypes
	{
		None,
		Violence,
		Emotion,
		Strategy,
		Control,
		Liberty,
		Puzzle,
		Simplity,
		Story,
	}

	public GameTypes GameType;

	void OnMouseDown()
	{
		if(GameType == GameTypes.None)
		{
			Parent.ParentPj.Type = Project.Types.None;
		}
		else if(GameType == GameTypes.Violence)
		{
			Parent.ParentPj.Type = Project.Types.Violence;
		}
		else if(GameType == GameTypes.Emotion)
		{
			Parent.ParentPj.Type = Project.Types.Emotion;
		}
		else if(GameType == GameTypes.Strategy)
		{
			Parent.ParentPj.Type = Project.Types.Strategy;
		}
		else if(GameType == GameTypes.Control)
		{
			Parent.ParentPj.Type = Project.Types.Control;
		}
		else if(GameType == GameTypes.Liberty)
		{
			Parent.ParentPj.Type = Project.Types.Liberty;
		}
		else if(GameType == GameTypes.Puzzle)
		{
			Parent.ParentPj.Type = Project.Types.Puzzle;
		}
		else if(GameType == GameTypes.Simplity)
		{
			Parent.ParentPj.Type = Project.Types.Simplity;
		}
		else if(GameType == GameTypes.Story)
		{
			Parent.ParentPj.Type = Project.Types.Story;
		}

		Destroy (Parent.gameObject);
	}
}