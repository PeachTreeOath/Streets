using System;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public int playerNum;

    public float speed = 5f;
    public Transform bulletSpawn;

    private Rigidbody2D rBody;
    private Collider2D mCollider;

    private Weapon weapon;

    private ContactFilter2D interactableFilter;

    public override void OnStartClient()
    {
        base.OnStartClient();

        playerNum = GameManager.instance.RegisterPlayer(this);
    }

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();
        weapon = GetComponentInChildren<Weapon>();
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
            GameObject bullet = weapon.AttemptShot(this);
            if (bullet)
            {
                CmdFire(bullet);
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
    private void CmdFire(GameObject bullet)
    {
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }

    private void Interact()
    {
        Collider2D[] overlaps = new Collider2D[8];
        int numResults = mCollider.OverlapCollider(interactableFilter, overlaps);
        if (numResults > 0)
        {
            for (int i = 0; i < numResults; i++)
            {
                Interactable interactable = overlaps[i].GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact(this);
                }
            }
        }
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        Destroy(weapon);
        newWeapon.transform.SetParent(transform);
        weapon = newWeapon;
    }
}
