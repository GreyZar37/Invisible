using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;

    private float currentTimer;
    public float cooldownTimer;

    private Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTimer -= Time.deltaTime;
        if(currentTimer <= 0)
        {
            currentTimer = 0;
        }



        if (Input.GetButtonDown("Fire1") && currentTimer == 0 && PlayerMovement.isGrounded == true) 
        {
            Shoot();
            currentTimer = cooldownTimer;

            anim.SetBool("isShooting", true);
           
        }
        else if(currentTimer <= 0.8)
        {
            anim.SetBool("isShooting", false);
            
        }
       
        
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
       
        
    }
}
