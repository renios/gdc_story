using UnityEngine;
using System.Collections;

public class MemberSlot : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public ProjectSetting ParentSetting;

	public SpriteRenderer Renderer;

	public SpriteRenderer HairRenderer;
	public SpriteRenderer ShirtsRenderer;
	public SpriteRenderer PantsRenderer;

	public MemberSlotText Text;

	public int IndexNumber;

	Vector3 InitialMousePosition;
	Vector3 InitialPosition;
	public GameObject Self;

	public BoxCollider2D Collider;

	void Start()
	{
		SetRenderer ();
		Text.SendMessage ("SetText");
	}

	void OnMouseDown()
	{
		InitialPosition = transform.position;
		InitialMousePosition = Input.mousePosition;
		InitialMousePosition.z = 0;
		InitialMousePosition = Camera.main.ScreenToWorldPoint(InitialMousePosition);    
	}

	void OnMouseDrag()
	{
		Vector3 WorldPoint = Input.mousePosition;
		WorldPoint.z = 0;
		WorldPoint = Camera.main.ScreenToWorldPoint(WorldPoint);    
		
		Vector3 PositionDifference = WorldPoint - InitialMousePosition;
		PositionDifference.z = 0;
		
		InitialMousePosition = Input.mousePosition;
		InitialMousePosition.z = 10;
		InitialMousePosition = Camera.main.ScreenToWorldPoint(InitialMousePosition);
		
		Self.transform.position = new Vector3(Self.transform.position.x + PositionDifference.x, Self.transform.position.y + PositionDifference.y, Self.transform.position.z + PositionDifference.z);
	}

	void OnMouseUp()
	{
		RaycastHit2D[] HitObjects = Physics2D.RaycastAll (transform.position, transform.forward);
		
		foreach(RaycastHit2D HitObject in HitObjects)
		{
			if(Var.Mems[IndexNumber].ProjectPosition == Character.ProjectPositionIndex.None)
			{
				if(HitObject.collider.gameObject.tag == "PlanPosition")
				{
					if(Var.OnTutorial == false || Var.Mng.PjTuto.Page == 10)
					{
						Var.Mems[IndexNumber].ProjectPosition = Character.ProjectPositionIndex.Plan;
						ParentSetting.ParentProject.PlanAbility = Var.Mems[IndexNumber].Plan;

						if(ParentSetting.ParentProject.ProjectManager != null)
						{
							ParentSetting.ParentProject.ProjectManager.ProjectPosition = Character.ProjectPositionIndex.None;
						}
						ParentSetting.ParentProject.ProjectManager = Var.Mems[IndexNumber];

						if(Var.OnTutorial == true)
						{
							Var.Mng.PjTuto.SendMessage("ActivateRenderer");
							Var.Mng.PjTuto.Collider.enabled = true;
						}
					}
				}
				else if(HitObject.collider.gameObject.tag == "ProgrammingPosition")
				{
					if(Var.OnTutorial == false || Var.Mng.PjTuto.Page == 10)
					{
						Var.Mems[IndexNumber].ProjectPosition = Character.ProjectPositionIndex.Programming;
						ParentSetting.ParentProject.ProgrammingAbility = Var.Mems[IndexNumber].Programming;

						if(ParentSetting.ParentProject.Programmer != null)
						{
							ParentSetting.ParentProject.Programmer.ProjectPosition = Character.ProjectPositionIndex.None;
						}
						ParentSetting.ParentProject.Programmer = Var.Mems[IndexNumber];
						
						if(Var.OnTutorial == true)
						{
							Var.Mng.PjTuto.SendMessage("ActivateRenderer");
							Var.Mng.PjTuto.Collider.enabled = true;
						}
					}
				}
				else if(HitObject.collider.gameObject.tag == "ArtPosition")
				{
					if(Var.OnTutorial == false || Var.Mng.PjTuto.Page == 10)
					{
						Var.Mems[IndexNumber].ProjectPosition = Character.ProjectPositionIndex.Art;
						ParentSetting.ParentProject.ArtAbility = Var.Mems[IndexNumber].Art;

						if(ParentSetting.ParentProject.ArtDirecter != null)
						{
							ParentSetting.ParentProject.ArtDirecter.ProjectPosition = Character.ProjectPositionIndex.None;
						}
						ParentSetting.ParentProject.ArtDirecter = Var.Mems[IndexNumber];
						
						if(Var.OnTutorial == true)
						{
							Var.Mng.PjTuto.SendMessage("ActivateRenderer");
							Var.Mng.PjTuto.Collider.enabled = true;
						}
					}
				}
				else if(HitObject.collider.gameObject.tag == "SoundPosition")
				{
					if(Var.OnTutorial == false || Var.Mng.PjTuto.Page == 10)
					{
						Var.Mems[IndexNumber].ProjectPosition = Character.ProjectPositionIndex.Sound;
						ParentSetting.ParentProject.SoundAbility = Var.Mems[IndexNumber].Sound;

						if(ParentSetting.ParentProject.SoundDirecter != null)
						{
							ParentSetting.ParentProject.SoundDirecter.ProjectPosition = Character.ProjectPositionIndex.None;
						}
						ParentSetting.ParentProject.SoundDirecter = Var.Mems[IndexNumber];
						
						if(Var.OnTutorial == true)
						{
							Var.Mng.PjTuto.SendMessage("ActivateRenderer");
							Var.Mng.PjTuto.Collider.enabled = true;
						}
					}
				}
			}
		}

		transform.position = InitialPosition;
	}

	void SetRenderer()
	{
		Renderer.sprite = Var.Mems [IndexNumber].Renderer.sprite;
		if(Var.Mems[IndexNumber].Special == true)
		{
			HairRenderer.sprite = null;
			ShirtsRenderer.sprite = null;
			PantsRenderer.sprite = null;
		}
		else
		{
			HairRenderer.sprite = Var.Mems [IndexNumber].HairRenderer.sprite;
			HairRenderer.color = Var.Mems [IndexNumber].HairRenderer.color;
			ShirtsRenderer.sprite = Var.Mems [IndexNumber].ShirtsRenderer.sprite;
			ShirtsRenderer.color = Var.Mems [IndexNumber].ShirtsRenderer.color;
			PantsRenderer.sprite = Var.Mems [IndexNumber].PantsRenderer.sprite;
			PantsRenderer.color = Var.Mems [IndexNumber].PantsRenderer.color;
		}
	}

	void EmptyRenderer()
	{
		Renderer.sprite = null;
		HairRenderer.sprite = null;
		ShirtsRenderer.sprite = null;
		PantsRenderer.sprite = null;
	}
}