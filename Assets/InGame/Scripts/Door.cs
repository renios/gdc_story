using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public GroupActivity GroupPrefab;
	GroupActivity Group;

	public NoticeMessage NoticePf;
	NoticeMessage Notice;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 43)
		{
			Var.Mng.AudioSources[0].Play ();
			if (Var.MenuActivated == true) 
			{
				Group = Instantiate (GroupPrefab) as GroupActivity;
			}
			else
			{
				Notice = Instantiate(NoticePf) as NoticeMessage;
				Notice.NoticeType = NoticeMessage.NoticeTypes.AlreadyGroupActivity;
			}

			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
			}
		}
	}
}
