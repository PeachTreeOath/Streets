using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private Rigidbody2D rBody;
    private Weapon weapon;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();

        if(isLocalPlayer)
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
            GameObject bullet = weapon.AttemptShot();
            if (bullet)
            {
                CmdFire(bullet);
            }
        }

        if(Input.GetButton("Interact"))
        {

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
    private void CmdFire(GameObject bullet)
    {
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }
}
