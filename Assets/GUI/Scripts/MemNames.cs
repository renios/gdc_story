using UnityEngine;
using System.Collections;

public class MemNames : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;

	public MemberListPopup Parent;
	
	void Update()
	{
		if(Var.Mems.Count >= Parent.Page*6-5)
		{
			Text.text = Var.Mems [Parent.Page * 6 - 6].Name;
		}
		if(Var.Mems.Count >= Parent.Page*6-4)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 5].Name;
		}
		if(Var.Mems.Count >= Parent.Page*6-3)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 4].Name;
		}
		if(Var.Mems.Count >= Parent.Page*6-2)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 3].Name;
		}
		if(Var.Mems.Count >= Parent.Page*6-1)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 2].Name;
		}
		if(Var.Mems.Count >= Parent.Page*6)
		{
			Text.text += "\n"+Var.Mems [Parent.Page * 6 - 1].Name;
		}
	}
}