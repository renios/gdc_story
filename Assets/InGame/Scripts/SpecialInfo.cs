using UnityEngine;
using System.Collections;

public class SpecialInfo : MonoBehaviour
{
	public NoticeMessage Parent;

	public TextMesh Text;

	void Start()
	{
		if(Parent.InfoMember.Special == false)
		{
			Text.text = "특수능력 없음";
		}
		else
		{
			if(Parent.InfoMember.Name == "변회장")
			{
				Text.text = "동아리의 총책임자로서,\n절대 탈퇴하지 않습니다.";
			}
			else if(Parent.InfoMember.Name == "오키드")
			{
				Text.text = "프로젝트에 참여하면,\n다른 회원들간 친밀도를\n상당히 향상시킵니다.";
			}
			else if(Parent.InfoMember.Name == "부렁봇")
			{
				Text.text = "음주를 하면 3배,\n회식/MT를 가면 2배로\n충성도가 회복됩니다.";
			}
			else if(Parent.InfoMember.Name == "김고니")
			{
				Text.text = "직접 명령할 수 없고\n매 턴 마음대로 행동합니다.\n(프로젝트 배치는 가능)";
			}
			else if(Parent.InfoMember.Name == "이유진")
			{
				Text.text = "방학 동안 사라져서\n조작이 불가능합니다.";
			}
			else if(Parent.InfoMember.Name == "쎈타")
			{
				Text.text = "가끔씩 배정된 활동을\n무시하고 롤을 합니다.";
			}
			else if(Parent.InfoMember.Name == "오레오")
			{
				Text.text = "각종 업그레이드 비용을\n할인시켜 줍니다.";
			}
			else if(Parent.InfoMember.Name == "코딩형근로자")
			{
				Text.text = "??";
			}
			else if(Parent.InfoMember.Name == "타쿠호")
			{
				Text.text = "무능함";
			}
			else if(Parent.InfoMember.Name == "다리")
			{
				Text.text = "동아리 내에 커플이\n많으면 많을수록 충성도가\n빠르게 떨어집니다.";
			}
			else if(Parent.InfoMember.Name == "M")
			{
				Text.text = "동아리 내에 여성회원이\n많으면 많을수록 능력치가\n빠르게 상승합니다.";
			}
			else if(Parent.InfoMember.Name == "요미")
			{
				Text.text = "일정 확률로 능력치가\n오르는 대신 떨어집니다.";
			}
			else if(Parent.InfoMember.Name == "강참치")
			{
				Text.text = "게임을 하면 능력치가\n2배로 향상됩니다.\n음주를 하면 2턴 동안\n행동을 할 수 없게 됩니다.";
			}
			else if(Parent.InfoMember.Name == "퐝순")
			{
				Text.text = "남자회원과 함께 활동하면\n충성도가 떨어지지 않고\n친밀도가 빠르게 쌓입니다.";
			}
			else if(Parent.InfoMember.Name == "펜펜")
			{
				Text.text = "회식을 하면 1턴,\n음주를 하면 2턴간\n능력치가 2배 빨리\n상승합니다.";
			}
			else if(Parent.InfoMember.Name == "네모누리")
			{
				Text.text = "혼자 행동하면 충성도가\n하락하지 않습니다.";
			}
			else if(Parent.InfoMember.Name == "트롤러")
			{
				Text.text = "랜덤으로 프로젝트를\n하나 폭파시킵니다.";
			}
		}
	}
}