using UnityEngine;
using System.Collections;

public class SoundSetting : MonoBehaviour
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public bool OnOff = true;

	public SpriteRenderer Renderer;

	public Sprite On;
	public Sprite Off;

	void Start () 
	{
		Renderer.sprite = On;
	}

	void OnMouseDown()
	{
		if(Var.Mng.BGM.enabled == true)
		{
			Var.Mng.BGM.enabled = false;
			Renderer.sprite = Off;
		}
		else if(Var.Mng.BGM.enabled == false)
		{
			Var.Mng.BGM.enabled = true;
			Renderer.sprite = On;
		}
	}
}
