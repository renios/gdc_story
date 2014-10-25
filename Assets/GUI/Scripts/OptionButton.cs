using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public CloseOption Closer;

	public Help HelpPf;

	public SavePopup SavePopupPf;
	public SavePopup LoadPopupPf;

	public enum ButtonTypes
	{
		ToTitle,
		Save,
		Load,
		Help,
		None,
	}
	public ButtonTypes ButtonType;

	void OnMouseDown()
	{
		if(Var.OnTutorial == false)
		{
			Var.Mng.AudioSources [0].Play ();
		}
		if(ButtonType == ButtonTypes.Save)
		{
			Instantiate(SavePopupPf);
			Closer.SendMessage("OnMouseUpAsButton");
		}
		else if(ButtonType == ButtonTypes.Load)
		{
			Instantiate(LoadPopupPf);
			Closer.SendMessage("OnMouseUpAsButton");
		}
		else if(ButtonType == ButtonTypes.Help)
		{
			Instantiate(HelpPf);
			Closer.SendMessage("OnMouseUpAsButton");
		}
	}
}
