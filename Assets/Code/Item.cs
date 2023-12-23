using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Color color;
  
    float moveDuration = 0.5f;
    public Vector3 testPortalVec;
    Vector3 startVec;
    Vector3 endVec;
    Vector3 tempVec;

    private float elapsedTime = 0f;
    private float t = 0;
    private void Awake()
    {
        color = GetComponent<SpriteRenderer>().color;
    }
    private void Start()
    {
        startVec = transform.position;
        endVec = startVec - new Vector3(0, 0.1f, 0);
    }

    private void Update()
    {
        switch (transform.tag)
        {
            
            case "Brush":
            case "Point":
            case "Paint":
                if (t < 1)
                {
                    elapsedTime += Time.deltaTime;
                    t = Mathf.Clamp01(elapsedTime / moveDuration);
                    transform.position = Vector3.Lerp(startVec, endVec, t);
                }
                if (t >= 1f)
                {
                    t = 0;
                    elapsedTime = 0;
                    tempVec = startVec;
                    startVec = endVec;
                    endVec = tempVec;
                }
                break;
            case "Water":
            case "testPortal":
                break;
        }
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (transform.tag)
        {

            case "Brush":
                GameManager.instance.player.MixColor(color);
                gameObject.SetActive(false);
                //Destroy(gameObject);
                break;
            case "Paint":
                GameManager.instance.player.ChangeColor(color);
                gameObject.SetActive(false);
                //Destroy(gameObject);
                break;
            case "Water":
                GameManager.instance.player.ChangeColor(color);
                break;
            case "Point":
                gameObject.SetActive(false);
                //Destroy(gameObject);
                break;
            case "Trap":
                GameManager.instance.current_IM.resetItems();
                GameManager.instance.player.ChangeColor(Color.white);
                GameManager.instance.player.transform.position = new Vector3(0, 0, 0);
                
                break;
            case "Finish":
                GameManager.instance.gameStart(0);
                GameManager.instance.player.transform.position = new Vector3(0, 0, 0);
                break;
            case "testPortal":
                GameManager.instance.player.gameObject.transform.position = testPortalVec;
                break;
        }
        
        GameManager.instance.currentColor = GameManager.instance.player.GetComponent<SpriteRenderer>().color;   //GameManager¿« currentColor ∞ªΩ≈
        GameManager.instance.current_CWM.JudgeColor();
        //Debug.Log(GameManager.instance.currentColor);
    }
    
}
