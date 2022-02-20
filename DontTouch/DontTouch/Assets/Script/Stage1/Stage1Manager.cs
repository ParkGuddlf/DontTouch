using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Manager : MonoBehaviour
{
    [SerializeField] Text butText;
    [SerializeField] Slider slider;
    void Start()
    {
        StartCoroutine(SliderValuePlus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //코루틴
    IEnumerator SliderValuePlus()
    {
        yield return new WaitForSeconds(2f);
        while (slider.value<0.5f)
        {
            slider.value += Random.Range(0.01f, 0.1f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    //다음씬버튼
    public void NextStage()
    {
        if (butText.text == "Start" && slider.value >= 0.95f)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (butText.text == "Menu")
        {
            //LoadSceneAsync게임 오버버튼나오게 
            SceneManager.LoadScene("Title");
        }
    }


}
