using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IInventoryItem
{

    public float fireRate = 0;
    public float damage = 10;
    public float bulletSpeed = 10;

    private float timeToFire = 0;
    private Transform firePoint;

    // Use this for initialization
    void Start()
    {
        firePoint = transform.Find("FirePoint");
    }

    /// <summary>
    /// If able to create a bullet, instantiate one locally and return it.
    /// </summary>
    /// <returns></returns>
    public GameObject AttemptShot(PlayerController player)
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

    private GameObject Shoot(PlayerController player)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePos = (Vector2)firePoint.position;

        GameObject bullet = Instantiate<GameObject>(ResourceLoader.instance.bulletFab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(mousePos - firePos) * bulletSpeed;
        bullet.GetComponent<Bullet>().playerNum = player.playerNum;

        return bullet;
    }

    public InventoryType GetInventoryType()
    {
        return InventoryType.WEAPON;
    }
}
