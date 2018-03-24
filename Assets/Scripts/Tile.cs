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
            
            // Building (0-1) 20%
            if (randomTerrain <= 1)
            {
                terrain[0].SetActive(true);
            }
            
            // Street (2-5) 40%

            // Ruin TOP (6-7) 20%
            if (randomTerrain == 6 || randomTerrain == 7)
            {
                terrain[1].SetActive(true);
            }

            // Ruin RIGHT (8-9) 20%
            if (randomTerrain >= 8)
            {
                terrain[2].SetActive(true);
            }

            terrainDone = true;
        }
    }
}
