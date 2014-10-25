using UnityEngine;
using System.Collections;

public class ProjectPageMove : MonoBehaviour 
{
	GlobalVariables Variables = GlobalVariables.GetInstance ();

	public ProjectSetting Parent;

	public bool Next;

	public MemberSlot Slot1;
	public MemberSlot Slot2;
	public MemberSlot Slot3;

	void OnMouseDown()
	{
		if(Next == true && Variables.Mems.Count > (Parent.Page+1)*3)
		{
			Parent.Page += 1;

			Slot1.IndexNumber += 3;
			Slot1.SendMessage("SetRenderer");
			Slot1.Text.SendMessage("SetText");
			Slot2.IndexNumber += 3;
			Slot3.IndexNumber += 3;

			if(Variables.Mems.Count == (Parent.Page*3)+1)
			{
				Slot2.SendMessage("EmptyRenderer");
				Slot2.Text.Text.text = null;
				Slot2.Collider.enabled = false;
				Slot3.SendMessage("EmptyRenderer");
				Slot3.Text.Text.text = null;
				Slot3.Collider.enabled = false;
			}
			else if(Variables.Mems.Count == (Parent.Page*3)+2)
			{
				Slot2.SendMessage("SetRenderer");
				Slot2.Text.SendMessage("SetText");
				Slot3.SendMessage("EmptyRenderer");
				Slot3.Text.Text.text = null;
				Slot3.Collider.enabled = false;
			}
			else
			{
				Slot2.SendMessage("SetRenderer");
				Slot2.Text.SendMessage("SetText");
				Slot3.SendMessage("SetRenderer");
				Slot3.Text.SendMessage("SetText");
			}
		}
		else if(Next == false && Parent.Page != 0)
		{
			Parent.Page -= 1;

			Slot1.IndexNumber -= 3;
			Slot1.SendMessage("SetRenderer");
			Slot1.Text.SendMessage("SetText");
			Slot1.Collider.enabled = true;
			Slot2.IndexNumber -= 3;
			Slot2.SendMessage("SetRenderer");
			Slot2.Text.SendMessage("SetText");
			Slot2.Collider.enabled = true;
			Slot3.IndexNumber -= 3;
			Slot3.SendMessage("SetRenderer");
			Slot3.Text.SendMessage("SetText");
			Slot3.Collider.enabled = true;
		}
	}
}