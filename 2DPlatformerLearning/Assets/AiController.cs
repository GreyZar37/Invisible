using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{

    public float speed;

    public float runSpeed;

    public float distance = 2f;

    public float sightDistence = 1000;
    public float wallSpotDistence;

    private bool movingRight = true;

    public Transform groundCheck;

    public Rigidbody2D rb;

    private Transform targetPlayer;

 

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

       
        


        
        
             
        
       
        RaycastHit2D groundInfoY = Physics2D.Raycast(groundCheck.position,Vector2.down, distance);


        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, sightDistence);

        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, transform.right, wallSpotDistence);



        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                if (Vector2.Distance(transform.position, targetPlayer.position) >= 12)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, runSpeed * Time.deltaTime);
                }


            }

        }

        if (wallInfo.collider != null)
        {
            if (wallInfo.collider.CompareTag("Wall"))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }


           
        

      
            if (groundInfoY.collider == false)
        {
           if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
      
    }
}
