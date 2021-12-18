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
    public static int playerScore = 0;
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
        playerScore = 0;
        GameOverText.gameObject.SetActive(false);
        StartGameText.gameObject.SetActive(true);
        ExitGameText.gameObject.SetActive(true);
        Title.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameOverText.gameObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);
        }
        
    }

    public static void UpdateScore(int enemyValue)
    {
        playerScore = playerScore + enemyValue;
        Debug.Log(playerScore);
    }

    public static void GameOver()
    {
        gameOver = true;
    }

    public void StartGame()
    {
        playerScore = 0;
        GameOverText.gameObject.SetActive(false);
        StartGameText.gameObject.SetActive(false);
        ExitGameText.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        gameOver = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
