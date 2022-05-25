using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall") && isActive)
        {
            print("GameOver");
        }
    }
}
