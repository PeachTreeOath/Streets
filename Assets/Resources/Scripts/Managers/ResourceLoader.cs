using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : Singleton<ResourceLoader>
{

    public GameObject bulletFab;
    public GameObject bulletTrailFab;
    public GameObject muzzleFlashFab;

    public GameObject buildingFab;
    public GameObject hqFab;
    public GameObject wallFab;
    public GameObject doorFab;
    public GameObject floorFab;
    public GameObject streetFab;

    public GameObject pistolPickupFab;
    public GameObject shotgunPickupFab;

    protected override void Awake()
    {
        base.Awake();

        LoadResources();
    }

    private void LoadResources()
    {
        bulletFab = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletTrailFab = Resources.Load<GameObject>("Prefabs/BulletTrail");
        muzzleFlashFab = Resources.Load<GameObject>("Prefabs/MuzzleFlash");

       // buildingFab = Resources.Load<GameObject>("Prefabs/Building");
       // hqFab = Resources.Load<GameObject>("Prefabs/HQ");
        wallFab = Resources.Load<GameObject>("Prefabs/Wall");
        doorFab = Resources.Load<GameObject>("Prefabs/Door");
        // floorFab = Resources.Load<GameObject>("Prefabs/Floor");
        // streetFab = Resources.Load<GameObject>("Prefabs/Street");

        pistolPickupFab = Resources.Load<GameObject>("Prefabs/Pickups/PistolPickup");
        shotgunPickupFab = Resources.Load<GameObject>("Prefabs/Pickups/ShotgunPickup");
    }
}
