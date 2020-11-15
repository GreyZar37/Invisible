using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{

    public float speed;
    public float distance = 2f;

    public float sightDistence;

    private bool movingRight = true;

    public Transform groundCheck;

    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * speed*Time.deltaTime);
        RaycastHit2D groundInfoY = Physics2D.Raycast(groundCheck.position,Vector2.down, distance);


        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, sightDistence);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
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
