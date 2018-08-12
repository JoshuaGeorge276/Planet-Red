using System.Collections;
using System.Collections.Generic;
using PlanetRed.Core;
using UnityEngine;

public class PlayerCamera : ManagedBehaviour {

    public GameObject target;
    [Range(0.0f, 1.0f)]
    public float followSmoothing = 0.3f;

    private Vector3 velocity;
    private Vector3 offset;

	// Use this for initialization
	protected override void Start () 
	{
        base.Start();
        offset = transform.position - target.transform.position;
	}

    public override void ManagedUpdate(float a_fDeltaTime)
    {
        
    }

    public override void ManagedLateUpdate(float a_fDeltaTime)
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + offset, ref velocity, followSmoothing);
    }
}
