using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageINFO : MonoBehaviour
{
    public static StageINFO instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    //���� Ŭ������ ���������� ������ ����ִ´�.
    public string scenename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scenename != SceneManager.GetActiveScene().name)
            scenename = SceneManager.GetActiveScene().name;
    }
}
