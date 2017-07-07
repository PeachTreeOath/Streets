using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{

    [SyncVar]
    public int currentPlayerNum;

    public Dictionary<int, PlayerController> playerList;

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

        playerList = new Dictionary<int, PlayerController>();
    }

    void Start()
    {
        Cursor.visible = false;
    }

    public int RegisterPlayer(PlayerController newPlayer)
    {
        currentPlayerNum++;
        playerList.Add(currentPlayerNum, newPlayer);

        return currentPlayerNum;
    }
}
