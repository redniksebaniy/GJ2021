using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TV : MonoBehaviour
{
    //public int scene = 0;

    //public void TimeJump()
    //{
    //    if (scene == 0)
    //    {
    //        SceneManager.LoadScene(1);
    //        Debug.Log("Time Jumped");
    //    }
    //    else
    //    {
    //        SceneManager.LoadScene(0);
    //        Debug.Log("Time Jumped");
    //    }
    //}
    public int scene = 1;

    public void TimeJump()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
            Debug.Log("Time Jumped");
        }
        else
        {
            SceneManager.LoadScene(1);
            Debug.Log("Time Jumped");
        }
    }
}
