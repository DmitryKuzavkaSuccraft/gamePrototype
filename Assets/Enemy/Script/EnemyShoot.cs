using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {

        if ( Time.time >= timeToFire && GameObject.Find("Character") != null)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            ProjectileMove vfxMoveController = vfx.GetComponent<ProjectileMove>();
            vfxMoveController.whoShooting = gameObject;
            
            vfx.transform.localRotation = gameObject.transform.rotation;
        }
        else
        {
            Debug.Log("no fire point");
        }
    }
}
