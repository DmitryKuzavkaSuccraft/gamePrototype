using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    public float speed;
    public float gravity;

    private GameObject player;               // Reference to the player's position.
    private CharacterController controller;
    private Vector3 offset = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameObject.Find("Character");
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}

