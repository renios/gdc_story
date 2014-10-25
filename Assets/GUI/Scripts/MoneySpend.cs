using UnityEngine;
using System.Collections;

public class MoneySpend : MonoBehaviour {

	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;
	
	private int IndexNumber;
	
	void Start()
	{
		if(Var.MoneyChangeLog.Count <= 6)
		{
			for(IndexNumber=0;IndexNumber<Var.MoneyChangeLog.Count;IndexNumber++)
			{
				if(Var.MoneyChangeLog[IndexNumber] < 0)
				{
					Text.text +=Var.MoneyChangeLog[IndexNumber]+"만원\n";
				}
				else
				{
					Text.text += "\n";
				}
			}
		}
		else
		{
			for(int i = 6; i > 0; i=i-1)
			{
				if(Var.MoneyChangeLog[Var.MoneyChangeLog.Count - i] < 0)
				{
					Text.text += Var.MoneyChangeLog[Var.MoneyChangeLog.Count - i]+"만원\n";
				}
				else
				{
					Text.text += "\n";
				}
			}
		}
	}
}
