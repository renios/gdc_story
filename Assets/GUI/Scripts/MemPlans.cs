using UnityEngine;
using System.Collections;

public class MemPlans : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;
	
	public MemberListPopup Parent;
	
	int IndexNumber;
	
	void Update()
	{
		if(Var.Mems.Count >= Parent.Page*6-5)
		{
			Text.text = ""+Var.Mems [Parent.Page * 6 - 6].Abilities[0];
		}
		if(Var.Mems.Count >= Parent.Page*6-4)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 5].Abilities[0];
		}
		if(Var.Mems.Count >= Parent.Page*6-3)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 4].Abilities[0];
		}
		if(Var.Mems.Count >= Parent.Page*6-2)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 3].Abilities[0];
		}
		if(Var.Mems.Count >= Parent.Page*6-1)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 2].Abilities[0];
		}
		if(Var.Mems.Count >= Parent.Page*6)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 1].Abilities[0];
		}
	}
}