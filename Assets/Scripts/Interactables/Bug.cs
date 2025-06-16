using UnityEngine;

public class Bug : BaseInteractable
{
    [SerializeField] protected Stat stat;

    protected GameManager gameManager;
    
    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
    }

    public override void OnInteract(Vector3 interactPosition)
    {
        if (gameManager == null)
        {
            Debug.Log("gameManager is null");
            return;
        }
        Destroy(gameObject);
    }

    protected override void OnDestroy()
    {
        if (isQuit) return;

        if (gameManager == null)
        {
            Debug.Log("gameManager is null");
            return;
        }

        gameManager.AddScore(stat.value);
        Debug.Log(gameManager.score);
        base.OnDestroy();
    }
}
