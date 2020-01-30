using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandle : MonoBehaviour
{
    public int health;
    GameObject gameManger;
    // Use this for initialization
    void Start()
    {
        gameManger = GameObject.Find("GameMan");
    }

    public void DecreaseHealth(int n = 10)
    {
        health -= n;
        if (health <= 0)
        {
            gameManger.SendMessage("KillEnemy");
            Destroy(this.gameObject);
        }
    }
}
