using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This script will manage the state of the game

    public static GameManager instance = null;
    public int level;
    public int redTeamScore;
    public int blueTeamScore;
    public int inning;
    public int timerValueInSeconds = 0;
    public Vector3 playerOrigin;

    private QuestionManager qm;
    private Question q;
    private bool newQuestion;
    private bool gameOver;
    private bool menuOn;
    private bool winCondition;
    private bool stopTimer;
    // A boolean value set when the player is using the menu
    private bool playingGame;
    // A boolean value set when the player respawns
    private bool playerRespawning;

    private float currentDeltaTime;

    // Awake is always called before any Start functions
    private void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set instance to this
            instance = this;
        }
        else if (instance != this)
        {
            // If instance already exists and it's not this
            // Then destroy this. This enforces the singleton pattern,
            // meaning there can only be one instance of a GameManager.
            Destroy(gameObject);
        }

        // Sets this to not be destroyed when reloading scene
        // Edit: Thought I needed it but decided not to use it
        // because it messed with saving the level data from
        // the GameManager since it did not refresh itself upon
        // loading a new scene.
        // DontDestroyOnLoad(gameObject);

        instance.gameOver = false;
        instance.menuOn = false;
        instance.stopTimer = false;
        instance.winCondition = false;
        instance.playingGame = false;
        instance.playerRespawning = false;
        instance.newQuestion = false;
        instance.timerValueInSeconds = timerValueInSeconds;
        instance.currentDeltaTime = 0f;
        instance.inning = 1;
        instance.redTeamScore = 0;
        instance.blueTeamScore = 0;

        instance.qm = new QuestionManager();
        instance.q = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (!stopTimer)
        {
            if (currentDeltaTime >= 1.0f)
            {
                timerValueInSeconds += 1;
                currentDeltaTime = 0f;
            }
            else
            {
                currentDeltaTime += Time.deltaTime;
            }
        }
    }

    public void GameOver(bool playerResult)
    {
        gameOver = true;
        stopTimer = true;

        if (inning > 3)
        {
            winCondition = true;
        }
        else
        {
            winCondition = false;
        }
    }

    public void SetGameMenu(bool value)
    {
        menuOn = value;
    }

    public void SetStopTimer(bool value)
    {
        stopTimer = value;
    }

    public void SetPlayingGame(bool value)
    {
        playingGame = value;
    }

    public void SetPlayerRespawning(bool value)
    {
        playerRespawning = value;
    }

    public void IncreaseRedTeamScore()
    {
        redTeamScore += 1;
    }

    public void IncreaseBlueTeamScore()
    {
        blueTeamScore += 1;
    }

    public void IncreaseInning()
    {
        inning += 1;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public bool IsMenuOn()
    {
        return menuOn;
    }

    public bool getWinCondition()
    {
        return winCondition;
    }

    public bool GetStopTimer()
    {
        return stopTimer;
    }

    public bool GetPlayingGame()
    {
        return playingGame;
    }

    public bool GetPlayerRespawning()
    {
        return playerRespawning;
    }

    public Vector3 GetPlayerOrigin()
    {
        return playerOrigin;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetInning()
    {
        return inning;
    }

    public int GetRedTeamScore()
    {
        return redTeamScore;
    }

    public int GetBlueTeamScore()
    {
        return blueTeamScore;
    }

    public Question GetCurrentQuestion()
    {
        newQuestion = false;
        return q;
    }

    public void SelectQuestion(int baseNumber)
    {
        // This method will set the new current question
        // in the GameManager
        q = qm.Get(baseNumber);
        newQuestion = true;
    }

    public void SetReplayCondition()
    {
        timerValueInSeconds = 0;
        SetStopTimer(false);
        SetGameMenu(false);
    }

    public void SetPlayerOrigin(Vector3 newOrigin)
    {
        playerOrigin = newOrigin;
    }

    public bool IsNewQuestion()
    {
        return newQuestion;
    }
}
