using System.Collections;
using System.Collections.Generic;
using PlanetRed.Core;
using UnityEngine;

public class SimpleMovement : ManagedBehaviour 
{

    public float speed = 5.0f; 

	// Use this for initialization
	protected override void Start () 
    {
		base.Start();
	}

    public override void ManagedUpdate(float a_fDeltaTime)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);

        transform.position += (direction.normalized * speed * a_fDeltaTime);
    }
}
