using UnityEngine;

public class UnknownEvent : BaseInteractable
{
    [SerializeField] private Stat stat;
    
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
                TimerSpeedup(Random.Range(-30, -9));
                break;

            case 1:
                TimerSpeedup(Random.Range(10, 31));
                break;
            case 2:
                Debug.Log("Nothing happens");
                break;
        }

        Destroy(gameObject);
    }

    private void TimerSpeedup(float time)
    {
        if (time < 0)
            Debug.Log("Hurry up, time runs shortly!");
        else
            Debug.Log("So lucky, you get more time because the guest says he will be late");

        _gameManager.OnTimerChanged(time);
    }
}
