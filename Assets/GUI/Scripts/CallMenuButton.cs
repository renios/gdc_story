using UnityEngine;
using System.Collections;

public class CallMenuButton : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public static bool display=true;
	public GameObject MenuPrefab;
	public GameObject Menu;

	void Start () 
	{
		display = true;
	}

	void Update()
	{
		if (!display)
		{
			if (transform.position.x > -6.2)
			{
				transform.Translate (Vector3.left * Time.deltaTime * 1);
			}
		} 
		else 
		{
			if (transform.position.x < -5.36) 
			{
				transform.Translate (Vector3.right * Time.deltaTime * 1);
			}
		}
	}

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.Tutorial.Page == 1)
		{
			Menu = Instantiate (MenuPrefab) as GameObject;

			if (display) 
			{
				display=false;
			}

			if(Var.OnTutorial == true)
			{
				Var.Mng.Tutorial.Page += 1;
			}
		}
	}

	IEnumerator Blink()
	{
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Renderer>().enabled = true;
	}
}
