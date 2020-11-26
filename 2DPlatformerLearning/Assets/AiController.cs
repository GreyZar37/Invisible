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

    private bool flip = false;

    public Transform groundCheck;

    public Rigidbody2D rb;

    public Transform targetPlayer;


    private float CurrentTime;
    private float CooldownTime = 1.5f  ;



    private float CurrentTimeShoot;
    private float CooldownTimeShoot = 1;

    private float CurrentTimeFlip;
    private float CooldownTimeFlip = 0.1f;


    public GameObject bulletPrefab;
    public Transform firepoint;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {



        CurrentTimeShoot -= Time.deltaTime;

        if (CurrentTimeShoot <= 0)
        {
            CurrentTimeShoot = 0;
        }


        if (CurrentTime <= 0)
        {
            CurrentTime = 0;
        }


        if (CurrentTimeFlip <= 0)
        {
            CurrentTimeFlip = 0;
        }



        RaycastHit2D groundInfoY = Physics2D.Raycast(groundCheck.position,Vector2.down, distance);


        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, sightDistence);

        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, transform.right, wallSpotDistence);



        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {

                CurrentTime = CooldownTime;

                if (Vector2.Distance(transform.position, targetPlayer.position) >= 10)
                {

                    transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, runSpeed * Time.deltaTime);

                    CurrentTimeFlip -= Time.deltaTime;

                }
                else if (Vector2.Distance(transform.position, targetPlayer.position) <= 10 )
                {

                    CurrentTimeFlip -= Time.deltaTime;
                    if (CurrentTimeShoot == 0)
                    {
                        Shoot();
                        CurrentTimeShoot = CooldownTimeShoot;
                        
                    }
                    
                }
               

            }

        }

       if (wallInfo.collider != null)
        {

            CurrentTime -= Time.deltaTime;


            if (wallInfo.collider.CompareTag("Wall") && CurrentTime <= 0)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);

            }
        }

       if(CurrentTime <= 0 && CurrentTimeFlip <= 0)
        {
            flip = true;
            CurrentTimeFlip = CooldownTimeFlip;
        }



       if(flip == true)
        {
            transform.Rotate(0f, 180f, 0);
            flip = false;
        }


        print(CurrentTimeFlip);

        if (groundInfoY.collider == false)
        {
           if(movingRight == true)
            {
                transform.Rotate(0f, 180f, 0);
                movingRight = false;
            }
            else
            {
                transform.Rotate(0f, 180f, 0);
                movingRight = true;
            }
        }
      
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);


    }

}
