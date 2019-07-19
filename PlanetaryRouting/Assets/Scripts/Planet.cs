using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rot = 100f;
    public float radius = 2f;
    public float gravity = 1f;

    private Rocket rocket;

    protected virtual void Update()
    {
        if (rocket != null)
        {
            Vector3 dir = transform.InverseTransformDirection(transform.position - rocket.transform.position);
            dir *= radius + 0.5f - dir.magnitude;
            rocket.AddForce(dir * gravity * Time.deltaTime);
            rocket.AddRotation(Quaternion.Euler(0f , 0f, Vector3.Dot(dir, transform.up) * rot * gravity * Time.deltaTime));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rocket rocket;

        if ((rocket = collision.gameObject.GetComponent<Rocket>()) != null)
        {
            OnPlanetHit(rocket);
        }
    }

    public virtual void OnPlanetHit(Rocket rocket)
    {
        Debug.Log("Planet hit.");
        Destroy(rocket.gameObject);
    }

    public virtual void OnRocketEnter(Rocket rocket)
    {
        Debug.Log("Rocket entered");
        this.rocket = rocket;
    }

    public virtual void OnRocketExit(Rocket rocket)
    {
        Debug.Log("Rocket exited");
        this.rocket = null;
    }
}
