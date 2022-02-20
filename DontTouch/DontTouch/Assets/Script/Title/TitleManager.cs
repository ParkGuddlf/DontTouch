using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//풀스크린 체크박스그림 게임 시작버튼 종료버튼누르면 나가기버튼누르기 1스테이지 시작한다
public class TitleManager : MonoBehaviour
{
    public static TitleManager instance;

    //현재 타이틀의 상태
    public string titleState;
    //해상도 리스트
    [SerializeField] List<Resolution> resolutions = new List<Resolution>();
    //해상도번호
    [SerializeField] int aspectNum;
    //해상도판넬**[ser]지우지말것
    [SerializeField] Text aspectText;
    //풀스크린 체크박스**[ser]지우지말것
    [SerializeField] Toggle fullScreenToggle;
    //변경을 취소할경우 값
    [SerializeField] float soundValueCancle;
    [SerializeField] int aspectNumCancle;
    [SerializeField] bool fullScreenCancle;

    //사운드 바**[ser]지우지말것
    [SerializeField] Scrollbar soundScroll;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        resolutions.AddRange(Screen.resolutions);
        //해상도 저장불러오기
        if (!PlayerPrefs.HasKey("aspectNum"))
            aspectNum = resolutions.Count - 1;
        else
            aspectNum = PlayerPrefs.GetInt("aspectNum");
        //소리 저장불러오기
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
    //위에는 ture면 내려가고 false면 올라간다
    //아래쪽은 ture면 올라가고 false면 내려간다
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

    //버튼모음
    //이동버튼
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
    //종료버튼
    public void Quit() => Application.Quit();
    //해상도 조절버튼 해상도변경
    public void AspectButton(int i)
    {
        aspectNum += i;

        if (aspectNum < 0)
            aspectNum = resolutions.Count - 1;
        else if (aspectNum > resolutions.Count - 1)
            aspectNum = 0;
        aspectText.text = resolutions[aspectNum].width + "X" + resolutions[aspectNum].height;

    }
    //설정변경 확인 버튼
    public void CheckOK()
    {
        Screen.SetResolution(resolutions[aspectNum].width, resolutions[aspectNum].height, fullScreenToggle.isOn);
        //변경 값을 저장해서 다시켜도 유지되게
        PlayerPrefs.SetInt("aspectNum", aspectNum);
        PlayerPrefs.SetFloat("sound", soundScroll.value);
        titleState = "Title";
    }
    //설정변경 취소 버튼
    public void CheckNo()
    {
        titleState = "Title";
        //3개를 값을 바꾸면 안된다 소리값, AspectNum, 풀스크린 불값 저장해서 취소를 누르면 저장한값으로 돌려보낸다

        soundScroll.value = soundValueCancle;
        aspectNum = aspectNumCancle;
        aspectText.text = resolutions[aspectNumCancle].width + "X" + resolutions[aspectNumCancle].height;
        fullScreenToggle.isOn = fullScreenCancle;

    }
}
