using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MakeProject : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public Project ProjectPrefab;
	public Project Project1;
	Project Project2;
	Project Project3;
	Project Project4;
	Project Project5;

	public List<Project> Projects = new List<Project>();

	void OnMouseDown()
	{
		if(Var.OnTutorial == false || Var.Mng.PjTuto.Page == 3)
		{
			if(Projects.Count == 0)
			{
				Project1 = Instantiate(ProjectPrefab, new Vector3(0, 0.7f, ProjectPrefab.transform.position.z), Quaternion.identity) as Project;
				Project1.Number = 1;
				Projects.Add (Project1);
			}
			else if(Projects.Count == 1)
			{
				Project2 = Instantiate(ProjectPrefab, new Vector3(0, -0.1f, ProjectPrefab.transform.position.z), Quaternion.identity) as Project;
				Project2.Number = 2;
				Projects.Add(Project2);
			}
			else if(Projects.Count == 2)
			{
				Project3 = Instantiate(ProjectPrefab, new Vector3(0, -0.9f, ProjectPrefab.transform.position.z), Quaternion.identity) as Project;
				Project3.Number = 3;
				Projects.Add(Project3);
			}
			else if(Projects.Count == 3)
			{
				Project4 = Instantiate(ProjectPrefab, new Vector3(0, -1.7f, ProjectPrefab.transform.position.z), Quaternion.identity) as Project;
				Project4.Number = 4;
				Projects.Add(Project4);
			}
			else if(Projects.Count == 4)
			{
				Project5 = Instantiate(ProjectPrefab, new Vector3(0, -2.5f, ProjectPrefab.transform.position.z), Quaternion.identity) as Project;
				Project5.Number = 5;
				Projects.Add(Project5);
			}

			if(Var.OnTutorial == true)
			{
				Var.Mng.PjTuto.Page += 1;
				Var.Mng.PjTuto.Collider.enabled = true;
			}
		}
	}

	IEnumerator Blink()
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