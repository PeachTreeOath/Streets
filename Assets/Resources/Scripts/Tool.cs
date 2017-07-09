using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour, IInventoryItem
{

    public InventoryType GetInventoryType()
    {
        return InventoryType.TOOL;
    }

    public Sprite GetItemSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }
}
