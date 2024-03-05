using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public Rigidbody rb;
    public float enginePowerThrust, liftBooster, drag, angularDrag;
    
    void FixedUpdate()
    {
        //1.Add Thrust
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePowerThrust);
        }
        
        //2.Lift
        Vector3 lift = Vector3.Project(rb.velocity , transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);
        
        //3.drag
        rb.drag = rb.velocity.magnitude * drag;
        rb.angularDrag = rb.velocity.magnitude * angularDrag;

        //4.control
        //4.1 left - right
        rb.AddTorque(Input.GetAxis("Horizontal")* transform.forward * -1);
        //4.2 up - down
        rb.AddTorque(Input.GetAxis("Vertical")* transform.right);
        
    }
    
}
