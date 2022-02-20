using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPanel : MonoBehaviour
{
    Animator animator;
    RectTransform rectTransform;
    [SerializeField] Transform center;
    [SerializeField] Transform top;
    [SerializeField] string panelOnState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleManager.instance.titleState == panelOnState)
        {
            transform.position = Vector3.MoveTowards(transform.position, center.position + new Vector3(0, 1, 0), 50 * Time.deltaTime);
        }
        else if (TitleManager.instance.titleState != panelOnState)
        {
            transform.position = Vector3.MoveTowards(transform.position, top.position , 50 * Time.deltaTime);
        }
    }
    IEnumerator Down()
    {

        yield return new WaitForSeconds(0.5f);
    }

}
