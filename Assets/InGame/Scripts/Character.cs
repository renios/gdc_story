using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour 
{
	GlobalVariables Var = GlobalVariables.GetInstance ();

	public NoticeMessage NoticePrefab;
	NoticeMessage Notice;

	bool DoubleClick;
	float DoubleClickTime;

	public float HairR;
	public float HairG;
	public float HairB;
	public float ShirtsR;
	public float ShirtsG;
	public float ShirtsB;
	public float PantsR;
	public float PantsG;
	public float PantsB;

	public bool Special;
	public bool Gender;

	public bool Controllable;
	public int UnControllableDuration;

	public int Violence;
	public int Emotion;
	public int Strategy;
	public int Control;
	public int Liberty;
	public int Puzzle;
	public int Simplity;
	public int Story;
	
	public bool Chief;
	public bool Loaded;

	public SpriteRenderer HairRenderer;
	public SpriteRenderer ShirtsRenderer;
	public SpriteRenderer PantsRenderer;
	public SpriteRenderer MaleBase;
	public SpriteRenderer FemaleBase;
	public SpriteRenderer MaleHair1;
	public SpriteRenderer MaleShirts1;
	public SpriteRenderer MalePants1;
	public SpriteRenderer FemaleHair1;
	public SpriteRenderer FemaleShirts1;
	public SpriteRenderer FemalePants1;

	public enum SpecialNameIndex
	{
		없음,
		변회장,
		오키드,
		이유진,
		김고니,
		오레오,
		부렁봇,
		쎈타,
		타쿠호,
		코딩형근로자,
		다리,
		M,
		요미,
		강참치,
		퐝순,
		펜펜,
		네모누리,
		트롤러,
	}
	public SpecialNameIndex SpecialName;
	public string Name;

	public enum ActionIndex
	{
		None,
		Game,
		Programming,
		BdGm,
		Draw,
		Compose,
		Book,
		Watch,
		Cook,
		Piano,
		Plan,
	}
	public ActionIndex CurrentAct;

	public ActionIndex PrevAct1;
	public ActionIndex PrevAct2;

	public enum ProjectPositionIndex
	{
		None,
		Plan,
		Programming,
		Art,
		Sound,
	}
	public ProjectPositionIndex ProjectPosition;

	public enum Talents
	{
		None,
		Plan,
		Programming,
		Art,
		Sound,
	}
	public Talents Tal;
	public Talents UnTal;

	public SpriteRenderer Renderer;
	public SpriteRenderer Balloon;

	public Sprite Jiwon;
	public Sprite Orchid;
	public Sprite Yujin;
	public Sprite Gon;
	public Sprite Burung;
	public Sprite Center;
	public Sprite Oreo;
	public Sprite Takuho;
	public Sprite Worker;
	public Sprite Bridge;
	public Sprite Moon;
	public Sprite Yomi;
	public Sprite Tuna;
	public Sprite Soon;
	public Sprite Penpen;
	public Sprite Nemo;
	public Sprite Troll;
	
	public int Loyalty;
	
	public List <int> Abilities = new List<int>();
	public List <int> Relationship = new List<int>();
	public List <Character> Friends = new List<Character> ();
	public List <Character> Lovers = new List<Character>();

	public int MemberNumber;
	public int GenderMemberNumber;

	public BoxCollider2D Collider;

	public int ReqRelationToLover()
	{
		return 35 * (Lovers.Count + 2);
	}

	IEnumerator Start ()
	{
		if(Chief == true)
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
		else if(Loaded == false)
		{
			if(Special == true)
			{
				Name = ""+SpecialName;

				SetSpecMemAbil();
				SetSpecMemEtc();
			}
			else
			{
				SetRandomAbility();
				
				if(Gender == true)
				{
					Debug.Log("Gender is Male.");
					int NameNumber = UnityEngine.Random.Range(0, Var.MaleNameList.Count);
					Name = Var.MaleNameList[NameNumber];
					Var.MaleNameList.Remove(Var.MaleNameList[NameNumber]);
					
					Renderer.sprite = MaleBase.sprite;
					HairRenderer.sprite = MaleHair1.sprite;
					ShirtsRenderer.sprite = MaleShirts1.sprite;
					PantsRenderer.sprite = MalePants1.sprite;
					
					GenderMemberNumber = Var.MaleMems.Count;
				}
				else
				{
					Debug.Log ("Gender is Female.");
					int NameNumber = UnityEngine.Random.Range(0, Var.FemaleNameList.Count);
					Name = Var.FemaleNameList[NameNumber];
					Var.FemaleNameList.Remove(Var.FemaleNameList[NameNumber]);
					
					Renderer.sprite = FemaleBase.sprite;
					HairRenderer.sprite = FemaleHair1.sprite;
					ShirtsRenderer.sprite = FemaleShirts1.sprite;
					PantsRenderer.sprite = FemalePants1.sprite;
					
					GenderMemberNumber = Var.FemaleMems.Count;
				}
				
				HairR = (float)UnityEngine.Random.Range (0, 11);
				HairG = (float)UnityEngine.Random.Range (0, 11);
				HairB = (float)UnityEngine.Random.Range (0, 11);
				ShirtsR = (float)UnityEngine.Random.Range (0, 11);
				ShirtsG = (float)UnityEngine.Random.Range (0, 11);
				ShirtsB = (float)UnityEngine.Random.Range (0, 11);
				PantsR = (float)UnityEngine.Random.Range (0, 11);
				PantsG = (float)UnityEngine.Random.Range (0, 11);
				PantsB = (float)UnityEngine.Random.Range (0, 11);

				Violence = (int)UnityEngine.Random.Range (1, 10);
				Emotion = (int)UnityEngine.Random.Range (1, 10);
				Strategy = (int)UnityEngine.Random.Range (1, 10);
				Control = (int)UnityEngine.Random.Range (1, 10);
				Liberty = (int)UnityEngine.Random.Range (1, 10);
				Puzzle = (int)UnityEngine.Random.Range (1, 10);
				Simplity = (int)UnityEngine.Random.Range (1, 10);
				Story = (int)UnityEngine.Random.Range (1, 10);

				SetRendererColors();

				Loyalty = 30;
			}
			
			Relationship.Add (0);
			MemberNumber = Var.Mems.Count;
			
			foreach(Character Member in Var.Mems)
			{
				Relationship.Add (0);
				Member.Relationship.Add (0);
			}
			Var.Mems.Add (this);
			if(Gender == true)
			{
				Var.MaleMems.Add (this);
			}
			else
			{
				Var.FemaleMems.Add(this);
			}
		}

		transform.Translate (0, 0, -0.02f * MemberNumber);
	}

	void Update()
	{
		if(DoubleClick == true)
		{
			if(DoubleClickTime > 0)
			{
				DoubleClickTime -= Time.deltaTime;
			}
			else
			{
				DoubleClick = false;
				DoubleClickTime = 0.5f;
			}
		}

		if(Chief == true && Var.OnTutorial == false)
		{
			Destroy(gameObject);
		}
	}

	Vector3 InitMosPos;
	public GameObject Self;
	void OnMouseDown()
	{
		Var.DraggingMem = this;
		if(DoubleClick == false)
		{
			Var.Mng.AudioSources[1].Play();
			DoubleClick = true;
		}
		else
		{
			if(Var.MemberInfoOn == false)
			{
				if(Var.OnTutorial == true && Var.Mng.Tutorial.Page == 31)
				{
					Var.Mng.Tutorial.Page += 1;
				}
				Var.MemberInfoOn = true;
				Notice = Instantiate(NoticePrefab) as NoticeMessage;
				Notice.NoticeType = NoticeMessage.NoticeTypes.MemberInfo;
				Notice.InfoMember = this;
			}
		}
		InitMosPos = Input.mousePosition;
		InitMosPos.z = 0;
		InitMosPos = Camera.main.ScreenToWorldPoint(InitMosPos);
	}
	void OnMouseDrag()
	{
		if(Controllable == true)
		{
			Vector3 WorldPoint = Input.mousePosition;
			WorldPoint.z = 0;
			WorldPoint = Camera.main.ScreenToWorldPoint(WorldPoint);    
			
			Vector3 PositionDifference = WorldPoint - InitMosPos;
			PositionDifference.z = 0;
			
			InitMosPos = Input.mousePosition;
			InitMosPos.z = 10;
			InitMosPos = Camera.main.ScreenToWorldPoint(InitMosPos);
			
			Self.transform.position = new Vector3(Self.transform.position.x + PositionDifference.x, Self.transform.position.y + PositionDifference.y, Self.transform.position.z + PositionDifference.z);
			
			RaycastHit2D[] HitObjects = Physics2D.RaycastAll (transform.position, transform.forward);
			
			foreach(RaycastHit2D HitObject in HitObjects)
			{
				if(HitObject.collider.gameObject.tag == "WhiteBoard" || HitObject.collider.gameObject.tag == "Computer" || HitObject.collider.gameObject.tag == "Easel" || HitObject.collider.gameObject.tag == "Composer" || HitObject.collider.gameObject.tag == "BoardGame" || HitObject.collider.gameObject.tag == "Book" || HitObject.collider.gameObject.tag == "TV" || HitObject.collider.gameObject.tag == "Game" || HitObject.collider.gameObject.tag == "Piano" || HitObject.collider.gameObject.tag == "Cook")
				{
					HitObject.collider.gameObject.SendMessage("BeTransParent");
				}
			}
		}
	}

	void OnMouseUp()
	{
		if(Controllable == true)
		{
			Var.DraggingMem = null;
			CancelCurrentAction();
			SetCurrentAction();
		}
	}

	void SetRandomAbility()
	{
		int RandomAbility1 = UnityEngine.Random.Range (0, 4);
		int RandomAbility2 = UnityEngine.Random.Range (0, 3);
		int RandomAbility3 = UnityEngine.Random.Range (0, 2);

		int StanAbil = (Var.Semester * 10) - 5;
		if(StanAbil < 0)
		{
			StanAbil = 5;
		}
		
		if(RandomAbility1 == 0)
		{
			Abilities[0] = StanAbil*4;
			if(RandomAbility2 == 0)
			{
				Abilities[1] = StanAbil*3;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*2;
					Abilities[3] = StanAbil;
				}
				else
				{
					Abilities[2] = StanAbil;
					Abilities[3] = StanAbil*2;
				}
			}
			else if(RandomAbility2 == 1)
			{
				Abilities[1] = StanAbil*2;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*3;
					Abilities[3] = StanAbil;
				}
				else
				{
					Abilities[2] = StanAbil;
					Abilities[3] = StanAbil*3;
				}
			}
			else if(RandomAbility2 == 2)
			{
				Abilities[1] = StanAbil;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*3;
					Abilities[3] = StanAbil*2;
				}
				else
				{
					Abilities[2] = StanAbil*2;
					Abilities[3] = StanAbil*3;
				}
			}
		}
		else if(RandomAbility1 == 1)
		{
			Abilities[0] = StanAbil*3;
			if(RandomAbility2 == 0)
			{
				Abilities[1] = StanAbil*4;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*2;
					Abilities[3] = StanAbil;
				}
				else
				{
					Abilities[2] = StanAbil;
					Abilities[3] = StanAbil*2;
				}
			}
			else if(RandomAbility2 == 1)
			{
				Abilities[1] = StanAbil*2;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*4;
					Abilities[3] = StanAbil;
				}
				else
				{
					Abilities[2] = StanAbil;
					Abilities[3] = StanAbil*4;
				}
			}
			else if(RandomAbility2 == 2)
			{
				Abilities[1] = StanAbil;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*4;
					Abilities[3] = StanAbil*2;
				}
				else
				{
					Abilities[2] = StanAbil*2;
					Abilities[3] = StanAbil*4;
				}
			}
		}
		else if(RandomAbility1 == 2)
		{
			Abilities[0] = StanAbil*2;
			if(RandomAbility2 == 0)
			{
				Abilities[1] = StanAbil*4;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*3;
					Abilities[3] = StanAbil;
				}
				else
				{
					Abilities[2] = StanAbil;
					Abilities[3] = StanAbil*3;
				}
			}
			else if(RandomAbility2 == 1)
			{
				Abilities[1] = StanAbil*3;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*4;
					Abilities[3] = StanAbil;
				}
				else
				{
					Abilities[2] = StanAbil;
					Abilities[3] = StanAbil*4;
				}
			}
			else if(RandomAbility2 == 2)
			{
				Abilities[1] = StanAbil;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*4;
					Abilities[3] = StanAbil*3;
				}
				else
				{
					Abilities[2] = StanAbil*3;
					Abilities[3] = StanAbil*4;
				}
			}
		}
		else if(RandomAbility1 == 3)
		{
			Abilities[0] = StanAbil;
			if(RandomAbility2 == 0)
			{
				Abilities[1] = StanAbil*4;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*3;
					Abilities[3] = StanAbil*2;
				}
				else
				{
					Abilities[2] = StanAbil*2;
					Abilities[3] = StanAbil*3;
				}
			}
			else if(RandomAbility2 == 1)
			{
				Abilities[1] = StanAbil*3;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*4;
					Abilities[3] = StanAbil*2;
				}
				else
				{
					Abilities[2] = StanAbil*2;
					Abilities[3] = StanAbil*4;
				}
			}
			else if(RandomAbility2 == 2)
			{
				Abilities[1] = StanAbil*2;
				if(RandomAbility3 == 0)
				{
					Abilities[2] = StanAbil*4;
					Abilities[3] = StanAbil*3;
				}
				else
				{
					Abilities[2] = StanAbil*3;
					Abilities[3] = StanAbil*4;
				}
			}
		}
		
		int TalentNumber = UnityEngine.Random.Range (1, 5);
		int UnTalentNumber = UnityEngine.Random.Range (1, 4);
		
		if(TalentNumber == 1)
		{
			Tal = Talents.Plan;
			if(UnTalentNumber == 1)
			{
				UnTal = Talents.Programming;
			}
			else if(UnTalentNumber == 2)
			{
				UnTal = Talents.Art;
			}
			else if(UnTalentNumber == 3)
			{
				UnTal = Talents.Sound;
			}
		}
		else if(TalentNumber == 2)
		{
			Tal = Talents.Programming;
			if(UnTalentNumber == 1)
			{
				UnTal = Talents.Plan;
			}
			else if(UnTalentNumber == 2)
			{
				UnTal = Talents.Art;
			}
			else if(UnTalentNumber == 3)
			{
				UnTal = Talents.Sound;
			}
		}
		else if(TalentNumber == 3)
		{
			Tal = Talents.Art;
			if(UnTalentNumber == 1)
			{
				UnTal = Talents.Plan;
			}
			else if(UnTalentNumber == 2)
			{
				UnTal = Talents.Programming;
			}
			else if(UnTalentNumber == 3)
			{
				UnTal = Talents.Sound;
			}
		}
		else if(TalentNumber == 4)
		{
			Tal = Talents.Sound;
			if(UnTalentNumber == 1)
			{
				UnTal = Talents.Plan;
			}
			else if(UnTalentNumber == 2)
			{
				UnTal = Talents.Programming;
			}
			else if(UnTalentNumber == 3)
			{
				UnTal = Talents.Art;
			}
		}
	}

	public void SetSpecMemEtc()
	{
		if(Name == "변회장")
		{
			Renderer.sprite = Jiwon;
			Tal = Talents.Plan;
			UnTal = Talents.Sound;
		}
		else if(Name == "이유진")
		{
			Renderer.sprite = Yujin;
			Tal = Talents.Plan;
			UnTal = Talents.Programming;
		}
		else if(Name == "부렁봇")
		{
			Renderer.sprite = Burung;
			Tal = Talents.Art;
			UnTal = Talents.Programming;
		}
		else if(Name == "쎈타")
		{
			Renderer.sprite = Center;
			Tal = Talents.Sound;
			UnTal = Talents.Art;
		}
		else if(Name == "오레오")
		{
			Renderer.sprite = Oreo;
			Tal = Talents.Sound;
			UnTal = Talents.Plan;
		}
		else if(Name == "오키드")
		{
			Renderer.sprite = Orchid;
			Tal = Talents.Programming;
			UnTal = Talents.Art;
		}
		else if(Name == "김고니")
		{
			Renderer.sprite = Gon;
			Tal = Talents.Art;
			UnTal = Talents.Sound;
		}
		else if(Name == "타쿠호")
		{
			Renderer.sprite = Takuho;
			Tal = Talents.Plan;
			UnTal = Talents.Art;
		}
		else if(Name == "코딩형근로자")
		{
			Renderer.sprite = Worker;
			Tal = Talents.Programming;
			UnTal = Talents.Sound;
		}
		else if(Name == "다리")
		{
			Renderer.sprite = Bridge;
			Tal = Talents.Programming;
			UnTal = Talents.Art;
		}
		else if(Name == "M")
		{
			Renderer.sprite = Moon;
			Tal = Talents.Plan;
			UnTal = Talents.Art;
		}
		else if(Name == "요미")
		{
			Renderer.sprite = Yomi;
			Tal = Talents.Art;
			UnTal = Talents.Plan;
		}
		else if(Name == "강참치")
		{
			Renderer.sprite = Tuna;
			Tal = Talents.Plan;
			UnTal = Talents.Sound;
		}
		else if(Name == "퐝순")
		{
			Renderer.sprite = Soon;
			Tal = Talents.Plan;
			UnTal = Talents.Programming;
		}
		else if(Name == "펜펜")
		{
			Renderer.sprite = Penpen;
			Tal = Talents.Programming;
			UnTal = Talents.Plan;
		}
		else if(Name == "네모누리")
		{
			Renderer.sprite = Nemo;
			Tal = Talents.Plan;
			UnTal = Talents.Sound;
		}
		else if(Name == "트롤러")
		{
			Renderer.sprite = Troll;
			Tal = Talents.Plan;
			UnTal = Talents.Sound;
		}
	}

	public void SetSpecMemAbil()
	{
		if(Name == "변회장")
		{
			Abilities[0] = 70;
			Abilities[2] = 70;

			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 1000;
		}
		else if(Name == "이유진")
		{
			Abilities[0] = 250;
			Abilities[1] = 10;
			Abilities[2] = 20;
			Abilities[3] = 5;

			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;

			Loyalty = 10;
		}
		else if(Name == "부렁봇")
		{
			Abilities[0] = 50;
			Abilities[1] = 10;
			Abilities[2] = 430;
			Abilities[3] = 50;

			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;

			Loyalty = 20;
		}
		else if(Name == "쎈타")
		{
			Abilities[0] = 50;
			Abilities[1] = 30;
			Abilities[2] = 5;
			Abilities[3] = 430;

			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;

			Loyalty = 20;
		}
		else if(Name == "오레오")
		{
			Abilities[0] = 200;
			Abilities[1] = 210;
			Abilities[2] = 5;
			Abilities[3] = 210;

			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;

			Loyalty = 20;
		}
		else if(Name == "오키드")
		{
			Abilities[0] = 20;
			Abilities[1] = 150;
			Abilities[2] = 5;
			Abilities[3] = 150;

			Violence = 5;
			Emotion = 6;
			Strategy = 9;
			Control = 4;
			Liberty = 5;
			Puzzle = 8;
			Simplity = 2;
			Story = 8;

			Loyalty = 20;
		}
		else if(Name == "김고니")
		{
			Abilities[0] = 25;
			Abilities[1] = 200;
			Abilities[2] = 200;
			Abilities[3] = 10;

			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;

			Loyalty = 20;

			Controllable = false;
		}
		else if(Name == "타쿠호")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;

			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;

			Loyalty = 20;
		}
		else if(Name == "코딩형근로자")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
		else if(Name == "다리")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
		else if(Name == "M")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
		else if(Name == "요미")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
		else if(Name == "강참치")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
		else if(Name == "퐝순")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
		else if(Name == "펜펜")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
		else if(Name == "네모누리")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
		else if(Name == "트롤러")
		{
			Abilities[0] = 1;
			Abilities[1] = 1;
			Abilities[2] = 1;
			Abilities[3] = 1;
			
			Violence = 5;
			Emotion = 5;
			Strategy = 5;
			Control = 5;
			Liberty = 5;
			Puzzle = 5;
			Simplity = 5;
			Story = 5;
			
			Loyalty = 20;
		}
	}

	void SetRendererColors()
	{
		HairRenderer.color = new Color(0.1f*HairR, 0.1f*HairG, 0.1f*HairB, 1f);
		ShirtsRenderer.color = new Color(0.1f*ShirtsR, 0.1f*ShirtsG, 0.1f*ShirtsB, 1f);
		PantsRenderer.color = new Color(0.1f*PantsR, 0.1f*PantsG, 0.1f*PantsB, 1f);
	}

	public void CancelCurrentAction()
	{
		if(CurrentAct == ActionIndex.Plan)
		{
			Var.PlanMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.Programming)
		{
			Var.ProgramMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.Draw)
		{
			Var.DrawMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.Compose)
		{
			Var.ComposeMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.BdGm)
		{
			Var.BdGmMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.Watch)
		{
			Var.WatchMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.Game)
		{
			Var.GameMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.Book)
		{
			Var.BookMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.Cook)
		{
			Var.CookMems.Remove(this);
		}
		else if(CurrentAct == ActionIndex.Piano)
		{
			Var.PiaMems.Remove(this);
		}

		Balloon.enabled = false;
		CurrentAct = ActionIndex.None;
	}

	void SetCurrentAction()
	{
		RaycastHit2D[] HitObjects = Physics2D.RaycastAll (transform.position, transform.forward);
		
		foreach(RaycastHit2D HitObject in HitObjects)
		{
			if(HitObject.collider.gameObject.tag == "Game" && Var.GameMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on Game");
				Balloon.enabled = true;
				CurrentAct = ActionIndex.Game;
				Var.GameMems.Add(this);
			}
			else if(HitObject.collider.gameObject.tag == "Computer" && Var.ProgramMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on Computer");
				CurrentAct = ActionIndex.Programming;
				Balloon.enabled = true;
				Var.ProgramMems.Add(this);
			}
			else if(HitObject.collider.gameObject.tag == "BoardGame" && Var.BdGmMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on BoardGame");
				CurrentAct = ActionIndex.BdGm;
				Balloon.enabled = true;
				Var.BdGmMems.Add(this);
			}
			else if(HitObject.collider.gameObject.tag == "Easel" && Var.DrawMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on SketchBook");
				if(Chief == true)
				{
					if(Var.Mng.Tutorial.Page == 28)
					{
						Var.Mng.Tutorial.Page += 1;
						Var.Mng.Tutorial.Collider.enabled = true;
					}
				}
				else
				{
					CurrentAct = ActionIndex.Draw;
					Var.DrawMems.Add(this);
				}

				Balloon.enabled = true;
			}
			else if(HitObject.collider.gameObject.tag == "Composer" && Var.ComposeMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on Composer");
				CurrentAct = ActionIndex.Compose;
				Balloon.enabled = true;
				Var.ComposeMems.Add(this);
			}
			else if(HitObject.collider.gameObject.tag == "Book" && Var.BookMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on Book");
				CurrentAct = ActionIndex.Book;
				Balloon.enabled = true;
				Var.BookMems.Add(this);
			}
			else if(HitObject.collider.gameObject.tag == "TV" && Var.WatchMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on TV");
				CurrentAct = ActionIndex.Watch;
				Balloon.enabled = true;
				Var.WatchMems.Add(this);
			}
			else if(HitObject.collider.gameObject.tag == "WhiteBoard" && Var.PlanMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on WhiteBoard");
				if(Chief == true)
				{
					if(Var.Mng.Tutorial.Page == 20)
					{
						Var.Mng.Tutorial.Page += 1;
						Var.Mng.Tutorial.Collider.enabled = true;
					}
				}
				else
				{
					if(Var.OnTutorial == true && Var.Mng.Tutorial.Page == 22)
					{
						Var.Mng.Tutorial.Page += 1;
						Var.Mng.Tutorial.Collider.enabled = true;
					}
					else
					{
						CurrentAct = ActionIndex.Plan;
						Var.PlanMems.Add(this);	
					}
				}

				Balloon.enabled = true;
			}
			else if(HitObject.collider.gameObject.tag == "Cook" && Var.CookMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on Cook");
				CurrentAct = ActionIndex.Cook;
				Balloon.enabled = true;
				Var.CookMems.Add(this);
			}
			else if(HitObject.collider.gameObject.tag == "Piano" && Var.PiaMems.Count < 2)
			{
				Var.Mng.AudioSources[3].Play ();
				Debug.Log ("Drag on Piano");
				CurrentAct = ActionIndex.Piano;
				Balloon.enabled = true;
				Var.PiaMems.Add(this);
			}
		}
	}

	public void SetPosition()
	{
		float PointX = Random.Range (-1.3f, 1.7f);
		float PointY = Random.Range (-0.4f, 1);

		transform.position = new Vector3(PointX, PointY, -2-(MemberNumber*0.02f));
	}
}