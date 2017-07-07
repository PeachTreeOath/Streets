using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AIDirector : NetworkBehaviour
{

    public static AIDirector instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    /// <summary>
    /// Selects next target to attack.
    /// </summary>
    /// <param name="transform"></param>
    /// <returns>Closest player transform. Null if no player found.</returns>
    public Transform ChooseTarget(Transform transform)
    {
        // Find nearest player
        // TODO: Make this more sophisticated
        int nearestPlayer = 0;
        float nearestDistance = float.MaxValue;
        foreach(KeyValuePair<int, PlayerController> entry in GameManager.instance.playerList)
        {
            PlayerController newPlayer = entry.Value;
            float newDistance = Vector2.Distance(transform.position, newPlayer.transform.position);
            if (newDistance < nearestDistance)
            {
                nearestDistance = newDistance;
                nearestPlayer = newPlayer.playerNum;
            }
        }

        Transform closestTransform = null;
        if(nearestPlayer != 0)
        {
            closestTransform = GameManager.instance.playerList[nearestPlayer].transform;
        }
        return closestTransform;
    }

}
