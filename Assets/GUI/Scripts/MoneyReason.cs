using UnityEngine;
using System.Collections;

public class MoneyReason : MonoBehaviour {

	GlobalVariables Var = GlobalVariables.GetInstance ();
	
	public TextMesh Text;
	
	private int IndexNumber;
	
	void Start()
	{
		if(Var.MoneyChangeLog.Count <= 6)
		{
			for(IndexNumber=0;IndexNumber<Var.MoneyChangeLog.Count;IndexNumber++)
			{
				Text.text +=Var.MoneyReasonLog[IndexNumber]+"\n";
			}
		}
		else
		{
			for(int i = 6; i > 0; i=i-1)
			{
				Text.text += Var.MoneyReasonLog[Var.MoneyChangeLog.Count - i]+"\n";
			}
		}
	}
}
