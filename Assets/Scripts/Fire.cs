using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float timer;
    float maxt;
    // Use this for initialization
    void Start()
    {
        timer = 0;
        maxt = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxt)
        {
            Destroy(this.gameObject);
        }
    }
}
