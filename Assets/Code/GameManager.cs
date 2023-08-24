using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Current Stage")]
    public int number; // �׽�Ʈ��.
    public ColorWallManager current_CWM; //���� ���������� colorWallManager
    public Color currentColor;
    [Header("# Game Object")]
    public Player player;
    public GameObject stages;
    
    private void Awake()
    {
        instance = this;
        currentColor = player.GetComponent<SpriteRenderer>().color;
        current_CWM = stages.transform.GetChild(number).Find("Color Wall").GetComponent<ColorWallManager>(); //ȨŸ��
        gameStart(number); // �׽�Ʈ�� ���� ���ӽ��۽� �ٷ� �� ���������� �� �� �ְ��� 
    }

    public void gameStart(int number)
    {
        instance.player.transform.position = Vector3.zero;
        instance.player.ChangeColor(Color.white);
        current_CWM = stages.transform.GetChild(number).Find("Color Wall").GetComponent<ColorWallManager>();//ȨŸ��� �Ѿ��
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
