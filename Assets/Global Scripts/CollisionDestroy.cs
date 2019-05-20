using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    public bool isEnemy = false;
    public bool isProjectile = false;
    public bool isBuilding = false;
    public bool isCharacter = false;
    public GameObject dieEffect;

    private ProjectileMove projectileController;

    private void OnCollisionEnter(Collision collision)
    {
        CollisionDestroy targetLifeCycle = collision.gameObject.GetComponent<CollisionDestroy>();
        
        if (targetLifeCycle != null)
        {
            if (this.isCharacter && targetLifeCycle.isEnemy)
            {
                Destroy(gameObject);
            }
            if (targetLifeCycle.isProjectile)
            {
                projectileController = collision.gameObject.GetComponent<ProjectileMove>();
                bool isFirendlyFire = projectileController != null && projectileController.whoShooting.name == gameObject.name;
                if (!isFirendlyFire)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnDestroy()
    {
        Vector3 diePosition = gameObject.transform.position;
        if (dieEffect != null)
        {
            GameObject dieVFX = Instantiate(dieEffect, gameObject.transform.position, Quaternion.identity);
        }
        
    }
}
