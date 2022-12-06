using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 target;
    
    public float moveSpeed = 1f;

    public float destroyTime = 1.5f;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    void Update()
    {
        transform.Translate((transform.position -target) * moveSpeed * Time.deltaTime * -1);
        //transform.position = Vector3.MoveTowards(transform.position, 2*target, moveSpeed * Time.deltaTime);
    }

    
}
