using UnityEngine;
using System.Collections;

public class ProjectText : MonoBehaviour 
{
	public Project Parent;
	public TextMesh Text;

	void Update()
	{
		Text.text = Parent.Number + "";
	}
}