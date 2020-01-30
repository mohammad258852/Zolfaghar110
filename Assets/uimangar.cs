using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uimangar : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoToNext()
    {
        Application.LoadLevel("First_Scene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}

