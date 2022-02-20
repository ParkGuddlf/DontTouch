using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//����� �Ϻκи� �����ֱ�� �����پ��鼭 ����ȭ���� �ε����� ����� 1�������� ���� ��� ���ӽ����� �Ϻκи� �����ֱ� �ݴ�� �����ϸ� �ɵ�

public class NextStage : MonoBehaviour
{
    [SerializeField] string zoomMod;
    //Bland1�� ��ġ�� retcttra posx1060�̸� �پ������
    [SerializeField] GameObject bland1;

    void Update()
    {
        switch (zoomMod)
        {
            case "IN":
                if (bland1.GetComponent<RectTransform>().position.x <= -18 )//��,�����ε� ��ġ�� �ƴ� �������� ��ư�� ��������
                {
                    if (transform.localScale.x > 0)
                        transform.localScale -= Vector3.one * 25;
                    else if (transform.localScale.x == 0)
                        SceneManager.LoadScene("Stage1");

                }
                break;
            case "OUT":
                if (transform.localScale.x < 3000)
                    transform.localScale += Vector3.one * 25;
                break;
        }
        
    }
}
