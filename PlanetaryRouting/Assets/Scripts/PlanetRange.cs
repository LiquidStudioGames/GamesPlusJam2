using UnityEngine;

public class PlanetRange : MonoBehaviour
{
    private Planet planet;

    private void Start()
    {
        planet = GetComponentInParent<Planet>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rocket rocket;

        if ((rocket = other.GetComponent<Rocket>()) != null)
        {
            planet.OnRocketEnter(rocket);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rocket rocket;

        if ((rocket = other.GetComponent<Rocket>()) != null)
        {
            planet.OnRocketExit(rocket);
        }
    }
}
