using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;

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

    public float preparationTime = 30f;
    public float gameTime = 60f;

    [SerializeField] private ARSpawner bugSpawner;
    [SerializeField] private ARTapToPlace arTapToPlace;
    [SerializeField] private TMP_Text timeText;

    [NonSerialized] public GameState gameState;
    [NonSerialized] public int score;
    [NonSerialized] public float buffedScoreIncrement;

    private void Start()
    {
        score = 0;
        buffedScoreIncrement = 0;
        gameState = GameState.PlaceCoil;
    }

    private void Update()
    {
        HandleGameState();
        Timer();
        SwitchState();
    }

    private void HandleGameState()
    {
        if (gameState == GameState.PlaceCoil)
        {
            arTapToPlace.enabled = true;
            bugSpawner.enabled = false;
        }
        else if (gameState == GameState.CatchBugs)
        {
            arTapToPlace.enabled = false;
            bugSpawner.enabled = true;
        }
        else
        {
            arTapToPlace.enabled = false;
            bugSpawner.enabled = false;
        }
    }

    private void Timer()
    {
        if (gameState == GameState.PlaceCoil)
        {
            preparationTime -= Time.deltaTime;
            DisplayTime(preparationTime);
        }
        else if (gameState == GameState.CatchBugs) 
        {
            gameTime -= Time.deltaTime;
            DisplayTime(gameTime);
        }
    }

    private void SwitchState()
    {
        if (gameState == GameState.PlaceCoil && preparationTime <= 0)
        {
            gameState = GameState.CatchBugs;
            preparationTime = 0;
        }    
        else if (gameState == GameState.CatchBugs && gameTime <= 0)
        {
            gameState = GameState.GameOver;
            gameTime = 0;
        } 
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay++;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddScore(float addedScore)
    {
        score += Mathf.RoundToInt(addedScore * (buffedScoreIncrement + 1.0f));
    }

}
