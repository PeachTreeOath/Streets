using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour, IInteractable {

    public IInventoryItem item;

    public void Interact(PlayerController player)
    {
        bool equipped = player.EquipItem(item);
        if(equipped) Destroy(gameObject);
    }
}
