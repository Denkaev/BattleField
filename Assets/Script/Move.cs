﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float speed = 0.4f;
    Vector3 dest = Vector3.zero;
    void Start()
    {
        dest = transform.position;
    }
    
    private void FixedUpdate()
    {
        Vector3 p = Vector3.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody>().MovePosition(p);

        // Check for Input if not moving
        if ((Vector3)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector3.up))
                dest = (Vector3)transform.position + Vector3.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector3.right))
                dest = (Vector3)transform.position + Vector3.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector3.up))
                dest = (Vector3)transform.position - Vector3.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector3.right))
                dest = (Vector3)transform.position - Vector3.right;
        }
        
        // Animation Parameters
        //Vector3 dir = dest - (Vector3)transform.position;
        //GetComponent<Animator>().SetFloat("DirX", dir.x);
        //GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector3 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector3 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
       
}
