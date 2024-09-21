using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float climbRate;
    public float diveRate;

    private float pitch;
    private float roll;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        float verticalInput = Input.GetAxis("Vertical");

        // get the user's horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // calculate pitch and roll
        pitch = verticalInput * rotationSpeed * Time.deltaTime;
        roll = horizontalInput * rotationSpeed * Time.deltaTime;

        // apply pitch and roll to the plane
        transform.Rotate(Vector3.right * pitch);
        transform.Rotate(Vector3.forward * roll);

        // move the plane forward
        transform.Translate(Vector3.forward * speed * 0.5f);

        // climb or dive based on vertical input
        if (verticalInput > 0)
        {
            transform.Translate(Vector3.up * climbRate * 0.5f);
        }
        else if (verticalInput < 0)
        {
            transform.Translate(Vector3.down * diveRate * 0.5f);
        }

        // limit the plane's pitch and roll
        pitch = Mathf.Clamp(pitch, -30f, 30f);
        roll = Mathf.Clamp(roll, -30f, 30f);
    }
}