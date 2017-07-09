using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour, IInventoryItem
{

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public InventoryType GetInventoryType()
    {
        return InventoryType.TOOL;
    }
}
