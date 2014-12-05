using UnityEngine;
using System.Collections;

public class RoomObj : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public SpriteRenderer Renderer;

	public Sprite Level1;
	public Sprite Level2;
	public Sprite Level3;

	public int Level;

	public bool Upgrades;

	bool Blinking;

	public enum ObjTypes
	{
		Wb,
		Cpu,
		Tb,
		Sb,
		Cps,
		Bg,
		Tv,
		Game,
		Book,
		Cook,
		Pia,
		Vs,
		Pst,
		Sf,
		Hanger,
		Rfr,
		Door,
		Cld,
	}
	public ObjTypes ObjType;

	void Update()
	{
		if(Upgrades == true && Blinking == false)
		{
			if(Var.DraggingMem != null)
			{
				RaycastHit2D[] HitObjects = Physics2D.RaycastAll (transform.position, -transform.forward);

				bool Dragging = false;
				
				foreach(RaycastHit2D HitObject in HitObjects)
				{
					if(HitObject.collider.gameObject == Var.DraggingMem.gameObject)
					{
						Dragging = true;
					}
				}

				if(Dragging == false)
				{
					Renderer.color = new Color(255, 255, 255, 1);
				}
			}
			else
			{
				Renderer.color = new Color(255, 255, 255, 1);
			}
		}
	}

	void SetPosition()
	{
		Room room = Var.Mng.Room;
		if(ObjType == ObjTypes.Wb)
		{
			if(Level == 1 || Level == 2)
			{
				if(Var.Mng.Room.Level == 1)
				{
					transform.position = new Vector3(room.transform.position.x-0.56f, room.transform.position.y+1.72f, 0);
				}
				else if(Var.Mng.Room.Level == 2)
				{
					transform.position = new Vector3(room.transform.position.x-1.56f, room.transform.position.y+1.44f, 0);
				}
				else if(Var.Mng.Room.Level == 3)
				{
					transform.position = new Vector3(room.transform.position.x-1.44f, room.transform.position.y+1.52f, 0);
				}
			}
			else if(Level == 3)
			{
				transform.position = new Vector3(room.transform.position.x-1.44f, room.transform.position.y+1.08f, 0);
			}
		}
		else if(ObjType == ObjTypes.Cpu)
		{
			if(Level == 1)
			{
				if(Var.Mng.Room.Level == 1)
				{
					transform.position = new Vector3(room.transform.position.x-2, room.transform.position.y+0.4f, 0);
				}
				else if(Var.Mng.Room.Level == 2)
				{
					transform.position = new Vector3(room.transform.position.x-3, room.transform.position.y-0.12f, 0);
				}
				else
				{
					transform.position = new Vector3(room.transform.position.x-2.8f, room.transform.position.y-0.04f, 0);
				}
			}
			else
			{
				if(Var.Mng.Room.Level == 2)
				{
					transform.position = new Vector3(room.transform.position.x-3, room.transform.position.y+0.04f, 0);
				}
				else
				{
					transform.position = new Vector3(room.transform.position.x-2.92f, room.transform.position.y+0.16f, 0);
				}
			}
		}
		else if(ObjType == ObjTypes.Tb)
		{
			if(Var.Mng.Room.Level == 1)
			{
				transform.position = new Vector3(room.transform.position.x-0.08f, room.transform.position.y-0.56f, 0);
			}
			else if(Var.Mng.Room.Level == 2)
			{
				transform.position = new Vector3(room.transform.position.x-0.2f, room.transform.position.y-0.48f, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x+1.4f, room.transform.position.y-2.2f, 0);
			}
		}
		else if(ObjType == ObjTypes.Sb)
		{
			if(Level == 1)
			{
				if(Var.Mng.Room.Level == 1)
				{
					transform.position = new Vector3(room.transform.position.x+0.16f, room.transform.position.y-0.24f, -1);
				}
				else if(Var.Mng.Room.Level == 2)
				{
					transform.position = new Vector3(room.transform.position.x+0.04f, room.transform.position.y-0.16f, -1);
				}
				else
				{
					transform.position = new Vector3(room.transform.position.x+1.6f, room.transform.position.y-1.88f, -1);
				}
			}
			else
			{
				if(Var.Mng.Room.Level == 2)
				{
					transform.position = new Vector3(room.transform.position.x+0.08f, room.transform.position.y+0.36f, -1);
				}
				else
				{
					transform.position = new Vector3(room.transform.position.x+1.64f, room.transform.position.y-1.36f, -1);
				}
			}
		}
		else if(ObjType == ObjTypes.Cps)
		{
			if(Level == 1)
			{
				if(Var.Mng.Room.Level == 1)
				{
					transform.position = new Vector3(room.transform.position.x-0.48f, room.transform.position.y-0.44f, -1);
				}
				else if(Var.Mng.Room.Level == 2)
				{
					transform.position = new Vector3(room.transform.position.x-0.6f, room.transform.position.y-0.36f, -1);
				}
			}
			else
			{

			}
		}
		else if(ObjType == ObjTypes.Bg)
		{
			if(Level == 0)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else if(Var.Mng.Room.Level == 2)
			{
				transform.position = new Vector3(room.transform.position.x, room.transform.position.y-2, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x, room.transform.position.y-0.4f, 0);
			}
		}
		else if(ObjType == ObjTypes.Tv)
		{
			if(Level == 0)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else if(Var.Mng.Room.Level == 2)
			{
				Var.Mng.Tv.transform.position = new Vector3(room.transform.position.x+2.8f, room.transform.position.y+0.2f, 0);
			}
			else
			{
				if(Level != 3)
				{
					Var.Mng.Tv.transform.position = new Vector3(room.transform.position.x+3.6f, room.transform.position.y-0.12f, 0);
				}
				else
				{
					Var.Mng.Tv.transform.position = new Vector3(room.transform.position.x+3.6f, room.transform.position.y+0.4f, 0);
				}
			}
		}
		else if(ObjType == ObjTypes.Game)
		{
			if(Level == 0)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x+2.92f, room.transform.position.y, 0.1f);
			}
		}
		else if(ObjType == ObjTypes.Book)
		{
			if(Level == 0)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x-4.4f, room.transform.position.y-0.36f, 0);
			}
		}
		else if(ObjType == ObjTypes.Cook)
		{
			if(Level == 0)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x+4.44f, room.transform.position.y-1.44f, 0);
			}
		}
		else if(ObjType == ObjTypes.Pia)
		{
			if(Level == 0)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x-0.88f, room.transform.position.y-3.12f, 0);
			}
		}
		else if(ObjType == ObjTypes.Vs)
		{
			if(Var.Mng.Room.Level == 1)
			{
				transform.position = new Vector3(room.transform.position.x+2.48f, room.transform.position.y+0.2f, 0);
			}
			else if(Var.Mng.Room.Level == 2)
			{
				transform.position = new Vector3(room.transform.position.x+3.8f, room.transform.position.y-0.16f, 0);
			}
			else if(Var.Mng.Room.Level == 3)
			{
				transform.position = new Vector3(room.transform.position.x+4.8f, room.transform.position.y-0.68f, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x+0.04f, room.transform.position.y-4.04f, 0);
			}
		}
		else if(ObjType == ObjTypes.Pst)
		{
			if(Var.Mng.Room.Level == 1)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x-0.52f, room.transform.position.y+1.96f, 0);
			}
		}
		else if(ObjType == ObjTypes.Sf)
		{
			if(Var.Mng.Room.Level <= 2)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else if(Var.Mng.Room.Level == 3)
			{
				transform.position = new Vector3(room.transform.position.x-2.68f, room.transform.position.y-2.04f, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x-3.6f, room.transform.position.y-2.56f, 0);
			}
		}
		else if(ObjType == ObjTypes.Hanger)
		{
			if(Var.Mng.Room.Level <= 2)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else if(Var.Mng.Room.Level == 3)
			{
				transform.position = new Vector3(room.transform.position.x-0.8f, room.transform.position.y-2.04f, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x-5.48f, room.transform.position.y-1f, 0);
			}
		}
		else if(ObjType == ObjTypes.Rfr)
		{
			if(Var.Mng.Room.Level <= 3)
			{
				transform.position = new Vector3(room.transform.position.x+10, room.transform.position.y+10, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x+6, room.transform.position.y-1.28f, 0);
			}
		}
		else if(ObjType == ObjTypes.Door)
		{
			if(Var.Mng.Room.Level <= 2)
			{
				transform.position = new Vector3(room.transform.position.x+0.64f, room.transform.position.y+1.76f, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x+1.08f, room.transform.position.y+1.56f, 0);
			}
		}
		else if(ObjType == ObjTypes.Cld)
		{
			if(Var.Mng.Room.Level <= 2)
			{
				transform.position = new Vector3(room.transform.position.x+1.72f, room.transform.position.y+1.32f, 0);
			}
			else
			{
				transform.position = new Vector3(room.transform.position.x+2, room.transform.position.y+1.2f, 0);
			}
		}
	}

	IEnumerator Blink()
	{
		Blinking = true;

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

		Blinking = false;
	}

	void BeTransParent()
	{
		Renderer.color = new Color(255, 255, 255, 0.5f);
	}
	void BeDefault()
	{
		Renderer.color = new Color (255, 255, 255, 1);
	}
}
