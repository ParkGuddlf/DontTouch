using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    // 현재 단계의 정보를 받아와서 리스타트를 그단계다시시작 타이틀은 타이틀로
    [SerializeField] GameObject blend;
    //나왔을떄 현재 단계의 스테이지정보를 찾는다
    [SerializeField] GameObject stageInfo;

    string nextSceneName;

    void Start()
    {
        //태그에서 스테이지인포를 찾아서 그놈의 스테이지이름을 받아와서 보낸다
        stageInfo = FindObjectOfType<StageINFO>().gameObject;
    }


    public void Restart()
    {
        //그스테이지로 다시이동
    }
    public void Title()
    {
        nextSceneName = "Title";
        blend.SetActive(true);
        //타이틀로이동 
        StartCoroutine(NextScene(nextSceneName));
        
    }
    IEnumerator NextScene(string sceneName)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(0.5f);
        asyncOperation.allowSceneActivation = true;
    }

}
