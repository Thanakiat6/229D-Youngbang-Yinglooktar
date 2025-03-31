using UnityEngine;

public class MyAirForce : MonoBehaviour
{

    private Rigidbody rb;
    public float enginePowwer = 25;
    public float liftBooster = 0.5f;
    public float dragDamp = 0.03f;
    public float angularDragdamp = 0.03f;

    public float yawPower = 25;
    public float pitchPower = 25;
    public float rollPower = 15;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePowwer);
        }

        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        rb.linearVelocity -= rb.linearVelocity * dragDamp;
        rb.angularVelocity -= rb.angularVelocity * angularDragdamp;

        float yaw = Input.GetAxis("Horizontal") * yawPower;
        rb.AddTorque(transform.up * yaw);

        float pitch = Input.GetAxis("Vertical") * pitchPower;
        rb.AddTorque(-transform.right * pitch);

        float roll = Input.GetAxis("Roll") * pitchPower;
        rb.AddTorque(-transform.forward * roll);
    }

}

