using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public void StartLevel()
    {
        Application.LoadLevel("City");
    }

    /*internal static object GetActiveScene()
    {
        throw new NotImplementedException();
    }*/
}
