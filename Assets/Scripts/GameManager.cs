using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject wallSpawner;

    public TMP_Text txtScore;
    public GameObject pnGameOver;

    int score = 0;

    private void Start()
    {
        
    }

    public void GameOver()
    {
        Destroy(wallSpawner);

        MoveWall[] wallsArray = GameObject.FindObjectsOfType<MoveWall>();

        foreach(MoveWall wall in wallsArray)
        {
            wall.enabled = false;
        }
        pnGameOver.SetActive(true);
    }

    public void UpdateScore(int value)
    {
        score += value;
        txtScore.text = "Score: " + score.ToString();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
