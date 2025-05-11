using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Connect : MonoBehaviour
{
    private GameObject pin;
    public Transform candy;
    private Collider2D range;
    public SpriteRenderer rend;
    public GameObject ropeJoint;
    public float offset = 0.1f;



    private void Start()
    {
        pin = GetComponent<GameObject>();
        range = GetComponent<Collider2D>();
       
    }
    private List<Transform> joints = new();



    private void OnCollisionEnter2D(Collision2D collision)
    {
        connectRope();
        if(candy.GetComponent<Joint2D>().connectedBody == joints[joints.Count - 1].GetComponent<Rigidbody2D>())
        {
            range.enabled = false;
            rend.enabled = false;
        }
       
    }

    private void connectRope()
    {

        int jointCount = (int)(Vector3.Distance(transform.position, candy.position) / offset);

        Vector3 pos = transform.position;
        for (int i = 0; i < jointCount; i++)
        {
            GameObject joint = Instantiate(ropeJoint, pos, Quaternion.identity, transform);

            pos = Vector3.Lerp(transform.position, candy.position, (float)i / jointCount);

            //connect joint to pin 
            if (i == 0)
            {
                joint.GetComponent<Joint2D>().connectedBody = GetComponent<Rigidbody2D>();
            }
            //connect rope to previous joint
           else
           {
               joint.GetComponent<Joint2D>().connectedBody = joints[i - 1].GetComponent<Rigidbody2D>();
           }

            joints.Add(joint.transform);
        }

        //connect to candy
        candy.GetComponent<Joint2D>().connectedBody = joints[joints.Count - 1].GetComponent<Rigidbody2D>();
    }


}

