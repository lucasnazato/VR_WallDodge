using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    bool isLooking = false;
    float timeToButton = 0.5f;

    public GameObject imgEasy;
    public GameObject imgNormal;
    public GameObject imgHard;

    public GameObject canvasStart;
    public GameObject canvasScore;

    public WallSpawner wallSpawner;

    float timeBetweenWalls = 6;
    float wallSpeed = 5;
    int numberOfWalls = 10;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // ===== EASY MODE =====
    public void InvokeEasyMode()
    {
        Invoke("EasyMode", timeToButton);
        isLooking = true;
    }

    private void EasyMode()
    {
        if (isLooking)
        {
            timeBetweenWalls = 6;
            wallSpeed = 5;
            numberOfWalls = 10;

            imgEasy.SetActive(true);
            imgNormal.SetActive(false);
            imgHard.SetActive(false);
        }
    }


    // ===== NORMAL MODE =====
    public void InvokeNormalMode()
    {
        Invoke("NormalMode", timeToButton);
        isLooking = true;
    }

    private void NormalMode()
    {
        if (isLooking)
        {
            timeBetweenWalls = 5;
            wallSpeed = 6;
            numberOfWalls = 15;

            imgEasy.SetActive(false);
            imgNormal.SetActive(true);
            imgHard.SetActive(false);
        }
    }


    // ===== HARD MODE =====
    public void InvokeHardMode()
    {
        Invoke("HardMode", timeToButton);
        isLooking = true;
    }

    private void HardMode()
    {
        if (isLooking)
        {
            timeBetweenWalls = 3;
            wallSpeed = 7;
            numberOfWalls = 20;

            imgEasy.SetActive(false);
            imgNormal.SetActive(false);
            imgHard.SetActive(true);
        }
    }


    // ===== START LEVEL =====
    public void InvokeStartLevel()
    {
        Invoke("StartLevel", timeToButton);
        isLooking = true;
    }

    private void StartLevel()
    {
        if (isLooking)
        {
            wallSpawner.enabled = true;

            wallSpawner.timeBetweenWalls = timeBetweenWalls;
            wallSpawner.wallSpeed = wallSpeed;
            wallSpawner.numberOfWalls = numberOfWalls;

            wallSpawner.InvokeSpawnWall();

            canvasStart.SetActive(false);
            canvasScore.SetActive(true);

            gm.UpdateScore(0);
        }
    }

    // ===== RESTART LEVEL =====
    public void InvokeRestartLevel()
    {
        Invoke("RestartLevel", timeToButton);
        isLooking = true;
    }

    private void RestartLevel()
    {
        if (isLooking) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Cancel invoke of button function
    public void CancelButtonInvoke()
    {
        isLooking = false;
    }
}
