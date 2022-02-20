using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImgCjange : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    Toggle toggle;
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = sprites[0];
        }
        else
            transform.GetChild(0).GetComponent<Image>().sprite = sprites[1];
    }
}
