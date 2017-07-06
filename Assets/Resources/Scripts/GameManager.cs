using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{

    [SyncVar]
    public int currentPlayerNum;

    public static GameManager instance;

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
        //Cursor.visible = false;
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        Debug.Log(player);
    }

    public int GetCurrentPlayerNum()
    {
        return currentPlayerNum++;
    }
}
