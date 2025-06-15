using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    public virtual void OnInteract(Vector3 interactPosition) 
    {
        Debug.Log("Hey, what's up?");
    }

    protected virtual void OnDestroy() 
    {
        Debug.Log(gameObject + " says: Im dead...");
    }
}
