using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

    private Steering[] steerings;

    public float maxSpeed = 10;

    public float maxForce = 100;

    protected float sqrtMaxSpeed;

    public float mass = 1;

    public Vector3 velocity;

    public float damping = 0.9f;

    public float computeInterval = 0.2f;

    public bool isPlanar = true;

    private Vector3 steeringForcee;

    protected Vector3 acceleration;

    public float timer;



	// Use this for initialization
	void Start () {
        steeringForcee = new Vector3(0, 0, 0);
        sqrtMaxSpeed = maxSpeed * maxSpeed;
        timer = 0;

        steerings = GetComponent<Steering>();
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        steeringForcee = new Vector3(0, 0, 0);
        
        if(timer > computeInterval)
        {
            foreach(Steering s in steerings)
            {
                if (s.enabled)
                    steeringForcee += s.Force() * s.weight;
            }

            steeringForcee = Vector3.ClampMagnitude(steeringForcee, maxForce);

            acceleration = steeringForcee / mass;

            timer = 0;
        }
	}
}
