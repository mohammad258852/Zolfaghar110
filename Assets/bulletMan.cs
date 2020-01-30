using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMan : MonoBehaviour
{
    public int dir;
    public float speed;
    // Use this for initialization
    void Start()
    {
        gameObject.transform.Rotate(0, 0, -90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);
    }
    public void SetDir(int d)
    {
        dir = d;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collid");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
