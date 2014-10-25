using UnityEngine;
using System.Collections;

public class PageMove : MonoBehaviour 
{
	public Help Parent;

	public bool Next;

	void OnMouseDown()
	{
		if(Next == true && Parent.Page != 18)
		{
			Parent.Page += 1;
		}
		else if(Next == false && Parent.Page != 0)
		{
			Parent.Page -= 1;
		}
	}

	void Update()
	{
		if(Next == true && Parent.Page == 18)
		{
			renderer.enabled = false;
		}
		else if(Next == true)
		{
			renderer.enabled = true;
		}
		else if(Next == false && Parent.Page == 0)
		{
			renderer.enabled = false;
		}
		else
		{
			renderer.enabled= true;
		}
	}
}
