using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    // ���� �ܰ��� ������ �޾ƿͼ� ����ŸƮ�� �״ܰ�ٽý��� Ÿ��Ʋ�� Ÿ��Ʋ��
    [SerializeField] GameObject blend;
    //�������� ���� �ܰ��� �������������� ã�´�
    [SerializeField] GameObject stageInfo;

    string nextSceneName;

    void Start()
    {
        //�±׿��� �������������� ã�Ƽ� �׳��� ���������̸��� �޾ƿͼ� ������
        stageInfo = FindObjectOfType<StageINFO>().gameObject;
    }


    public void Restart()
    {
        //�׽��������� �ٽ��̵�
    }
    public void Title()
    {
        nextSceneName = "Title";
        blend.SetActive(true);
        //Ÿ��Ʋ���̵� 
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
