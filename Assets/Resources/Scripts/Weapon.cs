using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IInventoryItem
{

    public float fireRate = 0;
    public float damage = 10;
    public float bulletSpeed = 10;
    public int numBullets = 1;
    public float spreadAngle = 0;

    private float timeToFire = 0;

    /// <summary>
    /// If able to create bullets, instantiate locally and return them.
    /// </summary>
    /// <returns>List of bullets to spawn</returns>
    public List<GameObject> AttemptShot(PlayerController player)
    {
        // Single shot weapon
        if (fireRate == 0 && Input.GetButtonDown("Fire1"))
        {
            return Shoot(player);
        }
        // Automatic weapon
        else
        {
            if (Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                return Shoot(player);
            }
        }
        return null;
    }

    private List<GameObject> Shoot(PlayerController player)
    {
        List<GameObject> bulletList = new List<GameObject>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePos = (Vector2)player.firePoint.position;

        for (int i = 0; i < numBullets; i++)
        {
            GameObject bullet = Instantiate<GameObject>(ResourceLoader.instance.bulletFab, player.firePoint.position, player.firePoint.rotation);
            Vector2 tempMousePos = mousePos;
            if(spreadAngle != 0)
            {
                float angle = UnityEngine.Random.Range(-spreadAngle, spreadAngle);
                tempMousePos = mousePos.Rotate(angle);
            }
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(mousePos - firePos) * bulletSpeed;
            bullet.GetComponent<Bullet>().playerNum = player.playerNum;
            bulletList.Add(bullet);
        }

        return bulletList;
    }

    public InventoryType GetInventoryType()
    {
        return InventoryType.WEAPON;
    }
}
