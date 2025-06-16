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
    [SerializeField] private UserInteraction arInteractor;

    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverText;

    [NonSerialized] public GameState gameState;
    [NonSerialized] public int score;
    [NonSerialized] public float buffedScoreIncrement;

    private void Start()
    {
        score = 0;
        buffedScoreIncrement = 0;
        gameState = GameState.PlaceCoil;
        gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        HandleGameState();
        Timer();
        DisplayScore();
        SwitchState();
    }

    private void HandleGameState()
    {
        if (gameState == GameState.PlaceCoil)
        {
            arTapToPlace.enabled = true;
            arInteractor.enabled = true;
            bugSpawner.enabled = false;
        }
        else if (gameState == GameState.CatchBugs)
        {
            arTapToPlace.enabled = false;
            arInteractor.enabled = true;
            bugSpawner.enabled = true;
        }
        else
        {
            arInteractor.enabled = false;
            arTapToPlace.enabled = false;
            bugSpawner.enabled = false;

            gameOverText.gameObject.SetActive(true);
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

    public void AddScore(float addedScore)
    {
        score += Mathf.RoundToInt(addedScore * Mathf.Max((buffedScoreIncrement + 100f)/100f, 0));
    }

    public void OnTimerChanged(float changeAmount)
    {
        gameTime += changeAmount;
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay++;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

}
