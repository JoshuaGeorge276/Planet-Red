using System.Collections;
using System.Collections.Generic;
using PlanetRed.Core;
using UnityEngine;

public class SimpleMovement : ManagedBehaviour 
{

    private int ANIM_RUNNING = Animator.StringToHash("Running");

    public float speed = 5.0f;
    public float rotationSmoothing = 0.3f;

    private CharacterController character;
    private Animator anim;

    private Vector3 movementDirection;
    private Vector3 zeroVector;

	// Use this for initialization
	void Start () {
        character = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();	
	}

    public override void ManagedUpdate(float a_fDeltaTime)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);

        movementDirection = direction * speed * Time.deltaTime;

        Move();
        Rotate();

        anim.SetFloat(ANIM_RUNNING, direction.normalized.sqrMagnitude);

	}

    private void Move()
    {
        character.Move(movementDirection);
    }

    private void Rotate()
    {
        Quaternion lookRotation = Quaternion.LookRotation(movementDirection);


        if (transform.rotation != lookRotation && movementDirection != zeroVector)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSmoothing);
        }
       
    }
}
