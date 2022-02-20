using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject coinObjt;
    public int life;
    bool coin;
    public bool startbut;
    public int coinNum;
    Stage2AManger stage2;

    [SerializeField] GameObject gameover;
    void Start()
    {
        stage2 = FindObjectOfType<Stage2AManger>();
    }

    // Update is called once per frame
    void Update()
    {
        //라이프가 0이되면 게임오버띄우면서 코인 스타트 불 펄스 게임정지
        //인설트코인 다시나오고 색깔도 다시흰색으로 화면에

        if (life == 0)
        {
            coin = false;
            startbut = false;
            stage2.isCount = false;
            stage2.startGame = false;
            coinObjt.SetActive(false);
        }
        if (coinNum == 0 && !coin)
        {
            gameover.SetActive(true);
        }
    }
    //동전을 눌러서 넣고 시작을 누르면 3 2 1 하고 문제출제
    public void InsertCoin()
    {
        //코인불트루
        //전체 동전개수로 가능횟수만들기 동전 넣을때만다 동전 갯수가 줄어든다
        if (!coin)
        {
            life = 3;
            coin = true;
            coinNum--;
            coinObjt.SetActive(true);
        }
    }
    public void StartGame()
    {
        if (coin)
            startbut = true;
    }


}
