using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    //��ȭ�ý��� ����� ������ư������ ������ȭ�������� �����ð��� ������ ��Ʈ�� �ش�.
    //�ε��� ��ٸ��⸸ �Ҳ��� ���� �ٸ� ��� �������� �ɵ������� ������ �϶����̾�
    //������ ���� Start��ư�� ���� ���� ������ ����ϰ�
    //��ȭ�� 15�� ���� ��ٸ��� ������ �Ѵ�
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
    //�ڷ�ƾ���� ����� �ð��� ���� �׽ð��� �´� ��Ʈ�� ������ ���ϳ��ϳ��� ������ ��ȭ�ϴ� �������� ������ ��ȭ�� �ѱ���ְԸ����.
    IEnumerator TimeCheck()
    {
        yield return new WaitForSeconds(1.0f);
        time += Time.deltaTime;
        if (time >0 && talkNum ==0)
        {
            talkNum++;
            yield return StartCoroutine(TalkText("�ε��� ������" + " Start"+ " ��ư�� �����ּ���.\n" + "Start�� �����ܰ�� ���� ��ư�Դϴ�."));            
        }
        else if (time > 15 && talkNum == 1)
        {
            talkNum++;
            yield return StartCoroutine(TalkText("��� �ε��ٸ� ���� ��ƴ��� �ʹ� �������� ����?"));
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(TalkText("���� �غ�!"));
        }
        else if (time > 30 && talkNum == 2)
        {
            talkNum++;
            yield return StartCoroutine(TalkText("�ɵ������� ���ڵ� ��ġ�� ������ ���� ����� ���鼭 �ϴ°ž�"));
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(TalkText("���ڴ�" + " Start"));
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
