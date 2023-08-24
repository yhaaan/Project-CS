using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    Collider2D coll;
    public Color color;
    private void Start()
    {
        //color = GetComponent<SpriteRenderer>().color;
        coll = GetComponent<Collider2D>();
    }

    public void SetColl()
    {
        if (Color.Equals(GameManager.instance.currentColor, color))
        {
            coll.enabled = false;
        }
        else
            coll.enabled = true;
    }
}
