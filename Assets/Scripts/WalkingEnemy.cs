using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{

    // Use this for initialization
    GameObject player;
    public float minspeed;
    public float maxspeed;
    float speed;
    public float minDistance;
    public float maxDistance;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        speed = Random.Range(minspeed, maxspeed);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Distance();
        if (dist >= minDistance && dist <= maxDistance)
        {
            speed = Random.Range(minspeed, maxspeed);
            Walk();
        }
    }

    void Walk()
    {
        Vector3 movement = player.transform.position - gameObject.transform.position;
        float moveSize = SizeofVec(movement);
        movement = movement / moveSize * speed * Time.deltaTime;
        gameObject.transform.Translate(movement);
    }
    float SizeofVec(Vector3 n)
    {
        return Mathf.Sqrt(Mathf.Pow(n.x, 2) + Mathf.Pow(n.y, 2) + Mathf.Pow(n.z, 2));
    }
    float Distance()
    {
        Vector3 disVec = player.transform.position - gameObject.transform.position;
        return SizeofVec(disVec);
    }
}
