using UnityEngine;
using System.Collections;

public class RoomUpgrade : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public Question QuestionPrefab;
	Question QuestionInstance;

	public SpriteRenderer Renderer;

	public Sprite Level1;
	public Sprite Level2;
	public Sprite Level3;

	public BoxCollider2D Collider;

	public enum ObjectTypes
	{
		Room,
		Wb,
		Cpu,
		Sb,
		Cps,
		Bg,
		Tv,
		Gm,
		Bk,
		Ck,
		Pia,
	}
	public ObjectTypes ObjectType;
	
	public TextMesh Text;

	void Start()
	{
		if(ObjectType == ObjectTypes.Room)
		{
			if(Var.Mng.Room.Level == 1)
			{
				Text.text = "동아리방 2단계\n25만원/명성 120";
			}
			else if(Var.Mng.Room.Level == 2)
			{
				Text.text = "동아리방 3단계\n40만원/명성 420";
			}
			else if(Var.Mng.Room.Level == 3)
			{
				Text.text = "동아리방 4단계\n55만원/명성 830";
			}
			else if(Var.Mng.Room.Level == 4)
			{
				Text.text = "동아리방\n업그레이드 완료";
			}
		}
		if(ObjectType == ObjectTypes.Wb)
		{
			if(Var.Mng.Wb.Level == 1)
			{
				Renderer.sprite = Level2;
				Text.text = "화이트보드 2단계\n5만원/명성 100";
			}
			else if(Var.Mng.Wb.Level == 2)
			{
				Renderer.sprite = Level3;
				Text.text = "화이트보드 3단계\n7만원/명성 350";
			}
			else if(Var.Mng.Wb.Level == 3)
			{
				Renderer.sprite = Level3;
				Text.text = "화이트보드\n업그레이드 완료";
			}
		}
		else if(ObjectType == ObjectTypes.Cpu)
		{
			if(Var.Mng.Cpu.Level == 1)
			{
				Renderer.sprite = Level2;
				Text.text = "컴퓨터 2단계\n5만원/명성 100";
			}
			else if(Var.Mng.Cpu.Level == 2)
			{
				Renderer.sprite = Level3;
				Text.text = "컴퓨터 3단계\n7만원/명성 350";
			}
			else if(Var.Mng.Cpu.Level == 3)
			{
				Renderer.sprite = Level3;
				Text.text = "컴퓨터\n업그레이드 완료";
			}
		}
		else if(ObjectType == ObjectTypes.Sb)
		{
			if(Var.Mng.Sb.Level == 1)
			{
				Renderer.sprite = Level2;
				Text.text = "스케치북 2단계\n5만원/명성 100";
			}
			else if(Var.Mng.Sb.Level == 2)
			{
				Renderer.sprite = Level3;
				Text.text = "스케치북 3단계\n7만원/명성 350";
			}
			else if(Var.Mng.Sb.Level == 3)
			{
				Renderer.sprite = Level3;
				Text.text = "스케치북\n업그레이드 완료";
			}
		}
		else if(ObjectType == ObjectTypes.Cps)
		{
			if(Var.Mng.Cps.Level == 1)
			{
				Renderer.sprite = Level2;
				Text.text = "작곡연습 2단계\n5만원/명성 100";
			}
			else if(Var.Mng.Cps.Level == 2)
			{
				Renderer.sprite = Level3;
				Text.text = "작곡연습 3단계\n7만원/명성 350";
			}
			else if(Var.Mng.Cps.Level == 3)
			{
				Renderer.sprite = Level3;
				Text.text = "작곡연습\n업그레이드 완료";
			}
		}
		else if(ObjectType == ObjectTypes.Bg)
		{
			if(Var.Mng.Room.Level > 1)
			{
				if(Var.Mng.Bg.Level == 0)
				{
					Renderer.sprite = Level1;
					Text.text = "보드게임 1단계\n2만원/명성 150";
				}
				else if(Var.Mng.Bg.Level == 1)
				{
					Renderer.sprite = Level2;
					Text.text = "보드게임 2단계\n2만원/명성 400";
				}
				else if(Var.Mng.Bg.Level == 2)
				{
					Renderer.sprite = Level3;
					Text.text = "보드게임 3단계\n2만원/명성 650";
				}
				else if(Var.Mng.Bg.Level == 3)
				{
					Renderer.sprite = Level3;
					Text.text = "보드게임\n업그레이드 완료";
				}
			}
			else
			{
				Collider.enabled = false;
			}
		}
		else if(ObjectType == ObjectTypes.Tv)
		{
			if(Var.Mng.Room.Level > 1)
			{
				if(Var.Mng.Tv.Level == 0)
				{
					Renderer.sprite = Level1;
					Text.text = "TV 1단계\n8만원/명성 150";
				}
				else if(Var.Mng.Tv.Level == 1)
				{
					Renderer.sprite = Level2;
					Text.text = "TV 2단계\n1만원/명성 450";
				}
				else if(Var.Mng.Tv.Level == 2)
				{
					Renderer.sprite = Level3;
					Text.text = "TV 3단계\n10만원/명성 550";
				}
				else if(Var.Mng.Tv.Level == 3)
				{
					Renderer.sprite = Level3;
					Text.text = "TV\n업그레이드 완료";
				}
			}
			else
			{
				Collider.enabled = false;
			}
		}
		else if(ObjectType == ObjectTypes.Gm)
		{
			if(Var.Mng.Room.Level > 2)
			{
				if(Var.Mng.Gm.Level == 0)
				{
					Renderer.sprite = Level1;
					Text.text = "게임기 1단계\n7만원/명성 500";
				}
				else if(Var.Mng.Gm.Level == 1)
				{
					Renderer.sprite = Level2;
					Text.text = "게임기 2단계\n7만원/명성 600";
				}
				else if(Var.Mng.Gm.Level == 2)
				{
					Renderer.sprite = Level3;
					Text.text = "게임기 3단계\n7만원/명성 700";
				}
				else if(Var.Mng.Gm.Level == 3)
				{
					Renderer.sprite = Level3;
					Text.text = "게임기\n업그레이드 완료";
				}
			}
			else
			{
				Collider.enabled = false;
			}
		}
		else if(ObjectType == ObjectTypes.Bk)
		{
			if(Var.Mng.Room.Level > 2)
			{
				if(Var.Mng.Bk.Level == 0)
				{
					Renderer.sprite = Level1;
					Text.text = "책장 1단계\n7만원/명성 400";
				}
				else if(Var.Mng.Bk.Level == 1)
				{
					Renderer.sprite = Level2;
					Text.text = "책장 2단계\n3.5만원/명성 500";
				}
				else if(Var.Mng.Bk.Level == 2)
				{
					Renderer.sprite = Level3;
					Text.text = "책장 3단계\n3.5만원/명성 600";
				}
				else if(Var.Mng.Bk.Level == 3)
				{
					Renderer.sprite = Level3;
					Text.text = "책장\n업그레이드 완료";
				}
			}
			else
			{
				Collider.enabled = false;
			}
		}
		else if(ObjectType == ObjectTypes.Ck)
		{
			if(Var.Mng.Room.Level > 3)
			{
				if(Var.Mng.Ck.Level == 0)
				{
					Renderer.sprite = Level1;
					Text.text = "조리도구 1단계\n5만원/명성 500";
				}
				else if(Var.Mng.Ck.Level == 1)
				{
					Renderer.sprite = Level2;
					Text.text = "조리도구 2단계\n무료/명성 700";
				}
				else if(Var.Mng.Ck.Level == 2)
				{
					Renderer.sprite = Level3;
					Text.text = "조리도구 3단계\n무료/명성 800";
				}
				else if(Var.Mng.Ck.Level == 3)
				{
					Renderer.sprite = Level3;
					Text.text = "조리도구\n업그레이드 완료";
				}
			}
			else
			{
				Collider.enabled = false;
			}
		}
		else if(ObjectType == ObjectTypes.Pia)
		{
			if(Var.Mng.Room.Level > 3)
			{
				if(Var.Mng.Pia.Level == 0)
				{
					Renderer.sprite = Level1;
					Text.text = "피아노 1단계\n5만원/명성 500";
				}
				else if(Var.Mng.Pia.Level == 1)
				{
					Renderer.sprite = Level2;
					Text.text = "피아노 2단계\n7만원/명성 600";
				}
				else if(Var.Mng.Pia.Level == 2)
				{
					Renderer.sprite = Level3;
					Text.text = "피아노 3단계\n10만원/명성 700";
				}
				else if(Var.Mng.Pia.Level == 3)
				{
					Renderer.sprite = Level3;
					Text.text = "피아노\n업그레이드 완료";
				}
			}
			else
			{
				Collider.enabled = false;
			}
		}
	}

	void OnMouseDown()
	{
		if(Var.OnTutorial == false)
		{
			QuestionInstance = Instantiate (QuestionPrefab) as Question;
			if(ObjectType == ObjectTypes.Room)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.RoomUpg;
			}
			else if(ObjectType == ObjectTypes.Wb)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.WbUpg;
			}
			else if(ObjectType == ObjectTypes.Cpu)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.CpuUpg;
			}
			else if(ObjectType == ObjectTypes.Sb)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.SbUpg;
			}
			else if(ObjectType == ObjectTypes.Cps)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.CpsUpg;
			}
			else if(ObjectType == ObjectTypes.Bg)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.BgUpg;
			}
			else if(ObjectType == ObjectTypes.Tv)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.TvUpg;
			}
			else if(ObjectType == ObjectTypes.Gm)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.GmUpg;
			}
			else if(ObjectType == ObjectTypes.Bk)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.BkUpg;
			}
			else if(ObjectType == ObjectTypes.Ck)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.CkUpg;
			}
			else if(ObjectType == ObjectTypes.Pia)
			{
				QuestionInstance.QuestionType = Question.QuestionTypes.PiaUpg;
			}
		}
	}
}