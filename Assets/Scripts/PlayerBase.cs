using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public Vector3 movePos;

    GameObject player;
    bool canMove = false;

    float timeToMove = 0.45f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    public void InvokeChangePosition()
    {
        Invoke("ChangePosition", timeToMove);
        canMove = true;
    }

    public void CancelChangePosition()
    {
        canMove = false;
    }

    private void ChangePosition()
    {
        if (canMove) player.transform.position = movePos;
    }
}
