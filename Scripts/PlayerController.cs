using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  //This also works with joystick, PS this is topdown movement

    private Rigidbody2D rb;
    public float MoveSpeed = 5f;

    Vector2 movement;

    public Animator animator;
    public float minX = -9.0f;
    public float maxX = 9.0f;
    public float minY = -4f;
    public float maxY = 4f;

    public GameObject gameController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        
    }

     private void FixedUpdate()
     {
        //rb.velocity = new Vector2(horizontal * MoveSpeed, vertical * MoveSpeed);
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        gameController.GetComponent<GameController>().EndGame();
    }
}