using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Project : MonoBehaviour 
{	
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public int Number;
	public ProjectSetting SettingPrefab;
	ProjectSetting Setting;

	public int PlanAbility;
	public int ProgrammingAbility;
	public int ArtAbility;
	public int SoundAbility;

	//public Character PjMems[0];
	//public Character PjMems[1];
	//public Character PjMems[2];
	//public Character PjMems[3];

	public List<Character> PjMems = new List<Character> ();

	public SpriteRenderer Renderer;

	public Sprite Project1;
	public Sprite Project2;
	public Sprite Project3;
	public Sprite Project4;
	public Sprite Project5;
	
	public int Rank;

	public enum Types
	{
		None,
		Violence,
		Emotion,
		Strategy,
		Control,
		Liberty,
		Puzzle,
		Simplity,
		Story,
	}
	
	public Types Type;

	void Start()
	{
		if(Number == 1)
		{
			Renderer.sprite = Project1;
		}
		else if(Number == 2)
		{
			Renderer.sprite = Project2;
		}
		else if(Number == 3)
		{
			Renderer.sprite = Project3;
		}
		else if(Number == 4)
		{
			Renderer.sprite = Project4;
		}
		else
		{
			Renderer.sprite = Project5;
		}
	}

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.PjTuto.Page == 6)
		{
			Setting = Instantiate (SettingPrefab) as ProjectSetting;
			Setting.ParentProject = this;

			if(Var.OnTutorial == true)
			{
				Var.Mng.PjTuto.Page += 1;
				Var.Mng.PjTuto.Collider.enabled = true;
			}
		}
	}

	public IEnumerator Blink()
	{
		renderer.enabled = false;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = true;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = false;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = true;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = false;
		yield return new WaitForSeconds(0.5f);
		renderer.enabled = true;
	}
}