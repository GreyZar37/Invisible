using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{

    private PlatformEffector2D effector;
    public float waitTime;

    float cooldownTimer = 0.2f;


    private bool setLock;



    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();

        StartCoroutine(enumerator());
        
    }

    // Update is called once per frame
    void Update()
    {

     

        if (Input.GetKeyUp(KeyCode.S))
        {

            waitTime = 0.2f;

            setLock = true;
            cooldownTimer =  0.2f;
         
        }

        if(setLock == true)
        {
            if (effector.rotationalOffset == 180f)
            {
                print(cooldownTimer);
                if (cooldownTimer <= 0)
                {
                    effector.rotationalOffset = 0f;

                }
                cooldownTimer -= Time.deltaTime;
            }

        }



        if (Input.GetKey(KeyCode.S))
        {
            if(waitTime<= 0)
            {
                effector.rotationalOffset = 180f;

                waitTime = 0.2f;



            }
            else
            {
                waitTime -= Time.deltaTime;
            }

            setLock = false;

        }
        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0f;
           
        }
      
       

      
    }


    IEnumerator enumerator()
    {

        yield return new WaitForSeconds(0.3f);
        effector.rotationalOffset = 0f;


        yield return null;
    }


}
