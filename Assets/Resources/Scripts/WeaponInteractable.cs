using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteractable : MonoBehaviour, Interactable {

    public Weapon weapon;

    public void Interact(PlayerController player)
    {
        player.EquipWeapon(weapon);
        Destroy(gameObject);
    }
}
