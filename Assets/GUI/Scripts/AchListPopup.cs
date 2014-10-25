using UnityEngine;
using System.Collections;

public class AchListPopup : MonoBehaviour 
{
	public GlobalVariables Var = GlobalVariables.GetInstance ();

	public GameObject MenuPrefab;
	public GameObject MenuInstance;
	
	public SpriteRenderer Renderer;

	public Sprite Page1;
	public Sprite Page2;
	public Sprite Page3;
	public Sprite Page4;

	public int Page;

	public bool Global;

	void Start()
	{
		Page = 1;
		Renderer.sprite = Page1;
	}

	void OnMouseDown()
	{
		if(Page != 4)
		{
			Page += 1;
			if(Page == 2)
			{
				Renderer.sprite = Page2;
			}
			else if(Page == 3)
			{
				Renderer.sprite = Page3;
			}
			else if(Page == 4)
			{
				Renderer.sprite = Page4;
			}
		}
		else
		{
			if(Global == false)
			{
				if(Var.OnTutorial == true && Var.Mng.Tutorial.Page == 11)
				{
					Var.Mng.Tutorial.Page += 1;
				}
				
				MenuInstance=Instantiate(MenuPrefab) as GameObject;
				Destroy(gameObject);
			}
			else
			{
				Application.LoadLevel("Title");
			}

		}
	}
}
