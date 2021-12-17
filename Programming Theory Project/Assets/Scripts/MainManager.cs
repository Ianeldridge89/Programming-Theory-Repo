using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // ENCAPSULATION
    //public static MainManager Instance { get; set; }
    public TextMeshProUGUI gameOverText;

    public static int playerScore = 0;
    // Start is called before the first frame update

    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public static void UpdateScore(int enemyValue)
    {
        playerScore = playerScore + enemyValue;
        Debug.Log(playerScore);
    }
}
