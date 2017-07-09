using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour, IInteractable {

    public void Interact(PlayerController player)
    {
        bool equipped = player.EquipItem(GetComponentInChildren<IInventoryItem>());
        if(equipped) Destroy(gameObject);
    }
}
