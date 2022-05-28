using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject[] wallsArray;
    int index = -1;
    int randomIndex = 0;

    float initialDelay = 2;
    public float timeBetweenWalls = 6;
    public float wallSpeed = 5;
    public int numberOfWalls = 10;
    int loop = 0;

    public void InvokeSpawnWall()
    {
        Invoke("SpawnWall", initialDelay);
    }

    void SpawnWall()
    {
        loop++;

        do
        {
            randomIndex = Random.Range(0, wallsArray.Length);
        } while (randomIndex == index);

        index = randomIndex;

        GameObject tempWall = Instantiate(wallsArray[index], transform.position, Quaternion.identity);
        tempWall.GetComponent<MoveWall>().speed = wallSpeed;

        if (loop < numberOfWalls)
        {

        }

        if (loop < numberOfWalls)
        {
            Invoke("SpawnWall", timeBetweenWalls);
        }
    }
}
