﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
