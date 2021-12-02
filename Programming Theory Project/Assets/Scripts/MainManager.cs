using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static int playerScore = 0;
    // Start is called before the first frame update

    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerScore);
    }

    public static void UpdateScore(int enemyValue)
    {
        playerScore = playerScore + enemyValue;
    }
}
