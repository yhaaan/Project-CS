using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWallManager : MonoBehaviour
{
    //�����յ��� ������ ����
    public wall[] walls;

    private void Awake()
    {
       
    }
    private void OnEnable()
    {
        walls = this.GetComponentsInChildren<wall>();
    }
    public void JudgeColor()
    {
        foreach(wall wall in walls)
        {
            wall.SetColl();
        }
    }

}
