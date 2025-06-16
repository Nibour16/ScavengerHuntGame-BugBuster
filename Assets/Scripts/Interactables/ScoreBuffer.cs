using UnityEngine;

public class ScoreBuffer : BaseInteractable
{    
    private void Update()
    {
        if (Camera.main != null)
            transform.LookAt(Camera.main.transform);
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

        gameManager.buffedScoreIncrement += stat.value;
        Debug.Log("You are buffed, you can get more score from the bugs");
    }
}
