using UnityEngine;

public class BugNest : BaseInteractable
{
    protected override void Start()
    {
        base.Start();
        Debug.Log("Bug nest is spawned, you get less score from bugs");
        gameManager.buffedScoreIncrement -= stat.value;
        Debug.Log(gameManager.buffedScoreIncrement);
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
        if (gameManager == null)
        {
            Debug.Log("gameManager is null");
            return;
        }

        Debug.Log("Bug nest is destroyed, it never reduces your score from bugs");
        gameManager.buffedScoreIncrement += stat.value;
    }
}
