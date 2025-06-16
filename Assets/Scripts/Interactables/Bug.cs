using UnityEngine;

public class Bug : BaseInteractable
{
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
