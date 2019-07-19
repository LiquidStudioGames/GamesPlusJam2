using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rocket rocket;

        if ((rocket = other.GetComponent<Rocket>()) != null)
        {
            OnTargetReached();
        }
    }

    public virtual void OnTargetReached()
    {
        Debug.Log("Reached target.");
    }
}
