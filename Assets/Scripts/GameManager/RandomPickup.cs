using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickup : MonoBehaviour
{
    [Header("Randomise Pickup")]
    public GameObject[] pickups;
    private List<GameObject> prevPickups = new List<GameObject>();
    private int randomPickup;
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

    #region Randomise Pickups
    void RandomisePickup()
    {
        if (pickupDone == false)
        {
            randomPickup = Random.Range(0,6);

            // IF prevPickups List DOES NOT Contain randomPickup from pickups Array THEN
            if (!prevPickups.Contains(pickups[randomPickup]))
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
            prevPickups.Add(pickups[randomPickup]);

            pickupDone = false;

            RandomisePickup();
        }
    }
    #endregion
}
