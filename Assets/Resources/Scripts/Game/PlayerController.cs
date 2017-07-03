using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private Weapon weapon;

    void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            GameObject bullet = weapon.AttemptShot();
            if (bullet)
            {
                CmdFire(bullet);
            }
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
    private void CmdFire(GameObject bullet)
    {
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }
}
