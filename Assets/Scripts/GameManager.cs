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
    public GameObject pnWin;

    int score = 0;

    public void GameOver()
    {
        Destroy(wallSpawner);

        MoveWall[] wallsArray = GameObject.FindObjectsOfType<MoveWall>();

        foreach(MoveWall wall in wallsArray)
        {
            Destroy(wall.gameObject);
        }
        pnGameOver.SetActive(true);
    }

    public void UpdateScore(int value)
    {
        score += value;
        txtScore.text = "Walls: " + score.ToString() + " / " + wallSpawner.GetComponent<WallSpawner>().numberOfWalls;

        // Win Condition
        if (score >= wallSpawner.GetComponent<WallSpawner>().numberOfWalls)
        {
            Destroy(wallSpawner);

            MoveWall[] wallsArray = GameObject.FindObjectsOfType<MoveWall>();

            foreach (MoveWall wall in wallsArray)
            {
                Destroy(wall.gameObject);
            }

            pnWin.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
