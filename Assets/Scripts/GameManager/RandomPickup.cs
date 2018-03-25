using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickup : MonoBehaviour
{
    [Header("Randomise Pickup")]
    public GameObject[] pickups;
    private int randomPickup;
    private int currentPickup;
    private bool pickupDone;

    void Start()
    {
        pickupDone = false;
        RandomisePickup();
    }

    
    void Update()
    {
        RandomNewPickup();
    }

    #region
    void RandomisePickup()
    {
        if (pickupDone == false)
        {
            randomPickup = Random.Range(0,6);

            if (randomPickup != currentPickup)
            {
                pickups[randomPickup].SetActive(true);

                pickupDone = true;
            }
        }

    }

    void RandomNewPickup()
    {
        if (pickups[randomPickup].activeSelf == false)
        {
            currentPickup = randomPickup;

            pickupDone = false;

            RandomisePickup();
        }
    }
    #endregion
}
