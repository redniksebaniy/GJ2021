using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public int scene = 1;

    public void TimeJump()
    {
        switch(scene)
        {
            case 1:SceneManager.LoadScene(2); break;
            case 2:SceneManager.LoadScene(1); break;
        }
        Debug.Log("Time Jumped");
    }
}
