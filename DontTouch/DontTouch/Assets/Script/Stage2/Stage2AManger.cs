using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Stage2AManger : MonoBehaviour
{
    //처음 시작할떄 대화로 어떻게하면 탈출이 가능한지 설명 그이후 미니게임의 설명문을 띄우고 확인을 누르면 시작한다
    [SerializeField] Text questionText;
    [SerializeField] float countTime;
    public int realTime;
    float nextTime = 1.0f;
    [SerializeField] bool change;
    PlayerLife playerLife;

    public bool isCount;
    public bool startGame;

    [SerializeField] Image coinIMG;
    [SerializeField] List<Sprite> coinSprite;
    [SerializeField] GameObject dmgEffect;
    // Start is called before the first frame update
    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinSpriteChange();
        //스위치문으로 체력에따라서 0이면 정지 나머지는 진행
        if (!playerLife.startbut)
        {
            questionText.text = "INSERT COIN";
            questionText.color = Color.white;
            return;
        }
        //코루틴 받아와서 시작
        //시작버튼을눌렀을때 시작 321 하고시작 
        else if (playerLife.startbut && !isCount)
            StartCoroutine(CountNum());
        else if(startGame)
        {
            countTime += Time.deltaTime;
            if (countTime > nextTime || change)//정답을 맞추면 다음 문제로
            {
                change = false;
                StartCoroutine(TextChange());
                if (countTime > 1)
                {
                    playerLife.life--;
                    StartCoroutine(LifeDownEffect());
                }
                countTime = 0;
            }
        }
    }
    //글자를 빨강 파랑 초록으로 바꾸고 글자에 따라 글자와 다른 색갈로 바꾼다.
    //바꾸고 3초안에 맞는 버튼을 누르면 성공 누르지못하거나 다른버튼을 누르면 실패
    IEnumerator TextChange()
    {
        //change = false;
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                questionText.text = "빨강";                
                break;
            case 1:
                questionText.text = "파랑";
                break;
            case 2:
                questionText.text = "초록";
                break;
        }
        ChangeColor();
        yield return null;
    }
    void ChangeColor()
    {
        int colorNum = Random.Range(0, 2);

        switch (questionText.text)
        {
            case "빨강":
                switch (colorNum)
                {
                    case 0:
                        questionText.color = Color.blue;
                        break;
                    case 1:
                        questionText.color = Color.green;
                        break;
                }
                break;
            case "파랑":
                switch (colorNum)
                {
                    case 0:
                        questionText.color = Color.red;
                        break;
                    case 1:
                        questionText.color = Color.green;
                        break;
                }
                break;
            case "초록":
                switch (colorNum)
                {
                    case 0:
                        questionText.color = Color.red;
                        break;
                    case 1:
                        questionText.color = Color.blue;
                        break;
                }
                break;
            default:
                questionText.color = Color.white;
                break;
        }
        
    }
    //코루틴으로만들어서 플레이어라이프에 스타트가 트루면 3 2 1 하고 게임시작
    Color k;
    public void Collect(string color)
    {
        if (!playerLife.startbut)
            return;
        switch (color)
        {
            case "빨강":
                k = Color.red;
                break;
            case "파랑":
                k = Color.blue;
                break;
            case "초록":
                k = Color.green;
                break;
        }
        if (questionText.color != k)
        {
            playerLife.life--;
            StartCoroutine(LifeDownEffect());
        }
        //버튼을 누르면 맞는 버튼인지 확인 아니면 라이프 감소        
        change = true;
        countTime = 0;

    }
    IEnumerator CountNum()
    {
        isCount = true;
        questionText.text = "3";
        yield return new WaitForSeconds(1f);
        questionText.text = "2";
        yield return new WaitForSeconds(1f);
        questionText.text = "1";
        yield return new WaitForSeconds(1f);
        questionText.text = "Start";
        yield return new WaitForSeconds(1f);
        startGame = true;
    }
    IEnumerator LifeDownEffect()
    {
        dmgEffect.SetActive(true);
        Debug.Log("red Effect on");
        yield return new WaitForSeconds(0.1f);
        dmgEffect.SetActive(false);
        Debug.Log("red Effect off");
    }
    void CoinSpriteChange()
    {
        switch (playerLife.coinNum)
        {
            case 5:
                coinIMG.sprite = coinSprite[0];
                break;
            case 4:
                coinIMG.sprite = coinSprite[1];
                break;
            case 3:
                coinIMG.sprite = coinSprite[2];
                break;
            case 2:
                coinIMG.sprite = coinSprite[3];
                break;
            case 1:
                coinIMG.sprite = coinSprite[4];
                break;
            case 0:
                coinIMG.sprite = coinSprite[5];
                break;
        }
    }

    public void QuestionTextStart()
    {
        //이동이 아니라 로딩창불러오기
        if(questionText.text == "Start")
            SceneManager.LoadScene("Title");
    }
}
