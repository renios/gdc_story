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
			GetComponent<Renderer>().enabled = false;
		}
		else if(Next == true)
		{
			GetComponent<Renderer>().enabled = true;
		}
		else if(Next == false && Parent.Page == 0)
		{
			GetComponent<Renderer>().enabled = false;
		}
		else
		{
			GetComponent<Renderer>().enabled= true;
		}
	}
}
