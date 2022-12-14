using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;

   

    //public float moving = 1f;
    //private Rigidbody2D rb;
    //Vector2 movement;

    public Animator animator;
    public bool startAni = true;
    private void Start()
    {
       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            
        }
        if (Input.GetMouseButton(0))
        {
            
            touchStart = true;
            startAni = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
           
            touchStart = false;
            startAni = false;
        }
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            animator.SetFloat("Horizontal", direction.x * -1);
            animator.SetFloat("Vertical", direction.y * -1);
            if(startAni)    animator.SetFloat("Speed", 1);   
            else animator.SetFloat("Speed", 0);
            moveCharacter(direction * -1);
            startAni = false;
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        }
        else
        {
            
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            startAni = false;
           
        }
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
        
    }
}