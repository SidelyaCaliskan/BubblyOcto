using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int playerLives = 3;
    [SerializeField] private int coins = 0;

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI coinsText;
    
    void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
        coinsText.text = coins.ToString();
    }

    public void ProcessPLayerDeath()
    {
        if (playerLives > 1)
        {
            Invoke(nameof(TakeLife), 1);
        }
        else
        {
            Invoke(nameof(ResetGameSession), 1);
        }
    }

    public void AddToCoins()
    {
        coins++;
        coinsText.text = coins.ToString();
    }

    public void ResetGameSession()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }
}
