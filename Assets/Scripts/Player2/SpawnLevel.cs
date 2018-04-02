using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class SpawnLevel : NetworkBehaviour
{
    public GameObject levelPrefab;
    GameObject levelInstantiated;

    private bool levelDone;

    void Start()
    {
        CmdSyncLevel();
    }

    [Command]
    void CmdSyncLevel()
    {
        levelDone = false;

        if (isServer && levelDone == false)
        {
            Debug.Log("is Server!");

            levelInstantiated = Instantiate(levelPrefab);

            NetworkServer.Spawn(levelInstantiated);

            levelDone = true;
        }
    }
}
