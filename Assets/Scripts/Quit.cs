﻿using System.Collections;
using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Runtime.Hosting;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // ApplicationActivator.Quit();  BitVector32
        }
    }
}