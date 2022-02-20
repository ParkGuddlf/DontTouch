using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//데브곰 일부분만 보여주기로 점점줄어들면서 검정화면의 로딩씬을 만들고 1스테이지 제외 모든 게임시작을 일부분만 보여주기 반대로 시작하면 될듯

public class NextStage : MonoBehaviour
{
    [SerializeField] string zoomMod;
    //Bland1의 위치가 retcttra posx1060이면 줄어들기시작
    [SerializeField] GameObject bland1;

    void Update()
    {
        switch (zoomMod)
        {
            case "IN":
                if (bland1.GetComponent<RectTransform>().position.x <= -18 )//ㅂ,ㄹ라인드 위치가 아닌 스테이지 버튼을 눌렀을때
                {
                    if (transform.localScale.x > 0)
                        transform.localScale -= Vector3.one * 25;
                    else if (transform.localScale.x == 0)
                        SceneManager.LoadScene("Stage1");

                }
                break;
            case "OUT":
                if (transform.localScale.x < 3000)
                    transform.localScale += Vector3.one * 25;
                break;
        }
        
    }
}
