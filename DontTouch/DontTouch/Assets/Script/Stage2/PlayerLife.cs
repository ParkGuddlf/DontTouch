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
        //�������� 0�̵Ǹ� ���ӿ������鼭 ���� ��ŸƮ �� �޽� ��������
        //�μ�Ʈ���� �ٽó����� ���� �ٽ�������� ȭ�鿡

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
    //������ ������ �ְ� ������ ������ 3 2 1 �ϰ� ��������
    public void InsertCoin()
    {
        //���κ�Ʈ��
        //��ü ���������� ����Ƚ������� ���� ���������� ���� ������ �پ���
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
