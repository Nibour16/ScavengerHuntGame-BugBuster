using UnityEngine;

public class Bug : BaseInteractable
{
    [SerializeField] protected BugStat bugStat;

    protected GameManager gameManager;
    
    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
    }

    public override void OnInteract()
    {
        if (gameManager == null)
        {
            Debug.Log("gameManager is null");
            return;
        }
        gameManager.AddScore(bugStat.score);
        Debug.Log(gameManager.score);
        Destroy(gameObject);
    }
}
