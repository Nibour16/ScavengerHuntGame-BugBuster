using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    public Stat stat;

    protected bool isQuit = false;
    
    public virtual void OnInteract(Vector3 interactPosition) 
    {
        Debug.Log("Hey, what's up?");
    }

    protected virtual void OnDestroy() 
    {
        if (isQuit) return;
        
        Debug.Log(gameObject + " says: Im dead...");
    }

    protected virtual void OnApplicationQuit()
    {
        isQuit = true;
    }
}
