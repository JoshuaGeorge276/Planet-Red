using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {
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
