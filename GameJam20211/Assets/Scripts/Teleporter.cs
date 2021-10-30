using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public int scene = 1;

    public void TimeJump()
    {
        SceneManager.LoadScene(scene);
        Debug.Log("Time Jumped");
    }
}
