using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public int bulletBudget = 100;
    private int bulletIndex;
    private List<GameObject> bullets = new List<GameObject>();

    private GameObject objectPoolParent;
    private GameObject bulletParent;

    void Init()
    {
        Clear();

        objectPoolParent = new GameObject();
        bulletParent = new GameObject();

        bulletParent.transform.SetParent(objectPoolParent.transform);

        CreateBudget(ResourceLoader.instance.bulletFab, bulletBudget, bulletParent, bullets);
    }

    private void CreateBudget(GameObject prefab, int budget, GameObject parent, List<GameObject> list)
    {
        for(int i = 0; i < budget; i++)
        {
            GameObject go = Instantiate(prefab);
            go.SetActive(false);
            go.transform.SetParent(parent.transform);
        }
    }

    public GameObject RequestObject(OP_Type type)
    {
        GameObject returnObj = null;

        switch(type)
        {
            case OP_Type.bullet:
                if (bulletIndex > bullets.Count - 1)
                    bulletIndex = 0;
                returnObj = bullets[bulletIndex];
                bulletIndex++;
                break;
        }

        return returnObj;
    }

    private void Clear()
    {
        if(objectPoolParent)
            Destroy(objectPoolParent);
        if (bulletParent)
            Destroy(bulletParent);

        bullets.Clear();
    }

    public enum OP_Type
    {
        bullet
    }
}
