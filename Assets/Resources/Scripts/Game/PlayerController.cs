using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Use this for initialization
    void Start()
    {
        CmdSpawnBullet();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");
        Vector2 circleVector = Vector2.ClampMagnitude(new Vector2(xSpeed, ySpeed), 1);
        float timeStep = Time.deltaTime * speed;
        transform.Translate(circleVector * timeStep);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        GetComponent<SpriteRenderer>().material.color = Color.blue;
    }

    [Command]
    private void CmdSpawnBullet()
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);
        
        NetworkServer.Spawn(bullet);
    }

    [Command]
    private void CmdFire()
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(6, 0);

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2);
    }
}
