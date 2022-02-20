using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    //대화시스템 만들기 다음버튼누르면 다음대화가나오고 일정시간이 지나면 힌트를 준다.
    //로딩을 기다리기만 할꺼야 직접 바를 잡고 움직여봐 능동적으로 게임을 하란말이야
    //다차면 이제 Start버튼을 눌러 나도 끝나고 퇴근하게
    //대화는 15초 정도 기다리면 나오게 한다
    float time;
    Text talkBar;    
    int talkNum;
    void Start()
    {
        talkBar = GetComponentInChildren<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TimeCheck());
    }
    //코루틴으로 만들고 시간을 측정 그시간에 맞는 맨트가 나오게 글하나하나가 나오게 대화하는 형식으로 누르면 대화를 넘길수있게만든다.
    IEnumerator TimeCheck()
    {
        yield return new WaitForSeconds(1.0f);
        time += Time.deltaTime;
        if (time >0 && talkNum ==0)
        {
            talkNum++;
            yield return StartCoroutine(TalkText("로딩이 끝나면" + " Start"+ " 버튼을 눌러주세요.\n" + "Start는 다음단계로 가는 버튼입니다."));            
        }
        else if (time > 15 && talkNum == 1)
        {
            talkNum++;
            yield return StartCoroutine(TalkText("어릴때 로딩바를 직접 잡아당기고 싶다 생각한적 없어?"));
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(TalkText("지금 해봐!"));
        }
        else if (time > 30 && talkNum == 2)
        {
            talkNum++;
            yield return StartCoroutine(TalkText("능동적으로 글자도 고치고 게임은 직접 만들어 가면서 하는거야"));
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(TalkText("글자는" + " Start"));
        }
        yield return null;

    }
    IEnumerator TalkText(string narration)
    {
        talkBar.text = "";
        for (int i = 0; i < narration.Length; i++)
        {
            talkBar.text += narration[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
