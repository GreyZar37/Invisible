using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShooting : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
