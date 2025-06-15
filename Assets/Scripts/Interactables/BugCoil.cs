using UnityEngine;

public class BugCoil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the bug component
        if (other.TryGetComponent<Bug>(out var component))
            Destroy(component.gameObject);
    }
}
