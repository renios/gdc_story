using UnityEngine;
using System.Collections;

public class Question : MonoBehaviour 
{
	public enum QuestionTypes
	{
		ClbIntro,
		RoomUpg,
		WbUpg,
		CpuUpg,
		SbUpg,
		CpsUpg,
		BgUpg,
		TvUpg,
		GmUpg,
		BkUpg,
		CkUpg,
		PiaUpg,
		PassTuto,
	}
	public QuestionTypes QuestionType;
	
	public Wall WallPf;
	public Wall WallIs;
	
	void Start()
	{
		WallIs = Instantiate (WallPf, new Vector3(WallPf.transform.position.x, WallPf.transform.position.y, -5), Quaternion.identity) as Wall;
	}
}