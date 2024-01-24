using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float traction;
    public float acceleration;
    public float handling;
    public float launchForce;
    public int carryingCapacity;
    public int currentPassengers;
    public Vector3 launchTrajectory;

    Rigidbody r;
    float curSpeed;
    public bool launch;

    public KeyCode drop;
    public string axisH;
    public string axisV;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 c = new Vector2(Input.GetAxis(axisH), Input.GetAxis(axisV));
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, new Vector3(c.x,0,c.y), handling, 0.0f);
        if(c.magnitude > 1){ c.Normalize(); }
        if (c.magnitude > 0.5) { launch = true; launchTrajectory = new Vector3(0, 4, 0) + (r.velocity * 0.5f) + transform.forward * (launchForce + r.velocity.magnitude * 0.5f); } else { launch = false; }
        if (Vector2.Angle(new Vector2(r.velocity.x, r.velocity.z), c) > 90) { c *= 0.33f; } //If the angle you're trying to move at is more than 90 degrees away from the direction you're facing, you'll slow down for a sharper turn
        curSpeed += c.magnitude * maxSpeed * (acceleration - 1) * (traction - 1);
        transform.rotation = Quaternion.LookRotation(newDirection);
        curSpeed /= acceleration;
        r.velocity += transform.forward * curSpeed;
        r.velocity = new Vector3(r.velocity.x/traction, r.velocity.y, r.velocity.z/traction);
    }

    public Vector3 PassengerPosition(int passengerNum)
    {
        return new Vector3(((passengerNum - 1) % 3 - 1) *0.5f,1,Mathf.Floor((passengerNum - 1) / 3 - 1) * 0.5f);
    }


}