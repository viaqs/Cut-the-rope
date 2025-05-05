using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Rigidbody2D candy;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            transform.position = other.transform.position;
            transform.parent = other.transform;

            candy = other.GetComponent<Rigidbody2D>();
            candy.gravityScale = -1;
        }
        else if (other.CompareTag("Cursor") && candy != null)
        {
            candy.gravityScale = 1;
            Destroy(gameObject);
            //TODO: sound & vfx
        }
    }
}
