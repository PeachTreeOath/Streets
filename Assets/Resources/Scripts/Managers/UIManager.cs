using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

	public void UpdateInventoryImage(int position, Sprite newSprite)
    {
        Transform item = transform.FindDeepChild("Item" + position);
        item.GetComponent<Image>().sprite = newSprite;
    }
}
