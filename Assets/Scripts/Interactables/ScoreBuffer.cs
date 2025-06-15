using UnityEngine;

public class ScoreBuffer : BaseInteractable
{
    [SerializeField] private Stat scoreBufferStat;
    
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
        if (_gameManager == null)
        {
            Debug.Log("gameManager is null");
            return;
        }
        
        Destroy(gameObject);
    }

    protected override void OnDestroy()
    {
        _gameManager.buffedScoreIncrement += scoreBufferStat.value;
        Debug.Log("You are buffed, you can get more score from the bugs");
    }
}
