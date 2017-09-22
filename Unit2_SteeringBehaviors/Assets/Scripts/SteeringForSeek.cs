using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringForSeek : Steering {

    public GameObject target;

    private Vector3 desireVelocity;

    private Vehicle m_vehicle;

    private float maxSpeed;

    private bool isPlanar;


	// Use this for initialization
	void Start () {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
        isPlanar = m_vehicle.isPlanar;
	}

    public override Vector3 Force()
    {
        desireVelocity = (target.transform.position - transform.position).normalized * maxSpeed;
        if (isPlanar)
            desireVelocity.y = 0;
        return (desireVelocity - m_vehicle.velocity);
    }
}
