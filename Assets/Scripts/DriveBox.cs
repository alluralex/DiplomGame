using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DriveBox : MonoBehaviour
{
    [SerializeField] Hero driver;

    [SerializeField] List<Hero> passengers;
    public void GoToCarMorty(Hero player)
    {
        if (driver == null)
        {
            driver = player;
        }
        else if (driver != null && passengers.Count <= 3)
        {
            passengers.Add(player);
        }
        else 
        { 
            Debug.Log("Тачка забита до отказа...");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
