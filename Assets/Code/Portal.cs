using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] stateSprite = new Sprite[3];
    public int stageNum = 0; //들어갈 스테이지 넘버
    public bool isLock = true;
    private ColorEffect colorEffect;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorEffect = GetComponentInChildren<ColorEffect>();
        change_Challenge();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLock == true)
            return;
        GameManager.instance.gameStart(stageNum);
    }
    public void change_Lock() //잠김
    {
        colorEffect.onOff = false;
        spriteRenderer.sprite = stateSprite[0];
    }
    public void change_Challenge() //도전가능
    {
        spriteRenderer.sprite = stateSprite[1];
    }
    
    public void change_Clear() //클리어
    {
        colorEffect.onOff = true;
        spriteRenderer.sprite = stateSprite[2];
    }
}
