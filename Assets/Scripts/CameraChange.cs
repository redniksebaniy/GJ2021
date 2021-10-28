using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject targetObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<CameraFocus>().CameraMove(targetObject);
        }
    }
}

//Временно бесполезен