using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public int scene = 0;

    public void TimeJump()
    {
        switch(scene)
        {
            case 0: SceneManager.LoadScene(1); break;
            case 1: SceneManager.LoadScene(0); break;
        }
        Debug.Log("Time Jumped");
    }
}
