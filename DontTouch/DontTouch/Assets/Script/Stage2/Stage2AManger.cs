using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Stage2AManger : MonoBehaviour
{
    //ó�� �����ҋ� ��ȭ�� ����ϸ� Ż���� �������� ���� ������ �̴ϰ����� ������ ���� Ȯ���� ������ �����Ѵ�
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
        //����ġ������ ü�¿����� 0�̸� ���� �������� ����
        if (!playerLife.startbut)
        {
            questionText.text = "INSERT COIN";
            questionText.color = Color.white;
            return;
        }
        //�ڷ�ƾ �޾ƿͼ� ����
        //���۹�ư���������� ���� 321 �ϰ���� 
        else if (playerLife.startbut && !isCount)
            StartCoroutine(CountNum());
        else if(startGame)
        {
            countTime += Time.deltaTime;
            if (countTime > nextTime || change)//������ ���߸� ���� ������
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
    //���ڸ� ���� �Ķ� �ʷ����� �ٲٰ� ���ڿ� ���� ���ڿ� �ٸ� ������ �ٲ۴�.
    //�ٲٰ� 3�ʾȿ� �´� ��ư�� ������ ���� ���������ϰų� �ٸ���ư�� ������ ����
    IEnumerator TextChange()
    {
        //change = false;
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                questionText.text = "����";                
                break;
            case 1:
                questionText.text = "�Ķ�";
                break;
            case 2:
                questionText.text = "�ʷ�";
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
            case "����":
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
            case "�Ķ�":
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
            case "�ʷ�":
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
    //�ڷ�ƾ���θ��� �÷��̾�������� ��ŸƮ�� Ʈ��� 3 2 1 �ϰ� ���ӽ���
    Color k;
    public void Collect(string color)
    {
        if (!playerLife.startbut)
            return;
        switch (color)
        {
            case "����":
                k = Color.red;
                break;
            case "�Ķ�":
                k = Color.blue;
                break;
            case "�ʷ�":
                k = Color.green;
                break;
        }
        if (questionText.color != k)
        {
            playerLife.life--;
            StartCoroutine(LifeDownEffect());
        }
        //��ư�� ������ �´� ��ư���� Ȯ�� �ƴϸ� ������ ����        
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
        //�̵��� �ƴ϶� �ε�â�ҷ�����
        if(questionText.text == "Start")
            SceneManager.LoadScene("Title");
    }
}
