using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //프리팹들을 보관할 변수
    public Item[] Items;

    private void OnEnable()
    {
        Items = this.GetComponentsInChildren<Item>();
    }
    public void resetItems()
    {
        foreach (Item item in Items)
        {
            item.gameObject.SetActive(true);
        }
    }
}
