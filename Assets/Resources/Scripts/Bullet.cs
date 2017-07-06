﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int playerNum;

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Check for bullet hitting self first
        PlayerController player = col.GetComponent<PlayerController>();
        if (player != null)
        {
            if (player.playerNum == playerNum)
                return;
        }

        Health health = col.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

        if(col.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
