using UnityEngine;
using System.Collections;

public class MemLoyaltys : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;
	
	public MemberListPopup Parent;
	
	int IndexNumber;
	
	void Update()
	{
		if(Var.Mems.Count >= Parent.Page*6-5)
		{
			Text.text = ""+Var.Mems [Parent.Page * 6 - 6].Loyalty;
		}
		if(Var.Mems.Count >= Parent.Page*6-4)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 5].Loyalty;
		}
		if(Var.Mems.Count >= Parent.Page*6-3)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 4].Loyalty;
		}
		if(Var.Mems.Count >= Parent.Page*6-2)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 3].Loyalty;
		}
		if(Var.Mems.Count >= Parent.Page*6-1)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 2].Loyalty;
		}
		if(Var.Mems.Count >= Parent.Page*6)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 1].Loyalty;
		}
	}
}