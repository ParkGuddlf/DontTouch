using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Ǯ��ũ�� üũ�ڽ��׸� ���� ���۹�ư �����ư������ �������ư������ 1�������� �����Ѵ�
public class TitleManager : MonoBehaviour
{
    public static TitleManager instance;

    //���� Ÿ��Ʋ�� ����
    public string titleState;
    //�ػ� ����Ʈ
    [SerializeField] List<Resolution> resolutions = new List<Resolution>();
    //�ػ󵵹�ȣ
    [SerializeField] int aspectNum;
    //�ػ��ǳ�**[ser]����������
    [SerializeField] Text aspectText;
    //Ǯ��ũ�� üũ�ڽ�**[ser]����������
    [SerializeField] Toggle fullScreenToggle;
    //������ ����Ұ�� ��
    [SerializeField] float soundValueCancle;
    [SerializeField] int aspectNumCancle;
    [SerializeField] bool fullScreenCancle;

    //���� ��**[ser]����������
    [SerializeField] Scrollbar soundScroll;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        resolutions.AddRange(Screen.resolutions);
        //�ػ� ����ҷ�����
        if (!PlayerPrefs.HasKey("aspectNum"))
            aspectNum = resolutions.Count - 1;
        else
            aspectNum = PlayerPrefs.GetInt("aspectNum");
        //�Ҹ� ����ҷ�����
        if (!PlayerPrefs.HasKey("sound"))
            soundScroll.value = 0.5f;
        else
            soundScroll.value = PlayerPrefs.GetFloat("sound");

    }
    private void Start()
    {
        titleState = "Title";

        aspectText.text = resolutions[aspectNum].width + " X " + resolutions[aspectNum].height;
    }
    //������ ture�� �������� false�� �ö󰣴�
    //�Ʒ����� ture�� �ö󰡰� false�� ��������
    public bool aniBool;
    public bool start = true;
    void Update()
    {
        switch (titleState)
        {
            case "Title":
                aniBool = true;
                break;
            case "Option":
                aniBool = false;
                break;
            case "Exit":
                break;
            case "Start":
                aniBool = false;
                start = false;
                
                break;
        }

    }

    //��ư����
    //�̵���ư
    public void ButtonClick(string _titleState)
    {
        titleState = _titleState;
        if (titleState == "Option")
        {
            soundValueCancle = soundScroll.value;
            aspectNumCancle = aspectNum;
            fullScreenCancle = fullScreenToggle.isOn;
        }
    }
    //�����ư
    public void Quit() => Application.Quit();
    //�ػ� ������ư �ػ󵵺���
    public void AspectButton(int i)
    {
        aspectNum += i;

        if (aspectNum < 0)
            aspectNum = resolutions.Count - 1;
        else if (aspectNum > resolutions.Count - 1)
            aspectNum = 0;
        aspectText.text = resolutions[aspectNum].width + "X" + resolutions[aspectNum].height;

    }
    //�������� Ȯ�� ��ư
    public void CheckOK()
    {
        Screen.SetResolution(resolutions[aspectNum].width, resolutions[aspectNum].height, fullScreenToggle.isOn);
        //���� ���� �����ؼ� �ٽ��ѵ� �����ǰ�
        PlayerPrefs.SetInt("aspectNum", aspectNum);
        PlayerPrefs.SetFloat("sound", soundScroll.value);
        titleState = "Title";
    }
    //�������� ��� ��ư
    public void CheckNo()
    {
        titleState = "Title";
        //3���� ���� �ٲٸ� �ȵȴ� �Ҹ���, AspectNum, Ǯ��ũ�� �Ұ� �����ؼ� ��Ҹ� ������ �����Ѱ����� ����������

        soundScroll.value = soundValueCancle;
        aspectNum = aspectNumCancle;
        aspectText.text = resolutions[aspectNumCancle].width + "X" + resolutions[aspectNumCancle].height;
        fullScreenToggle.isOn = fullScreenCancle;

    }
}
