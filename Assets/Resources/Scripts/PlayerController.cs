﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{


    public float speed = 5f;

    public int playerNum;
    public Transform firePoint;

    private Inventory inventory;
    private Rigidbody2D rBody;
    private Collider2D mCollider;
    private ContactFilter2D interactableFilter;

    public override void OnStartClient()
    {
        base.OnStartClient();

        playerNum = GameManager.instance.RegisterPlayer(this);
    }

    void Start()
    {
        firePoint = transform.Find("FirePoint");
        rBody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();
        interactableFilter = new ContactFilter2D();
        interactableFilter.useTriggers = true;

        if (isLocalPlayer)
        {
            Camera.main.GetComponent<CameraFollow>().SetFollow(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            //transform.position = Vector2.Lerp(transform.position, syncPos, Time.deltaTime * lerpRate);
        }

        if (Input.GetButton("Fire1"))
        {
            Weapon currWeapon = inventory.GetWeapon();
            if (currWeapon != null)
            {
                List<GameObject> bullet = currWeapon.AttemptShot(this);
                if (bullet != null)
                {
                    CmdFire(bullet);
                }
            }
        }

        if (Input.GetButton("Interact"))
        {
            Interact();
        }

        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");
        Vector2 circleVector = Vector2.ClampMagnitude(new Vector2(xSpeed, ySpeed), 1);
        float timeStep = Time.deltaTime * speed;
        rBody.velocity = circleVector * timeStep;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        GetComponent<SpriteRenderer>().material.color = Color.blue;
    }

    [Command]
    private void CmdFire(List<GameObject> bulletList)
    {
        foreach (GameObject bullet in bulletList)
        {
            NetworkServer.Spawn(bullet);
            Destroy(bullet, 2);
        }
    }

    private void Interact()
    {
        Collider2D[] overlaps = new Collider2D[8];
        int numResults = mCollider.OverlapCollider(interactableFilter, overlaps);
        if (numResults > 0)
        {
            for (int i = 0; i < numResults; i++)
            {
                IInteractable interactable = overlaps[i].GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(this);
                }
            }
        }
    }

    public bool EquipItem(IInventoryItem newItem)
    {
        return inventory.AddToInventory(newItem);
    }
}
