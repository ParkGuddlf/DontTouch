using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBoard : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void BoardUp()
    {
        animator.SetBool("Up", true);
    }
}
