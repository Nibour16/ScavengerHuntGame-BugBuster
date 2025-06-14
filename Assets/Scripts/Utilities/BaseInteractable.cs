using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    public virtual void OnInteract() 
    {
        Debug.Log("Hey, what's up?");
    }

    protected virtual void OnDestroy() 
    {
        Debug.Log("Im dead...");
    }
}
