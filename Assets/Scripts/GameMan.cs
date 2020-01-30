using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{

    // Use this for initialization
    int killedEnemy;
    public GameObject controll;
    public GameObject controll1;
    public GameObject heli;
    public int enemyNumber;
    void Start()
    {
        killedEnemy = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void KillEnemy()
    {
        Debug.Log("Enemy Killed");
        killedEnemy++;
        if (killedEnemy == enemyNumber)
        {
            Destroy(controll);
            Destroy(controll1);
            heli.SendMessage("LandOrder");
            //Application.LoadLevel("SecondScene");
        }
    }
}
