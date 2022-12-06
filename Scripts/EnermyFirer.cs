using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyFirer : MonoBehaviour
{
    [SerializeField] GameObject firer;
    [SerializeField] float minTimeFire = 2f , maxTimeFire = 4f ;
    private float fireTime = 0f, lastFire = 0f;

    private GameObject player;

    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        UpdateFireTime();
        player = GameObject.FindGameObjectWithTag("Player");

        gameController = GameObject.FindGameObjectWithTag("GameController");

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastFire + fireTime)
        {
            Fire();
        }
    }

    void UpdateFireTime()
    {
        lastFire = Time.time;
        fireTime = Random.Range(minTimeFire, maxTimeFire + 1);

    }
    void Fire()
    {
        GameObject fire = Instantiate(firer,transform.position, Quaternion.identity) as GameObject;
        fire.GetComponent<BulletController>().target = player.transform.position;
        UpdateFireTime();

        gameController.GetComponent<GameController>().GetPoint();

    }
}
