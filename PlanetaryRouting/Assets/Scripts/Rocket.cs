using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float stamina = 100f;
    public float staminaUsage = 100f;
    public float rotation = 20f;
    public float acceleration = 100f;

    private bool launched;
    private Rigidbody rb;

    private void Start ()
    {
        launched = false;
        rb = GetComponent<Rigidbody> ();
    }

    private void Update ()
    {
        if (!launched)
        {
            if (Input.GetKeyDown (KeyCode.Space))
                launched = true;
        }

        else if (stamina > 0f)
        {
            if (Input.GetKey (KeyCode.Space))
            {
                stamina -= staminaUsage * Time.deltaTime;
                rb.AddForce (transform.up * acceleration * Time.deltaTime, ForceMode.Acceleration);
            }

            if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))
            {
                stamina -= staminaUsage * Time.deltaTime;
                rb.AddForce (-transform.up * acceleration * Time.deltaTime, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.A))
            {
                stamina -= staminaUsage * Time.deltaTime;
                AddRotation (Quaternion.Euler (0f, 0f, rotation * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.D))
            {
                stamina -= staminaUsage * Time.deltaTime;
                AddRotation (Quaternion.Euler (0f, 0f, -rotation * Time.deltaTime));
            }
        }
    }

    public void AddRotation (Quaternion rotation)
    {
        transform.rotation *= rotation;
        rb.velocity = rotation * rb.velocity;
    }

    public void AddForce (Vector3 force)
    {
        transform.Translate (force, Space.World);
    }
}
