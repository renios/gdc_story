using UnityEngine;
using System.Collections;

public class LoadSlots : MonoBehaviour 
{
	public int SlotNumber;

	void OnMouseDown()
	{
		PlayerPrefs.SetInt ("LoadedSlot", SlotNumber);
		Application.LoadLevel ("InGame");
	}
}
