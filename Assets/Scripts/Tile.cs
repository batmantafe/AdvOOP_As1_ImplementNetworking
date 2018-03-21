using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] terrain;
    private int randomTerrain;
    private bool terrainDone;

    // Use this for initialization
    void Start()
    {
        terrainDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        RandomiseTerrain();
    }

    void RandomiseTerrain()
    {
        if (terrainDone == false)
        {
            randomTerrain = Random.Range(0,10);
            
            // Building (0-3) 40%
            if (randomTerrain <= 4)
            {
                terrain[0].SetActive(true);
            }
            
            // Street (4-7) 40%

            // Ruin (8-9) 20%
            if (randomTerrain >= 8)
            {
                terrain[1].SetActive(true);
            }

            terrainDone = true;
        }
    }
}
