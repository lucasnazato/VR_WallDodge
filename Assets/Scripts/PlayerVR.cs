using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVR : MonoBehaviour
{
    public Camera playerCamera;

    GameManager gameManager;

    void Start()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Look At Direction
        Vector3 lookDirection = playerCamera.transform.forward;
        Vector3 startLocation = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y - 0.5f, playerCamera.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                Destroy(other.gameObject);
                gameManager.GameOver();
                break;
            case "Score":
                gameManager.UpdateScore(1);
                break;
            default:
                break;
        }
    }
}
