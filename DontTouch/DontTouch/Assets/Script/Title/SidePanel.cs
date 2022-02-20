using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePanel : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Title", TitleManager.instance.start);        
    }
}
