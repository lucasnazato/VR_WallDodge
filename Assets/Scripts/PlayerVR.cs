using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVR : MonoBehaviour
{
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;

    float maxDistance = 1000;
    public LayerMask pointMask;

    float lookAtPoint = 0;
    float timeToMove = 0.5f;

    public PlayerBase currentPoint;

    public LayerMask buttonMask;
    float lookAtButton = 0;
    float timeToRestart = 0.75f;

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
        Debug.DrawRay(startLocation, lookDirection * maxDistance, Color.red);

        // Check for collisions with MovePoint
        RaycastHit hitPoint;
        if (Physics.Raycast(playerCamera.transform.position, lookDirection, out hitPoint, maxDistance, pointMask))
        {
            lookAtPoint += Time.deltaTime;
            if (lookAtPoint >= timeToMove)
            {
                transform.position = new Vector3(hitPoint.transform.position.x, 0, hitPoint.transform.position.z);

                currentPoint.isActive = false;

                currentPoint = hitPoint.transform.gameObject.GetComponent<PlayerBase>();
                currentPoint.isActive = true;

                lookAtPoint = 0;
            }
        }
        else
        {
            lookAtPoint = 0;
        }

        
        // Check for collisions with Restart Button
        RaycastHit hitButton;
        if (Physics.Raycast(playerCamera.transform.position, lookDirection, out hitButton, maxDistance, buttonMask))
        {
            lookAtButton += Time.deltaTime;
            if (lookAtButton >= timeToRestart)
            {
                gameManager.RestartLevel();
                lookAtButton = 0;
            }
        }
        else
        {
            lookAtButton = 0;
        }
        

        //Camera Movement
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                gameManager.GameOver();
                Destroy(other.gameObject);
                break;
            case "Score":
                gameManager.UpdateScore(1);
                break;
            default:
                break;
        }
    }
}
