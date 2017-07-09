using UnityEngine;

public interface IInventoryItem
{
    InventoryType GetInventoryType();

    Sprite GetItemSprite();

    void SetParent(Transform parent);
}
