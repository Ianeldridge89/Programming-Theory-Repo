using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainManager : MonoBehaviour
{
    // ENCAPSULATION
    public static MainManager Instance { get; set; }

    public static bool gameOver = false;
    public GameObject GameOverText;
    public GameObject StartGameText;
    public GameObject ExitGameText;
    public GameObject Title;
    public GameObject RestartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveNumberText;
    public static int playerScore = 0;
    public static bool isGameActive;
    // Start is called before the first frame update

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        isGameActive = false;
        gameOver = false;
        playerScore = 0;
        GameOverText.gameObject.SetActive(false);
        StartGameText.gameObject.SetActive(true);
        ExitGameText.gameObject.SetActive(true);
        Title.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);
        scoreText.text = "SCORE: " + playerScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            TextForGameOver();
        }
        scoreText.text = "SCORE: " + playerScore;
        waveNumberText.text = "WAVE NUMBER: " + SpawnManager.waveNumber;
    }

    public static void UpdateScore(int enemyValue)
    {
        playerScore = playerScore + enemyValue;
        Debug.Log(playerScore);

    }

    public static void GameOver()
    {
        gameOver = true;
        isGameActive = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }

    }

    public void TextForGameOver()
    {
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        ExitGameText.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        isGameActive = true;
        playerScore = 0;
        SpawnManager.waveNumber = 0;
        GameOverText.gameObject.SetActive(false);
        StartGameText.gameObject.SetActive(false);
        ExitGameText.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        gameOver = false;
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
