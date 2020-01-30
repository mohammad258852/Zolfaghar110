using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject walkingEnemy;
    public float minTime;
    public float maxTime;
    float timer;
    float waitingTime;
    // Use this for initialization
    void Start()
    {
        timer = 0;
        waitingTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            GameObject.Instantiate(walkingEnemy, transform.position, Quaternion.identity);
            timer = 0;
            waitingTime = Random.Range(minTime, maxTime);
        }
    }
}
