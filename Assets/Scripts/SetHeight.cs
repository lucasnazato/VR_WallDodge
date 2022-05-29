using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeight : MonoBehaviour
{
    GameObject player;
    bool canMove = false;

    float timeToMove = 0.45f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // === CROUCH ===
    public void InvokeCrouch()
    {
        Invoke("Crouch", timeToMove);
        canMove = true;
    }

    private void Crouch()
    {
        if (canMove)
        {
            player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.5f, 0);
            player.GetComponent<CapsuleCollider>().height = 1;
            player.transform.GetChild(0).transform.localPosition = new Vector3(0, 1, 0);
        }
    }

    // === GET UP ===
    public void InvokeStand()
    {
        Invoke("Stand", timeToMove);
        canMove = true;
    }

    private void Stand()
    {
        if (canMove)
        {
            player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.95f, 0);
            player.GetComponent<CapsuleCollider>().height = 1.9f;
            player.transform.GetChild(0).transform.localPosition = new Vector3(0, 1.7f, 0);
        }
    }

    // ===
    public void CancelBaseInvoke()
    {
        canMove = false;
    }
}
