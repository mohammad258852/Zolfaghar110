﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellComeMessage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }
}
