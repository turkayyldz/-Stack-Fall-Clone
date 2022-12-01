using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] obstacleModel;
    [HideInInspector]// Panelde Kaybetmek.
    public GameObject[] obstaclePrefab = new GameObject[4];
    public GameObject winPrefeb;

    private GameObject temp1Obstacle, temp2Obstacle;

    private int level = 1, addNumber = 7;

    float obstacleNumber;



    void Start()
    {
        randomObstaclegenerator();
        for (obstacleNumber = 0; obstacleNumber >-level -addNumber ; obstacleNumber -= 0.5f)
        {
            //level kontrol
            if (level<=20)
            {
                temp1Obstacle = Instantiate(obstaclePrefab[Random.Range(0, 2)]);
            }
            if (level > 20 && level<50)
            {
                temp1Obstacle = Instantiate(obstaclePrefab[Random.Range(1, 3)]);
            }
            if (level > 50 && level < 100)
            {
                temp1Obstacle = Instantiate(obstaclePrefab[Random.Range(2, 4)]);
            }
            if (level >100 )
            {
                temp1Obstacle = Instantiate(obstaclePrefab[Random.Range(3, 4)]);
            }

            temp1Obstacle.transform.position = new Vector3(0, obstacleNumber - 0.01f, 0);
            temp1Obstacle.transform.eulerAngles = new Vector3(0, obstacleNumber * 8, 0);
        }
        temp2Obstacle = Instantiate(winPrefeb);
        temp2Obstacle.transform.position= new Vector3(0, obstacleNumber - 0.01f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomObstaclegenerator()
    {
        int random = Random.Range(0, 5);
        switch (random)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i];
                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i+4];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 8];
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 12];
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 16];
                }
                break;


            default:
                break;
        }
    }
}
