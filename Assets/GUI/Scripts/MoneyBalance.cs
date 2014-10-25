using UnityEngine;
using System.Collections;

public class MoneyBalance : MonoBehaviour {

	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;
	
	private int IndexNumber;
	
	void Start()
	{
		if(Var.MoneyChangeLog.Count <= 6)
		{
			for(IndexNumber=0;IndexNumber<Var.MoneyChangeLog.Count;IndexNumber++)
			{
				Text.text +=Var.MoneyRemainLog[IndexNumber]+"만원\n";
			}
		}
		else
		{
			for(int i = 6; i > 0; i=i-1)
			{
				Text.text += Var.MoneyRemainLog[Var.MoneyChangeLog.Count - i]+"만원\n";
			}
		}
	}
}
