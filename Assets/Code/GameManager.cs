using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Player Info")]
    public int Level;
    [Header("# Stage Info")]
    public int StageNum; // 테스트용.
    public ColorWallManager current_CWM; //현재 스테이지의 colorWallManager
    public ItemManager current_IM;
    public Color currentColor;
    [Header("# Game Object")]
    public Player player;
    public GameObject stages;
    
    private void Awake()
    {
        Level = 0;
        instance = this;
        currentColor = player.GetComponent<SpriteRenderer>().color;
        current_CWM = stages.transform.GetChild(StageNum).Find("Color Wall").GetComponent<ColorWallManager>(); //홈타운
        current_IM = stages.transform.GetChild(StageNum).Find("Items").GetComponent<ItemManager>();
        gameStart(StageNum); // 테스트를 위해 게임시작시 바로 그 스테이지로 갈 수 있게함 
    }

    public void gameStart(int number)
    {
        StageNum = number;
        instance.player.transform.position = Vector3.zero; //플레이어 위치 초기화
        instance.player.ChangeColor(Color.white);           //플레이어 색상 초기화 
        current_CWM = stages.transform.GetChild(number).Find("Color Wall").GetComponent<ColorWallManager>(); //CWM 설정
        current_IM = stages.transform.GetChild(number).Find("Items").GetComponent<ItemManager>();
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
