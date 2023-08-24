using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWallManager : MonoBehaviour
{
    //프리팹들을 보관할 변수
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
