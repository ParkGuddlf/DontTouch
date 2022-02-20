using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    Image fadeoutIMG;
    
    private void Awake()
    {
        fadeoutIMG = GetComponent<Image>();
        StartCoroutine(_FadeOut());
        

    }
    private void Start()
    {
        
    }


    IEnumerator _FadeOut()
    {
        while(fadeoutIMG.color.a != 0)
        {
            if(fadeoutIMG.color.a < 0.2f)
            {
                Destroy(gameObject);
                break;
            }    
            Color _color = fadeoutIMG.color;
            _color.a -= 0.1f;
            yield return new WaitForSeconds(0.05f);
            fadeoutIMG.color = _color;
        }        
    }
}
