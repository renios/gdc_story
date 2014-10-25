using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public SpriteRenderer Renderer;

	public int Level;

	public Sprite Room1;
	public Sprite Room2;
	public Sprite Room3;
	public Sprite Room4;

	void Start()
	{
		Level = 1;
		Renderer.sprite = Room1;
	}

	Vector3 InitMosPos;
	public GameObject Self;

	void OnMouseDown()
	{
		InitMosPos = Input.mousePosition;
		InitMosPos.z = 0;
		InitMosPos = Camera.main.ScreenToWorldPoint(InitMosPos);
	}

	void OnMouseDrag()
	{
		Vector3 WorldPoint = Input.mousePosition;
		WorldPoint.z = 0;
		WorldPoint = Camera.main.ScreenToWorldPoint(WorldPoint);    
		
		Vector3 PosDif = WorldPoint - InitMosPos;
		PosDif.z = 0;
		
		InitMosPos = Input.mousePosition;
		InitMosPos.z = 10;
		InitMosPos = Camera.main.ScreenToWorldPoint(InitMosPos);
		
		Self.transform.position = new Vector3(Self.transform.position.x + PosDif.x, Self.transform.position.y + PosDif.y, Self.transform.position.z + PosDif.z);
		foreach(Character Mem in Var.Mems)
		{
			Mem.transform.position = new Vector3(Mem.transform.position.x+PosDif.x, Mem.transform.position.y+PosDif.y, Mem.transform.position.z+PosDif.z);
		}
		if(Var.Mng.Chief != null)
		{
			Var.Mng.Chief.transform.position = new Vector3(Var.Mng.Chief.transform.position.x+PosDif.x, Var.Mng.Chief.transform.position.y+PosDif.y, Var.Mng.Chief.transform.position.z+PosDif.z);
		}
	}
}