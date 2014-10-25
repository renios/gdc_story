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
		if(ProjectRoleType == ProjectRoleTypes.Plan && ParentSetting.ParentProject.ProjectManager != null)
		{
			Renderer.sprite = ParentSetting.ParentProject.ProjectManager.Renderer.sprite;
			HairRenderer.sprite = ParentSetting.ParentProject.ProjectManager.HairRenderer.sprite;
			HairRenderer.color = ParentSetting.ParentProject.ProjectManager.HairRenderer.color;
			ShirtsRenderer.sprite = ParentSetting.ParentProject.ProjectManager.ShirtsRenderer.sprite;
			ShirtsRenderer.color = ParentSetting.ParentProject.ProjectManager.ShirtsRenderer.color;
			PantsRenderer.sprite = ParentSetting.ParentProject.ProjectManager.PantsRenderer.sprite;
			PantsRenderer.color = ParentSetting.ParentProject.ProjectManager.PantsRenderer.color;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Programming && ParentSetting.ParentProject.Programmer != null)
		{
			Renderer.sprite = ParentSetting.ParentProject.Programmer.Renderer.sprite;
			HairRenderer.sprite = ParentSetting.ParentProject.Programmer.HairRenderer.sprite;
			HairRenderer.color = ParentSetting.ParentProject.Programmer.HairRenderer.color;
			ShirtsRenderer.sprite = ParentSetting.ParentProject.Programmer.ShirtsRenderer.sprite;
			ShirtsRenderer.color = ParentSetting.ParentProject.Programmer.ShirtsRenderer.color;
			PantsRenderer.sprite = ParentSetting.ParentProject.Programmer.PantsRenderer.sprite;
			PantsRenderer.color = ParentSetting.ParentProject.Programmer.PantsRenderer.color;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Art && ParentSetting.ParentProject.ArtDirecter != null)
		{
			Renderer.sprite = ParentSetting.ParentProject.ArtDirecter.Renderer.sprite;
			HairRenderer.sprite = ParentSetting.ParentProject.ArtDirecter.HairRenderer.sprite;
			HairRenderer.color = ParentSetting.ParentProject.ArtDirecter.HairRenderer.color;
			ShirtsRenderer.sprite = ParentSetting.ParentProject.ArtDirecter.ShirtsRenderer.sprite;
			ShirtsRenderer.color = ParentSetting.ParentProject.ArtDirecter.ShirtsRenderer.color;
			PantsRenderer.sprite = ParentSetting.ParentProject.ArtDirecter.PantsRenderer.sprite;
			PantsRenderer.color = ParentSetting.ParentProject.ArtDirecter.PantsRenderer.color;
		}
		else if(ProjectRoleType == ProjectRoleTypes.Sound && ParentSetting.ParentProject.SoundDirecter != null)
		{
			Renderer.sprite = ParentSetting.ParentProject.SoundDirecter.Renderer.sprite;
			HairRenderer.sprite = ParentSetting.ParentProject.SoundDirecter.HairRenderer.sprite;
			HairRenderer.color = ParentSetting.ParentProject.SoundDirecter.HairRenderer.color;
			ShirtsRenderer.sprite = ParentSetting.ParentProject.SoundDirecter.ShirtsRenderer.sprite;
			ShirtsRenderer.color = ParentSetting.ParentProject.SoundDirecter.ShirtsRenderer.color;
			PantsRenderer.sprite = ParentSetting.ParentProject.SoundDirecter.PantsRenderer.sprite;
			PantsRenderer.color = ParentSetting.ParentProject.SoundDirecter.PantsRenderer.color;
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