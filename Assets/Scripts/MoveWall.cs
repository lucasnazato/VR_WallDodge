using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed = 1;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }
}
