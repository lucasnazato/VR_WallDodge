using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVR : MonoBehaviour
{
    public Camera playerCamera;

    GameManager gameManager;

    float cameraAngle;

    void Start()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        cameraAngle = playerCamera.transform.localEulerAngles.z;

        if (Mathf.Abs(cameraAngle) > 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -cameraAngle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
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
                Destroy(other.gameObject);
                break;
            default:
                break;
        }

        Invoke("ResetHeight", 0.2f);
    }

    private void ResetHeight()
    {
        gameObject.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.95f, 0);
        gameObject.GetComponent<CapsuleCollider>().height = 1.9f;
        gameObject.transform.GetChild(0).transform.localPosition = new Vector3(0, 1.7f, 0);
    }
}
