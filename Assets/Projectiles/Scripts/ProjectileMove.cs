using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public float destroyDelay = 2;

    public GameObject whoShooting;

    private void Start()
    {
        Destroy(gameObject, destroyDelay);
    }


    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No speed");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        Destroy(gameObject);
    }
}
