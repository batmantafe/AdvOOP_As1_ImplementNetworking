using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Randomise Terrain")]
    public GameObject[] terrain;
    private int randomTerrain;
    private bool terrainDone;

    void Start()
    {
        terrainDone = false;
    }

    void Update()
    {
        RandomiseTerrain();
    }

    #region Randomise Terrain
    void RandomiseTerrain()
    {
        if (terrainDone == false)
        {
            randomTerrain = Random.Range(0,10);
            
            // Building (0) 10%
            if (randomTerrain == 0)
            {
                terrain[0].SetActive(true);
            }
            
            // Street (1-3) 30%

            // Ruin TOP (4-6) 30%
            if (randomTerrain >= 4 && randomTerrain <= 6)
            {
                terrain[1].SetActive(true);
            }

            // Ruin RIGHT (7-9) 30%
            if (randomTerrain >= 7 && randomTerrain <= 9)
            {
                terrain[2].SetActive(true);
            }

            terrainDone = true;
        }
    }
    #endregion


}
