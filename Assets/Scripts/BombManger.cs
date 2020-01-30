using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManger : MonoBehaviour
{
    public int power;
    public GameObject fire;
    // Use this for initialization
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Object.Instantiate(fire, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Object.Instantiate(fire, this.gameObject.transform.position, Quaternion.identity);
            other.gameObject.SendMessage("DecreaseHealth", power);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Pokidan"))
        {
            Object.Instantiate(fire, this.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
