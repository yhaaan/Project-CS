using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Player Info")]
    public int Level;
    [Header("# Stage Info")]
    public int StageNum; // �׽�Ʈ��.
    public ColorWallManager current_CWM; //���� ���������� colorWallManager
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
        current_CWM = stages.transform.GetChild(StageNum).Find("Color Wall").GetComponent<ColorWallManager>(); //ȨŸ��
        current_IM = stages.transform.GetChild(StageNum).Find("Items").GetComponent<ItemManager>();
        gameStart(StageNum); // �׽�Ʈ�� ���� ���ӽ��۽� �ٷ� �� ���������� �� �� �ְ��� 
    }

    public void gameStart(int number)
    {
        StageNum = number;
        instance.player.transform.position = Vector3.zero; //�÷��̾� ��ġ �ʱ�ȭ
        instance.player.ChangeColor(Color.white);           //�÷��̾� ���� �ʱ�ȭ 
        current_CWM = stages.transform.GetChild(number).Find("Color Wall").GetComponent<ColorWallManager>(); //CWM ����
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
