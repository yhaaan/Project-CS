using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int stageNum = 0; //�� �������� �ѹ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.gameStart(stageNum);
    }
}
