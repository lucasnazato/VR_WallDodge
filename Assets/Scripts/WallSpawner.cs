using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject[] wallsArray;
    int index = -1;
    int randomIndex = 0;

    void Start()
    {
        Invoke("SpawnWall", 2f);
    }

    void SpawnWall()
    {
        do
        {
            randomIndex = Random.Range(0, wallsArray.Length - 1);
        } while (randomIndex == index);

        index = randomIndex;

        GameObject tempWall = Instantiate(wallsArray[index], transform.position, Quaternion.identity);
        tempWall.GetComponent<MoveWall>().speed = 5;

        Invoke("SpawnWall", 6f);
    }
}
