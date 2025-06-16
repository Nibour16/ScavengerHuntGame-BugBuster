using UnityEngine;

public class UnknownEvent : BaseInteractable
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (Camera.main != null)
            transform.LookAt(Camera.main.transform);
    }

    public override void OnInteract(Vector3 interactPosition)
    {
        var randomIndex = Random.Range(0, 3);

        switch (randomIndex)
        {
            case 0:
                TimerSpeedup(0.5f);
                break;

            case 1:
                TimerSpeedup(1.5f);
                break;
            case 2:
                Debug.Log("Nothing happens");
                break;
        }

        Destroy(gameObject);
    }

    private void TimerSpeedup(float time)
    {
        if (time < 1)
        {
            Debug.Log("timer is slowed down");
        }
        else
        {
            Debug.Log("timer is sped up");
        }
    }
}
