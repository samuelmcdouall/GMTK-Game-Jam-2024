using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GJ24PlaneHazard : GJ24SizeableObject
{
    //public override void Start()
    //{
    //    base.Start();
    //}

    // Update is called once per frame
    public override void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        if (transform.position.x < EdgeOfViewableScreen)
        {
            Destroy(gameObject);
        }
    }
}
