using UnityEngine;

public class BugCoil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the bug component
        if (other.GetComponent<Bug>() != null)
            Destroy(other.gameObject);
    }
}
