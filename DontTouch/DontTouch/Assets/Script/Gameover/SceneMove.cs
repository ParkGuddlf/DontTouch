using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene("GameOver"));
    }

    IEnumerator NextScene(string sceneName)
    {
        yield return null;
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);  
    }
}
