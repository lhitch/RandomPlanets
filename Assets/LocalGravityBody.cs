using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGravityBody : MonoBehaviour {

    public LocalGravityAttractor attractor;
    private Transform myTransform;

	// Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        attractor.Attract(myTransform);
	}
}
