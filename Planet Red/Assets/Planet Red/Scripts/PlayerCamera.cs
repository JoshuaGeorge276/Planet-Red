using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public GameObject target;
    [Range(0.0f, 1.0f)]
    public float followSmoothing = 0.3f;

    private Vector3 velocity;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.transform.position;
	}

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + offset, ref velocity, followSmoothing);
    }
}
