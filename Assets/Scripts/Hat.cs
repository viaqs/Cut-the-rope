using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public Transform hatOut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = hatOut.position;
    }
}
