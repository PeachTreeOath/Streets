using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : Singleton<ResourceLoader>
{

    public GameObject bullet;
    public GameObject bulletTrail;
    public GameObject muzzleFlash;

    protected override void Awake()
    {
        base.Awake();

        LoadResources();
    }

    private void LoadResources()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletTrail = Resources.Load<GameObject>("Prefabs/BulletTrail");
        muzzleFlash = Resources.Load<GameObject>("Prefabs/MuzzleFlash");
    }
}
