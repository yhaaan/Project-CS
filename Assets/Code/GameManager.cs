using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Current Stage")]
    public int number; // 테스트용.
    public ColorWallManager current_CWM; //현재 스테이지의 colorWallManager
    public Color currentColor;
    [Header("# Game Object")]
    public Player player;
    public GameObject stages;
    
    private void Awake()
    {
        instance = this;
        currentColor = player.GetComponent<SpriteRenderer>().color;
        current_CWM = stages.transform.GetChild(number).Find("Color Wall").GetComponent<ColorWallManager>(); //홈타운
        gameStart(number); // 테스트를 위해 게임시작시 바로 그 스테이지로 갈 수 있게함 
    }

    public void gameStart(int number)
    {
        instance.player.transform.position = Vector3.zero;
        instance.player.ChangeColor(Color.white);
        current_CWM = stages.transform.GetChild(number).Find("Color Wall").GetComponent<ColorWallManager>();//홈타운에서 넘어갈때
        for (int i = 0; i < stages.transform.childCount; i++)
        {
            if (i == number)
                stages.transform.GetChild(i).gameObject.SetActive(true);
            else
                stages.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}

[System.Serializable]
public struct StageInfo
{
    public int stageNumber;
    public ColorWallManager colorWallManager;
}
