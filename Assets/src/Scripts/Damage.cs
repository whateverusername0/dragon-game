using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject DamageObjectPrefab;
    public float DamagePower;
    public float healthPoints;

    public void Start()
    {
        DamagePower = -10f;
        healthPoints = 100f;
    }

    public void Clicked()
    {
        if (healthPoints + DamagePower > 0)
        {
            if (DamagePower > 0)
            {
                healthPoints = healthPoints + DamagePower;
                Debug.Log("Damage: +" + DamagePower + "\nHP: " + healthPoints);
            }
            else
            {
                healthPoints = healthPoints + DamagePower;
                Debug.Log("Damage: " + DamagePower + "\nHP: " + healthPoints);
            }
        } else
        {
            Debug.Log("Oh no, they killed Rayan Gosling!");
            Destroy(gameObject);
        }
    }
}
