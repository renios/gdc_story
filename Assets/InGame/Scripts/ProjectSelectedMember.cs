using UnityEngine;
using System.Collections;

public class ProjectSelectedMember : MonoBehaviour 
{
	GlobalVariables Variables = GlobalVariables.GetInstance ();

	public ProjectSetting ParentSetting;
	public SpriteRenderer Renderer;

	public SpriteRenderer HairRenderer;
	public SpriteRenderer ShirtsRenderer;
	public SpriteRenderer PantsRenderer;

	public enum ProjectRoleTypes
	{
		Plan,
		Programming,
		Art,
		Sound,
	}
	public ProjectRoleTypes ProjectRoleType;

	void Update()
	{
		if(ProjectRoleType == ProjectRoleTypes.Plan && ParentSetting.ParentProject.PjMems[0] != null)
		{
			Renderer.sprite = ParentSetting.ParentProject.PjMems[0].Renderer.sprite;
			HairRenderer.sprite = ParentSetting.ParentProject.PjMems[0].HairRenderer.sprite;
			HairRenderer.color = ParentSetting.ParentProject.PjMems[0].HairRenderer.color;
			ShirtsRenderer.sprite = ParentSetting.ParentProject.PjMems[0].ShirtsRenderer.sprite;
			ShirtsRenderer.color = ParentSetting.ParentProject.PjMems[0].ShirtsRenderer.color;
			PantsRenderer.sprite = ParentSetting.ParentProject.PjMems[0].PantsRenderer.sprite;
			PantsRenderer.color = ParentSetting.ParentProject.PjMems[0].PantsRenderer.color;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Programming && ParentSetting.ParentProject.PjMems[1] != null)
		{
			Renderer.sprite = ParentSetting.ParentProject.PjMems[1].Renderer.sprite;
			HairRenderer.sprite = ParentSetting.ParentProject.PjMems[1].HairRenderer.sprite;
			HairRenderer.color = ParentSetting.ParentProject.PjMems[1].HairRenderer.color;
			ShirtsRenderer.sprite = ParentSetting.ParentProject.PjMems[1].ShirtsRenderer.sprite;
			ShirtsRenderer.color = ParentSetting.ParentProject.PjMems[1].ShirtsRenderer.color;
			PantsRenderer.sprite = ParentSetting.ParentProject.PjMems[1].PantsRenderer.sprite;
			PantsRenderer.color = ParentSetting.ParentProject.PjMems[1].PantsRenderer.color;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Art && ParentSetting.ParentProject.PjMems[2] != null)
		{
			Renderer.sprite = ParentSetting.ParentProject.PjMems[2].Renderer.sprite;
			HairRenderer.sprite = ParentSetting.ParentProject.PjMems[2].HairRenderer.sprite;
			HairRenderer.color = ParentSetting.ParentProject.PjMems[2].HairRenderer.color;
			ShirtsRenderer.sprite = ParentSetting.ParentProject.PjMems[2].ShirtsRenderer.sprite;
			ShirtsRenderer.color = ParentSetting.ParentProject.PjMems[2].ShirtsRenderer.color;
			PantsRenderer.sprite = ParentSetting.ParentProject.PjMems[2].PantsRenderer.sprite;
			PantsRenderer.color = ParentSetting.ParentProject.PjMems[2].PantsRenderer.color;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Sound && ParentSetting.ParentProject.PjMems[3] != null)
		{
			Renderer.sprite = ParentSetting.ParentProject.PjMems[3].Renderer.sprite;
			HairRenderer.sprite = ParentSetting.ParentProject.PjMems[3].HairRenderer.sprite;
			HairRenderer.color = ParentSetting.ParentProject.PjMems[3].HairRenderer.color;
			ShirtsRenderer.sprite = ParentSetting.ParentProject.PjMems[3].ShirtsRenderer.sprite;
			ShirtsRenderer.color = ParentSetting.ParentProject.PjMems[3].ShirtsRenderer.color;
			PantsRenderer.sprite = ParentSetting.ParentProject.PjMems[3].PantsRenderer.sprite;
			PantsRenderer.color = ParentSetting.ParentProject.PjMems[3].PantsRenderer.color;
		}
	}
	
	void OnMouseDown()
	{
		Variables.ProjectRoleType = ProjectRoleType;
		Renderer.sprite = null;

		if(ProjectRoleType == ProjectRoleTypes.Plan)
		{
			ParentSetting.ParentProject.PlanAbility = 0;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Programming)
		{
			ParentSetting.ParentProject.ProgrammingAbility = 0;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Art)
		{
			ParentSetting.ParentProject.ArtAbility = 0;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Sound)
		{
			ParentSetting.ParentProject.SoundAbility = 0;
		}

		Debug.Log (ProjectRoleType + " Slot Clicked."); 
	}
}