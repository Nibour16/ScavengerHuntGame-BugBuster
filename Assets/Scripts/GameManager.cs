using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    #region Instance Setup
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    [NonSerialized] public int score;
    [NonSerialized] public float buffedScoreIncrement;

    private void Start()
    {
        score = 0;
        buffedScoreIncrement = 0;
    }

    public void AddScore(float addedScore)
    {
        score += Mathf.RoundToInt(addedScore * (buffedScoreIncrement + 1.0f));
    }
}
